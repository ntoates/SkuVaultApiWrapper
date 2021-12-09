using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetProduct
{
	public class GetProductResponse : BaseResponseModel
	{
		public ProductDetails ProductDetails { get; set; }
	}
}
