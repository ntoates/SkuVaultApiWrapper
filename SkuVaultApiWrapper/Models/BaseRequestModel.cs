namespace SkuVaultApiWrapper.Models
{
	public abstract class BaseRequestModel
	{
		public abstract string Endpoint();
		public string TenantToken { get; set; }
		public string UserToken { get; set; }

		public void SetTenantToken(string tenantToken)
		{
			TenantToken = tenantToken;
		}
		public void SetUserToken(string userToken)
		{
			UserToken = userToken;
		}
	}
}
