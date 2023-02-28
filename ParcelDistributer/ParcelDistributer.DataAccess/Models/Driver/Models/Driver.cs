using ParcelDistributer.DataAccess.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributer.DataAccess.Models.Driver.Models
{
    public class Driver : BaseModel
    {
        [Key]
        public int numDriverID { get; set; }

        public string? varDriverName { get; set; }
        public string? varDriverAddress { get; set; }
        public string? varDriverNIC { get; set; }
        public string? varDriverContactNo { get; set; }

        [NotMapped]
        public string? varDriverUserName { get; set; }

        [NotMapped]
        public string? varDriverUserPassword { get; set; }
    }
}