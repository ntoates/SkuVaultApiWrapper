using NUnit.Framework;
using SkuVaultApiWrapper.Endpoints;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SkuVaultApiWrapperTest.Endpoints
{
	[TestFixture]
	public class GetWarehousesTests : BaseTestClass
	{
		[Test]
		public async Task GetSinglePage_ValidRequest_ReturnsExpectedObject()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserTokens();
			var getWarehousesRequest = new GetWarehouseRequest{ PageNumber = 0 };

			// Act
			GetWarehouseResponse response = await getWarehousesRequest.GetSinglePage(svAccount);
			foreach(var warehouse in response.Warehouses)
			{
				Console.WriteLine($"Warehouse Id: {warehouse.Id} - Warehouse Code: {warehouse.Code}");
			}

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsTrue(response.Warehouses.Count > 0);

		}
	}
}
