namespace Instagraph.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserFollower
    {
        //UserId – an integer, Primary Key
        [Required]
        public int UserId { get; set; }

        //User – a User
        public User User { get; set; }

        //FollowerId – an integer, Primary Key
        [Required]
        public int FollowerId { get; set; }

        //Follower – a User
        public User Follower { get; set; }
    }
}