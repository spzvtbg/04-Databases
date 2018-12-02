namespace Emploies.Application.Engines
{
    using System;

    class Engine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    String[] commandLine = OutputProvider.ReadComand();
                    CommandActivator.ExecuteCurrentCommand(commandLine);
                }
                catch (Exception ex)
                {
                    OutputProvider.ThrowException(ex.Message);
                }
            }
        }
    }
}
