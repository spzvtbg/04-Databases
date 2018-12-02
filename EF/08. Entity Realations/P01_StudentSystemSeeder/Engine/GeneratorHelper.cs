namespace P01_StudentSystemSeeder.Engine
{
    using P01_StudentSystemSeeder.DataValues;
    using System;

    public class GeneratorHelper
    {
        static int randomIndex = 0;

        static Random randomGenerator = new Random();

        public static string PersonName(string[] firstNames, string[] lastNames)
        {
            randomIndex = randomGenerator.Next(0, firstNames.Length);
            string firstName = firstNames[randomIndex];

            randomIndex = randomGenerator.Next(0, lastNames.Length);
            string lastName = lastNames[randomIndex];

            if (firstName.EndsWith('а') || firstName.EndsWith('я'))
            {
                lastName += "a";
            }
            return string.Format("{0} {1}", firstName, lastName);
        }

        public static string PhoneNumber()
        {
            int code = randomGenerator.Next(0, 100);
            int secondCode = randomGenerator.Next(0, 100);
            int phoneNumber = randomGenerator.Next(0, 1000);
            return string.Format("0{0:D2}-{1:D2}-{2:D3}", code, secondCode, phoneNumber);
        }

        public static DateTime Date()
        {
            int year = randomGenerator.Next(1960, 2010);
            int month = randomGenerator.Next(1, 13);
            int days = randomGenerator.Next(0, 32);
            return new DateTime(year, month, 1).AddDays(days);
        }

        public static DateTime Date(int birthYear)
        {
            int year = randomGenerator.Next(birthYear + 7, 2010);
            int month = randomGenerator.Next(1, 13);
            int days = randomGenerator.Next(0, 32);
            return new DateTime(year, month, 1).AddDays(days);
        }

        public static decimal Price()
        {
            int index = randomGenerator.Next(0, Ints.Prices.Length);
            return Ints.Prices[index];
        }
    }
}
