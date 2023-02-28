using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.Driver.DTOs
{
    public class DriverDTO : BaseModelDTO
    {
        public int numDriverID { get; set; }
        public string? varDriverName { get; set; }
        public string? varDriverAddress { get; set; }
        public string? varDriverNIC { get; set; }
        public string? varDriverContactNo { get; set; }
        public string? varDriverUserName { get; set; }
        public string? varDriverUserPassword { get; set; }
    }
}