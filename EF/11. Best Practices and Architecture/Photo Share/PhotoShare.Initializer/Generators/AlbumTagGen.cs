namespace PhotoShare.Initializer.Generators
{
    using System.Linq;
    using System.Collections.Generic;

    using PhotoShare.Data;
    using PhotoShare.Models;

    public class AlbumTagGen
    {
        private static ICollection<AlbumTag> randomAlbumsTags = new HashSet<AlbumTag>();

        public static void InitializeRandomData(PhotoShareContext context)
        {
            var tagsIds = context.Tags.Select(x => x.Id).ToArray();
            var albumIds = context.Albums.Select(x => x.Id).ToArray();

            for (int index = 1; index <= tagsIds.Length; index++)
            {
                for (int count = 1; count <= albumIds.Length; count++)
                {
                    var currentAlbumTag = new AlbumTag();
                    currentAlbumTag.TagId = index;
                    currentAlbumTag.AlbumId = count;
                    randomAlbumsTags.Add(currentAlbumTag);
                }
            }

            context.AlbumTags.AddRange(randomAlbumsTags);
            context.SaveChanges();
        }
    }
}
