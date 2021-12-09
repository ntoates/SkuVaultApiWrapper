using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class AvailableQuantitiesItem
	{
		public List<string> AlternateSkus { get; set; }
		public string Sku { get; set; }
		public int AvailableQuantity { get; set; }
		public string LastModifiedDateTimeUtc { get; set; }
		public bool IsAlternateSku { get; set; } = true;
	}
}
