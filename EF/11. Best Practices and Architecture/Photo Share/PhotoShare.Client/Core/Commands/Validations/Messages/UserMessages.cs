namespace PhotoShare.Client.Core.Commands.Validations.Messages
{
    public static class UserMessages
    {
        public const string InvalidPassword = "Passwords do not match!";

        public static string InvalidUsername(string username) => $"Username {username} is already taken!";

        public static string Success(string username) => $"User {username} was registered successfully!";
    }
}
