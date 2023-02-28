using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Driver.Response;

namespace ParcelDistributer.Service.Driver
{
    public interface IDriverRepository
    {
        public Task<DriverListResponse> Get();

        public Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Driver.Models.Driver driver);

        public Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Driver.Models.Driver driver);

        public Task<BaseResponse> Delete(int numDriverID);

        public Task<DriverAvailablityListResponse> GetAvailableDrivers(string dtDeliveryDate);

    }
}