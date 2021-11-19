using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.SkuVaultApiClientExtensions
{
    public static class GetTokensExtension
    {
        public static async Task<GetTokensResponse> GetTokensForUser(this SkuVaultApiClient apiClient, GetTokensRequest request)
        {
            return await PostRequest.PostAsync<GetTokensResponse>(apiClient, request, SkuVaultEndpoints.getTokens);
        }
    }
}
