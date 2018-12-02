namespace _03.EmployeesFullInformation
{
    using System;
    using System.Linq;

    using P02_DatabaseFirst.Data;

    public class EmploeesInfo
    {
        public static void Main()
        {
            var db = new SoftUniContext();

            var employees = db.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })/*.OrderBy(e => e.EmployeeId)*/;

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }
        }
    }
}
