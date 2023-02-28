using System.ComponentModel.DataAnnotations;

namespace ParcelDistributer.DataAccess.Models.Driver.Response
{
    public class AvailableDriverListResponse
    {
        [Key]
        public int numDriverID { get; set; }
        public string? varDriverName { get; set; }
        public string? varDriverAddress { get; set; }
        public string? varDriverNIC { get; set; }
        public string? varDriverContactNo { get; set; }
        public bool? bitActive { get; set; }
        public DateTime? dtCreatedDate { get; set; }
        public DateTime? dteditedDate { get; set; }
        public DateTime? dtDeletedDate { get; set; }
    }
}