namespace SkuVaultApiWrapper.Models
{
	public class SkuVaultApiClientConfig
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }

		public SkuVaultApiClientConfig()
		{
			
		}

		public SkuVaultApiClientConfig(string tenantToken, string userToken)
		{
			this.TenantToken = tenantToken;
			this.UserToken = userToken;
		}
	}
}
