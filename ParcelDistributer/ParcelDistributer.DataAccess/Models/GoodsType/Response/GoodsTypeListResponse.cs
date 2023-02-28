using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.GoodsType.DTOs;

namespace ParcelDistributer.DataAccess.Models.GoodsType.Response
{
    public class GoodsTypeListResponse : BaseResponse
    {
        public List<GoodsTypeDTO>? GoodsTypes { get; set; }
    }
}