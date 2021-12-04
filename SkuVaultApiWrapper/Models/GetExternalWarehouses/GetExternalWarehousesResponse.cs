using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetExternalWarehousesResponse : BaseResponseModel
	{
		public List<ExternalWarehouse> Warehouses { get; set; }
	}
}
