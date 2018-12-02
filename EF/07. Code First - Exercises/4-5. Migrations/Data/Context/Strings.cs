namespace P03_SalesDatabase.Data.Context
{
    using System.IO;

    public class Strings
    {
        /* Use when you testing in Judge; */
        //private const string FilePath = ".";

        private const string FilePath = @"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt";

        public const string ConectionString = "Server={0};Database=Sales;Integrated Security=True;";

        public static string Connection()
        {
            return File.ReadAllText(FilePath);
        }
    }
}
