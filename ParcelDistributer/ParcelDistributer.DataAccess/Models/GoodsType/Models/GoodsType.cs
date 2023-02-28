using ParcelDistributer.DataAccess.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributer.DataAccess.Models.GoodsType.Models
{
    public class GoodsType : BaseModel
    {
        [Key]
        public int numGoodsTypeID { get; set; }

        public string? varGoodsTypeName { get; set; }
        public string? varGoodsTypeDescription { get; set; }
    }
}