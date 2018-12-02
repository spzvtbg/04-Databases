using System.IO;

namespace Instagraph.Data
{
    internal class Configuration
    {
        internal static string ConnectionString => "Server={0};Database=Instagraph;Integrated Security=True;";

        internal static string ServerName => 
            File.ReadAllText(@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt");
    }
}
