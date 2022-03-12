using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.GetClassifications
{
	public class GetClassificationsRequest : BasePagedRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getClassifications;
	}
}
