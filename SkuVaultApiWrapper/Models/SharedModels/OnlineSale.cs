using System;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class OnlineSale
	{
		public string Id { get; set; }
		public List<OnlineSaleItem> Items { get; set; }
		public DateTime LastPrintedDate { get; set; }
		public string Notes { get; set; }
		public bool PrintedStatus { get; set; }
		public string Status { get; set; }
	}
}
