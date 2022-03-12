using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetWarehouses
{
	public class GetWarehousesResponse : BaseResponseModel
	{
		public List<Warehouse> Warehouses { get; set; }
	}
}
