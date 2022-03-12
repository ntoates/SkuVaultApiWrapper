using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.GetTokens
{
	public class GetTokensRequest : BaseRequestModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public override string Endpoint() => SkuVaultEndpoints.getTokens;
	}
}
