using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
    public class GetWarehouseItemQuantityRequest : BaseRequestModel
    {
        public int WarehouseId { get; set; }
        public string Sku { get; set; }
    }

    public class GetWarehouseItemQuantityResponse : BaseResponseModel
    {
        public List<string> Errors { get; set; }
        public int TotalQuantityOnHand { get; set; }
    }
}
