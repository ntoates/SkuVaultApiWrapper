using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkuVaultApiWrapper.Models;
using System;

namespace SkuVaultApiWrapper.Extensions
{
	/// <summary>
	/// Good articles for this pattern can be found here: 
	/// https://dotnetcoretutorials.com/2017/01/24/servicecollection-extension-pattern/
	/// https://tim-maes.com/2019/10/21/net-core-tutorial-using-the-servicecollection-extension-pattern/
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// Adds the Configuration, HttpClientFactory, and Service for the SkuVault API Client.
		/// </summary>
		/// <param name="services">The service collection we are extending.</param>
		/// <param name="skuVaultApiClientConfigurationSection">The Configuration section</param>
		public static void AddSkuVaultApiWrapper(this IServiceCollection services, IConfiguration skuVaultApiClientConfigurationSection)
		{
			services.Configure<SkuVaultApiClientConfig>(skuVaultApiClientConfigurationSection);
			services.AddHttpClient<ISkuVaultApiClient, SkuVaultApiClient>(client =>
			{
				client.BaseAddress = new Uri("https://app.skuvault.com/");
			});

			services.AddTransient<SkuVaultApiClient>();
		}
	}
}
