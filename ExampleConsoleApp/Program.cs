using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models;
using System.Configuration;

namespace ExampleConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<SkuVaultApiClientConfig>()
                .Build();

            // Inject Http client and Config into our ExampleClass
            IServiceCollection services = new ServiceCollection();
            services.AddHttpClient<ISkuVaultApiClient, SkuVaultApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://testing.com");
                // Can configure http client here as needed
            });
            services.Configure<SkuVaultApiClientConfig>(builder.GetSection("SkuVaultApiClientConfig"));

            services.AddTransient<IClassThatDoesStuff, ClassThatDoesStuff>();



            // Get Builder and Run
            IServiceProvider provider = services.BuildServiceProvider();
            var exampleClass = provider.GetService<IClassThatDoesStuff>();
            exampleClass?.Run();
        }
    }
}