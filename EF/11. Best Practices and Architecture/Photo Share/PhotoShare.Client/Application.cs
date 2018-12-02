namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Models;
    using PhotoShare.Initializer;

    public class Application
    {
        public static void Main()
        {
            //ResetDatabase();

            //CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine();
            engine.Run();
        }

        private static void ResetDatabase()
        {
            using (var db = new PhotoShareContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                InitialData.Seed(db);
            }
        }
    }
}
