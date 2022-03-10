using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetPurchaseOrders
{
	public class GetPurchaseOrdersRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getPOs;
		public string ModifiedAfterDateTimeUtc { get; set; }
		public string ModifiedBeforeDateTimeUtc { get; set; }
		public string Status { get; set; }
		public bool IncludeProducts { get; set; }
		public List<string> PONumbers { get; set; }
	}
}
