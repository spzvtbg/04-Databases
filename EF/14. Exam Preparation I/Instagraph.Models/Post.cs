namespace Instagraph.Models
{
    using System.Collections.Generic;

    public class Post
    {
        public Post()
        {
            this.Comments = new List<Comment>();
        }

        //Id – an integer, Primary Key
        public int Id { get; set; }

        //Caption – a string
        public string Caption { get; set; }

        //UserId – an integer
        public int UserId { get; set; }

        //User – a User
        public User User { get; set; }

        //PictureId – an integer
        public int PictureId { get; set; }

        //Picture – a Picture
        public Picture Picture { get; set; }

        //Comments – a Collection of type Comment
        public ICollection<Comment> Comments { get; set; }
    }
}