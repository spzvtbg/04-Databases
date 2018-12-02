namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Data;
    using Models;
    using PhotoShare.Client.Core.Atributes;
    using PhotoShare.Client.Core.Contracts;
    using PhotoShare.Client.Core.Commands.Validations;
    using PhotoShare.Client.Core.Commands.Validations.Messages;

    [Command("registeruser")]
    public class RegisterUserCommand : ICommand
    {
        private string Username { get; set; }

        private string Password { get; set; }

        private string RepeatedPassword { get; set; }

        private string Email { get; set; }

        public void Parse(string[] commandData)
        {
            this.Username = commandData[1];
            this.Password = commandData[2];
            this.RepeatedPassword = commandData[3];
            this.Email = commandData[4];
        }

        private static PhotoShareContext context = new PhotoShareContext();

        // RegisterUser <username> <password> <repeat-password> <email>
        public void Execute()
        {
            RegisterUserValidator.AreEqual(this.Password, this.RepeatedPassword);
            RegisterUserValidator.Exists(this.Username, context);

            User user = new User
            {
                Username = this.Username,
                Password = this.Password,
                Email = this.Email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (context)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(UserMessages.Success(this.Username)); 
        }
    }
}
