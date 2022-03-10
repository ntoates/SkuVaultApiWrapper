namespace SkuVaultApiWrapper.Models
{
	public abstract class BaseRequestModel
	{
		public abstract string Endpoint();
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
		internal bool IsMissingTokens => string.IsNullOrWhiteSpace(TenantToken) || string.IsNullOrWhiteSpace(UserToken);
	}
}
