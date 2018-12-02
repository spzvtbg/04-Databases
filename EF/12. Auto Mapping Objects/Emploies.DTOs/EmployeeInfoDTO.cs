namespace Emploies.DTOs
{
    public class EmployeeInfoDTO
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.ID} - {this.FirstName} {this.Surname} - {this.Salary:F2}";
        }
    }
}
