using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models
{
	public class BasePagedRequestModel :BaseRequestModel
	{
		public int PageNumber { get; set; }
	}
}
