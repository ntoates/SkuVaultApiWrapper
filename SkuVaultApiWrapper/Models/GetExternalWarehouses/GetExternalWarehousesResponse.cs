using SkuVaultApiWrapper.Models.SharedModels;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.GetExternalWarehouses
{
	public class GetExternalWarehousesResponse : BaseResponseModel
	{
		public List<ExternalWarehouse> Warehouses { get; set; }
	}
}
