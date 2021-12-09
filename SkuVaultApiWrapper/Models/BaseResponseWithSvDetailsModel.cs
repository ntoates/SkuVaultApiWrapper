using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models
{
	public class BaseResponseWithSvDetailsModel : BaseResponseModel
	{
		public string Status { get; set; } = "Unknown";
		public List<string> Errors { get; set; }
	}
}
