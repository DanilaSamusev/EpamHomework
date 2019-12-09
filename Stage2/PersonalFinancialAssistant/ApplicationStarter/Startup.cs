using Client;
using Client.Interfaces;
using FinancialAnalyzer;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationStarter
{
    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IClient, ConsoleClient>();
            collection.AddScoped<IWriter, ConsoleWriter>();
            collection.AddScoped<IReader, ConsoleReader>();
            collection.AddScoped<FinancialNoteMapper>();
            collection.AddScoped<Application>();
            collection.AddSingleton<FinancialFlowAnalyzer>();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}