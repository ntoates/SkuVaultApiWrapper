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
			var warehouseResponse = _skuVaultApiClient.GetWarehouses(new GetWarehouseRequest()).GetAwaiter().GetResult();
			//var externalWarehouseResponse = _skuVaultApiClient.GetExternalWarehouses(new GetExternalWarehousesRequest()).GetAwaiter().GetResult();
			//var integrationsResponse = _skuVaultApiClient.GetIntegrations(new GetIntegrationsRequest()).GetAwaiter().GetResult();
			//var classificaitonResponse = _skuVaultApiClient.GetClassifications(new GetClassificationsRequest()).GetAwaiter().GetResult();
			//var brandsReponse = _skuVaultApiClient.GetBrands(new GetBrandsRequest()).GetAwaiter().GetResult();
			//var locationsResponse = _skuVaultApiClient.GetLocations(new GetLocationsRequest()).GetAwaiter().GetResult();
			//var kitsResponse = _skuVaultApiClient.GetKits(new GetKitsRequest()).GetAwaiter().GetResult();
			var productResponse = _skuVaultApiClient.GetProduct(new GetProductRequest { ProductSKU = "testsku1001" }).GetAwaiter().GetResult();
			//var productsResponse = _skuVaultApiClient.GetProducts(new GetProductsRequest { ProductSkus = new List<string> { "C0009" } }).GetAwaiter().GetResult();
			//var purchaseOrderResponse = _skuVaultApiClient.GetPurchaseOrders(new GetPurchaseOrdersRequest { }).GetAwaiter().GetResult();
			//var availableQuantitiesResponse = _skuVaultApiClient.GetAvailableQuantities(new GetAvailableQuantitiesRequest { }).GetAwaiter().GetResult();


			Console.WriteLine("Injection is neat!");
			Console.WriteLine("");

			//Console.WriteLine("Warehouse from your account: " + warehouseResponse.Warehouses?.FirstOrDefault()?.Code);
			//Console.WriteLine("External Warehouse from your account: " + externalWarehouseResponse.Warehouses?.FirstOrDefault()?.Code);
			//Console.WriteLine("Integration from your account: " + integrationsResponse.Accounts?.FirstOrDefault()?.Name);
			//Console.WriteLine("Classification from your account: " + classificaitonResponse.Classifications.FirstOrDefault()?.Name);
			//Console.WriteLine("Brand from your account: " + brandsReponse.Brands.FirstOrDefault()?.Name);
			//Console.WriteLine("Warehouse-Location from your account: " + locationsResponse.Items.FirstOrDefault()?.WarehouseCode + "-" + locationsResponse.Items.FirstOrDefault()?.LocationCode);
			//Console.WriteLine("Kit from your account: SKU = " + kitsResponse.Kits.FirstOrDefault()?.SKU);
			Console.WriteLine("Product Description and QuantityAvailable from your product from /getProduct: " + productResponse?.Product?.Description + "-" + productResponse?.Product?.QuantityAvailable);
			//Console.WriteLine("Product Description and QuantityAvailable from your product from /getProducts: " + productsResponse?.Products?.FirstOrDefault()?.Description + "-" + productsResponse?.Products?.FirstOrDefault()?.QuantityAvailable);
			//Console.WriteLine("Purchase Order ID from your account:" + purchaseOrderResponse?.PurchaseOrders?.FirstOrDefault()?.PoId);
			//Console.WriteLine("Sku and AvailableQuantity from your account:" + availableQuantitiesResponse?.Items?.FirstOrDefault()?.Sku + "-" + availableQuantitiesResponse?.Items?.FirstOrDefault()?.AvailableQuantity);
		}
	}
}
