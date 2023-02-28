using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Customer.Response;

namespace ParcelDistributer.Service.Customer
{
    public interface ICustomerRepository
    {
        public Task<CustomerListResponse> Get();

        public Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Customer.Models.Customer customer);

        public Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Customer.Models.Customer customer);

        public Task<BaseResponse> Delete(int numCustomerID);
    }
}