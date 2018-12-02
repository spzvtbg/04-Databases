namespace _07.EmployeesProjects
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    using P02_DatabaseFirst.Data;

    public class EmployeesProjects
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employeesProjects = context.Employees
                   .Include(e => e.EmployeesProjects)
                   .ThenInclude(e => e.Project)
                   .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                   .Take(30)
                   .ToList();

                foreach (var employee in employeesProjects)
                {
                    var managerId = employee.ManagerId;
                    var manager = context.Employees.Find(managerId);

                    Console.WriteLine($"{employee.FirstName} {employee.LastName} – Manager: {manager.FirstName} {manager.LastName}");


                    foreach (var project in employee.EmployeesProjects)
                    {
                        string format = "M/d/yyyy h:mm:ss tt";

                        string startDate = project.Project.StartDate.ToString(format, CultureInfo.InvariantCulture);

                        string endDate = project.Project.EndDate.ToString();

                        if (String.IsNullOrWhiteSpace(endDate))
                        {
                            endDate = "not finished";
                        }
                        else
                        {
                            endDate = project.Project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture);
                        }

                        Console.WriteLine($"--{project.Project.Name} - {startDate} - {endDate}");
                    }
                }
            }
        }
    }
}
