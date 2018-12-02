namespace Emploies.Application.Core.Contracts
{
    public interface ICommand
    {
        void Execute(string[] commandParameters);
    }
}
