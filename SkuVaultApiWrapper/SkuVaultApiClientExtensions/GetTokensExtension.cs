using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.SkuVaultApiClientExtensions
{
	/// <summary>
	/// Internal API for getting tokens from provided user email and user password. TODO: Remove this. Not needed for public client use.
	/// </summary>
	internal static class GetTokensExtension
	{
		internal static async Task<GetTokensResponse> GetTokensForUserAsync(this SkuVaultApiClient apiClient, GetTokensRequest request)
		{
			return await PostRequest.PostAsync<GetTokensResponse>(apiClient, request, SkuVaultEndpoints.getTokens);
		}
	}
}
