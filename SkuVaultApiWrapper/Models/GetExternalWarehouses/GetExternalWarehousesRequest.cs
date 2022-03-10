using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetExternalWarehousesRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getExternalWarehouses;
	}
}
