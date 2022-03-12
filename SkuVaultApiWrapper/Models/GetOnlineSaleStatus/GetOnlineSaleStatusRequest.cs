using SkuVaultApiWrapper.Models.Shared;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetOnlineSaleStatus
{
	public class GetOnlineSaleStatusRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getOnlineSaleStatus;
		public List<string> OrderIds { get; set; }

	}
}
