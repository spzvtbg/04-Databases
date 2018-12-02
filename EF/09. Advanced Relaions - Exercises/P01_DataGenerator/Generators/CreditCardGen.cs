namespace P01_DataGenerator.Generators
{
    using System;
    using System.Text;

    using P01_BillsPaymentSystem.Models;

    public class CreditCardGen
    {
        public static int firstNumber;
        public static Random random = new Random();
        public static StringBuilder stringBuilder;

        public static CreditCard CreateNewCreditCard()
        {
            var limit = GetLimit();
            var moneyOwed = GetMoneyOwed(limit);
            var newCreditCard = new CreditCard(limit);
            newCreditCard.ExpirationDate = GetDate();
            newCreditCard.Withdraw(ref moneyOwed);
            return newCreditCard;
        }

        private static DateTime GetDate()
        {
            var year = random.Next(2018, 2026);
            var month = random.Next(1, 13);
            var day = random.Next(1, 29);
            return new DateTime(year, month, day);
        }

        private static decimal GetLimit()
        {
            var limits = new[] { 100, 200, 500, 1000, 2000, 5000, 10000 };
            var index = random.Next(0, limits.Length);

            return limits[index];
        }

        private static decimal GetMoneyOwed(decimal limit)
        {
            return Convert.ToDecimal(random.Next(0, (int)limit));
        }
    }
}
