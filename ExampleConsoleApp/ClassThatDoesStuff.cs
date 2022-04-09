using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Extensions;
using SkuVaultApiWrapper.Models.CreateBrands;
using SkuVaultApiWrapper.Models.GetOnlineSaleStatus;
using SkuVaultApiWrapper.Models.SharedModels;
using SkuVaultApiWrapper.Models.SyncOnlineSale;

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
			var request = new CreateBrandsRequest { Brands = new List<Brand> { new Brand { Name = "ApiCreatedBrand1" }, new Brand { Name = "ApiCreatedBrand2" } } };
			var response = _skuVaultApiClient.CreateBrands(request).GetAwaiter().GetResult();
			Console.WriteLine($"Errors Exist: {response.Errors.Any()} --- Status: {response.Status}");
		}
	}
}
