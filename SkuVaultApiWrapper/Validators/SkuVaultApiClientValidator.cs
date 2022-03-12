using SkuVaultApiWrapper.Models;
using System;
using System.Net.Http;

namespace SkuVaultApiWrapper.Validators
{
	internal class SkuVaultApiClientValidator
	{
		public SkuVaultApiClientValidator()
		{
		}

		internal void ValidateOptions(HttpClient httpClient, SkuVaultApiClientConfig config)
		{
			var errors = new Errors();
			if (httpClient == null)
				errors.AddError("HttpClient can not be null.");

			if(string.IsNullOrWhiteSpace(config.UserToken))
				errors.AddError("User Token can not be null, empty, or whitespace.");

			if (string.IsNullOrWhiteSpace(config.TenantToken))
				errors.AddError("Tenant Token can not be null, empty, or whitespace.");

			if (errors.ErrorsExist)
				throw new ArgumentException(errors.GenerateErrorString());
		}
	}
}
