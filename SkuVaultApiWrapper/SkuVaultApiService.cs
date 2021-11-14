using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SkuVaultApiWrapper
{
	public class SkuVaultApiService
	{
		internal HttpClient HttpClient { get; set; }
		public string TenantToken { get; internal set; }
		public string UserToken { get; internal set; }
		public bool IsMissingTokens => TenantToken == null && UserToken == null;

		SkuVaultApiService(string tenantToken, string userToken, HttpClient httpClient)
		{
			TenantToken = tenantToken;
			UserToken = userToken;
			HttpClient = httpClient;
		}
	}
}
