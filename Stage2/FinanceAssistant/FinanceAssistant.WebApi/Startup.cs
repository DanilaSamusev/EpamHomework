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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
