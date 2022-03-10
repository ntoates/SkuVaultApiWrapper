using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Extensions;
using SkuVaultApiWrapper.Models.GetAvailableQuantities;
using SkuVaultApiWrapper.Models.GetBrands;
using SkuVaultApiWrapper.Models.GetIntegrations;
using SkuVaultApiWrapper.Models.GetKits;
using SkuVaultApiWrapper.Models.GetLocations;
using SkuVaultApiWrapper.Models.GetProduct;
using SkuVaultApiWrapper.Models.GetProducts;
using SkuVaultApiWrapper.Models.GetPurchaseOrders;
using SkuVaultApiWrapper.Models.SkuVaultModels;

namespace ExampleConsoleApp
{
	public class ClassThatDoesStuff : IClassThatDoesStuff
	{
		private readonly SkuVaultApiClient _skuVaultApiClient;

		public ClassThatDoesStuff(SkuVaultApiClient skuvaultApiClient)
		{
			_skuVaultApiClient = skuvaultApiClient;
		}

		public void Run()
		{
			var warehouseResponse = _skuVaultApiClient.GetWarehouses(new GetWarehousesRequest()).GetAwaiter().GetResult();
			Console.WriteLine("Warehouse from your account: " + warehouseResponse.Warehouses?.FirstOrDefault()?.Code);
		}
	}
}
