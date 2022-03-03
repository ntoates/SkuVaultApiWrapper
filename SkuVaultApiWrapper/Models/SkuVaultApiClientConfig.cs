﻿namespace SkuVaultApiWrapper.Models
{
	public class SkuVaultApiClientConfig
	{
		public string TenantToken { get; set; }
		public string UserToken { get; set; }
		public string UserEmail { get; set; }
		public string UserPassword { get; set; }
		internal bool TokensAreNotEmpty => !string.IsNullOrWhiteSpace(TenantToken) && !string.IsNullOrWhiteSpace(UserToken);
		internal bool CredentialsAreNotEmpty => !string.IsNullOrWhiteSpace(UserEmail) && !string.IsNullOrWhiteSpace(UserPassword);

		public SkuVaultApiClientConfig()
		{
		}

		public SkuVaultApiClientConfig(string tenantToken, string userToken, string userEmail, string userPassword)
		{
			TenantToken = tenantToken;
			UserToken = userToken;
			UserEmail = userEmail;
			UserPassword = userPassword;
		}
	}
}
