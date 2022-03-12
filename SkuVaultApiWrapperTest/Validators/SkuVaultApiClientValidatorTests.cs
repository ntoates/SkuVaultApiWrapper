using NUnit.Framework;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Validators;
using System;
using System.Net.Http;

namespace SkuVaultApiWrapperTest.Validators
{
	[TestFixture]
	public class SkuVaultApiClientValidatorTests
	{
		private SkuVaultApiClientValidator _validator = new SkuVaultApiClientValidator();

		[Test]
		public void ValidateOptions_NoIssues_ExceptionIsNotThrown()
		{

			var action = () => _validator.ValidateOptions(
				new HttpClient(),
				new SkuVaultApiClientConfig("TenantToken", "UserToken")
			);

			Assert.DoesNotThrow(action.Invoke);
		}

		[Test]
		public void ValidateOptions_MultipleIssues_ExceptionMessagesJoinCorrectly()
		{
			try
			{
				var action = () => _validator.ValidateOptions(
					null,
					new SkuVaultApiClientConfig(null, null)
				);
			}
			catch (ArgumentException ex)
			{
				Assert.Equals("HttpClient can not be null. User Token can not be null, empty, or whitespace. Tenant Token can not be null, empty, or whitespace.", ex.Message);
			}
			catch { Assert.Fail(); }
		}

		[Test]
		public void ValidateOptions_TenantTokenIsNull_ThrowsArgumentExceptionMessage()
		{
			try
			{
				var action = () => _validator.ValidateOptions(
					new HttpClient(),
					new SkuVaultApiClientConfig("TenantToken", null)
				);
			}
			catch (ArgumentException ex)
			{
				Assert.Equals("Tenant Token can not be null, empty, or whitespace.", ex.Message);
			}
			catch { Assert.Fail(); }
		}

		[Test]
		public void ValidateOptions_UserTokenIsNull_ThrowsArgumentExceptionMessage()
		{
			try
			{
				var action = () => _validator.ValidateOptions(
					new HttpClient(),
					new SkuVaultApiClientConfig(null, "UserToken")
				);
			}
			catch (ArgumentException ex)
			{
				Assert.Equals("User Token can not be null, empty, or whitespace.", ex.Message);
			}
			catch { Assert.Fail(); }
		}

		[Test]
		public void ValidateOptions_HttpClientIsNull_ThrowsArgumentExceptionMessage()
		{
			try
			{
				var action = () => _validator.ValidateOptions(
					null,
					new SkuVaultApiClientConfig("TenantToken", "UserToken")
				);
			}
			catch (ArgumentException ex)
			{
				Assert.Equals("HttpClient can not be null.", ex.Message);
			}
			catch { Assert.Fail(); }
		}
	}
}
