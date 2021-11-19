using SkuVaultApiWrapper.Models.SvWarehouses;
using System.Collections.Generic;

namespace SkuVaultApiWrapper.Models.SkuVaultModels
{
    public class GetWarehouseRequest : BaseRequestModel
    {
        public int PageNumber { get; set; }
    }

    public class GetWarehouseResponse : BaseResponseModel
    {
        public List<Warehouse> Warehouses { get; set; }
    }
}
