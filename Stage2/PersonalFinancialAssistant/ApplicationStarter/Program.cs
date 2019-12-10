using Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Startup.ConfigureServices();
            var client = serviceProvider.GetService<IClient>();
            client.Run();
        }
    }
}