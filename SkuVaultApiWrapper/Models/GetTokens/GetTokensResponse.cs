namespace SkuVaultApiWrapper.Models.GetTokens
{
	public class GetTokensResponse : BaseResponseModel
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
	}
}
