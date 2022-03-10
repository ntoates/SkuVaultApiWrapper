using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetLocations
{
	public class GetLocationsRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getLocations;
	}
}
