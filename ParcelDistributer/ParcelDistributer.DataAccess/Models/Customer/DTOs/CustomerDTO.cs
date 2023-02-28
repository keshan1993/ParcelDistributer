using ParcelDistributer.DataAccess.Models.Base;

namespace ParcelDistributer.DataAccess.Models.Customer.DTOs
{
    public class CustomerDTO : BaseModelDTO
    {
        public int numCustomerID { get; set; }
        public string? varCustomerName { get; set; }
        public string? varCustomerAddress { get; set; }
        public string? varCustomerNIC { get; set; }
        public string? varCustomerContactNo { get; set; }
        public string? varCustomerUserName { get; set; }
        public string? varCustomerUserPassword { get; set; }
    }
}