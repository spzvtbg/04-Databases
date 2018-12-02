namespace _00.Minions.Renderer
{
    using System;

    using _00.Minions.Common;
    using _00.Minions.UserInterface;

    public class OutPutRenderer
    {
        public static void SelectOption(string[] options)
        {
            var index = Constants.Ints.DefaultZero;

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey();
                NonCostants.ClearKeyBuffer();
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    index = index == 0 ? options.Length - 1 : index - 1;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    index = Math.Abs((index + 1) % options.Length);
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {

                }
                ConsoleWriteHelper.ShowBodiContent(options, index);
            }
        }
    }
}
