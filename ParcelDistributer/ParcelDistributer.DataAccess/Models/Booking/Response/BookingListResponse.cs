using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Booking.DTOs;

namespace ParcelDistributer.DataAccess.Models.Booking.Response
{
    public class BookingListResponse : BaseResponse
    {
        public List<BookingDTO> Bookings { get; set; }
    }
}