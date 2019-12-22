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
using Microsoft.Extensions.Configuration;

namespace ConsoleUserInterface
{
    public class Startup
    {
        private static IConfiguration AppConfiguration { get; set; }
        
        public static UserInterface Build()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("F:\\MyWorks\\Epam\\Solutions\\Stage2\\FinanceAssistant\\ConsoleUserInterface\\appsettings.json");
            AppConfiguration = builder.Build();
            
            var serviceProvider = ConfigureServices();
            
            return serviceProvider.GetService<UserInterface>();
        }

        private static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            var connectionString = AppConfiguration.GetSection("ConnectionStrings:ConnectionString").Value;
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