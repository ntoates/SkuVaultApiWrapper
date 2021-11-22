using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper
{
	public class SkuVaultApiClient : ISkuVaultApiClient
	{
		internal HttpClient _httpClient;
		internal SkuVaultApiClientConfig _apiClientConfig;

		/// <summary>
		/// Constructor for use with injection (View ExampleConsoleApp to see pattern in use)
		/// </summary>
		public SkuVaultApiClient(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
		{
			if (httpClient == null)
			{
				throw new ArgumentException("HttpClient can not be null.");
			}

			if (!config.Value.TokensAreValid && !config.Value.CredentialsAreValid)
			{
				throw new ArgumentException("Either Tokens or Credentials must not be null or empty.");
			}

			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://app.skuvault.com/");
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (config.Value.TokensAreValid || !config.Value.CredentialsAreValid)
			{
				_apiClientConfig = config.Value;
				return;
			}

			// Attempt to get tokens from user credentials if provided
			GetTokensResponse getTokensResponse = this.GetTokens(config.Value.UserEmail, config.Value.UserPassword).GetAwaiter().GetResult();
			if ( TokensResponseWasValid(getTokensResponse))
			{
				_apiClientConfig = new SkuVaultApiClientConfig
				(
					getTokensResponse.TenantToken,
					getTokensResponse.UserToken,
					config.Value.UserEmail,
					config.Value.UserPassword
				);
			}
			else
			{
				throw new UnableToGetTokensException("Unable to get Tokens from User Credentials.");
			}

		}

		private bool TokensResponseWasValid(GetTokensResponse getTokensResponse)
		{
			return getTokensResponse.ResponseStatusCode == System.Net.HttpStatusCode.OK && 
				getTokensResponse.TenantToken != null && 
				getTokensResponse.UserToken != null;
		}

		private async Task<GetTokensResponse> GetTokens(string userEmail, string userPassword)
		{
			// Attempt to get tokens from /getTokens Endpoint
			var getTokensRequest = new GetTokensRequest
			{
				Email = userEmail,
				Password = userPassword
			};
			string serializedRequestBody = JsonConvert.SerializeObject(getTokensRequest);

			var response = await _httpClient.PostAsync(SkuVaultEndpoints.getTokens, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));
			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<GetTokensResponse>(responseContent);
			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;
			return decodedResponseContent;
		}
	}
}
