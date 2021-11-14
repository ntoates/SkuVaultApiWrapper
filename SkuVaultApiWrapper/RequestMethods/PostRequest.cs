using Newtonsoft.Json;
using Polly;
using SkuVaultApiWrapper.Models.Shared;
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

		internal static async Task<T> Post<T>(SkuVaultAccount skuVaultAccount, BaseRequestModel request, string endpoint) where T : BaseResponseModel
		{

			// if request is missing tokens, add them from SkuVaultAccount
			if(request.IsMissingTokens && endpoint != "api/gettokens")
			{
				if(skuVaultAccount.IsMissingTokens)
				{
					throw new Exception("NO TOKENS FOUND THIS SHOULD NOT BE POSSIBLE");
				}
				request.TenantToken = skuVaultAccount.TenantToken;
				request.UserToken = skuVaultAccount.UserToken;
			}

			string serializedRequestBody = JsonConvert.SerializeObject(request);

			// Use Polly to retry the call if throttled
			var response = await Policy
				.HandleResult<HttpResponseMessage>(r => r.StatusCode == (HttpStatusCode)429)
				.WaitAndRetryAsync(NumberOfRetrys, i => pauseBetweenFailures, (result, timeSpan, retryCount, context) =>
				{
					// TODO: Remove: Debugigng purposes only
					Console.WriteLine($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount} of {NumberOfRetrys}.");
				})
				.ExecuteAsync(async  () => {
					// TODO: This should be a helper function that also set the pauseBetweenFailures to be whatever time SkuVault returns
					var responseMessage = await skuVaultAccount.HttpClient.PostAsync(endpoint, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));
					return responseMessage;
				}
			);

			// Setup and Return Response Content
			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<T>(responseContent);
			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;
			return decodedResponseContent;

		}
	}
}
