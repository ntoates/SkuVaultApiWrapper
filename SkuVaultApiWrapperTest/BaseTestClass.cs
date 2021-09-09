using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapperTest
{
	/// <summary>
	/// If you have a SkuVault account, you can input the tokens and credentials here to run the full suite of unit test.
	/// </summary>
	public class BaseTestClass
	{
		public static UserCredentials GoodUserCreds = new UserCredentials
		{
			Email = "",
			Password = ""
		};

		public static UserTokens GoodUserTokens= new UserTokens
		{
			UserToken = "",
			TenantToken = ""
		};

		public UserCredentials BadUserCreds = new UserCredentials
		{
			Email = "BadEmail@skuvault.com",
			Password = "BadPassword"
		};

		public UserTokens BadUserTokens = new UserTokens
		{
			UserToken = "BadUserToken",
			TenantToken = "BadTenantToken"
		};

		public SkuVaultAccount SkuVaultAccountFromUserTokens() {
			return new SkuVaultAccount(GoodUserTokens);
		}

		public SkuVaultAccount SkuVaultAccountFromUserCreds() {
			return new SkuVaultAccount(GoodUserCreds);
		}

	}
}
