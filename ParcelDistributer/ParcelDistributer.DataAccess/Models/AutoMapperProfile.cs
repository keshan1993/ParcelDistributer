using AutoMapper;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Booking.DTOs;
using ParcelDistributer.DataAccess.Models.Customer.DTOs;
using ParcelDistributer.DataAccess.Models.Driver.DTOs;
using ParcelDistributer.DataAccess.Models.Driver.Response;
using ParcelDistributer.DataAccess.Models.GoodsType.DTOs;

namespace ParcelDistributer.DataAccess.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BaseModel, BaseModelDTO>().IncludeAllDerived().ReverseMap();
            CreateMap<Customer.Models.Customer, CustomerDTO>().IncludeAllDerived().ReverseMap();
            CreateMap<Driver.Models.Driver, DriverDTO>().IncludeAllDerived().ReverseMap();
            CreateMap<Booking.Models.Booking, BookingDTO>().IncludeAllDerived().ReverseMap();
            CreateMap<GoodsType.Models.GoodsType, GoodsTypeDTO>().IncludeAllDerived().ReverseMap();
            CreateMap<AvailableDriverListResponse, AvailableDriverListResponseDTO>().IncludeAllDerived().ReverseMap();
        }
    }
}