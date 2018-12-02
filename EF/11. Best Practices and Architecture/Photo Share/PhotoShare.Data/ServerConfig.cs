namespace PhotoShare.Data
{
    using System.IO;

    internal class ServerConfig
    {
        internal static string ConnectionString => @"Server=.;Database=PhotoShare;Integrated Security=True;";

        internal static string MyConnection => @"Server={0};Database=PhotoShare;Integrated Security=True;";

        internal static string Path => File.ReadAllText(@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt");
    }
}
