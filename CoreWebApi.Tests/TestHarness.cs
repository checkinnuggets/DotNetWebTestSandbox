using System;
using System.IO;
using CoreWebApi.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreWebApi.Tests
{
    public class TestHarness : IDisposable
    {
        // Loosely based on:
        // https://www.hanselman.com/blog/real-browser-integration-testing-with-selenium-standalone-chrome-and-aspnet-core-21

        private const string RelativePathToWebProjectFolder = @"..\..\..\..\CoreWebApi\\";

        public InMemoryAddressBookDataStore DataStore { get; }

        public IWebHost WebHost { get; }


        public TestHarness(string url)
        {
            DataStore = new InMemoryAddressBookDataStore();

            var configBuilder = new ConfigurationBuilder();
            // configBuilder.AddJsonFile("testsettings.json");

            var config = configBuilder.Build();

            var contentRoot = Path.GetFullPath(RelativePathToWebProjectFolder, Directory.GetCurrentDirectory());

            var hostBuilder = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
                .UseEnvironment(Environments.Development)
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseUrls(url)
                .UseContentRoot(contentRoot)
                .UseKestrel();

            hostBuilder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IAddressBookDataStore>(provider => DataStore);
            });

            WebHost = hostBuilder.Build();
            WebHost.Start();
        }

        public void Dispose()
        {
            WebHost?.Dispose();
        }
    }
}
