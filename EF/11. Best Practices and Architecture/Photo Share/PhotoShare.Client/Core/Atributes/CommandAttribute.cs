namespace PhotoShare.Client.Core.Atributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute(string commandName)
        {
            this.Name = commandName;
        }

        public string Name { get; set; }
    }
}
