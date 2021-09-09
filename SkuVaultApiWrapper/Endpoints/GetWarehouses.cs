using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SvWarehouses;
using SkuVaultApiWrapper.RequestMethods;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Endpoints
{
	public class GetWarehouseRequest : BaseRequestModel
	{
		public int PageNumber { get; set; }

		public async Task<GetWarehouseResponse> GetSinglePage(SkuVaultAccount skuVaultAccount)
		{
			GetWarehouseResponse response = await PostRequest.Post<GetWarehouseResponse>(skuVaultAccount, this, SkuVaultEndpoints.getWarehouses);
			return response;
		}
	}

	public class GetWarehouseResponse : BaseResponseModel
	{
		public List<Warehouse> Warehouses { get; set; }
	}
}
