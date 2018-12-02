namespace P01_HospitalDatabase.Data.Common
{
    using System.IO;

    public class Strings
    {
        private const string FilePath = ".";//@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt";

        public const string ConectionString = "Server={0};Database=Hospital;Integrated Security=True;";

        public static string Connection()
        {
            return File.ReadAllText(FilePath);
        }
    }
}
