using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.GoodsType.DTOs
{
    public class GoodsTypeDTO : BaseModelDTO
    {
        public int numGoodsTypeID { get; set; }
        public string? varGoodsTypeName { get; set; }
        public string? varGoodsTypeDescription { get; set; }
    }
}