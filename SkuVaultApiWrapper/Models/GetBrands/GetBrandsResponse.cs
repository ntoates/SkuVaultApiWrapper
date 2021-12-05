using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetBrands
{
	public class GetBrandsResponse : BaseResponseModel
	{
		public List<Brand> Brands { get; set; }
	}
}
