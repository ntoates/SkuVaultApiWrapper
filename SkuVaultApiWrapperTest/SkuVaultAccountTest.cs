using NUnit.Framework;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Models.Shared;
using System;

namespace SkuVaultApiWrapperTest
{
	[TestFixture]
	public class SkuVaultAccountTest : BaseTestClass
	{
		[Test]
		public void ConstructionWithCredentials_ValidationFails_Throw()
		{
			// Arrange
			var emptyCredentials = new UserCredentials
			{
				Email = "",
				Password = ""
			};
			// Act
			Action action = () => new SkuVaultAccount(emptyCredentials);

			// Assert
			Assert.Throws<Exception>(action.Invoke);
		}

		[Test]
		public void ConstructionWithTokens_ValidationFails_Throw()
		{
			// Arrange
			var emptyTokens = new UserTokens
			{
				TenantToken = "",
				UserToken = ""
			};
			// Act
			Action action = () => new SkuVaultAccount(emptyTokens);

			// Assert
			Assert.Throws<Exception>(action.Invoke);
		}

		[Test]
		public void ConstructionWithTokens_AuthorizationSucceeds_AccountContainsCorrectData()
		{
			// Arrange/Act
			SkuVaultAccount svAccount = new SkuVaultAccount(GoodUserTokens);

			// Assert
			Assert.AreEqual(GoodUserTokens.TenantToken, svAccount.TenantToken);
			Assert.AreEqual(GoodUserTokens.UserToken, svAccount.UserToken);
		}

		[Test]
		public void ConstructionWithTokens_AuthorizationFails_ExceptionIsThrown()
		{
			// Arrange/Act
			Action action = () => new SkuVaultAccount(BadUserTokens);

			// Assert
			Assert.Throws<Exception>(action.Invoke);
		}

		[Test]
		public void ConstructionWithCredentials_AuthorizationSucceeds_ExpectedTokensReturned()
		{
			// Arrange/Act
			SkuVaultAccount svAccount = new SkuVaultAccount(GoodUserCreds);

			// Assert
			Assert.AreEqual(GoodUserTokens.TenantToken, svAccount.TenantToken);
			Assert.AreEqual(GoodUserTokens.UserToken, svAccount.UserToken);
		}

		[Test]
		public void ConstructionWithCredentials_AuthorizationFails_ExceptionIsThrown()
		{
			// Arrange/Act
			Action action = () => new SkuVaultAccount(BadUserCreds);

			// Assert
			Assert.Throws<Exception>(action.Invoke);
		}

		[Test]
		public void TenantToken_GetValue_Succeeds()
		{
			// Arrange/Act
			SkuVaultAccount svAccount = new SkuVaultAccount(GoodUserCreds);

			// Assert
			Assert.AreEqual(GoodUserTokens.TenantToken, svAccount.TenantToken);
		}

		[Test]
		public void UserToken_GetValue_Succeeds()
		{
			// Arrange/Act
			SkuVaultAccount svAccount = new SkuVaultAccount(GoodUserCreds);

			// Assert
			Assert.AreEqual(GoodUserTokens.UserToken, svAccount.UserToken);
		}
	}
}
