using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models
{
	public class BaseResponseWithSvDetailsModel : BaseResponseModel
	{
		public string SkuVaultResponseStatus { get; set; }
		public List<string> SkuVaultErrors { get; set; }
	}
}
