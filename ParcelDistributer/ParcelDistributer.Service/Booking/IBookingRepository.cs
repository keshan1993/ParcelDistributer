using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Booking.Response;

namespace ParcelDistributer.Service.Booking
{
    public interface IBookingRepository
    {
        public Task<BookingListResponse> Get();

        public Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Booking.Models.Booking booking);

        public Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Booking.Models.Booking booking);

        public Task<BaseResponse> Delete(int numBookingID);

        public Task<BookingListResponse> GetBookingByDriverID(int numDriverID);

        public Task<BaseResponse> SetBookingStartByDriverID(int numBookingID);

        public Task<BaseResponse> SetBookingCompleteByDriverID(int numBookingID);
    }
}