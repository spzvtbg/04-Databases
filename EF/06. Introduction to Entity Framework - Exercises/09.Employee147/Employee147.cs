namespace _09.Employee147
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using P02_DatabaseFirst.Data;

    public class Employee147
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employee = context.Employees
                   .Include(e => e.EmployeesProjects)
                   .ThenInclude(e => e.Project)
                   .SingleOrDefault(e => e.EmployeeId == 147);

                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                employee.EmployeesProjects
                    .OrderBy(p => p.Project.Name)
                    .ToList()
                    .ForEach(p => Console.WriteLine(p.Project.Name));
            }
        }
    }
}
