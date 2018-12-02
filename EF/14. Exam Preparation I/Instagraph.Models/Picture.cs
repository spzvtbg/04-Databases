namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
            this.Users = new List<User>();
            this.Posts = new List<Post>();
        }

        //Id – an integer, Primary Key
        public int Id { get; set; }

        //Path – a string
        [Required]
        public string Path { get; set; }

        //Size – a decimal
        [Required]
        public decimal Size { get; set; }

        //Users – a Collection of type User
        public ICollection<User> Users { get; set; }

        //Posts – a Collection of type Post
        public ICollection<Post> Posts { get; set; }
    }
}
