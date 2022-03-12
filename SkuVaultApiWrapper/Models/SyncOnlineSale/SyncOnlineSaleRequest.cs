using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SyncOnlineSale
{
	public class SyncOnlineSaleRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.syncOnlineSale;
		public string OrderId { get; set; }
		public string MarketplaceId { get; set; }
		public string OrderDateUtc { get; set; }
		public string CheckoutStatus { get; set; }
		public string ChannelType { get; set; }
		public string ChannelAccountId { get; set; }
		public List<FulfilledItem> FulfilledItems { get; set; }
		public List<ItemSku> ItemSkus { get; set; }
		public string Notes { get; set; }
		public int OrderTotal { get; set; }
		public string PaymentStatus { get; set; }
		public string SaleState { get; set; }
		public AutoRemoveInfo AutoRemoveInfo { get; set; }
		public ShippingInfo ShippingInfo { get; set; }

	}
}