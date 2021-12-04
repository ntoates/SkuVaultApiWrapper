using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkuVaultApiWrapper.Models;
using System;

namespace SkuVaultApiWrapper.Extensions
{

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSkuVaultApiWrapper(this IServiceCollection services, IConfigurationRoot configuration, string moduleName)
		{
			// TODO: Implement this
			//services.AddTransient<SkuVaultApiClient>();
			//var skuVaultApiWrapperConfig = (SkuVaultApiClientConfig)configuration.GetSection(nameof(SkuVaultApiClientConfig));
			//if (skuVaultApiWrapperConfig == null)
			//{
			//	throw new ArgumentException("SkuVaultApiClientConfig section is required when using the IServiceCollection extension to inject SkuVaultApiClient.");
			//}

			//services.Configure<SkuVaultApiClientConfig>(configuration.GetSection("SkuVaultApiClientConfig"));

			//services.ConfigureOptions<SkuVaultApiClientConfig>();
			//services.AddOptions<SkuVaultApiClientConfig>();
			//services.AddHttpClient<ISkuVaultApiClient, SkuVaultApiClient>(client =>
			//{
			//	client.BaseAddress = new Uri("https://testing.com");
			//	// Can configure http client here as needed
			//});
			return services;
		}
	}
}
