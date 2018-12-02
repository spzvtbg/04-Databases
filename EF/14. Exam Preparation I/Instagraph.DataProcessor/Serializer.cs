namespace Instagraph.DataProcessor
{
    using System;
    using System.Linq;

    using Instagraph.Data;
    using Instagraph.DataProcessor.ExportDtos;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var postsWithoutComments = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new UncommentedPostsDto()
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                }).ToArray();

            var jsonString = JsonConvert.SerializeObject(postsWithoutComments, Formatting.Indented);
            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            throw new NotImplementedException();
        }
    }
}
