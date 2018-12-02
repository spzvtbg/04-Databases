using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var employeesCount = Convert.ToInt32(Console.ReadLine());
        var currentEmployeData = new string[] { };

        List<Employee> employees = new List<Employee>();

        for (int count = 0; count < employeesCount; count++)
        {
            currentEmployeData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = currentEmployeData[0];
            var salary = Convert.ToDecimal(currentEmployeData[1]);
            var position = currentEmployeData[2];
            var department = currentEmployeData[3];
            var email = string.Empty;
            var age = 0;

            var newEmployee = new Employee();

            if (currentEmployeData.Length == 6)
            {
                email = currentEmployeData[4];
                age = Convert.ToInt32(currentEmployeData[5]);
                newEmployee = new Employee(name, salary, position, department, email, age);
            }

            if (currentEmployeData.Length == 5 && currentEmployeData[4].Contains("@"))
            {
                email = currentEmployeData[4];
                newEmployee = new Employee(name, salary, position, department, email);
            }

            if (currentEmployeData.Length == 5 && int.TryParse(currentEmployeData[4], out age))
            {
                age = Convert.ToInt32(currentEmployeData[4]);
                newEmployee = new Employee(name, salary, position, department, age);
            }

            if (currentEmployeData.Length == 4)
            {
                newEmployee = new Employee(name, salary, position, department);
            }

            employees.Add(newEmployee);
        }

        var departments = new Dictionary<string, decimal>();

        foreach (var employee in employees)
        {
            if (!departments.ContainsKey(employee.Department))
            {
                departments[employee.Department] = 0;
            }
            departments[employee.Department] += employee.Salary;
        }

        var bestDepartment = departments.OrderByDescending(x => x.Value).First().Key;

        Console.WriteLine($"Highest Average Salary: {bestDepartment}");

        foreach (var employee in employees.Where(x => x.Department == bestDepartment)
            .OrderByDescending(x => x.Salary))
        {
            Console.WriteLine(employee.ToString());
        }
    }
}
