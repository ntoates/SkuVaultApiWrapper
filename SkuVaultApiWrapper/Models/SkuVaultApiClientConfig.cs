namespace SkuVaultApiWrapper.Models
{
    public class SkuVaultApiClientConfig
    {
        public string TenantToken { get; set; }
        public string UserToken { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        internal bool TokensAreValid => !string.IsNullOrWhiteSpace(TenantToken) && !string.IsNullOrWhiteSpace(UserToken);
        internal bool CredentialsAreValid => !string.IsNullOrWhiteSpace(TenantToken) && !string.IsNullOrWhiteSpace(UserToken);

    }
}
