using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class BrandWithEnabledStatus : Brand
	{
		public bool IsEnabled { get; set; }
	}
}
