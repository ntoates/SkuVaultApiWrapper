using Newtonsoft.Json;
using SkuVaultApiWrapper.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.RequestMethods
{
	internal class PostRequest
	{
		internal static async Task<T> PostAsync<T>(SkuVaultApiClient apiClient, BaseRequestModel request) where T : BaseResponseModel
		{
			request.SetTenantToken(apiClient.ApiClientConfig.TenantToken);
			request.SetUserToken(apiClient.ApiClientConfig.UserToken);

			string serializedRequestBody = JsonConvert.SerializeObject(request);

			var response = await apiClient.HttpClient.PostAsync(request.Endpoint(), new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));

			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<T>(responseContent);

			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;

			return decodedResponseContent;
		}
	}
}
