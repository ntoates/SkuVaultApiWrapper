using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetClassifications
{
	public class GetClassificationsResponse : BaseResponseModel
	{
		public List<Classification> Classifications { get; set; }
	}
}
