namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Followers = new List<UserFollower>();
            this.UsersFollowing = new List<UserFollower>();
            this.Posts = new List<Post>();
            this.Comments = new List<Comment>();
        }

         //Id – an integer, Primary Key
         public int Id { get; set; }

         //Username – a string with max length 30, Unique
         [Required]
         [MaxLength(30)]
         public string Username { get; set; }

        //Password – a string with max length 20
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        //ProfilePictureId – an integer
        public int ProfilePictureId { get; set; }

        //ProfilePicture – a Picture
        public Picture ProfilePicture { get; set; }

         //Followers – a Collection of type UserFollower
         public ICollection<UserFollower> Followers { get; set; }    
        
        //UsersFollowing – a Collection of type UserFollower
        public ICollection<UserFollower> UsersFollowing { get; set; }

         //Posts – a Collection of type Post
         public ICollection<Post> Posts { get; set; }

         //Comments – a Collection of type Comment
         public ICollection<Comment> Comments { get; set; }
    }
}