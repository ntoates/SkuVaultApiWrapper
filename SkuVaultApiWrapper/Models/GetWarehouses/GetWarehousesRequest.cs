using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.GetWarehouses
{
	public class GetWarehousesRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getWarehouses;
	}
}
