using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProduct
{
	public class GetProductRequest : BaseRequestModel
	{
		public string ProductCode { get; set; }
		public string ProductSKU { get; set; }
	}
}
