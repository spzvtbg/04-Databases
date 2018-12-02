namespace PhotoShare.Initializer.Generators
{
    using System.Collections.Generic;

    using PhotoShare.Data;
    using PhotoShare.Initializer.Generators.Enums;
    using PhotoShare.Models;

    public class TagGen
    {
        private static ICollection<Tag> randomTags = new List<Tag>();

        public static void InitializeRandomData(PhotoShareContext context)
        {
            var tagsCount = typeof(Tags).GetEnumValues().Length;
            for (int count = 0; count < tagsCount; count++)
            {
                var currentTag = new Tag();
                currentTag.Name = $"#{(Tags)count}";
                randomTags.Add(currentTag);
            }
            context.Tags.AddRange(randomTags);
            context.SaveChanges();
        }
    }
}
