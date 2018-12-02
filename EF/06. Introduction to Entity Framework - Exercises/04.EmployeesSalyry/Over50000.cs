namespace _04.EmployeesSalyry
{
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class Over50000
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees.Select(e => new
                {
                    e.Salary,
                    e.FirstName
                }).Where(e => e.Salary > 50000).OrderBy(e => e.FirstName);

                foreach (var employee in employees)
                {
                    System.Console.WriteLine(employee.FirstName);
                }
            }
        }
    }
}
