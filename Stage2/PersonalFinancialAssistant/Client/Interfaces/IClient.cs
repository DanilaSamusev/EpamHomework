namespace Client.Interfaces
{
    public interface IClient
    {
        void Run();
        int GetAction();
        decimal GetFinanceAmount();
    }
}