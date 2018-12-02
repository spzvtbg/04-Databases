namespace PhotoShare.Client.Core.Commands.Validations
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Client.Core.Commands.Validations.Messages;

    public class ModifyUserValidator
    {
        private static PhotoShareContext context = new PhotoShareContext();

        public static void UserNotFound(string username)
        {
            if (!context.Users.Select(u => u.Username).Contains(username))
            {
                throw new ArgumentException(string.Format(ModifyMessage.UserNotFound, username));
            }
        }

        public static void PropertyNotFound(string property)
        {
            if (!typeof(User).GetProperties().Select(p => p.Name.ToLower()).Contains(property.ToLower()))
            {
                throw new ArgumentException(string.Format(ModifyMessage.PropertyNotFound, property));
            }
        }

        public static void InvalidPassword(string password)
        {
            if (!password.Any(x => x >= 'a' && x <= 'z') && !password.Any(x => x >= '0' && x <= '9'))
            {
                throw new ArgumentException(string.Format(ModifyMessage.InvalidPassword));
            }
        }

        public static void TownNotFound(string town)
        {
            if (!context.Towns.Select(t => t.Name).Contains(town))
            {
                throw new ArgumentException(string.Format(ModifyMessage.InvalidTown, town));
            }
        }

        public static void InvalidParameters(int count)
        {
            if (count != 4)
            {
                throw new ArgumentException(ModifyMessage.InvalidFormat);
            }
        }
    }
}
