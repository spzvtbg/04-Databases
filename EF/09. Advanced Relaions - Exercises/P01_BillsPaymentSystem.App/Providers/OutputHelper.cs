namespace P01_BillsPaymentSystem.App.Providers
{
    using System;

    using P01_BillsPaymentSystem.App.Constants;

    public class OutputHelper
    {
        public void PrintVerticalFrameSides(int row)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            
            Console.SetCursorPosition(0, row);
            Console.Write(Strings.FrameSymbol);
            Console.SetCursorPosition(Console.WindowWidth - 1, row);
            Console.Write(Strings.FrameSymbol);
        }

        public void PrintHorisontalFramePart()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write(new string(Strings.FrameSymbol, Console.WindowWidth));
        }

        public void PrintRow(string item, int top)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(9, top - 1);
            Console.Write(new string(' ', item.Length + 4));

            Console.SetCursorPosition(9, top);
            Console.Write($"  {item}  ");

            Console.SetCursorPosition(9, top + 1);
            Console.Write(new string(' ', item.Length + 4));
        }

        public void PrintRowAsSelected(string item, int top)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(9, top - 1);
            Console.Write(new string(' ', item.Length + 4));

            Console.SetCursorPosition(9, top);
            Console.Write($"  {item}  ");

            Console.SetCursorPosition(9, top + 1);
            Console.Write(new string(' ', item.Length + 4));
        }

        public void PrintStatus(string satus, int index)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(9 + Strings.Options[index].Length + 6, Integers.OptionsStartRows[index]);
            Console.Write(new string(' ', 11));
            Console.SetCursorPosition(9 + Strings.Options[index].Length + 6, Integers.OptionsStartRows[index]);
            Console.Write(satus);
            Console.SetCursorPosition(9 + Strings.Options[index].Length + 6, Integers.OptionsStartRows[index]);
        }

        public void PrintUserSelectingView()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(1, 1);
            Console.Write(new string('=', Console.WindowWidth - 2));

            Console.SetCursorPosition(1, 4);
            Console.Write(new string('=', Console.WindowWidth - 2));

            Console.SetCursorPosition(2, 3);
            Console.Write(Strings.EnterNumber);
        }

        public void PrintUserSelectingView(string paybills)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(1, 1);
            Console.Write(new string('=', Console.WindowWidth - 2));

            Console.SetCursorPosition(1, 6);
            Console.Write(new string('=', Console.WindowWidth - 2));

            Console.SetCursorPosition(2, 5);
            Console.Write(Strings.EnterData);

            Console.SetCursorPosition(2, 3);
            Console.Write(Strings.EnterNumber);
        }
    }
}
