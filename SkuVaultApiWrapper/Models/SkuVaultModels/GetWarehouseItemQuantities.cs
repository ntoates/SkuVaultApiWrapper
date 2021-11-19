using SkuVaultApiWrapper.Models.SkuVaultModels.Shared;
using System;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
    /// <summary>
    /// https://dev.skuvault.com/reference#getwarehouseitemquantities
    /// </summary>
    public class GetWarehouseItemQuantitiesRequest : BaseRequestModel
    {
        public DateTime ModifiedBeforeDateTimeUtc { get; set; }
        public DateTime ModifiedAfterDateTimeUtc { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string WarehouseId { get; set; } // Required
    }

    public class GetWarehouseItemQuantitiesResponse : BaseResponseModel
    {
        public List<SkuQuantityRecord> ItemQuantities { get; set; }
    }
}
