using SkuVaultApiWrapper.Models.GetAvailableQuantities;
using SkuVaultApiWrapper.Models.GetBrands;
using SkuVaultApiWrapper.Models.GetIntegrations;
using SkuVaultApiWrapper.Models.GetKits;
using SkuVaultApiWrapper.Models.GetLocations;
using SkuVaultApiWrapper.Models.GetProduct;
using SkuVaultApiWrapper.Models.GetProducts;
using SkuVaultApiWrapper.Models.GetPurchaseOrders;
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

		public static async Task<GetBrandsResponse> GetBrands(this SkuVaultApiClient apiClient, GetBrandsRequest request)
		{
			return await PostRequest.PostAsync<GetBrandsResponse>(apiClient, request, SkuVaultEndpoints.getBrands);
		}

		public static async Task<GetLocationsResponse> GetLocations(this SkuVaultApiClient apiClient, GetLocationsRequest request)
		{
			return await PostRequest.PostAsync<GetLocationsResponse>(apiClient, request, SkuVaultEndpoints.getLocations);
		}

		public static async Task<GetKitsResponse> GetKits(this SkuVaultApiClient apiClient, GetKitsRequest request)
		{
			return await PostRequest.PostAsync<GetKitsResponse>(apiClient, request, SkuVaultEndpoints.getKits);
		}

		public static async Task<GetProductResponse> GetProduct(this SkuVaultApiClient apiClient, GetProductRequest request)
		{
			return await PostRequest.PostAsync<GetProductResponse>(apiClient, request, SkuVaultEndpoints.getProduct);
		}

		public static async Task<GetProductsResponse> GetProducts(this SkuVaultApiClient apiClient, GetProductsRequest request)
		{
			return await PostRequest.PostAsync<GetProductsResponse>(apiClient, request, SkuVaultEndpoints.getProducts);
		}

		public static async Task<GetPurchaseOrdersResponse> GetPurchaseOrders(this SkuVaultApiClient apiClient, GetPurchaseOrdersRequest request)
		{
			return await PostRequest.PostAsync<GetPurchaseOrdersResponse>(apiClient, request, SkuVaultEndpoints.getPOs);
		}

		public static async Task<GetAvailableQuantitiesResponse> GetAvailableQuantities(this SkuVaultApiClient apiClient, GetAvailableQuantitiesRequest request)
		{
			return await PostRequest.PostAsync<GetAvailableQuantitiesResponse>(apiClient, request, SkuVaultEndpoints.getAvailableQuantities);
		}
	}
}
