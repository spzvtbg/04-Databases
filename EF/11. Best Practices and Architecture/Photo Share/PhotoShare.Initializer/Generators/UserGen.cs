namespace PhotoShare.Initializer.Generators
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Initializer.Generators.Constants;
    using PhotoShare.Initializer.Generators.Enums;

    public class UserGen
    {
        private static string country;
        private static Random random = new Random();
        private static ICollection<int> ids;
        private static ICollection<User> randomUsers = new List<User>();

        public static void InitializeRandomData(PhotoShareContext context)
        {
            ids = context.Pictures.Select(x => x.Id).ToList();

            for (int count = 1; count <= Numerics.NumberOfUsers; count++)
            {
                var currentUser = new User();
                currentUser.FirstName = GetFirstName();
                currentUser.LastName = GetLastName(currentUser.FirstName);
                currentUser.ProfilePictureId = GetPictureId(ids);
                currentUser.Username = $"{currentUser.FirstName}_{currentUser.LastName}_{count}";
                currentUser.Email = GetEmail(currentUser.FirstName);
                currentUser.Password = GetPassword();
                currentUser.BornTownId = GetTownId(context);
                currentUser.CurrentTownId = GetTownId(context, null);
                currentUser.RegisteredOn = GetDate();
                currentUser.LastTimeLoggedIn = GetDate(currentUser.RegisteredOn.Value);
                randomUsers.Add(currentUser);
            }

            context.Users.AddRange(randomUsers);
            context.SaveChanges();
        }

        private static string GetFirstName()
        {
            int countryIndex = random.Next(0, Enum.GetValues(typeof(CountryNames)).Length);
            country = ((CountryNames)countryIndex).ToString();

            int townIndex = random.Next(0, typeof(UserFirstNames).GetNestedType(country).GetEnumValues().Length);
            country =  ((typeof(UserFirstNames).GetNestedType(country)).GetEnumName(townIndex)).ToString();
            return country;
        }

        private static string GetLastName(string firstName)
        {
            int countryIndex = random.Next(0, Enum.GetValues(typeof(CountryNames)).Length);
            country = ((CountryNames)countryIndex).ToString();

            if (country == CountryNames.Bulgaria.ToString() && firstName.EndsWith("a"))
            {
                int townIndex = random.Next(0, typeof(UserLastNames).GetNestedType(country).GetEnumValues().Length);
                return ((typeof(UserLastNames).GetNestedType(country)).GetEnumName(townIndex)).ToString() + "a";
            }
            else
            {
                int townIndex = random.Next(0, typeof(UserLastNames).GetNestedType(country).GetEnumValues().Length);
                return ((typeof(UserLastNames).GetNestedType(country)).GetEnumName(townIndex)).ToString();
            }
        }

        private static int? GetPictureId(ICollection<int> ids)
        {
            var ID = random.Next(0, ids.Count);
            ids.Remove(ID);
            if (ID == 0)
            {
                return null;
            }
            return ID;
        }

        private static string GetEmail(string firstName)
        {
            var email = "user{0}@{1}.{2}";

            var collection = Enum.GetValues(typeof(EmailPrefix));
            var elementsCount = collection.Length;
            var index = random.Next(0, elementsCount);
            var prefix = collection.GetValue(index).ToString();

            collection = Enum.GetValues(typeof(DotSomething));
            elementsCount = collection.Length;
            index = random.Next(0, elementsCount);
            var dotSometing = collection.GetValue(index).ToString();

            return string.Format(email, firstName.GetHashCode(), prefix, dotSometing);
        }

        private static string GetPassword()
        {
            var stringBuilder = new StringBuilder();
            var passwortLength = random.Next(5, 26);

            for (int count = 0; count < passwortLength; count++)
            {
                var currentSymbol = (char)random.Next(48, 127);
                stringBuilder.Append(currentSymbol);
            }

            return stringBuilder.ToString();
        }

        private static int? GetTownId(PhotoShareContext context, string nulll)
        {
            var townIDs = context.Towns.Where(x => x.Country == country).Select(x => x.Id).ToArray();
            if (townIDs.Length == 0)
            {
                return null;
            }
            return townIDs[random.Next(1, townIDs.Length)];
        }

        private static int? GetTownId(PhotoShareContext context)
        {
            return random.Next(1, context.Towns.Count());
        }

        private static DateTime? GetDate()
        {
            var year = random.Next(2018, 2026);
            var month = random.Next(1, 13);
            var day = random.Next(1, 29);
            var hour = random.Next(0, 24);
            var minutes = random.Next(0, 60);
            var seconds = random.Next(0, 60);
            return new DateTime(year, month, day, hour, minutes, seconds);
        }

        private static DateTime? GetDate(DateTime registeredDate)
        {
            var year = random.Next(2018, 2026);
            var month = random.Next(1, 13);
            var day = random.Next(1, 29);
            var hour = random.Next(0, 24);
            var minutes = random.Next(0, 60);
            var seconds = random.Next(0, 60);
            var newDate =  new DateTime(year, month, day, hour, minutes, seconds);

            if (registeredDate <= newDate)
            {
                return null;
            }
            else
            {
                return newDate;
            }
        }
    }
}
