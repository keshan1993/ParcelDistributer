using Microsoft.EntityFrameworkCore;
using ParcelDistributer.DataAccess.Models.Booking.Models;
using ParcelDistributer.DataAccess.Models.Customer.Models;
using ParcelDistributer.DataAccess.Models.Customer.Response;
using ParcelDistributer.DataAccess.Models.Driver.Models;
using ParcelDistributer.DataAccess.Models.Driver.Response;
using ParcelDistributer.DataAccess.Models.GoodsType.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDistributer.DataAccess
{
    public class DistributerContext : DbContext
    {
        public DistributerContext(DbContextOptions<DistributerContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<GoodsType> GoodsType { get; set; }


        [NotMapped]
        public DbSet<AvailableDriverListResponse> AvailableDriverListResponse { get; set; }
    }
}