using Authentication;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FinanceAssistant.WebApi
{
    public class Startup
    {
        private static IConfiguration AppConfiguration { get; set; }
        private string PathToFinanceReport;
        private string ConnectionToNotes;
        private string ConnectionToUsers;

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureJsonFiles(services);
            ConfigureTokenAuthentication(services);
            ConfigureDependencies(services);
            ConfigureSwagger(services);
            services.AddControllers();
        }

        private void ConfigureJsonFiles(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json");
            AppConfiguration = builder.Build();
            PathToFinanceReport = AppConfiguration.GetSection("ConnectionStrings:PathToReport").Value;
            ConnectionToNotes = AppConfiguration.GetSection("ConnectionStrings:ConnectionToNotes").Value;
            ConnectionToUsers = AppConfiguration.GetSection("ConnectionStrings:ConnectionToUsers").Value;
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<UserInterface>();
            services.AddScoped<FinanceAnalyzer>();
            services.AddScoped<TokenProvider>();
            services.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            services.AddScoped<IFinanceNoteService, FinanceNoteService>();
            
            services.AddScoped<IReporter, FileReporter>(fr =>
                new FileReporter(PathToFinanceReport, new FinanceNoteToStringConverter()));
            
            services.AddScoped<IUserRepository, UserJsonRepository>(ur =>
                new UserJsonRepository(ConnectionToUsers));
            
            services.AddScoped<IFinanceNoteRepository, FinanceNoteJsonRepository>(fr =>
                new FinanceNoteJsonRepository(ConnectionToNotes));
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
            });
        }

        private void ConfigureTokenAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthenticationOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthenticationOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceAssistant.Api");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}