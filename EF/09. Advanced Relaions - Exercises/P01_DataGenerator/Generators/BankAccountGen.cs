namespace P01_DataGenerator.Generators
{
    using System;
    using System.Text;

    using P01_BillsPaymentSystem.Models;
    using P01_DataGenerator.RandomData;

    public class BankAccountGen
    {
        public static Random random = new Random();
        public static StringBuilder stringBuilder;

        public static BankAccount CreateNewBankAccount()
        {
            var newBankAccount = new BankAccount();
            newBankAccount.BankName = GetBankName();
            newBankAccount.SwiftCode = GetSwiftCode();
            newBankAccount.Deposit(GetBalance());
            return newBankAccount;
        }

        private static string GetBankName()
        {
            var collection = Enum.GetValues(typeof(BulgarianBankNames));
            var elementsCount = collection.Length;
            var index = random.Next(0, elementsCount);
            return collection.GetValue(index).ToString();
        }

        private static string GetSwiftCode()
        {
            stringBuilder = new StringBuilder();
            var swiftCodeLength = random.Next(10, 21);

            for (int count = 0; count < swiftCodeLength; count++)
            {
                var currentSymbol = (char)random.Next(65, 91);
                stringBuilder.Append(currentSymbol);
            }

            return stringBuilder.ToString();
        }

        private static decimal GetBalance()
        {
            return (random.Next(0, 10000));
        }
    }
}
