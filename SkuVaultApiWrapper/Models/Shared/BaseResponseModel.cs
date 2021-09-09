using System.Net;

namespace SkuVaultApiWrapper.Models.Shared
{
	public class BaseResponseModel
	{
		public HttpStatusCode ResponseStatusCode { get; set; }
		public string ResponseReasonPhrase { get; set; }
	}
}
