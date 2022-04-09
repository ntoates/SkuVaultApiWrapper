using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkuVaultApiWrapper.DependencyInjection;

namespace ExampleConsoleApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Default ConfigurationBuilder pulling Configruation from user secrets.
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
				.AddUserSecrets<UserDefinedConfiguration>()
				.Build();

			// Add Configuration and Services for this library
			IServiceCollection services = new ServiceCollection();
			services.AddSkuVaultApiWrapper(builder.GetSection("SkuVaultApiClientConfig"));

			// Inject whatever class is doing stuff and run a basic method
			services.AddTransient<IClassThatDoesStuff, ClassThatDoesStuff>();

			IServiceProvider provider = services.BuildServiceProvider();
			var exampleClass = provider.GetService<IClassThatDoesStuff>();
			exampleClass?.Run();
		}
	}
}