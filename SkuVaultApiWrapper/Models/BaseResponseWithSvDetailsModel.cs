using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models
{
	public class BaseResponseWithSvDetailsModel<ListObject> : BaseResponseModel
	{
		public string Status { get; set; } = "Unknown";
		public List<ListObject> Errors { get; set; }
	}
}
