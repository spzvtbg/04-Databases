namespace Instagraph.Data.MondelsConfigs
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFollowerConfig : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> userFollower)
        {
            userFollower.HasKey(uf => new { uf.UserId, uf.FollowerId});

            userFollower
                .HasOne(uf => uf.User)
                .WithMany(uf => uf.Followers)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            userFollower
                .HasOne(uf => uf.Follower)
                .WithMany(uf => uf.UsersFollowing)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
