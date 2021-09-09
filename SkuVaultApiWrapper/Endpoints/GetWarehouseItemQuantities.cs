using SkuVaultApiWrapper.Models.Inventory;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.RequestMethods;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Endpoints
{
	/// <summary>
	/// https://dev.skuvault.com/reference#getwarehouseitemquantities
	/// </summary>
	public class GetWarehouseItemQuantitiesRequest : BaseRequestModel
	{
		public DateTime ModifiedBeforeDateTimeUtc { get; set; }
		public DateTime ModifiedAfterDateTimeUtc { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string WarehouseId { get; set; } // Required

		public async Task<GetWarehouseItemQuantitiesResponse> GetSinglePage(SkuVaultAccount skuVaultAccount)
		{
			GetWarehouseItemQuantitiesResponse response = await PostRequest.Post<GetWarehouseItemQuantitiesResponse>(skuVaultAccount, this, SkuVaultEndpoints.getWarehouseItemQuantities);
			return response;
		}
	}

	public class GetWarehouseItemQuantitiesResponse : BaseResponseModel
	{
		public List<SkuQuantityRecord> ItemQuantities { get; set; }
	}
}
