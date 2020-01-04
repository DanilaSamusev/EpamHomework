using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private string ConnectionString;

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
            ConnectionString = AppConfiguration.GetSection("ConnectionStrings:PathToNotes").Value;
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<UserInterface>();
            services.AddScoped<FinanceAnalyzer>();
            services.AddScoped<IFinanceNoteConverter, FinanceNoteToStringConverter>();
            services.AddScoped<IReporter, FileReporter>(fr =>
                new FileReporter(PathToFinanceReport, new FinanceNoteToStringConverter()));
            services.AddScoped<IFinanceNoteService, FinanceNoteNoteService>();
            services.AddScoped<IFinanceNoteRepository, FinanceNoteJsonRepository>(fr =>
                new FinanceNoteJsonRepository(ConnectionString));
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "Please enter into field the word 'Bearer' following by space and JWT",
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
                            ValidIssuer = AuthOptions.ISSUER,
                            ValidateAudience = true,                           
                            ValidAudience = AuthOptions.AUDIENCE,                            
                            ValidateLifetime = true,                            
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),                            
                            ValidateIssuerSigningKey = true,
                        };
                    });
        }

        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; // издатель токена
            public const string AUDIENCE = "MyAuthClient"; // потребитель токена
            const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
            public const int LIFETIME = 1; // время жизни токена - 1 минута
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}