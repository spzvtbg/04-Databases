namespace _00.Minions.UserInterface
{
    using System;

    using _00.Minions.Common;

    public class ConsoleWriter
    {
        public static void InitializeConsoleWindow()
        {
            Console.Title = new string(' ', Constants.Ints.TitleLeft) + Constants.Strings.AppTitle;
            Console.SetWindowSize(Constants.Ints.Width, Constants.Ints.WindowHeight);
            Console.SetBufferSize(Constants.Ints.Width, Constants.Ints.BufferHeight);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void InitializeContent()
        {
            ConsoleWriteHelper.ShowFrame();
            ConsoleWriteHelper.ShowFutterAndHeader(Constants.Strings.WelcomeText);
            ConsoleWriteHelper.ShowBodiContent(NonCostants.InitialContent(), 0);
        }
    }
}
