using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models;
using System.Configuration;

namespace SkuVaultApiWrapperExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //setup our DI
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            services.Configure<SkuVaultApiClientConfig>(config.GetSection(nameof(SkuVaultApiClientConfig)));

            services.AddHttpClient<ISkuVaultApiClient, SkuVaultApiClient>().ConfigureHttpClient((serviceProvider, httpClient) =>
             {
                 var clientConfig = serviceProvider.GetRequiredService<SkuVaultApiClientConfig>();
                 httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
             });
        }
    }
}