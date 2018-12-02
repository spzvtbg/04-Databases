namespace Emploies.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.ManagedEmploies = new List<Employee>();
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public decimal Salary { get; set; }

        public string Addresse { get; set; }

        public DateTime? Birthday { get; set; }

        public int? ManagerID { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> ManagedEmploies { get; set; }
    }
}
