using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetPurchaseOrders
{
	public class GetPurchaseOrdersResponse : BaseResponseModel
	{
		public List<PurchaseOrder> PurchaseOrders { get; set; }
	}
}
