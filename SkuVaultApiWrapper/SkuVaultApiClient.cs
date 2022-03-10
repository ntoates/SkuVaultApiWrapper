using Microsoft.Extensions.Options;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.RequestMethods;
using SkuVaultApiWrapper.Services;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper
{
	public class SkuVaultApiClient : ISkuVaultApiClient
	{
		internal HttpClient _httpClient;
		internal SkuVaultApiClientConfig _apiClientConfig;
		private TokenService _tokenService;

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
			_tokenService = new TokenService();
			GetTokensResponse getTokensResponse = _tokenService.GetTokensFromUserCredentials(config.Value.UserEmail, config.Value.UserPassword, httpClient).GetAwaiter().GetResult();

			_apiClientConfig = new SkuVaultApiClientConfig
			(
				getTokensResponse.TenantToken,
				getTokensResponse.UserToken,
				config.Value.UserEmail,
				config.Value.UserPassword
			);
		}

		/// <summary>
		/// Optional method of sending a specific request/response object.
		/// </summary>
		/// <typeparam name="T">A Request model inheriting from the BaseRequestModel</typeparam>
		/// <typeparam name="D">A Response model inheriting from the BaseResponseModel</typeparam>
		public async Task<D> Post<T, D>(T request) where T : BaseRequestModel where D : BaseResponseModel
		{
			return await PostRequest.PostAsync<D>(this, request, request.Endpoint());
		}

		/// <summary>
		/// Optional method of sending a specific request object while receiving a json string response back.
		/// This is useful as the response objects can change from SkuVault.
		/// </summary>
		/// <typeparam name="T">A Request model inheriting from the BaseRequestModel</typeparam>
		public async Task<string> Post<T>(T request) where T : BaseRequestModel
		{
			return await PostRequest.PostAsync(this, request, request.Endpoint());
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
