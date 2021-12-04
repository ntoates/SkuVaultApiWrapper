using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class Classification
	{
		public List<Attribute> Attributes { get; set; }
		public bool IsEnabled { get; set; }
		public string Name { get; set; }
	}
}
