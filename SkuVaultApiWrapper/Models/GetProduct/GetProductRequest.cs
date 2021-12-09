using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProduct
{
	public class GetProductRequest : BaseRequestModel
	{
		public List<string> ProductCode { get; set; }
		public List<string> ProductSKU { get; set; }
	}
}
