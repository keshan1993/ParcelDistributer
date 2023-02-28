using Microsoft.AspNetCore.Mvc;
using ParcelDistributer.API.Extensions;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Driver.Models;
using ParcelDistributer.DataAccess.Models.Driver.Response;
using ParcelDistributer.Service.Driver;

namespace ParcelDistributer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private IDriverRepository _driverService;

        public DriverController(IDriverRepository driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            DriverListResponse response = await _driverService.Get();
            return this.Send(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Driver driver)
        {
            BaseResponse response = await _driverService.Post(driver);
            return this.Send(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Driver driver)
        {
            BaseResponse response = await _driverService.Put(driver);
            return this.Send(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int numDriverID)
        {
            BaseResponse response = await _driverService.Delete(numDriverID);
            return this.Send(response);
        }

        [HttpGet]
        [Route("GetAvailableDrivers")]
        public async Task<IActionResult> GetAvailableDrivers(string dtDeliveryDate)
        {
            var response = await _driverService.GetAvailableDrivers(dtDeliveryDate);
            return this.Send(response);
        }
    }
}