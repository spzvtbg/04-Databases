namespace P1_DoctorsConsoleApplication
{
    using P1_DoctorsConsoleApplication.MyConsole;
    using P1_DoctorsConsoleApplication.Values;

    public class ConsoleView
    {
        public static void Initial()
        {
            ConsoleHelper.WindowFrame();
            ConsoleHelper.MenuFrame();
            ConsoleHelper.DisplayOptions(Options.InitialOptions);
            ConsoleHelper.Section("Hello Doctor! Wath you have to do to day?");
        }
    }
}
