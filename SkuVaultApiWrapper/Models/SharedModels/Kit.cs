using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class Kit
	{
		public int AvailableQuantity { get; set; }
		public string AvailableQuantityLastModifiedDateTimeUtc { get; set; }
		public List<string> Statuses { get; set; }
		public string Code { get; set; }
		public int Cost { get; set; }
		public string Description { get; set; }
		public List<KitLine> KitLines { get; set; }
		public string LastModifiedDateTimeUtc { get; set; }
		public string SKU { get; set; }
	}
}
