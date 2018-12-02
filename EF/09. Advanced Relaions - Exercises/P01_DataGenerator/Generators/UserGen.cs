namespace P01_DataGenerator.Generators
{
    using System;
    using System.Text;

    using P01_BillsPaymentSystem.Models;
    using P01_DataGenerator.RandomData;

    public class UserGen
    {
        public static int userCount = 0;
        public static Random random = new Random();
        public static StringBuilder stringBuilder;

        public static User CreateNewUser()
        {
            var newUser = new User();
            newUser.FirstName = GetFirstName();
            newUser.LastName = GetLastName(newUser.FirstName);
            newUser.Email = GetEmail(newUser.FirstName);
            newUser.Password = GetPassword();
            return newUser;
        }

        private static string GetFirstName()
        {
            var collection = Enum.GetValues(typeof(BulgarianFirstNames));
            var elementsCount = collection.Length;
            var index = random.Next(0, elementsCount);
            return collection.GetValue(index).ToString();
        }

        private static string GetLastName(string firstName)
        {
            var collection = Enum.GetValues(typeof(BulgarianLastNames));
            var elementsCount = collection.Length;
            var index = random.Next(0, elementsCount);
            var userLastName = collection.GetValue(index).ToString();

            stringBuilder = new StringBuilder();
            stringBuilder.Append(userLastName);

            if (firstName.EndsWith("a"))
            {
                return stringBuilder.Append("a").ToString();
            }
            else
            {
                return userLastName;
            } 
        }

        private static string GetEmail(string firstName)
        {
            var email = "user{0}@{1}.{2}";

            var collection = Enum.GetValues(typeof(EmailPrefix));
            var elementsCount = collection.Length;
            var index = random.Next(0, elementsCount);
            var prefix = collection.GetValue(index).ToString();

            collection = Enum.GetValues(typeof(DotSometing));
            elementsCount = collection.Length;
            index = random.Next(0, elementsCount);
            var dotSometing = collection.GetValue(index).ToString();

            return string.Format(email, firstName.GetHashCode(), prefix, dotSometing);
        }

        private static string GetPassword()
        {
            stringBuilder = new StringBuilder();
            var passwortLength = random.Next(5, 26);

            for (int count = 0; count < passwortLength; count++)
            {
                var currentSymbol = (char)random.Next(48, 127);
                stringBuilder.Append(currentSymbol);
            }

            return stringBuilder.ToString();
        }
    }
}
