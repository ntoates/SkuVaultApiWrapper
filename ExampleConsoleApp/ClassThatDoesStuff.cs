using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Extensions;
using SkuVaultApiWrapper.Models.GetProduct;

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
			var productResponse = _skuVaultApiClient.GetProduct(new GetProductRequest { ProductSKU = "testsku1001" }).GetAwaiter().GetResult();
			Console.WriteLine("Product Description and SKU from your product from /getProduct: " + productResponse.Product.Description + "-" + productResponse.Product.Sku);
		}
	}
}
