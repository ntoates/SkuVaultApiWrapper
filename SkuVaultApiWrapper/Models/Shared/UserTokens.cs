namespace SkuVaultApiWrapper.Models.Shared
{
	public class UserTokens
	{
		public string UserToken { get; set; }
		public string TenantToken { get; set; }
		internal bool AreValid => !string.IsNullOrWhiteSpace(TenantToken) && !string.IsNullOrWhiteSpace(UserToken);
	}
}
