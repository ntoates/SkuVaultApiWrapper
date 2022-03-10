using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetBrands
{
	public class GetBrandsRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getBrands;
	}
}
