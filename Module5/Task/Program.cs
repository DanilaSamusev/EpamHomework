using Task.Entities;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var isAnotherGameRequired = true;

            while (isAnotherGameRequired)
            {
                Game game = new Game();
                isAnotherGameRequired = game.Start();
            }
        }
    }
}