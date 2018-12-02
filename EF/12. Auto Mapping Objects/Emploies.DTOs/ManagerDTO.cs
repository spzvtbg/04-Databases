namespace Emploies.DTOs
{
    using Emploies.Models;
    using System.Collections.Generic;
    using System.Text;

    public class ManagerDTO
    {
        public ManagerDTO()
        {
            this.ManagedEmployees = new List<Employee>();
        }

        public int ManagerID { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public ICollection<Employee> ManagedEmployees { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.Surname} | Employees: {this.ManagedEmployees.Count}");
            foreach (var employee in this.ManagedEmployees)
            {
                sb.AppendLine($" - {employee.FirstName} {employee.Surname} - ${employee.Salary:F2}");
            }
            return sb.ToString();
        }
    }
}
