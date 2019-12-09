﻿using Client;
using Client.Interfaces;
using FinancialAnalyzer;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Startup.ConfigureServices();
            var application = serviceProvider.GetService<Application>();
            application.Start();
        }

        private static ServiceProvider InjectDependencies()
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