using System;

namespace SkuVaultApiWrapper
{
	internal class UnableToGetTokensException : Exception
	{
		public UnableToGetTokensException(string message) : base(message)
		{
		}
	}
}
