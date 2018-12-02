namespace ConsoleDrawHelper
{
    using System;

    public class Frame
    {
        public static void HoleFrame(char symbol, int columns, int rows, ConsoleColor color)
        {
            int count = 0;
            Console.ForegroundColor = color;
            Console.Write(new string(symbol, columns + 1));
            for (count = 1; count < rows; count++)
            {
                Console.SetCursorPosition(0, count);
                Console.Write(symbol);

                Console.SetCursorPosition(columns, count);
                Console.Write(symbol);
            }
            Console.SetCursorPosition(0, count);
            Console.Write(new string(symbol, columns + 1));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
