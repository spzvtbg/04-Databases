namespace _13._FindEmployees
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class FindEmployees
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees.Where(e => e.FirstName.ToLower().StartsWith("sa"))
                    .OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

                foreach (var employee in employees)
                {
                    var currentEmployee = employee.FirstName + " " + employee.LastName;
                    var jobTitle = employee.JobTitle;
                    var currentSalary = employee.Salary;
                    if (employee.DepartmentId == 1 || employee.DepartmentId == 2 
                        || employee.DepartmentId == 4 || employee.DepartmentId == 11)
                    {
                        currentSalary *= 1.12m;
                    }
                    Console.WriteLine($"{currentEmployee} - {jobTitle} - (${currentSalary:F2})");
                }
            }
        }
    }
}
