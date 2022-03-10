using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
	public class GetClassificationsRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getClassifications;
	}
}
