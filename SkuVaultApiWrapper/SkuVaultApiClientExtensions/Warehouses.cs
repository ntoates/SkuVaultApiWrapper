using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.SkuVaultApiClientExtensions
{
	internal static class Warehouses
	{
		internal static async Task<GetWarehouseResponse> GetTokensForUserAsync(this SkuVaultApiClient apiClient, GetWarehouseRequest request)
		{
			return await PostRequest.PostAsync<GetWarehouseResponse>(apiClient, request, SkuVaultEndpoints.getWarehouses);
		}
	}
}
