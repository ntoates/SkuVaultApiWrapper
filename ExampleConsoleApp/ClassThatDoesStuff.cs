using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Extensions;
using SkuVaultApiWrapper.Models.GetOnlineSaleStatus;
using SkuVaultApiWrapper.Models.GetProduct;
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
			//var saleRequest = new SyncOnlineSaleRequest { 
			//	OrderId = "12345",
			//	OrderTotal = 2.5,
			//	ItemSkus = new List<ItemSku> {
			//		new ItemSku { Sku = "testsku1001", Quantity = 5, UnitPrice = 2.5 }

			//	} 
			//};
			//var saleRespone = _skuVaultApiClient.SyncOnlineSale(saleRequest).GetAwaiter().GetResult();
			//Console.WriteLine($"Order Id: {saleRespone.OrderId} --- Status: {saleRespone.Status} --- ");

			var getOnlineSaleRequest = new GetOnlineSaleStatusRequest { OrderIds = new List<string> { "12345" } };
			var saleRespone = _skuVaultApiClient.GetOnlineSaleStatus(getOnlineSaleRequest).GetAwaiter().GetResult();
			Console.WriteLine($"Order Id: {saleRespone.Sales[0].Id} --- Status: {saleRespone.Sales[0].Status}");


		}
	}
}
