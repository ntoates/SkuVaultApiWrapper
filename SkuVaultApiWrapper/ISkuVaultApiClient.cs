using SkuVaultApiWrapper.Models;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper
{
	public interface ISkuVaultApiClient
	{
		public Task<D> Post<T, D>(T request) where T : BaseRequestModel where D : BaseResponseModel;
	}
}