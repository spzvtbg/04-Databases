namespace PhotoShare.Client.Core.Commands.Validations
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Client.Core.Commands.Validations.Messages;

    public static class RegisterUserValidator
    {
        public static void AreEqual(string password, string repeatedPassword)
        {
            if (password != repeatedPassword)
            {
                throw new ArgumentException(UserMessages.InvalidPassword);
            }
        }

        public static void Exists(string username, PhotoShareContext context)
        {
            if (context.Users.Any(u => u.Username == username))
            {
                //context.Dispose();
                throw new InvalidOperationException(UserMessages.InvalidUsername(username));
            }
        }
    }
}
