using Microsoft.Extensions.Options;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SkuVaultApiWrapper
{
	public class SkuVaultApiClient : ISkuVaultApiClient
	{
		internal HttpClient _httpClient;
		internal SkuVaultApiClientConfig _apiClientConfig;
		private TokenClient _tokensClient;

		/// <summary>
		/// Constructor for use with injection (View ExampleConsoleApp to see pattern in use)
		/// </summary>
		public SkuVaultApiClient(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
		{
			ValidateOptions(httpClient, config.Value);

			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://app.skuvault.com/");
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (config.Value.TokensAreNotEmpty)
			{
				_apiClientConfig = config.Value;
				return;
			}

			// Attempt to get tokens from user credentials if provided TODO: MOVE TO DIFFERENT CLASS
			_tokensClient = new TokenClient();
			GetTokensResponse getTokensResponse = _tokensClient.GetTokensOrThrow(config.Value.UserEmail, config.Value.UserPassword, httpClient).GetAwaiter().GetResult();

			_apiClientConfig = new SkuVaultApiClientConfig
			(
				getTokensResponse.TenantToken,
				getTokensResponse.UserToken,
				config.Value.UserEmail,
				config.Value.UserPassword
			);
		}

		private void ValidateOptions(HttpClient httpClient, SkuVaultApiClientConfig config)
		{
			var errors = new Errors();
			if (httpClient == null)
				errors.AddError("HttpClient can not be null.");

			if (!config.TokensAreNotEmpty && !config.CredentialsAreNotEmpty)
				errors.AddError("Either Tokens or Credentials must not be null or empty.");

			if (errors.ErrorsExist)
				throw new ArgumentException(errors.GenerateErrorString());
		}
	}
}
