using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProduct
{
	public class GetProductRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getProduct;
		public string ProductCode { get; set; }
		public string ProductSKU { get; set; }
	}
}
