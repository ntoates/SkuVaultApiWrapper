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

		/// <summary>
		/// Constructor for use with injection (View ExampleConsoleApp to see pattern in use)
		/// </summary>
		public SkuVaultApiClient(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
		{
			ValidateOptions(httpClient, config);

			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://app.skuvault.com/");
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			if (config.Value.TokensAreValid)
			{
				_apiClientConfig = config.Value;
				return;
			}

			// Attempt to get tokens from user credentials if provided TODO: MOVE TO DIFFERENT CLASS
			var tokensClient = new TokenClient();
			GetTokensResponse getTokensResponse = tokensClient.GetTokensOrThrow(config.Value.UserEmail, config.Value.UserPassword, httpClient).GetAwaiter().GetResult();

			_apiClientConfig = new SkuVaultApiClientConfig
			(
				getTokensResponse.TenantToken,
				getTokensResponse.UserToken,
				config.Value.UserEmail,
				config.Value.UserPassword
			);
		}

		internal void ValidateOptions(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
		{
			var errors = new Errors();
			if (httpClient == null)
			{
				errors.AddError("HttpClient can not be null.");
			}

			if (!config.Value.TokensAreValid && !config.Value.CredentialsAreValid)
			{
				errors.AddError("Either Tokens or Credentials must not be null or empty.");
			}

			if (errors.ErrorsExist)
				throw new ArgumentException(errors.GenerateErrorString());
		}
	}
}
