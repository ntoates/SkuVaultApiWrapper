using NUnit.Framework;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Endpoints;
using SkuVaultApiWrapper.RequestMethods;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SkuVaultApiWrapperTest.RequestMethods
{
	[TestFixture]
	class PostRequestTest : BaseTestClass
	{
		[Test]
		public void SimplePost_ReturnsExpectedData()
		{
			// Arrange
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.BaseAddress = new Uri("https://app.skuvault.com/");

			GetTokensRequest tokensRequest = new GetTokensRequest { Email = GoodUserCreds.Email, Password = GoodUserCreds.Password };

			// Act
			GetTokensResponse response = PostRequest.Post<GetTokensResponse>(SkuVaultAccountFromUserTokens(), tokensRequest, "api/gettokens").GetAwaiter().GetResult();

			// Assert
			Assert.AreEqual(GoodUserTokens.TenantToken, response.TenantToken);
			Assert.AreEqual(GoodUserTokens.UserToken, response.UserToken);
		}

		[Test]
		public async Task SimplePost_WhenThrottled_WaitsSuccessfully()
		{
			// Arrange
			var startTime = DateTime.Now;
			GetWarehouseRequest warehouseRequest = new GetWarehouseRequest
			{
				PageNumber = 0,
			};
			// Documentation says throttling on /getWarehouses is "Severe" or 1 per minute, but sometimes allows more.
			await warehouseRequest.GetSinglePage(SkuVaultAccountFromUserTokens());
			await warehouseRequest.GetSinglePage(SkuVaultAccountFromUserTokens());

			// Act
			GetWarehouseResponse getWarehousesReponse = await warehouseRequest.GetSinglePage(SkuVaultAccountFromUserTokens());
			var runTime = DateTime.Now - startTime;

			// Assert
			Assert.GreaterOrEqual(runTime.TotalSeconds, 60); // Fails if test did not have to wait through a throttle.
			Assert.AreEqual(HttpStatusCode.OK, getWarehousesReponse.ResponseStatusCode); 
		}

		[Test]
		public void SimplePost_WhenRequestMissingTokens_UseAccountTokens()
		{
			// Arrange
			GetExternalWarehousesRequest externalWarehouseRequest = new GetExternalWarehousesRequest
			{
				PageNumber = 0,
			};

			// Act
			Action action = () => externalWarehouseRequest.GetSinglePage(SkuVaultAccountFromUserTokens()).GetAwaiter().GetResult();

			// Assert
			Assert.DoesNotThrow(action.Invoke);
		}

		[Test]
		public void SimplePost_WhenRequestHasTokens_UseRequestTokens()
		{
			// Arrange
			GetExternalWarehousesRequest externalWarehouseRequest = new GetExternalWarehousesRequest
			{
				PageNumber = 0,
				TenantToken = GoodUserTokens.TenantToken,
				UserToken = GoodUserTokens.UserToken,

			};
			SkuVaultAccount missingTokenAccount = new SkuVaultAccount();

			// Act
			Action action = () => externalWarehouseRequest.GetSinglePage(missingTokenAccount).GetAwaiter().GetResult();

			// Assert
			Assert.DoesNotThrow(action.Invoke);
		}

		[Test]
		public void SimplePost_WhenNoTokensAvailable_ThrowsException()
		{
			// Arrange
			GetExternalWarehousesRequest externalWarehouseRequest = new GetExternalWarehousesRequest
			{
				PageNumber = 0,
			};
			SkuVaultAccount badAccount = new SkuVaultAccount();

			// Act
			Action action = () => externalWarehouseRequest.GetSinglePage(badAccount).GetAwaiter().GetResult();

			// Assert
			Assert.Throws<Exception>(action.Invoke);
		}
	}
}
