namespace _00.Minions.UserInterface
{
    using System;

    using _00.Minions.Common;

    public class ConsoleWriteHelper
    {
        public static void ShowFrame()
        {
            Console.SetCursorPosition(Constants.Ints.DefaultZero, Constants.Ints.DefaultZero);
            Console.Write(new string(Constants.Chars.Equal, Constants.Ints.Width));

            Console.SetCursorPosition(Constants.Ints.DefaultZero, Constants.Ints.HeaderRow);
            Console.Write(new string(Constants.Chars.Dash, Constants.Ints.Width));

            Console.SetCursorPosition(Constants.Ints.DefaultZero, Constants.Ints.StarsEndRow);
            Console.Write(new string(Constants.Chars.Dash, Constants.Ints.Width));

            Console.SetCursorPosition(Constants.Ints.DefaultZero, Constants.Ints.EndFrameRow);
            Console.Write(new string(Constants.Chars.Equal, Constants.Ints.Width));

            for (int row = Constants.Ints.DefaultOne; row < Constants.Ints.EndFrameRow; row++)
            {
                Console.SetCursorPosition(Constants.Ints.DefaultZero, row);
                Console.Write(new string(Constants.Chars.Star, Constants.Ints.DefaultOne));

                Console.SetCursorPosition(Constants.Ints.LastColumn, row);
                Console.Write(new string(Constants.Chars.Star, Constants.Ints.DefaultOne));
            }
        }

        public static void ShowFutterAndHeader(string header)
        {
            var width = NonCostants.MiddleView(header);

            Console.SetCursorPosition(width, Constants.Ints.DefaultOne);
            Console.Write(header);

            Console.SetCursorPosition(Constants.Ints.DefaultOne, Constants.Ints.FutterRow);
            Console.Write(Constants.Strings.MenuLeft);

            width = NonCostants.MiddleView(Constants.Strings.MenuMiddle);

            Console.SetCursorPosition(width, Constants.Ints.FutterRow);
            Console.Write(Constants.Strings.MenuMiddle);

            width = Console.WindowWidth - Constants.Strings.MenuRight.Length - Constants.Ints.DefaultOne;

            Console.SetCursorPosition(width, Constants.Ints.FutterRow);
            Console.Write(Constants.Strings.MenuRight);
        }

        public static void ShowBodiContent(string[] content, int index)
        {
            var totalRows = Constants.Ints.StarsEndRow - Constants.Ints.StarsStartRow;
            var rowDifference = totalRows / (content.Length + Constants.Ints.DefaultOne);
            var firstRow = Constants.Ints.StarsStartRow + rowDifference;

            foreach (var rowContent in content)
            {
                if (rowContent == content[index])
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                //else
                //{
                //    Console.BackgroundColor = ConsoleColor.Black;
                //    Console.ForegroundColor = ConsoleColor.DarkGray;
                //}

                Console.SetCursorPosition(NonCostants.MiddleView(rowContent),firstRow);
                Console.Write(rowContent);
                firstRow += rowDifference;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }
    }
}
