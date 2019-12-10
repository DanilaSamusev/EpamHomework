using Client;
using Client.Interfaces;
using FinancialAnalyzer;
using FinancialService;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationStarter
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IClient, ConsoleClient>();
            collection.AddScoped<IWriter, ConsoleWriter>();
            collection.AddScoped<IReader, ConsoleReader>();
            collection.AddScoped<FinancialNoteMapper>();
            collection.AddScoped<IFinancialService, FinancialService.FinancialService>();
            collection.AddSingleton<FinancialFlowAnalyzer>();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}