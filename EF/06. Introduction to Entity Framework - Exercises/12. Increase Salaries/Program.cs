namespace _12._Increase_Salaries
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using P02_DatabaseFirst.Data;

    public class Program
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var db = context.Employees
                     .Include(d => d.Departments)
                     .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                     e.Department.Name == "Information Services" || e.Department.Name == "Marketing")
                     .OrderBy(e => e.FirstName).ThenBy(e => e.LastName);
                
                foreach (var item in db)
                {
                    var newSalary = item.Salary * 1.12m;
                    Console.WriteLine($"{item.FirstName} {item.LastName} (${newSalary:F2})");
                }
            }
        }
    }
}
