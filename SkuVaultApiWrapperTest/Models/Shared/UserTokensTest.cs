using NUnit.Framework;
using SkuVaultApiWrapper.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkuVaultApiWrapperTest.Models.Shared
{
	[TestFixture]
	class UserTokensTest
	{
		[Test]
		public void AreValid_WhenNullTenantTokenAndWhiteSpaceUserToken_IsFalse()
		{
			// Arrange/Act
			UserTokens userTokens = new UserTokens { TenantToken = null, UserToken = "     " };

			// Assert
			Assert.IsFalse(userTokens.AreValid);
		}

		[Test]
		public void AreValid_WhenEmptyTenantTokenAndValidUserToken_IsFalse()
		{
			// Arrange/Act
			UserTokens userTokens = new UserTokens { TenantToken = "", UserToken = "realToken" };

			// Assert
			Assert.IsFalse(userTokens.AreValid);
		}

		[Test]
		public void AreValid_WhenValidTokens_IsTrue()
		{
			// Arrange/Act
			UserTokens userTokens = new UserTokens { TenantToken = "RealToken", UserToken = "realToken" };

			// Assert
			Assert.IsTrue(userTokens.AreValid);
		}
	}
}
