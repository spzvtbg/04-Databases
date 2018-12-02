namespace _10._DepartmentsMoreThan5Employees
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using P02_DatabaseFirst.Data;

    public class MoreThan5Employees
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var db = context.Departments.Include(x => x.Employees)
                    .Where(d => d.Employees.Count > 5)
                    .Select(d => new { d.Name, d.Manager, d.Employees })
                    .OrderBy(d => d.Employees.Count).ThenBy(d => d.Name);

                foreach (var d in db)
                {
                    System.Console.WriteLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");
                    foreach (var row in d.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                    {
                        System.Console.WriteLine($"{row.FirstName} {row.LastName} - {row.JobTitle}");
                    }
                    System.Console.WriteLine(new string('-', 10));
                }
            }
        }
    }
}
