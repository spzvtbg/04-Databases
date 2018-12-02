namespace P01_BillsPaymentSystem.App.Constants
{
    using System;

    public class Strings
    {
        public static string BoldLine => new string('=', Console.WindowWidth - 4);

        public static string SmallLine => new string('-', Console.WindowWidth - 4);

        public static string EmptyLine => new string(' ', Console.WindowWidth - EnterNumber.Length);

        public static string InvalidInput(int nbr) => string.Format("Error: User with ID ({0}) not found!", nbr);

        public static string InvalidInput(string str) => string.Format("Error: User with ID ({0}) not found!", str);

        public static string InvalidData = "Invalid data entered!";

        public static string InvalidInput() => string.Format("Insufficient funds!");

        public const string EnterNumber = "Enter User ID: ";

        public const string EnterData = "Enter Amount: ";

        public const string Back = "   PRESS ENTER TO BACK IN MAIN MENU   ";

        public const string User = "User: ";

        public const string BankAccounts = "Bank Accounts: ";

        public const string CreditCards = "Credit Cards: ";

        public const string ID = "-- ID: ";

        public const string Balance = "--- Balance: ";

        public const string Bank = "--- Bank: ";

        public const string Swift = "--- SWIFT: ";

        public const string Limit = "--- Limit: ";

        public const string MoneyOwed = "--- Money Owed: ";

        public const string LimitLeft = "--- Limit Left:: ";

        public const string ExpirationDate = "--- Expiration Date:: ";

        public const string DateFormat = "yyyy/MM";

        public const char FrameSymbol = '#';

        public const string Waiting = "Waiting ...";

        public const string WaitingID = "Waiting ID: ";

        public const string Done = "Done!";

        public static string[] Options => new string[] 
        {
            "CREATE DATABASE ( Bill Payment System )",
            "SEED SOME DATA ( Initial 100 )",
            "SELECT USER BY ID ( If you have allready the database )",
            "PAY BILLS( ID, Amount )",
            "QUIT FROM THIS CONSOLE APPLICATION"
        };

        public static string[] Methods => new string[]
        {
            "CreateDatabase",
            "SeedSomeData",
            "ShowUserByID",
            "PayBills",
            "QUIT FROM THIS CONSOLE APPLICATION"
        };
    }
}
