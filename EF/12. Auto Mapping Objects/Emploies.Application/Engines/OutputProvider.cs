namespace Emploies.Application.Engines
{
    using System;

    class OutputProvider
    {
        public static string[] ReadComand()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Enter command: ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine().Split();
        }

        public static void ThrowException(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public static void PrintMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
