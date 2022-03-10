using Newtonsoft.Json;
using SkuVaultApiWrapper.Models.Shared;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper.Services
{
	internal class TokenService
	{
		/// <summary>
		/// Default Constructor
		/// </summary>
		public TokenService()
		{
		}

		/// <summary>
		/// Attempts to get Tokens from SkuVault using userEmail/Password.
		/// </summary>
		/// <returns>A Task of GetTokensResponse</returns>
		/// <exception cref="UnableToGetTokensException">Thrown if the response does not contain tokens</exception>
		internal async Task<GetTokensResponse> GetTokensFromUserCredentials(string userEmail, string userPassword, HttpClient httpClient)
		{
			var getTokensRequest = new GetTokensRequest
			{
				Email = userEmail,
				Password = userPassword
			};
			string serializedRequestBody = JsonConvert.SerializeObject(getTokensRequest);

			var response = await httpClient.PostAsync(SkuVaultEndpoints.getTokens, new StringContent(serializedRequestBody, Encoding.UTF8, "application/json"));
			var responseContent = await response.Content.ReadAsStringAsync();
			var decodedResponseContent = JsonConvert.DeserializeObject<GetTokensResponse>(responseContent);
			decodedResponseContent.ResponseStatusCode = response.StatusCode;
			decodedResponseContent.ResponseReasonPhrase = response.ReasonPhrase;

			if (TokensResponseWasValid(decodedResponseContent))
				return decodedResponseContent;

			throw new UnableToGetTokensException("Unable to get Tokens from User Credentials.");
		}

		/// <summary>
		/// Checks the content in the response. This endpoint can return an OK status code with null content.
		/// </summary>
		/// <returns>True if the tokens response was valid</returns>
		private bool TokensResponseWasValid(GetTokensResponse getTokensResponse)
		{
			return getTokensResponse.ResponseStatusCode == System.Net.HttpStatusCode.OK &&
				getTokensResponse.TenantToken != null &&
				getTokensResponse.UserToken != null;
		}
	}
}
