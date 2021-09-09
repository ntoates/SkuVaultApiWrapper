using NUnit.Framework;
using SkuVaultApiWrapper.Endpoints;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SkuVaultApiWrapperTest.Endpoints
{
	[TestFixture]
	class GetWarehouseItemQuantitiesTests : BaseTestClass
	{
		[Test]
		public async Task GetSinglePage_ValidRequestWithoutDateFilter_ReturnsExpectedObject()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantitiesRequest
			{
				PageNumber = 0,
				PageSize = 1000,
				WarehouseId = "143457"
			};

			// Act
			GetWarehouseItemQuantitiesResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);

			foreach (var item in response.ItemQuantities)
			{
				Console.WriteLine($"Total Quantity: {item.Quantity} - Product Sku: {item.Sku}");
			}
			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsNotEmpty(response.ItemQuantities);
		}

		/// <summary>
		/// TODO: COMPLETE ONCE ABLE TO ADD/REMOVE ITEM INVENTORY
		/// </summary>
		[Test]
		public async Task GetSinglePage_ValidRequestWithDateFilter_ReturnsProductWithinTimeSpan()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantitiesRequest
			{
				PageNumber = 0,
				PageSize = 1000,
				WarehouseId = "143457",
				ModifiedAfterDateTimeUtc = DateTime.Now.AddDays(-10),
				ModifiedBeforeDateTimeUtc = DateTime.Now
			};

			// Act
			GetWarehouseItemQuantitiesResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);

			foreach (var item in response.ItemQuantities)
			{
				Console.WriteLine($"Total Quantity: {item.Quantity} - Product Sku: {item.Sku}");
			}
			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsNotEmpty(response.ItemQuantities);
		}

		/// <summary>
		/// TODO: COMPLETE ONCE ABLE TO ADD/REMOVE ITEM INVENTORY
		/// </summary>
		[Test]
		public async Task GetSinglePage_ValidRequestWithDateFilter_DoesNotReturnProductOutsideOfTimeSpan()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantitiesRequest
			{
				PageNumber = 0,
				PageSize = 1000,
				WarehouseId = "143457",
				ModifiedAfterDateTimeUtc = DateTime.Now.AddDays(-10),
				ModifiedBeforeDateTimeUtc = DateTime.Now
			};

			// Act
			GetWarehouseItemQuantitiesResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);

			foreach (var item in response.ItemQuantities)
			{
				Console.WriteLine($"Total Quantity: {item.Quantity} - Product Sku: {item.Sku}");
			}
			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsNotEmpty(response.ItemQuantities);
		}
	}
}
