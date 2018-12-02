namespace Instagraph.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        //Id – an integer, Primary Key
        public int Id { get; set; }

        //Content – a string with max length 250
        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        //UserId – an integer
        [Required]
        public int UserId { get; set; }

        //User – a User
        public User User { get; set; }

        //PostId – an integer
        [Required]
        public int PostId { get; set; }

        //Post – a Post
        public Post Post { get; set; }
    }
}