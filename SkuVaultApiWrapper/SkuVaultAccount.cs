using SkuVaultApiWrapper.Endpoints;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.RequestMethods;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SkuVaultApiWrapper
{
	public class SkuVaultAccount
	{
		internal HttpClient HttpClient { get; set; }
		public string TenantToken { get; internal set; }
		public string UserToken { get; internal set; }
		public bool IsMissingTokens => TenantToken == null && UserToken == null;

		public SkuVaultAccount()
		{
			// Get Skuvault HttpClient
			HttpClient = GetSkuVaultHttpClient();
		}


		public SkuVaultAccount(UserTokens userTokens)
		{
			// Validate userTokens
			if(!userTokens.AreValid)
			{
				throw new Exception("Invalid UserTokens Provided for SkuVaultAccount");
			}

			// Get Skuvault HttpClient
			HttpClient = GetSkuVaultHttpClient();

			// Validate Tokens are correct
			GetExternalWarehousesRequest externalWarehouseRequest = new GetExternalWarehousesRequest
			{
				PageNumber = 0,
				TenantToken = userTokens.TenantToken,
				UserToken = userTokens.UserToken
			};
			GetExternalWarehousesResponse getExternalWarehousesReponse = externalWarehouseRequest.GetSinglePage(this).GetAwaiter().GetResult();

			if (getExternalWarehousesReponse.ResponseStatusCode == HttpStatusCode.OK)
			{
				// Set Tokens for Account
				TenantToken = userTokens.TenantToken;
				UserToken = userTokens.UserToken;
			}
			else
			{
				// TODO: Better Exceptions
				throw new Exception("Unauthorized Tokens.");
			}
		}

		public SkuVaultAccount(UserCredentials userCredentials)
		{
			// Validate userCredentials
			if (!userCredentials.AreValid)
			{
				throw new Exception("Invalid UserCredentials Provided for SkuVaultAccount");
			}

			// Get Skuvault HttpClient
			HttpClient = GetSkuVaultHttpClient();

			// Attempt to get tokens from /getTokens Endpoint
			var getTokensRequest = new GetTokensRequest
			{
				Email = userCredentials.Email,
				Password = userCredentials.Password
			};
			GetTokensResponse response = getTokensRequest.GetSinglePage(this).GetAwaiter().GetResult();


			if (response.TenantToken != null && response.ResponseStatusCode == HttpStatusCode.OK)
			{
				// Set Tokens for Account
				TenantToken = response.TenantToken;
				UserToken = response.UserToken;
			}
			else if (response.TenantToken == null && response.ResponseStatusCode == HttpStatusCode.OK)
			{
				// TODO: Better Exceptions
				throw new Exception("Unauthorized Credentials.");
			}
			else
			{
				// TODO: Better Exceptions
				throw new Exception("Unable to get tokens for SkuVault account.");
			}
		}
		public HttpClient GetSkuVaultHttpClient()
		{
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.BaseAddress = new Uri("https://app.skuvault.com/"); // TODO: Allow setting of different envrionments?
			return httpClient;
		}
	}
}
