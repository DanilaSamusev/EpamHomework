using ConverterContracts;
using Converters;
using ReporterContracts;
using Reporters;
using ServiceContracts;
using Services;
using RepositoryContracts;
using Repositories;
using Microsoft.Extensions.DependencyInjection;
using FinanceAnalizer;

namespace ConsoleUserInterface
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<UserInterface>();
            collection.AddScoped<FinanceFlowAnalizer>();
            collection.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            collection.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            collection.AddScoped<IReporter, ConsoleReporter>();
            collection.AddScoped<IFinanceService, FinanceService>();
            collection.AddScoped<IFinanceNoteRepository, FinanceNoteRepository>();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
