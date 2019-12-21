using Business.Converters;
using Business.FinanceAnalyzer;
using Business.FinanceReporters;
using Business.Services;
using Contracts.ConverterContracts;
using Contracts.ReporterContracts;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUserInterface
{
    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<UserInterface>();
            collection.AddScoped<FinanceAnalyzer>();
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