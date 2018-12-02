namespace PhotoShare.Client.Core
{
    using System;

    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                Console.ReadKey();
                try
                {
                    string input = "ModifyUser Pe60 BornTown 456".Trim();//Console.ReadLine().Trim();
                    string[] data = input.Split(' ');
                    CommandDispatcher.DispatchCommand(data);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
