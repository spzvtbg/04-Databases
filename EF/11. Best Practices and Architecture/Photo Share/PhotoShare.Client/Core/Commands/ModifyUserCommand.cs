namespace PhotoShare.Client.Core.Commands
{
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Core.Atributes;
    using PhotoShare.Client.Core.Commands.Validations;
    using System;
    using PhotoShare.Client.Core.Commands.Validations.Messages;

    [Command("modifyuser")]
    public class ModifyUserCommand : ICommand
    {
        private static PhotoShareContext context = new PhotoShareContext();

        private string Username { get; set; }

        private string Property { get; set; }

        private string NewValue { get; set; }

        public ModifyUserCommand() { }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public void Parse(string[] commandData)
        {
            ModifyUserValidator.InvalidParameters(commandData.Length);

            this.Username = commandData[1];
            this.Property = commandData[2];
            this.NewValue = commandData[3];
        }

        public void Execute()
        {
            ModifyUserValidator.UserNotFound(this.Username);
            ModifyUserValidator.PropertyNotFound(this.Property);

            var exeMethods = typeof(ModifyUserCommand).GetMethods()
                .SingleOrDefault(m => m.Name.ToLower().Contains(this.Property.ToLower()))
                .Invoke(new ModifyUserCommand(), new object[] { });
        }

        public void ChangePassword()
        {
            ModifyUserValidator.InvalidPassword(this.NewValue);

            context.Users.SingleOrDefault(u => u.Username == this.Username).Password = this.NewValue;
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format(ModifyMessage.Success, this.Username, this.Property, this.NewValue));
        }
        
        public void ChangeBornTown()
        {
            ModifyUserValidator.TownNotFound(this.NewValue);
            ChangeTownID();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format(ModifyMessage.Success, this.Username, this.Property, this.NewValue));
        }

        public void ChangeCurrentTown()
        {
            ModifyUserValidator.TownNotFound(this.NewValue);
            ChangeTownID();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format(ModifyMessage.Success, this.Username, this.Property, this.NewValue));
        }

        private void ChangeTownID()
        {
            var newTownID = context.Towns.SingleOrDefault(t => t.Name == this.NewValue).Id;
            context.Users.SingleOrDefault(u => u.Username == this.Username).BornTownId = newTownID;
            context.SaveChanges();
        }
    }
}
