using System.Net;

namespace SkuVaultApiWrapper.Models
{
	public class BaseResponseModel
	{
		public HttpStatusCode ResponseStatusCode { get; set; }
		public string ResponseReasonPhrase { get; set; }
	}
}
