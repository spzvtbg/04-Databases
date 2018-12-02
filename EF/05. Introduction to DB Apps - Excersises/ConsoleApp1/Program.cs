namespace ConsoleApp1
{
    using ConsoleDrawHelper;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Frame.HoleFrame('|', 20, 10, ConsoleColor.Green);
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
