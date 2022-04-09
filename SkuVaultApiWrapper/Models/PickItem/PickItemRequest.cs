using SkuVaultApiWrapper.Models.Shared;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.PickItem
{
	public class PickItemRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.pickItem;
		public int WarehouseId { get; set; }
		public string LocationCode { get; set; }
		public string Code { get; set; }
		public string Sku { get; set; }
		public int Quantity { get; set; }
		public bool IsExpressPick { get; set; }
		public string Note { get; set; }
		public List<string> SerialNumbers { get; set; }
		public bool AllowPickItemNotInSale { get; set; }
		public bool AllowPickQuantityGreaterThanRemainingSaleQuantity { get; set; }
		public string PickMode { get; set; }
	}
}
