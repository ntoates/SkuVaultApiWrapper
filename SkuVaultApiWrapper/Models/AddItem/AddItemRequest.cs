using SkuVaultApiWrapper.Models.Shared;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.AddItem
{
	public class AddItemRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.addItem;
		public string Sku { get; set; }
		public string Code { get; set; }
		public int WarehouseId { get; set; }
		public string LocationCode { get; set; }
		public int Quantity { get; set; }
		public string Reason { get; set; }
		public string Note { get; set; }
		public List<string> SerialNumbers { get; set; }
	}
}
