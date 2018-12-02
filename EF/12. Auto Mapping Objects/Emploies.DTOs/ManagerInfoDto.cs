namespace Emploies.DTOs
{
    public class ManagerInfoDto
    {
        private string lastName;

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value != null ? value : "[no manager]";
            }
        }

    }
}
