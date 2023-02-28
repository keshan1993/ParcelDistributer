using Microsoft.AspNetCore.Mvc;
using ParcelDistributer.API.Extensions;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Booking.Models;
using ParcelDistributer.DataAccess.Models.Booking.Response;
using ParcelDistributer.Service.Booking;
using ParcelDistributer.Service.Driver;

namespace ParcelDistributer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingRepository _bookingService;

        public BookingController(IBookingRepository bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            BookingListResponse response = await _bookingService.Get();
            return this.Send(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Booking booking)
        {
            BaseResponse response = await _bookingService.Post(booking);
            return this.Send(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Booking booking)
        {
            BaseResponse response = await _bookingService.Put(booking);
            return this.Send(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int numBookingID)
        {
            BaseResponse response = await _bookingService.Delete(numBookingID);
            return this.Send(response);
        }

        [HttpGet]
        [Route("GetBookingByDriverID")]
        public async Task<IActionResult> GetBookingByDriverID(int numDriverID)
        {
            var response = await _bookingService.GetBookingByDriverID(numDriverID);
            return this.Send(response);
        }

        [HttpPut]
        [Route("SetBookingStartByDriverID/{numBookingID}")]
        public async Task<IActionResult> SetBookingStartByDriverID(int numBookingID)
        {
            BaseResponse response = await _bookingService.SetBookingStartByDriverID(numBookingID);
            return this.Send(response);
        }

        [HttpPut]
        [Route("SetBookingCompleteByDriverID/{numBookingID}")]
        public async Task<IActionResult> SetBookingCompleteByDriverID(int numBookingID)
        {
            BaseResponse response = await _bookingService.SetBookingCompleteByDriverID(numBookingID);
            return this.Send(response);
        }
    }
}