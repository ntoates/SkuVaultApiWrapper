using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public  class PurchaseOrderCost
	{
		public string Type { get; set; }
		public double Amount { get; set; }
		public string Note { get; set; }
	}
}
