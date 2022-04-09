using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.CreateBrands
{
	public class CreateBrandsRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.createBrands;
		public List<Brand> Brands { get; set; }
	}
}
