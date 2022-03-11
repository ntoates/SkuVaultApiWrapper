namespace ExampleConsoleApp
{
	internal class UserDefinedConfiguration
	{
		public string UserToken { get; set; }
		public string TenantToken { get; set; }

		public UserDefinedConfiguration(string userToken, string tenantToken)
		{
			UserToken = userToken;
			TenantToken = tenantToken;
		}
	}
}
