using SkuVaultApiWrapper.Models.GetAvailableQuantities;
using SkuVaultApiWrapper.Models.GetBrands;
using SkuVaultApiWrapper.Models.GetClassifications;
using SkuVaultApiWrapper.Models.GetExternalWarehouses;
using SkuVaultApiWrapper.Models.GetIntegrations;
using SkuVaultApiWrapper.Models.GetKits;
using SkuVaultApiWrapper.Models.GetLocations;
using SkuVaultApiWrapper.Models.GetOnlineSaleStatus;
using SkuVaultApiWrapper.Models.GetProduct;
using SkuVaultApiWrapper.Models.GetProducts;
using SkuVaultApiWrapper.Models.GetPurchaseOrders;
using SkuVaultApiWrapper.Models.GetWarehouses;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SyncOnlineSale;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Extensions
{
	public static class SkuVaultApiClientExtensions
	{
		public static async Task<GetWarehousesResponse> GetWarehouses(this SkuVaultApiClient apiClient, GetWarehousesRequest request)
		{
			return await PostRequest.PostAsync<GetWarehousesResponse>(apiClient, request);
		}

		public static async Task<GetExternalWarehousesResponse> GetExternalWarehouses(this SkuVaultApiClient apiClient, GetExternalWarehousesRequest request)
		{
			return await PostRequest.PostAsync<GetExternalWarehousesResponse>(apiClient, request);
		}

		public static async Task<GetIntegrationsResponse> GetIntegrations(this SkuVaultApiClient apiClient, GetIntegrationsRequest request)
		{
			return await PostRequest.PostAsync<GetIntegrationsResponse>(apiClient, request);
		}

		public static async Task<GetClassificationsResponse> GetClassifications(this SkuVaultApiClient apiClient, GetClassificationsRequest request)
		{
			return await PostRequest.PostAsync<GetClassificationsResponse>(apiClient, request);
		}

		public static async Task<GetBrandsResponse> GetBrands(this SkuVaultApiClient apiClient, GetBrandsRequest request)
		{
			return await PostRequest.PostAsync<GetBrandsResponse>(apiClient, request);
		}

		public static async Task<GetLocationsResponse> GetLocations(this SkuVaultApiClient apiClient, GetLocationsRequest request)
		{
			return await PostRequest.PostAsync<GetLocationsResponse>(apiClient, request);
		}

		public static async Task<GetKitsResponse> GetKits(this SkuVaultApiClient apiClient, GetKitsRequest request)
		{
			return await PostRequest.PostAsync<GetKitsResponse>(apiClient, request);
		}

		public static async Task<GetProductResponse> GetProduct(this SkuVaultApiClient apiClient, GetProductRequest request)
		{
			return await PostRequest.PostAsync<GetProductResponse>(apiClient, request);
		}

		public static async Task<GetProductsResponse> GetProducts(this SkuVaultApiClient apiClient, GetProductsRequest request)
		{
			return await PostRequest.PostAsync<GetProductsResponse>(apiClient, request);
		}

		public static async Task<GetPurchaseOrdersResponse> GetPurchaseOrders(this SkuVaultApiClient apiClient, GetPurchaseOrdersRequest request)
		{
			return await PostRequest.PostAsync<GetPurchaseOrdersResponse>(apiClient, request);
		}

		public static async Task<GetAvailableQuantitiesResponse> GetAvailableQuantities(this SkuVaultApiClient apiClient, GetAvailableQuantitiesRequest request)
		{
			return await PostRequest.PostAsync<GetAvailableQuantitiesResponse>(apiClient, request);
		}

		public static async Task<SyncOnlineSaleResponse> SyncOnlineSale(this SkuVaultApiClient apiClient, SyncOnlineSaleRequest request)
		{
			return await PostRequest.PostAsync<SyncOnlineSaleResponse>(apiClient, request);
		}

		public static async Task<GetOnlineSaleStatusResponse> GetOnlineSaleStatus(this SkuVaultApiClient apiClient, GetOnlineSaleStatusRequest request)
		{
			return await PostRequest.PostAsync<GetOnlineSaleStatusResponse>(apiClient, request);
		}
	}
}
