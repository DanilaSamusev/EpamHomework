namespace Client.Interfaces
{
    public interface IClient
    {
        void Write(string message);
        int GetAction();
        decimal GetMoneyAmount();
    }
}