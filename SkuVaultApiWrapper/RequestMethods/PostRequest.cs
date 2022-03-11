using Newtonsoft.Json;
using SkuVaultApiWrapper.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.RequestMethods
{
	internal class PostRequest
	{
		/// <summary>
		/// Returns a parsed 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="apiClient"></param>
		/// <param name="request"></param>
		/// <param name="endpoint"></param>
		/// <returns></returns>
		internal static async Task<T> PostAsync<T>(SkuVaultApiClient apiClient, BaseRequestModel request, string endpoint) where T : BaseResponseModel
		{
			// Add tokens to request body. Required for all SkuVault API endpoints.
			request.SetTenantToken(apiClient.ApiClientConfig.TenantToken);
			request.SetUserToken(apiClient.ApiClientConfig.UserToken);

			string serializedRequestBody = JsonConvert.SerializeObject(request);

			var response = await apiClient.HttpClient.PostAsync(endpoint, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));

			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<T>(responseContent);

			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;

			return decodedResponseContent;
		}

		/// <summary>
		/// Returns an HttpResponse Message for response parsing
		/// </summary>
		internal static async Task<HttpResponseMessage> PostAsync(SkuVaultApiClient apiClient, BaseRequestModel request, string endpoint)
		{
			request.SetTenantToken(apiClient.ApiClientConfig.TenantToken);
			request.SetUserToken(apiClient.ApiClientConfig.UserToken);

			string serializedRequestBody = JsonConvert.SerializeObject(request);

			return await apiClient.HttpClient.PostAsync(endpoint, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));
		}
	}
}
