namespace BookShop.Data
{
    using System.IO;

    internal static class ConnectionConfig
    {
        internal static string Common
        {
            get
            {
                return "Server=.;Database=BookShop;Integrated Security=True;";
            }
        }

        internal static string Private
        {
            get
            {
                return "Server={0};Database=BookShop;Integrated Security=True;";
            }
        }

        internal static string Name
        {
            get
            {
                return File.ReadAllText(@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt");
            }
        }
    }
}
