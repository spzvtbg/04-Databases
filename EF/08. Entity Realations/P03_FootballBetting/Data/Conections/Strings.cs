namespace P03_FootballBetting.Data.Conections
{
    using System.IO;

    public class Strings
    {
        public const string MyServerPath = @"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt";

        public const string MyConnection = "Server={0};Database=FootballBetting;Integrated Security=True;";

        public const string CommonConnection = "Server=.;Database=FootballBetting;Integrated Security=True;";

        public static string MyServer { get; } = File.ReadAllText(MyServerPath);
    }
}
