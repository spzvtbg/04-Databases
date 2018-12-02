namespace _05.EmployeesFrom
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class ResearchDevelopment
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Department,
                        e.Salary
                    });

                foreach (var e in employees)
                {
                    var info = $"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}";
                    Console.WriteLine(info);
                }
            }
        }
    }
}
