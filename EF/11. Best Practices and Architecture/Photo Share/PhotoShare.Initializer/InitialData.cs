namespace PhotoShare.Initializer
{
    using PhotoShare.Data;
    using PhotoShare.Initializer.Generators;

    public class InitialData
    {
        public static void Seed(PhotoShareContext context)
        {
            TagGen.InitializeRandomData(context);
            System.Console.WriteLine("Tags successfuly added");
            AlbumGen.InitializeRandomData(context);
            System.Console.WriteLine("Albums successfuly added");
            AlbumTagGen.InitializeRandomData(context);
            System.Console.WriteLine("AlbumsTags successfuly added");
            PictureGen.InitializeRandomData(context);
            System.Console.WriteLine("Pictures successfuly added");
            TownGen.InitializeRandomData(context);
            System.Console.WriteLine("Towns successfuly added");
            UserGen.InitializeRandomData(context);
            System.Console.WriteLine("Users successfuly added");
        }
    }
}