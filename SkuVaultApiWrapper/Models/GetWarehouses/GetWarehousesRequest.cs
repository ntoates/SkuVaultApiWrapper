using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetWarehousesRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getWarehouses;
	}
}
