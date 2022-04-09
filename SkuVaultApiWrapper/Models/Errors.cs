using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models
{
	internal class Errors
	{
		private List<string> ListOfErrors { get; set; }
		internal bool ErrorsExist => ListOfErrors.Count > 0;
		internal int ErrorCount => ListOfErrors.Count;

		internal Errors()
		{
			ListOfErrors = new List<string>();
		}

		internal void AddError(string errorMessage)
		{
			ListOfErrors.Add(errorMessage);
		}

		internal string GenerateErrorString()
		{
			string FullErrorMessage = "";
			for (int i = 0; i < ErrorCount; i++)
			{
				var stringToInsert = i < ErrorCount ? ListOfErrors[i] + " " : ListOfErrors[i];
				FullErrorMessage += stringToInsert;
			}
			return FullErrorMessage;
		}
	}
}
