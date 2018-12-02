namespace PhotoShare.Initializer.Generators
{
    using System;
    using System.Collections.Generic;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Initializer.Generators.Constants;

    public class AlbumGen
    {
        private static Random random = new Random();
        private static ICollection<Album> randomAlbums = new List<Album>();

        public static void InitializeRandomData(PhotoShareContext context)
        {
            for (int count = 0; count < Numerics.NumberOfTowns; count++)
            {
                var currentAlbum = new Album();
                var colorCount = typeof(Color).GetEnumValues().Length;
                currentAlbum.Name = "None";
                currentAlbum.BackgroundColor = (Color)random.Next(0, colorCount);
                currentAlbum.IsPublic = random.Next(0, 2) == 0 ? false : true;
                randomAlbums.Add(currentAlbum);
            }
            context.Albums.AddRange(randomAlbums);
            context.SaveChanges();
        }
    }
}