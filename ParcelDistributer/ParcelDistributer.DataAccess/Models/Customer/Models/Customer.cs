using ParcelDistributer.DataAccess.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributer.DataAccess.Models.Customer.Models
{
    public class Customer : BaseModel
    {
        [Key]
        public int numCustomerID { get; set; }

        public string? varCustomerName { get; set; }
        public string? varCustomerAddress { get; set; }
        public string? varCustomerNIC { get; set; }
        public string? varCustomerContactNo { get; set; }
        [NotMapped]
        public string? varCustomerUserName { get; set; }
        [NotMapped]
        public string? varCustomerUserPassword { get; set; }
    }
}