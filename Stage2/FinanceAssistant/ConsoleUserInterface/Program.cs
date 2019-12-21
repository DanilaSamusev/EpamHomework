using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUserInterface
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = Startup.ConfigureServices();
            var ui = serviceProvider.GetService<UserInterface>();
            ui.Run();
        }
    }
}