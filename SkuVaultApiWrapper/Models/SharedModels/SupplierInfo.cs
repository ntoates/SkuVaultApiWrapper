using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class SupplierInfo
	{
		public string SupplierName { get; set; }
		public string SupplierPartNumber { get; set; }
		public double Cost { get; set; }
		public double LeadTime { get; set; }
		public bool IsActive { get; set; }
		public bool IsPrimary { get; set; }
	}
}
