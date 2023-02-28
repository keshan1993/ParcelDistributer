using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.Customer.Response
{
    public class CustomerListResponse : BaseResponse
    {
        public List<Customer.Models.Customer> Customers { get; set; }
    }
}