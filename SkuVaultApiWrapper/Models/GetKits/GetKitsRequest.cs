using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetKits
{
	public class GetKitsRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getKits;
		public string AvailableQuantityModifiedAfterDateTimeUtc { get; set; }
		public string AvailableQuantityModifiedBeforeDateTimeUtc { get; set; }
		public bool GetAvailableQuantity { get; set; }
		public bool IncludeKitCost { get; set; }
		public string ModifiedAfterDateTimeUtc { get; set; }
		public string ModifiedBeforeDateTimeUtc { get; set; }
	}
}
