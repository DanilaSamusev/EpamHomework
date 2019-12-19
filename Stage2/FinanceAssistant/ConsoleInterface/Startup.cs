using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUserInterface
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<UserInterface>();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
