using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.SkuVaultApiClientExtensions;

namespace ExampleConsoleApp
{
	public class ClassThatDoesStuff : IClassThatDoesStuff
	{
		private readonly SkuVaultApiClient _skuVaultApiClient;

		public ClassThatDoesStuff(ISkuVaultApiClient skuvaultApiClient)
		{
			_skuVaultApiClient = (SkuVaultApiClient)skuvaultApiClient;
		}

		public void Run()
		{
			var result = _skuVaultApiClient.GetWarehouses(new GetWarehouseRequest()).GetAwaiter().GetResult();
			Console.WriteLine("Injection is neat! Here is a warehouse from your account: " + result.Warehouses.FirstOrDefault().Code);
		}
	}
}
