using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapper
{
	internal class Errors
	{
		private List<string> ListOfErrors { get; set; }
		internal bool ErrorsExist => ListOfErrors.Count > 0;
		internal int ErrorsCount => ListOfErrors.Count;

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
			if(ErrorsExist)
			{
				string FullErrorMessage = "";
				for(int i = 0; i < ErrorsCount; i++)
				{
					var stringToInsert = i < ErrorsCount ? ListOfErrors[i] + "; " : ListOfErrors[i];
					FullErrorMessage.Insert(FullErrorMessage.Length, stringToInsert);
				}
				return FullErrorMessage;
			}

			return null;
		}
	}
}
