using NUnit.Framework;
using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapperTest.Models.Shared
{
	[TestFixture]
	class UserCredentialsTest
	{
		[Test]
		public void AreValid_WhenNullTenantTokenAndWhiteSpaceUserToken_IsFalse()
		{
			// Arrange/Act
			UserCredentials userCredentials = new UserCredentials { Email = null, Password = "     " };

			// Assert
			Assert.IsFalse(userCredentials.AreValid);
		}

		[Test]
		public void AreValid_WhenEmptyTenantTokenAndValidUserToken_IsFalse()
		{
			// Arrange/Act
			UserCredentials userCredentials = new UserCredentials { Email = "", Password = "realPassword" };

			// Assert
			Assert.IsFalse(userCredentials.AreValid);
		}

		[Test]
		public void AreValid_WhenValidTokens_IsTrue()
		{
			// Arrange/Act
			UserCredentials userCredentials = new UserCredentials { Email = "realEmail", Password = "realPassword" };

			// Assert
			Assert.IsTrue(userCredentials.AreValid);
		}
	}
}
