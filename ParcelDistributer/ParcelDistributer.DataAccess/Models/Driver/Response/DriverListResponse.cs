using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.Driver.Response
{
    public class DriverListResponse : BaseResponse
    {
        public List<Driver.Models.Driver> Drivers { get; set; }
    }
}