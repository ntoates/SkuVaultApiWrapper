namespace SkuVaultApiWrapper.Models.Shared
{
	public class UserCredentials
	{
		public string Email { get; set; }
		public string Password { get; set; }
		internal bool AreValid => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
	}
}
