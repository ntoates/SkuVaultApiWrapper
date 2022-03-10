using SkuVaultApiWrapper.Models.Shared;

namespace SkuVaultApiWrapper.Models.GetIntegrations
{
	public class GetIntegrationsRequest : BaseRequestModel
	{
		public override string Endpoint() => SkuVaultEndpoints.getIntegrations;
	}
}
