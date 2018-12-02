namespace P01_StudentSystem.Data.Context
{
    using System.IO;

    public class Strings
    {
        public const string MyServerPath = @"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt";

        public const string MyConnection = "Server={0};Database=StudentSystem;Integrated Security=True;";

        public const string CommonConnection = "Server=.;Database=StudentSystem;Integrated Security=True;";

        public static string MyServer { get; } = File.ReadAllText(MyServerPath);
    }
}
