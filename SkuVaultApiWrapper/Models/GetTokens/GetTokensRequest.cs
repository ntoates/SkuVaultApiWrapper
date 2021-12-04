namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetTokensRequest : BaseRequestModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
