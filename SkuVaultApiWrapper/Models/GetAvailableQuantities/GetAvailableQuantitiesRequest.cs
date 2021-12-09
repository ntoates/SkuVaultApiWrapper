using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetAvailableQuantities
{
	public class GetAvailableQuantitiesRequest : BasePagedRequestModel
	{
		public string ModifiedAfterDateTimeUtc { get; set; }
		public string ModifiedBeforeDateTimeUtc { get; set; }
		public int PageSize { get; set; }
		public bool ExpandAlternateSkus { get; set; }
	}
}
