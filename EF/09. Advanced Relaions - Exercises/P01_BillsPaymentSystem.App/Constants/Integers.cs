namespace P01_BillsPaymentSystem.App.Constants
{
    using System;

    public class Integers
    {
        public const int Zero = 0;

        public const int InitialRow = 1;

        public const int MessageRow = 4;

        public static int[] Positions => new int[] { 10, 20, 29, 35};


        private static int rowDifferense = (Console.WindowHeight - 3) / 6 + 1;
        private static int startRow = ((Console.WindowHeight - 3) / 6 + 1) / 2;

        public static int[] OptionsStartRows = new int[]
        {
            startRow,
            rowDifferense + startRow,
            rowDifferense * 2 + startRow,
            rowDifferense * 3 + startRow,
            rowDifferense * 4 + startRow
        };
    }
}
