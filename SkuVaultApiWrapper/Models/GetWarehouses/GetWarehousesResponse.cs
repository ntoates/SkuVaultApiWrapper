using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetWarehousesResponse : BaseResponseModel
	{
		public List<Warehouse> Warehouses { get; set; }
	}
}
