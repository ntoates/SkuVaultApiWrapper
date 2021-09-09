using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.RequestMethods;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Endpoints
{
	public class GetTokensRequest : BaseRequestModel
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public async Task<GetTokensResponse> GetSinglePage(SkuVaultAccount skuVaultAccount)
		{
			GetTokensResponse response = await PostRequest.Post<GetTokensResponse>(skuVaultAccount, this, SkuVaultEndpoints.getTokens);
			return response;
		}
	}

	public class GetTokensResponse : BaseResponseModel
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
	}
}
