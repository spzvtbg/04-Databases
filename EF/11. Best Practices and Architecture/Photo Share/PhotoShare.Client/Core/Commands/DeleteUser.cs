namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Data;
    using PhotoShare.Client.Core.Contracts;

    public class DeleteUser : ICommand
    {
        private string Username { get; set; }

        public DeleteUser() { }

        public void Parse(string[] commandData)
        {
            throw new NotImplementedException();
        }

        // DeleteUser <username>
        public void Execute()
        {
            string username = commandData[1];
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with {username} was not found!");
                }

                // TODO: Delete User by username (only mark him as inactive)
                context.SaveChanges();

                return $"User {username} was deleted from the database!";
            }
        }
    }
}
