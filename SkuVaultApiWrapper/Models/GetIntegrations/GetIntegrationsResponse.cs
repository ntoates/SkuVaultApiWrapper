using SkuVaultApiWrapper.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.GetIntegrations
{
	public class GetIntegrationsResponse : BaseResponseModel
	{
		public List<Integration> Accounts { get; set; }
	}
}
