namespace _00.Minions
{
    using System;

    using _00.Minions.UserInterface;
    using _00.Minions.Renderer;
    using _00.Minions.Common;

    public class StartUP
    {
        public static void Main()
        {
            ConsoleWriter.InitializeConsoleWindow();
            ConsoleWriter.InitializeContent();
            OutPutRenderer.SelectOption(NonCostants.InitialContent());
            Console.ReadLine();
        }
    }
}
