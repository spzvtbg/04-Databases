using ConsoleDrawHelper;
using System;

namespace ConsoleApp2
{
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
