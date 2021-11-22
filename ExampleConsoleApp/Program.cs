using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models;

namespace ExampleConsoleApp
{
	/// <summary>
	/// You will need to add a User Secrets file containing user credentials for this to run successfully.
	/// </summary>
	/// <example> 
	/// Example secrets.json
	/// {
	///		"skuvaultapiclientconfig": {
	///			"useremail": "YourUserName",
	///			"userpassword": "YourUserPass"
	///		}
	/// } 
	/// </example>
	public class Program
	{
		public static void Main(string[] args)
		{
			// Default ConfigurationBuilder pulling Configruation from user secrets.
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddUserSecrets<UserDefineConfiguration>()
				.Build();

			// Inject IHttpClientFactory client into SkuVaultApiClient
			IServiceCollection services = new ServiceCollection();
			services.AddHttpClient<ISkuVaultApiClient, SkuVaultApiClient>(client =>
			{
				client.BaseAddress = new Uri("https://testing.com");
				// Can configure http client here as needed
			});

			// Configure SkuVaultApiClientConfig so it is available for reference
			services.Configure<SkuVaultApiClientConfig>(builder.GetSection("SkuVaultApiClientConfig"));

			// Inject whatever class is doing stuff
			services.AddTransient<IClassThatDoesStuff, ClassThatDoesStuff>();

			// Get Builder and Run
			IServiceProvider provider = services.BuildServiceProvider();
			var exampleClass = provider.GetService<IClassThatDoesStuff>();
			exampleClass?.Run();
		}
	}
}