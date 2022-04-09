using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetLocations
{
	public class GetLocationsResponse : BaseResponseWithSvDetailsModel<string>
	{
		public List<Location> Items { get; set; }
	}
}
