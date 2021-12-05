using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class Location
	{
		public string WarehouseCode { get; set; }
		public string WarehouseName { get; set; }
		public string LocationCode { get; set; }
		public string ContainerCode { get; set; }
		public string ParentLocation { get; set; }
		public int TotalQuantity { get; set; }
	}
}
