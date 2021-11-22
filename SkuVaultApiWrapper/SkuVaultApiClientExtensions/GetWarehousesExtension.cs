using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.SkuVaultApiClientExtensions
{
	public static class GetWarehousesExtension
	{
		public static async Task<GetWarehouseResponse> GetWarehouses(this SkuVaultApiClient apiClient, GetWarehouseRequest request)
		{
			return await PostRequest.PostAsync<GetWarehouseResponse>(apiClient, request, SkuVaultEndpoints.getWarehouses);
		}
	}
}
