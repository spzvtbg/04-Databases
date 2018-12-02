namespace PhotoShare.Client.Core.Contracts
{
    public interface ICommand
    {
        void Parse(string[] commandData);
        void Execute();
        //void Execute(ICommand instance);
    }
}
