namespace _00.Minions.Common
{
    using System.Data.SqlClient;
    using System.IO;

    public class DBConnection
    {
        public static SqlConnection Initialize()
        {
            return new SqlConnection(ConectingString(ServerName()));
        }

        private static string ConectingString(string server)
        {
            return Constants.Strings.ConnectingString.Replace(Constants.Strings.Server, server);
        }

        private static string ServerName()
        {
            return File.ReadAllText(Constants.Strings.ServerName);
        }
    }
}
