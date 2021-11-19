using NUnit.Framework;
using SkuVaultApiWrapper.Models;

namespace SkuVaultApiWrapperTest.Models
{
    [TestFixture]
    class BaseRequestModelTest
    {
        [Test]
        public void AreValid_WhenNullTenantTokenAndWhiteSpaceUserToken_IsFalse()
        {
            // Arrange/Act
            BaseRequestModel baseRequest = new BaseRequestModel { TenantToken = null, UserToken = "     " };

            // Assert
            Assert.IsTrue(baseRequest.IsMissingTokens);
        }

        [Test]
        public void AreValid_WhenEmptyTenantTokenAndValidUserToken_IsFalse()
        {
            // Arrange/Act
            BaseRequestModel baseRequest = new BaseRequestModel { TenantToken = "", UserToken = "realToken" };

            // Assert
            Assert.IsTrue(baseRequest.IsMissingTokens);
        }

        [Test]
        public void AreValid_WhenValidTokens_IsTrue()
        {
            // Arrange/Act
            BaseRequestModel baseRequest = new BaseRequestModel { TenantToken = "RealToken", UserToken = "realToken" };

            // Assert
            Assert.IsFalse(baseRequest.IsMissingTokens);
        }
    }
}
