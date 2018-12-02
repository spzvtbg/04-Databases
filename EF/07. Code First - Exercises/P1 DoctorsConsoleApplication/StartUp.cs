namespace P1_DoctorsConsoleApplication
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleView.Initial();

            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
