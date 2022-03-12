using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.GetExternalWarehouses
{
	public class GetExternalWarehousesRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getExternalWarehouses;
	}
}
