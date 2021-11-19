using SkuVaultApiWrapper.Models.SvWarehouses;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
    public class GetExternalWarehousesRequest : BaseRequestModel
    {
        public int PageNumber { get; set; }

    }

    public class GetExternalWarehousesResponse : BaseResponseModel
    {
        public List<ExternalWarehouse> Warehouses { get; set; }
    }
}
