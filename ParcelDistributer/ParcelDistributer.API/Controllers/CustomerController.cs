using Microsoft.AspNetCore.Mvc;
using ParcelDistributer.API.Extensions;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Customer.Models;
using ParcelDistributer.DataAccess.Models.Customer.Response;
using ParcelDistributer.Service.Customer;

namespace ParcelDistributer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerService;

        public CustomerController(ICustomerRepository customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            CustomerListResponse response = await _customerService.Get();
            return this.Send(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            BaseResponse response = await _customerService.Post(customer);
            return this.Send(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Customer customer)
        {
            BaseResponse response = await _customerService.Put(customer);
            return this.Send(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int numCustomerID)
        {
            BaseResponse response = await _customerService.Delete(numCustomerID);
            return this.Send(response);
        }
    }
}