namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Core.Atributes;
    using PhotoShare.Client.Core.Contracts;
    using System;

    [Command("acceptfriends")]
    public class AcceptFriendCommand : ICommand
    {
        protected AcceptFriendCommand() { }

        // AcceptFriend <username1> <username2>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Parse(string[] commandData)
        {
            throw new NotImplementedException();
        }
    }
}
