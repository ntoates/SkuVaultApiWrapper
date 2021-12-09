using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class KitLine
	{
		public int Combine { get; set; }
		public List<Item> Items { get; set; }
		public string LineName { get; set; }
		public int Quantity { get; set; }
	}
}
