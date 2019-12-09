namespace Client.Interfaces
{
    public interface IClient
    {
        void Run();
        void Write(string message);
        int GetAction();
        decimal GetMoneyAmount();
    }
}