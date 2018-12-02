namespace ProductShop.Dtos
{
    using System.Collections.Generic;

    public class UsersProductsDto
    {
        public UsersProductsDto()
        {
            this.users = new List<UserDto>();
        }

        public int usersCount { get; set; }

        public ICollection<UserDto> users { get; set; }
    }
}
