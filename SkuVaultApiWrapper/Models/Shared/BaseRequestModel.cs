namespace SkuVaultApiWrapper.Models.Shared
{
	public class BaseRequestModel
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
		internal bool IsMissingTokens => string.IsNullOrWhiteSpace(TenantToken) || string.IsNullOrWhiteSpace(UserToken);
	}
}
