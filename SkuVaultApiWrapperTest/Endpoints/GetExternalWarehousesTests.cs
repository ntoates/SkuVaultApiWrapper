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
	public class GetExternalWarehousesTests : BaseTestClass
	{
		[Test]
		public async Task GetSinglePage_ValidRequest_ReturnsExpectedObject()
		{

			// Arrange
			var svAccount = this.SkuVaultAccountFromUserCreds();
			var getExternalWarehousesRequest = new GetExternalWarehousesRequest();

			// Act
			GetExternalWarehousesResponse response = await getExternalWarehousesRequest.GetSinglePage(svAccount);
			foreach (var warehouse in response.Warehouses)
			{
				Console.WriteLine($"Warehouse Id: {warehouse.Id} - Warehouse Code: {warehouse.Code} - Warehouse Name: {warehouse.Name}");
			}

			// Assert
			Assert.AreEqual(HttpStatusCode.OK, response.ResponseStatusCode);
			Assert.IsTrue(response.Warehouses.Count > 0);
		}
	}
}
