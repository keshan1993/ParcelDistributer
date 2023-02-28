namespace ParcelDistributer.DataAccess.Models.Driver.DTOs
{
    public class AvailableDriverListResponseDTO
    {
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