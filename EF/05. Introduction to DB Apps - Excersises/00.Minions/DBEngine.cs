namespace _00.Minions
{
    using System;
    using System.Data.SqlClient;

    using _00.Minions.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class DBEngine
    {
        public void ConnectToServer()
        {

        }

        public static void CreateMinionsDB()
        {
            using (var connection = DBConnection.Initialize())
            {
                connection.Open();

                var db = new SqlCommand("select name from master.sys.databases", connection);
                var result = db.ExecuteReader();
                List<string> output = new List<string>();
                while (result.Read())
                {
                    output.Add((string)result[0]);
                }
                int length = output.OrderByDescending(x => x).First().Length;
                Console.WriteLine("| N  | Databases:              | ");
                Console.WriteLine(new string('-', length + 9));
                var count = 0;
                foreach (var value in output.OrderBy(x => x))
                {
                    if (value != "master" && value != "tempdb" && value != "model" && value != "msdb")
                    {
                        count++;
                        if (count < 10)
                        {
                            Console.WriteLine("| " + count + "  | " + value + new string(' ', length - value.Length) + " |");
                        }
                        else Console.WriteLine("| " + count + " | " + value + new string(' ', length - value.Length) +  " |");
                    }
                }
            }
        }
    }
}
