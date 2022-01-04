namespace SkuVaultApiWrapper.Models
{
	public class BaseRequestModel
	{
		internal string TenantToken { get; set; }
		internal string UserToken { get; set; }
		internal bool IsMissingTokens => string.IsNullOrWhiteSpace(TenantToken) || string.IsNullOrWhiteSpace(UserToken);
	}
}
