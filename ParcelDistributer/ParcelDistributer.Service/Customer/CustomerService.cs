using AutoMapper;
using ParcelDistributer.DataAccess;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Customer.Response;

namespace ParcelDistributer.Service.Customer
{
    public class CustomerService : ICustomerRepository
    {
        private readonly DistributerContext _context;
        private readonly IMapper _autoMapper;

        public CustomerService(DistributerContext context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<CustomerListResponse> Get()
        {
            try
            {
                var customerList = _context.Customer.Where(i => i.bitActive == true).ToList();
                return new CustomerListResponse()
                {
                    Customers = _autoMapper.Map<List<ParcelDistributer.DataAccess.Models.Customer.Models.Customer>>(customerList),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new CustomerListResponse() { Error = ValidateCustomer(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Customer.Models.Customer customer)
        {
            try
            {
                var _customer = new ParcelDistributer.DataAccess.Models.Customer.Models.Customer()
                {
                    varCustomerName = customer.varCustomerName,
                    varCustomerAddress = customer.varCustomerAddress,
                    varCustomerNIC = customer.varCustomerNIC,
                    varCustomerContactNo = customer.varCustomerContactNo,
                    varCustomerUserName = customer.varCustomerUserName,
                    varCustomerUserPassword = customer.varCustomerUserPassword,
                    bitActive = true,
                    dtCreatedDate = DateTime.Now,
                };
                _context.Customer.Add(_customer);
                _context.SaveChanges();

                return new BaseResponse()
                {
                    bitSuccess = true,
                    numCreatedID = _customer.numCustomerID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateCustomer(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Customer.Models.Customer customer)
        {
            try
            {
                var resulktSet = _context.Customer.FirstOrDefault(x => x.numCustomerID.Equals(customer.numCustomerID));
                resulktSet.varCustomerName = customer.varCustomerName;
                resulktSet.varCustomerAddress = customer.varCustomerAddress;
                resulktSet.varCustomerNIC = customer.varCustomerNIC;
                resulktSet.varCustomerContactNo = customer.varCustomerContactNo;
                resulktSet.varCustomerUserName = customer.varCustomerUserName;
                resulktSet.varCustomerUserPassword = customer.varCustomerUserPassword;
                resulktSet.bitActive = true;
                resulktSet.dteditedDate = DateTime.Now;
                if (resulktSet is null)
                    return new()
                    {
                        bitSuccess = false
                    };
                _context.SaveChanges();
                return new BaseResponse()
                {
                    bitSuccess = true,
                    numCreatedID = customer.numCustomerID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateCustomer(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numCustomerID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Delete(int numCustomerID)
        {
            try
            {
                var resulktSet = _context.Customer.FirstOrDefault(x => x.numCustomerID.Equals(numCustomerID));
                resulktSet.bitActive = false;
                resulktSet.dtDeletedDate = DateTime.Now;
                if (resulktSet is null)
                    return new()
                    {
                        bitSuccess = false
                    };
                _context.SaveChanges();
                return new BaseResponse()
                {
                    bitSuccess = true,
                    numCreatedID = numCustomerID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateCustomer(ex), bitSuccess = false };
            }
        }

        private ErrorDTO ValidateCustomer(Exception exception)
        {
            return new ErrorDTO()
            {
                ErrorType = exception.GetType().Name,
                ErrorMessage = exception.Message
            };
        }
    }
}