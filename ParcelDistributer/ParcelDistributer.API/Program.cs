using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParcelDistributer.DataAccess;
using ParcelDistributer.DataAccess.Models;
using ParcelDistributer.Service.Booking;
using ParcelDistributer.Service.Customer;
using ParcelDistributer.Service.Driver;
using ParcelDistributer.Service.GoodsType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services
    .AddDbContext<DistributerContext>(opt => opt.UseSqlServer(builder.Configuration
    .GetConnectionString("dbConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

//Repository Services
builder.Services.AddScoped<ICustomerRepository, CustomerService>();
builder.Services.AddScoped<IDriverRepository, DriverService>();
builder.Services.AddScoped<IBookingRepository, BookingService>();
builder.Services.AddScoped<IGoodsTypeRepository, GoodsTypeService>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseCors(options =>
   options.WithOrigins("http://localhost:4200")
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
});

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();