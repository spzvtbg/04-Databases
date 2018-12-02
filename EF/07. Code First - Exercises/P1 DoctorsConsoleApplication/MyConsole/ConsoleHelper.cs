namespace P1_DoctorsConsoleApplication.MyConsole
{
    using System;
    using System.Collections.Generic;

    class ConsoleHelper
    {
        public static void WindowFrame()
        {
            Console.Write(new string('#', Console.WindowWidth));

            for (int row = 1; row < Console.WindowHeight - 2; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write('#');

                Console.SetCursorPosition(Console.WindowWidth - 1, row);
                Console.Write('#');
            }

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write(new string('#', Console.WindowWidth));
        }

        public static void Section(string section)
        {
            int startLeftPosition = (Console.WindowWidth - 2 - section.Length) / 2;
            Console.SetCursorPosition(startLeftPosition, 2);
            Console.Write(section);
        }

        public static void MenuFrame()
        {
            Console.SetCursorPosition(1, 3);
            Console.Write(new string('_', Console.WindowWidth - 2));

            for (int row = 4; row < Console.WindowHeight - 2; row++)
            {
                Console.SetCursorPosition(1, row);
                Console.Write('|');

                Console.SetCursorPosition(Console.WindowWidth - 2, row);
                Console.Write('|');
            }

            Console.SetCursorPosition(2, Console.WindowHeight - 3);
            Console.Write(new string('_', Console.WindowWidth - 4));
        }

        public static void DisplayOptions(Dictionary<string, Position> options)
        {
            var optionsRows = options.Count + (options.Count - 1) * 2;
            var startRow = 4 + (Console.WindowHeight - 7 - optionsRows) / 2;

            foreach (var option in options)
            {
                var startLeft = (Console.WindowWidth - 4 - option.Key.Length) / 2;
                Console.SetCursorPosition(startLeft, startRow);
                Console.Write(option.Key);

                startRow += 3;

                option.Value.Col = startLeft - 2;
                option.Value.Row = startRow - 1;
            }
        }
    }
}
