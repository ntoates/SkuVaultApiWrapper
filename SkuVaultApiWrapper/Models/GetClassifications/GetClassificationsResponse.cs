using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetClassificationsResponse : BaseResponseModel
	{
		public List<Classification> Classifications { get; set; }
	}
}
