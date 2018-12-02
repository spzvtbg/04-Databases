using System;
using FastFood.Data;
using Newtonsoft.Json;
using FastFood.DataProcessor.Dto;
using System.Text;
using FastFood.Models;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;
using FastFood.Models.Enums;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var stringBuilder = new StringBuilder();

            var emploiesFromJson = JsonConvert.DeserializeObject<EmployeeExpDto[]>(jsonString);

            foreach (var employeeDto in emploiesFromJson)
            {
                var nameLength = employeeDto.Name.Length;
                var isNameValid = nameLength < 3 || nameLength > 30;
                var isAgeValid = employeeDto.Age < 15 || employeeDto.Age > 80;

                if (isNameValid)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                if (isAgeValid)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var position = new Position();

                if (isNameValid && isAgeValid)
                {
                    position = context.Positions.SingleOrDefault(x => x.Name == employeeDto.Position);
                }

                if (string.IsNullOrWhiteSpace(position.Name))
                {
                    position.Name = employeeDto.Position;
                }

                if (position.Name.Length < 3 || position.Name.Length > 30)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                if (!context.Positions.Any(x => x.Name == position.Name))
                {
                    context.Positions.Add(position);
                    context.SaveChanges();
                }

                var positionId = context.Positions.FirstOrDefault(x => x.Name == position.Name).Id;

                var employee = new Employee()
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    PositionId = positionId
                };

                if (context.Employees.Any(x => x.Name == employee.Name))
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                context.Employees.Add(employee);
                stringBuilder.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.SaveChanges();
            return stringBuilder.ToString().Trim();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var stringBuilder = new StringBuilder();

            var itemsFromJson = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            foreach (var item in itemsFromJson)
            {
                if (item.Name.Length < 3 || item.Name.Length > 30)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                if (item.Price < 0.01m)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                if (item.Category.Length < 3 || item.Category.Length > 30)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                var newCategory = new Category()
                {
                    Name = item.Category
                };

                var newItem = new Item()
                {
                    Name = item.Name,
                    Price = item.Price
                };

                bool hasItem = context.Items.Any(x => x.Name == item.Name);
                bool hasCategory = context.Categories.Any(x => x.Name == item.Category);

                if (hasItem)
                {
                    stringBuilder.AppendLine(FailureMessage);
                    continue;
                }

                if (!hasCategory)
                {
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }

                int categoryId = context.Categories.First(x => x.Name == item.Category).Id;

                newItem.CategoryId = categoryId;

                context.Items.Add(newItem);
                context.SaveChanges();

                stringBuilder.AppendLine(string.Format(SuccessMessage, newItem.Name));
            }

            return stringBuilder.ToString().Trim();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var stringBuilder = new StringBuilder();

            var parsed = XDocument.Parse(xmlString);
            var parsedOrders = parsed.Root.Elements();

            foreach (var order in parsedOrders)
            {
                var customer = order.Element("Customer")?.Value;
                if (string.IsNullOrEmpty(customer))
                {
                    continue;
                }

                var employee = order.Element("Employee")?.Value;
                if (string.IsNullOrEmpty(employee) || !context.Employees.Any(x => x.Name == employee))
                {
                    continue;
                }

                var dateTime = order.Element("DateTime")?.Value;
                var date = new DateTime();
                try
                {
                    date = DateTime.ParseExact(dateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                catch
                {
                    continue;
                }


                var typeIndex = OrderType.ForHere;
                var type = order.Element("Type")?.Value;
                if (type == OrderType.ToGo.ToString())
                {
                    typeIndex = OrderType.ToGo;
                }

                var registeredEmployee = context.Employees.FirstOrDefault(x => x.Name == employee);
                if (registeredEmployee == null)
                {
                    continue;
                }

                var newOrder = new Order()
                {
                    Customer = customer,
                    DateTime = date,
                    Type = typeIndex,
                    Employee = registeredEmployee
                };

                var orderItems = new List<OrderItem>();
                var isBroken = false;

                var items = order.Element("Items")?.Elements();
                foreach (var item in items)
                {
                    var name = item.Element("Name")?.Value;
                    var currentItem = context.Items.FirstOrDefault(x => x.Name == name);

                    if (currentItem == null)
                    {
                        isBroken = true;
                        break;
                    }

                    var quantity = item.Element("Quantity")?.Value;

                    int intQuantity;
                    if (!int.TryParse(quantity, out intQuantity))
                    {
                        isBroken = true;
                        break;
                    }

                    if (intQuantity < 1)
                    {
                        isBroken = true;
                        break;
                    }

                    var newOrderItem = new OrderItem();
                    newOrderItem.Order = newOrder;
                    newOrderItem.Item = currentItem;
                    newOrderItem.Quantity = intQuantity;

                    orderItems.Add(newOrderItem);
                }

                if (!isBroken)
                {
                    newOrder.TotalPrice = orderItems.Select(x => x.Item.Price).Sum();
                    context.Orders.Add(newOrder);
                    context.OrderItems.AddRange(orderItems);
                    var onDate = newOrder.DateTime.ToString("dd/MM/yyyy HH:mm");
                    stringBuilder.AppendLine($"Order for {newOrder.Customer} on {onDate} added");
                }
            }
            context.SaveChanges();
            return stringBuilder.ToString().Trim();
		}
	}
}