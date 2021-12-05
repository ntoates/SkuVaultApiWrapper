using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetLocations
{
	public class GetLocationsResponse : BaseResponseWithSvDetailsModel
	{
		public List<Location> Items { get; set; }
	}
}
