namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.IO;

    public static class ConnectionProvider
    {
        public static string Common
        {
            get
            {
                return "Server=.;Database=ProductShop;Integrated Security=True;";
            }
        }

        internal static string Private
        {
            get
            {
                return "Server={0};Database=ProductShop;Integrated Security=True;";
            }
        }

        internal static string Name
        {
            get
            {
                return File.ReadAllText(@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt");
            }
        }

        internal static void CreateConection(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Common);
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        public static string Connection => string.Format(Private, Name);
    }
}
