namespace Emploies.Application.Engines
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Emploies.Application.Core.Contracts;

    class CommandActivator
    {
        public static void ExecuteCurrentCommand(string[] commandParameters)
        {
            Type commandType = Assembly.GetExecutingAssembly().GetTypes()
                .SingleOrDefault(t => t.Name.ToLower().Contains(commandParameters[0].ToLower()));

            if (commandType != null)
            {
                ICommand selectedCommand = (ICommand)Activator.CreateInstance(commandType);
                selectedCommand.Execute(commandParameters);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }
        }
    }
}
