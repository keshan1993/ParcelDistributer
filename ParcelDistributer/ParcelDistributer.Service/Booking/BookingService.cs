using AutoMapper;
using ParcelDistributer.DataAccess;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Booking.DTOs;
using ParcelDistributer.DataAccess.Models.Booking.Response;

namespace ParcelDistributer.Service.Booking
{
    public class BookingService : IBookingRepository
    {
        private readonly DistributerContext _context;
        private readonly IMapper _autoMapper;

        public BookingService(DistributerContext context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<BookingListResponse> Get()
        {
            try
            {
                var bookingList = _context.Booking.Where(i => i.bitActive == true).Select(x => new BookingDTO
                {
                    numBookingID = x.numBookingID,
                    numCustomerID = x.numCustomerID,
                    varCustomerName = _context.Customer.Where(g => g.numCustomerID == x.numCustomerID).Select(g => g.varCustomerName).FirstOrDefault(),
                    dtDeliveryDate = x.dtDeliveryDate,
                    varBookingNo = x.varBookingNo,
                    varFromAddress = x.varFromAddress,
                    varToAddress = x.varToAddress,
                    numDistance = x.numDistance,
                    numGoodsTypeID = x.numGoodsTypeID,
                    varGoodsTypeName = _context.GoodsType.Where(g => g.numGoodsTypeID == x.numGoodsTypeID).Select(g => g.varGoodsTypeName).FirstOrDefault(),
                    numWeight = x.numWeight,
                    numPrice = x.numPrice,
                    bitIsApproved = x.bitIsApproved,
                    numDriverID = x.numDriverID,
                    varDriverName = _context.Driver.Where(g => g.numDriverID == x.numDriverID).Select(g => g.varDriverName).FirstOrDefault(),
                    dtApprovedDateTime = x.dtApprovedDateTime,
                    bitIsStarted = x.bitIsStarted,
                    dtStartedDateTime = x.dtStartedDateTime,
                    bitIsCompleted = x.bitIsCompleted,
                    dtCompletedDateTime = x.dtCompletedDateTime,
                    bitActive = x.bitActive,
                    dtCreatedDate = x.dtCreatedDate,
                    dtDeletedDate = x.dtDeletedDate,
                    dteditedDate = x.dteditedDate
                }).ToList();
                return new BookingListResponse()
                {
                    Bookings = _autoMapper.Map<List<BookingDTO>>(bookingList),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BookingListResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Booking.Models.Booking booking)
        {
            try
            {
                var bookingCount = _context.Booking.Where(b => b.bitActive == true).Count() + 1;

                var _booking = new ParcelDistributer.DataAccess.Models.Booking.Models.Booking()
                {
                    varBookingNo = "REF/" + bookingCount.ToString("000"),
                    numCustomerID = booking.numCustomerID,
                    dtDeliveryDate = booking.dtDeliveryDate,
                    varFromAddress = booking.varFromAddress,
                    varToAddress = booking.varToAddress,
                    numDistance = booking.numDistance,
                    numGoodsTypeID = booking.numGoodsTypeID,
                    numWeight = booking.numWeight,
                    numPrice = booking.numPrice,
                    bitIsApproved = true,
                    numDriverID = booking.numDriverID,
                    dtApprovedDateTime = DateTime.Now,
                    bitIsStarted = false,
                    bitIsCompleted = false,
                    bitActive = true,
                    dtCreatedDate = DateTime.Now,
                };
                _context.Booking.Add(_booking);
                _context.SaveChanges();

                return new BaseResponse()
                {
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Booking.Models.Booking booking)
        {
            try
            {
                var resulktSet = _context.Booking.FirstOrDefault(x => x.numBookingID.Equals(booking.numBookingID));
                resulktSet.varFromAddress = booking.varFromAddress;
                resulktSet.numCustomerID = booking.numCustomerID;
                resulktSet.dtDeliveryDate = booking.dtDeliveryDate;
                resulktSet.varToAddress = booking.varToAddress;
                resulktSet.numDistance = booking.numDistance;
                resulktSet.numGoodsTypeID = booking.numGoodsTypeID;
                resulktSet.numWeight = booking.numWeight;
                resulktSet.numPrice = booking.numPrice;
                resulktSet.bitIsApproved = true;
                resulktSet.numDriverID = booking.numDriverID;
                resulktSet.dtApprovedDateTime = DateTime.Now;
                resulktSet.bitIsStarted = false;
                resulktSet.bitIsCompleted = false;
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
                    numCreatedID = booking.numBookingID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numBookingID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Delete(int numBookingID)
        {
            try
            {
                var resulktSet = _context.Booking.FirstOrDefault(x => x.numBookingID.Equals(numBookingID));
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
                    numCreatedID = numBookingID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// GetBookingByDriverIDs
        /// <param name="numDriverID"></param>
        /// </summary>
        /// <returns></returns>
        public async Task<BookingListResponse> GetBookingByDriverID(int numDriverID)
        {
            try
            {
                var bookingList = _context.Booking.Where(i => i.bitActive == true && i.numDriverID == numDriverID).Select(x => new BookingDTO
                {
                    numBookingID = x.numBookingID,
                    numCustomerID = x.numCustomerID,
                    varCustomerName = _context.Customer.Where(g => g.numCustomerID == x.numCustomerID).Select(g => g.varCustomerName).FirstOrDefault(),
                    dtDeliveryDate = x.dtDeliveryDate,
                    varBookingNo = x.varBookingNo,
                    varFromAddress = x.varFromAddress,
                    varToAddress = x.varToAddress,
                    numDistance = x.numDistance,
                    numGoodsTypeID = x.numGoodsTypeID,
                    varGoodsTypeName = _context.GoodsType.Where(g => g.numGoodsTypeID == x.numGoodsTypeID).Select(g => g.varGoodsTypeName).FirstOrDefault(),
                    numWeight = x.numWeight,
                    numPrice = x.numPrice,
                    bitIsApproved = x.bitIsApproved,
                    numDriverID = x.numDriverID,
                    varDriverName = _context.Driver.Where(g => g.numDriverID == x.numDriverID).Select(g => g.varDriverName).FirstOrDefault(),
                    dtApprovedDateTime = x.dtApprovedDateTime,
                    bitIsStarted = x.bitIsStarted,
                    dtStartedDateTime = x.dtStartedDateTime,
                    bitIsCompleted = x.bitIsCompleted,
                    dtCompletedDateTime = x.dtCompletedDateTime,
                    bitActive = x.bitActive,
                    dtCreatedDate = x.dtCreatedDate,
                    dtDeletedDate = x.dtDeletedDate,
                    dteditedDate = x.dteditedDate
                }).ToList();
                return new BookingListResponse()
                {
                    Bookings = _autoMapper.Map<List<BookingDTO>>(bookingList),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new BookingListResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numBookingID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> SetBookingStartByDriverID(int numBookingID)
        {
            try
            {
                var resulktSet = _context.Booking.FirstOrDefault(x => x.numBookingID.Equals(numBookingID));
                resulktSet.bitIsStarted = true;
                resulktSet.dtStartedDateTime = DateTime.Now;
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
                    numCreatedID = numBookingID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numBookingID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> SetBookingCompleteByDriverID(int numBookingID)
        {
            try
            {
                var resulktSet = _context.Booking.FirstOrDefault(x => x.numBookingID.Equals(numBookingID));
                resulktSet.bitIsCompleted = true;
                resulktSet.dtCompletedDateTime = DateTime.Now;
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
                    numCreatedID = numBookingID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateBooking(ex), bitSuccess = false };
            }
        }

        private ErrorDTO ValidateBooking(Exception exception)
        {
            return new ErrorDTO()
            {
                ErrorType = exception.GetType().Name,
                ErrorMessage = exception.Message
            };
        }
    }
}