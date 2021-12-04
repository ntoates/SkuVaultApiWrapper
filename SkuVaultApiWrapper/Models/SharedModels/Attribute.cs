using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper.Models.SharedModels
{
	public class Attribute
	{
		public bool IsEnabled { get; set; }
		public bool IsRequired { get; set; }
		public string Name { get; set; }
		public List<string> Values { get; set; }
	}
}
