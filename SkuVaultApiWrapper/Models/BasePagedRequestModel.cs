namespace SkuVaultApiWrapper.Models
{
	public abstract class BasePagedRequestModel : BaseRequestModel
	{
		public int PageNumber { get; set; }
	}
}
