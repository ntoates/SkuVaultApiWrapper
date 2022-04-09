using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProducts
{
	public class GetProductsResponse : BaseResponseWithSvDetailsModel<string>
	{
		public List<ProductDetails> Products { get; set; }
	}
}
