namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetTokensResponse : BaseResponseModel
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
	}
}
