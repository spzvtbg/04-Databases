namespace PhotoShare.Initializer.Generators
{
    using System;
    using System.Collections.Generic;

    using PhotoShare.Models;
    using PhotoShare.Initializer.Generators.Enums;
    using PhotoShare.Data;

    public class TownGen
    {
        private static Random random = new Random();
        private static ICollection<Town> randomTowns = new List<Town>();

        public static void InitializeRandomData(PhotoShareContext context)
        {
            var countries = typeof(CountryNames).GetEnumValues();
            for (int x = 0; x < countries.Length; x++)
            {
                var country = (CountryNames)x;
                var towns = typeof(TownNames).GetNestedType(country.ToString()).GetEnumValues();

                for (int y = 0; y < towns.Length; y++)
                {
                    var currentTown = new Town(towns.GetValue(y).ToString(), ((CountryNames)x).ToString());
                    randomTowns.Add(currentTown);
                }
            }
            context.Towns.AddRange(randomTowns);
            context.SaveChanges();
        }
    }
}
