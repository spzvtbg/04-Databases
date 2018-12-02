namespace Emploies.DTOs
{
    public class EmployeesOlderThanDto
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public ManagerInfoDto Manager { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - ${this.Salary:F2} - Manager: {Manager.LastName}";
        }
    }
}
