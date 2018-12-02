namespace _00.Minions.Common
{
    using System;

    public class NonCostants
    {
        public static int MiddleView(string text)
        {
            return (Console.WindowWidth - text.Length) / 2;
        }

        public static string[] InitialContent()
        {
            return new string[]
            {
                Constants.Strings.ConnectToDB,
                Constants.Strings.ShowDataBases,
                Constants.Strings.CRUD
            };
        }

        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
