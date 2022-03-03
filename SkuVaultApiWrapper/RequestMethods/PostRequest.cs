using Newtonsoft.Json;
using Polly;
using SkuVaultApiWrapper.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.RequestMethods
{
	internal class PostRequest
	{
		internal static readonly int NumberOfRetrys = 2;
		internal static readonly TimeSpan pauseBetweenFailures = TimeSpan.FromSeconds(60);

		internal static async Task<T> PostAsync<T>(SkuVaultApiClient apiClient, BaseRequestModel request, string endpoint) where T : BaseResponseModel
		{
			// Add tokens to request body. Required for all SkuVault API endpoints.
			request.TenantToken = apiClient._apiClientConfig.TenantToken;
			request.UserToken = apiClient._apiClientConfig.UserToken;
			string serializedRequestBody = JsonConvert.SerializeObject(request);

			var response = await apiClient._httpClient.PostAsync(endpoint, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));

			// Setup and Return Response Content
			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<T>(responseContent);

			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;

			return decodedResponseContent;
		}
	}
}
