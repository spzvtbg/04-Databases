namespace _06._AddingNewAddress
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;

    public class UpdateEmploee
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
                var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                employee.Address = address;
                context.SaveChanges();

                var employees = context.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Select(e => new { e.Address }).Take(10);

                foreach (var addressее in employees)
                {
                    Console.WriteLine(addressее.Address.AddressText);
                }
            }
        }
    }
}
