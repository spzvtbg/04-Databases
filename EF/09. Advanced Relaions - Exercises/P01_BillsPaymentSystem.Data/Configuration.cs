namespace P01_BillsPaymentSystem.Data
{
    using System.IO;

    internal class Configuration
    {
        internal const string CommonConnection = "Server=.;Database=BillsPaymentSystem;Integrated Security=True;";

        internal const string MyConnection = "Server={0};Database=BillsPaymentSystem;Integrated Security=True;";

        internal static string Name => 
            File.ReadAllText(@"C:\Users\spzvt\Documents\SQL-Data\DB-Server-Connection.txt");
    }
}
