using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.RequestMethods;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Endpoints
{
	public class GetWarehouseItemQuantityRequest : BaseRequestModel
	{
		public int WarehouseId { get; set; }
		public string Sku { get; set; }

		public async Task<GetWarehouseItemQuantityResponse> GetSinglePage(SkuVaultAccount skuVaultAccount)
		{
			GetWarehouseItemQuantityResponse response = await PostRequest.Post<GetWarehouseItemQuantityResponse>(skuVaultAccount, this, SkuVaultEndpoints.getWarehouseItemQuantity);
			return response;
		}
	}

	public class GetWarehouseItemQuantityResponse : BaseResponseModel
	{
		public List<string> Errors { get; set; }
		public int TotalQuantityOnHand { get; set; }
	}
}
