using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Extensions;
using SkuVaultApiWrapper.Models.GetBrands;
using SkuVaultApiWrapper.Models.GetIntegrations;
using SkuVaultApiWrapper.Models.GetLocations;
using SkuVaultApiWrapper.Models.SkuVaultModels;

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
			var warehouseResponse = _skuVaultApiClient.GetWarehouses(new GetWarehouseRequest()).GetAwaiter().GetResult();
			var externalWarehouseResponse = _skuVaultApiClient.GetExternalWarehouses(new GetExternalWarehousesRequest()).GetAwaiter().GetResult();
			var integrationsResponse = _skuVaultApiClient.GetIntegrations(new GetIntegrationsRequest()).GetAwaiter().GetResult();
			var classificaitonResponse = _skuVaultApiClient.GetClassifications(new GetClassificationsRequest()).GetAwaiter().GetResult();
			var brandsReponse = _skuVaultApiClient.GetBrands(new GetBrandsRequest()).GetAwaiter().GetResult();
			var locationsResponse = _skuVaultApiClient.GetLocations(new GetLocationsRequest()).GetAwaiter().GetResult();

			Console.WriteLine("Injection is neat!");
			Console.WriteLine("");

			Console.WriteLine("Warehouse from your account: " + warehouseResponse.Warehouses?.FirstOrDefault()?.Code);
			Console.WriteLine("External Warehouse from your account: " + externalWarehouseResponse.Warehouses?.FirstOrDefault()?.Code);
			Console.WriteLine("Integration from your account: " + integrationsResponse.Accounts?.FirstOrDefault()?.Name);
			Console.WriteLine("Classification from your account: " + classificaitonResponse.Classifications.FirstOrDefault()?.Name);
			Console.WriteLine("Brand from your account: " + brandsReponse.Brands.FirstOrDefault()?.Name);
			Console.WriteLine("Warehouse-Location from your account: " + locationsResponse.Items.FirstOrDefault()?.WarehouseCode + "-" + locationsResponse.Items.FirstOrDefault()?.LocationCode);

		}
	}
}
