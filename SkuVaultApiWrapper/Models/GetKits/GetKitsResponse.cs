using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetKits
{
	public class GetKitsResponse:  BaseResponseWithSvDetailsModel
	{
		public List<Kit> Kits { get; set; }
	}
}
