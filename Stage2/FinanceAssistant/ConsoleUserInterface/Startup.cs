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
            var builder = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json");
            AppConfiguration = builder.Build();
            var serviceProvider = ConfigureServices();

            return serviceProvider.GetService<UserInterface>();
        }

        private static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();
            var pathToReport = AppConfiguration.GetSection("ConnectionStrings:PathToReport").Value;
            var connectionString = AppConfiguration.GetSection("ConnectionStrings:PathToNotes").Value;
            collection.AddScoped<UserInterface>();
            collection.AddScoped<FinanceAnalyzer>();
            collection.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            collection.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            collection.AddScoped<IReporter, FileReporter>(fr =>
                new FileReporter(pathToReport, new FinanceNoteToStringConverter()));
            collection.AddScoped<IFinanceNoteService, FinanceNoteService>();
            collection.AddScoped<IFinanceNoteRepository, FinanceNoteJsonRepository>(fr =>
                new FinanceNoteJsonRepository(connectionString));
            var serviceProvider = collection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}