using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SvWarehouses;
using SkuVaultApiWrapper.RequestMethods;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Endpoints
{
	public class GetExternalWarehousesRequest : BaseRequestModel
	{
		public int PageNumber { get; set; }

		public async Task<GetExternalWarehousesResponse> GetSinglePage(SkuVaultAccount skuVaultAccount)
		{
			GetExternalWarehousesResponse response = await PostRequest.Post<GetExternalWarehousesResponse>(skuVaultAccount, this, SkuVaultEndpoints.getExternalWarehouses);
			return response;
		}
	}

	public class GetExternalWarehousesResponse : BaseResponseModel
	{
		public List<ExternalWarehouse> Warehouses { get; set; }
	}
}
