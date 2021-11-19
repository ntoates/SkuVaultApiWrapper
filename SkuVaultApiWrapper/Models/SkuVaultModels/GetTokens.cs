namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
    public class GetTokensRequest : BaseRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class GetTokensResponse : BaseResponseModel
    {
        public string TenantToken { get; set; }
        public string UserToken { get; set; }
    }
}
