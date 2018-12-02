namespace PhotoShare.Initializer.Generators
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Initializer.Generators.Constants;

    public class PictureGen
    {
        private static Random random = new Random();
        private static ICollection<Picture> randomPictures = new List<Picture>();


        public static void InitializeRandomData(PhotoShareContext context)
        {
            for (int count = 0; count < Numerics.NumberOfUsers * 5; count++)
            {
                var newPicture = new Picture();
                newPicture.AlbumId = 1;
                newPicture.Title = "None";
                newPicture.Path = "None";
                newPicture.Caption = GetCaption();
                randomPictures.Add(newPicture);
            }
            context.Pictures.AddRange(randomPictures);
            context.SaveChanges();
        }

        private static string GetCaption()
        {
            var stringBuilder = new StringBuilder();

            for (int count = 0; count < 26; count++)
            {
                var currentSymbol = (char)random.Next(48, 127);
                stringBuilder.Append(currentSymbol);
            }

            return stringBuilder.GetHashCode().ToString();
        }
    }
}
