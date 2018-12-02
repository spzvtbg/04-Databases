namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Core.Atributes;

    public static class CommandDispatcher
    {
        public static void DispatchCommand(string[] data)
        {
            String command = data[0].ToLower();

            Type currentClass = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(a => a.GetCustomAttributes<CommandAttribute>()
                .Select(n => n.Name).Contains(command));

            ICommand instance = (ICommand)Activator.CreateInstance(currentClass);
            instance.Parse(data);
            instance.Execute();
        }
    }
}
