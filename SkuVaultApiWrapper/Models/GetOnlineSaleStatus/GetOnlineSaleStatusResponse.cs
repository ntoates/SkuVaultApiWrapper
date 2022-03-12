using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetOnlineSaleStatus
{
	public class GetOnlineSaleStatusResponse : BaseResponseModel
	{
		public List<OnlineSale> Sales { get; set; }
	}
}
