using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.CreateBrands
{
	public class BrandErrors
	{
		public string BrandName { get; set; }
		public List<string> ErrorMessages { get; set; }
	}
}