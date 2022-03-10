using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProducts
{
	public class GetProductsRequest : BasePagedRequestModel
	{
		public string ModifiedAfterDateTimeUtc { get; set; }
		public string ModifiedBeforeDateTimeUtc { get; set; }
		public int PageSize { get; set; }
		public List<string> ProductCodes { get; set; }
		public List<string> ProductSkus { get; set; }
		public override string Endpoint() => SkuVaultEndpoints.getProducts;
	}
}
