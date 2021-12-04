using SkuVaultApiWrapper.Models.GetIntegrations;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Extensions
{
	public static class SkuVaultApiClientExtensions
	{
		public static async Task<GetWarehousesResponse> GetWarehouses(this SkuVaultApiClient apiClient, GetWarehouseRequest request)
		{
			return await PostRequest.PostAsync<GetWarehousesResponse>(apiClient, request, SkuVaultEndpoints.getWarehouses);
		}

		public static async Task<GetExternalWarehousesResponse> GetExternalWarehouses(this SkuVaultApiClient apiClient, GetExternalWarehousesRequest request)
		{
			return await PostRequest.PostAsync<GetExternalWarehousesResponse>(apiClient, request, SkuVaultEndpoints.getExternalWarehouses);
		}

		public static async Task<GetIntegrationsResponse> GetIntegrations(this SkuVaultApiClient apiClient, GetIntegrationsRequest request)
		{
			return await PostRequest.PostAsync<GetIntegrationsResponse>(apiClient, request, SkuVaultEndpoints.getIntegrations);
		}

		public static async Task<GetClassificationsResponse> GetClassifications(this SkuVaultApiClient apiClient, GetClassificationsRequest request)
		{
			return await PostRequest.PostAsync<GetClassificationsResponse>(apiClient, request, SkuVaultEndpoints.getClassifications);
		}
	}
}
