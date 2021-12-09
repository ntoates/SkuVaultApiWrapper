using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetAvailableQuantities
{
	public class GetAvailableQuantitiesResponse : BaseResponseModel
	{
		public List<AvailableQuantitiesItem> Items { get; set; }
	}
}
