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
        /// Instantiates an instance of the SkuVaultApiClient.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <example>
        /// // Pulls configuration from appsettings or environment variables. Could also just manually add config here.
        /// services.Configure<SkuVaultApiClientConfig>(_configuration.GetSection(nameof(SkuVaultApiClientConfig)));
        /// 
        /// services.AddHttpClient<ITypedClient, TypedClient>().ConfigureHttpClient((serviceProvider, httpClient) =>
        ///	{
        ///		var clientConfig = serviceProvider.GetRequiredService<ITypedClientConfig>();
        ///		httpClient.BaseAddress = clientConfig.BaseUrl;
        ///		httpClient.Timeout = TimeSpan.FromSeconds(clientConfig.Timeout);
        ///		httpClient.DefaultRequestHeaders.Add("User-Agent", "BlahAgent");
        /// 	httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        /// });
        /// </example>
        public SkuVaultApiClient(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
        {
            if (httpClient == null)
            {
                throw new ArgumentException("HttpClient can not be null.");
            }

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://app.skuvault.com/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!config.Value.TokensAreValid && !config.Value.CredentialsAreValid)
            {
                throw new ArgumentException("Either Tokens or Credentials must not be null or empty.");
            }

            if (!config.Value.TokensAreValid && config.Value.CredentialsAreValid)
            {
                GetTokensResponse getTokensResponse = this.GetTokens(config.Value.UserEmail, config.Value.UserPassword).GetAwaiter().GetResult();
                if (getTokensResponse.ResponseStatusCode == System.Net.HttpStatusCode.OK)
                {
                    _apiClientConfig.TenantToken = getTokensResponse.TenantToken;
                    _apiClientConfig.UserToken = getTokensResponse.UserToken;
                }
                else
                {
                    throw new UnableToGetTokensException("Unable to get Tokens from User Credentials.");
                }
            }
            else
            {
                _apiClientConfig = config.Value;
            }
        }

        private async Task<GetTokensResponse> GetTokens(string userEmail, string userPassword)
        {
            // Get Skuvault HttpClient

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
