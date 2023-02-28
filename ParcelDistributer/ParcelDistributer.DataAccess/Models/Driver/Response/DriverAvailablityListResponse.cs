using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.Driver.Response
{
    public class DriverAvailablityListResponse : BaseResponse
    {
        public List<AvailableDriverListResponse> Drivers { get; set; }
    }
}