using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class ProductDetails
	{
		public string Id { get; set; }
		public string Code { get; set; }
		public string Sku { get; set; }
		public string PartNumber { get; set; }
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public double Cost { get; set; }
		public double RetailPrice { get; set; }
		public double SalePrice { get; set; }
		public string WeightValue { get; set; }
		public string WeightUnit { get; set; }
		public int ReorderPoint { get; set; }
		public string Brand { get; set; }
		public string Supplier { get; set; }
		public List<SupplierInfo> SupplierInfo { get; set; }
		public string Classification { get; set; }
		public int QuantityOnHand { get; set; }
		public int QuantityOnHold { get; set; }
		public int QuantityPicked { get; set; }
		public int QuantityPending { get; set; }
		public int QuantityAvailable { get; set; }
		public int QuantityIncoming { get; set; }
		public int QuantityInbound { get; set; }
		public int QuantityTransfer { get; set; }
		public int QuantityInStock { get; set; }
		public int QuantityTotalFBA { get; set; }
		public string CreatedDateUtc { get; set; }
		public string ModifiedDateUtc { get; set; }
		public List<string> Pictures { get; set; }
		public List<ProductAttribute> Attributes { get; set; }
		public string VariationParentSku { get; set; }
		public bool IsAlternateSKU { get; set; }
		public bool IsAlternateCode { get; set; }
		public int MOQ { get; set; }
		public string MOQInfo { get; set; }
		public int IncrementalQuantity { get; set; }
		public bool DisableQuantitySync { get; set; }
		public List<string> Statuses { get; set; }
	}
}
