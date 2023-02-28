using ParcelDistributer.DataAccess.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ParcelDistributer.DataAccess.Models.Booking.Models
{
    public class Booking : BaseModel
    {
        [Key]
        public int numBookingID { get; set; }
        public int? numCustomerID { get; set; }
        public DateTime? dtDeliveryDate { get; set; }
        public string? varBookingNo { get; set; }
        public string? varFromAddress { get; set; }
        public string? varToAddress { get; set; }
        public decimal? numDistance { get; set; }
        public int? numGoodsTypeID { get; set; }
        public decimal? numWeight { get; set; }
        public decimal? numPrice { get; set; }
        public bool? bitIsApproved { get; set; }
        public int? numDriverID { get; set; }
        public DateTime? dtApprovedDateTime { get; set; }
        public bool? bitIsStarted { get; set; }
        public DateTime? dtStartedDateTime { get; set; }
        public bool? bitIsCompleted { get; set; }
        public DateTime? dtCompletedDateTime { get; set; }
    }
}