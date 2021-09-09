using NUnit.Framework;
using SkuVaultApiWrapper.Endpoints;
using SkuVaultApiWrapper.RequestMethods;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SkuVaultApiWrapperTest.Endpoints
{
	[TestFixture]
	class GetWarehouseItemQuantityTests : BaseTestClass
	{
		[Test]
		public async Task GetSinglePage_ValidRequest_ReturnsExpectedObject()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantityRequest
			{
				Sku = "C0009",
				WarehouseId = 143457
			};

			// Act
			GetWarehouseItemQuantityResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);
			Console.WriteLine($"Total Quantity On Hand: {response.TotalQuantityOnHand} - Product Sku: {getWarehouseItemQuantityRequest.Sku} - Warehouse Id: {getWarehouseItemQuantityRequest.WarehouseId}");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsEmpty(response.Errors);
			Assert.IsTrue(response.TotalQuantityOnHand > 0);
		}

		[Test]
		public async Task GetSinglePage_WarehouseDoesNotExist_ReturnsSuccessWithNoQuantity()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantityRequest
			{
				Sku = "C0009",
				WarehouseId = 1
			};

			// Act
			GetWarehouseItemQuantityResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);
			Console.WriteLine($"Total Quantity On Hand: {response.TotalQuantityOnHand} - Product Sku: {getWarehouseItemQuantityRequest.Sku} - Warehouse Id: {getWarehouseItemQuantityRequest.WarehouseId}");

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsEmpty(response.Errors);
			Assert.AreEqual(0, response.TotalQuantityOnHand);
		}
	}
}
