using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Converters;
using Business.FinanceAnalyzer;
using Business.FinanceReporters;
using Business.Services;
using ConsoleUserInterface;
using Contracts.ConverterContracts;
using Contracts.ReporterContracts;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceAssistant.WebApi
{
    public class Startup
    {
        private static IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json");
            AppConfiguration = builder.Build();          
            var pathToReport = AppConfiguration.GetSection("ConnectionStrings:PathToReport").Value;
            var connectionString = AppConfiguration.GetSection("ConnectionStrings:PathToNotes").Value;

            services.AddControllers();
            services.AddScoped<UserInterface>();
            services.AddScoped<FinanceAnalyzer>();
            services.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            services.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            services.AddScoped<IReporter, FileReporter>(fr =>
                new FileReporter(pathToReport, new FinanceNoteToStringConverter()));
            services.AddScoped<IFinanceService, FinanceService>();
            services.AddScoped<IFinanceNoteRepository, FinanceNoteJsonRepository>(fr =>
                new FinanceNoteJsonRepository(connectionString));
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
