namespace P01_BillsPaymentSystem.App.Providers
{
    using System;
    using System.Text.RegularExpressions;

    using P01_BillsPaymentSystem.App.Constants;

    public class InputProvider
    {
        public int ReadNumber()
        {
            int number;
            string input = Regex.Escape(Console.ReadLine());

            if (!int.TryParse(input, out number))
            {
                throw new Exception(Strings.InvalidInput(input));
            }
            return number;
        }

        public void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public ConsoleKey Key()
        {
            return Console.ReadKey(true).Key;
        }



        public decimal[] ReadUserData()
        {
            int userID;
            string input = Regex.Escape(Console.ReadLine());

            if (!int.TryParse(input, out userID))
            {
                throw new Exception(Strings.InvalidInput(input));
            }

            decimal amount;
            Console.SetCursorPosition(16, 5);
            input = Regex.Escape(Console.ReadLine());

            if (!decimal.TryParse(input, out amount))
            {
                throw new Exception(Strings.InvalidData);
            }

            return new decimal[] { userID, amount };
        }
    }
}
