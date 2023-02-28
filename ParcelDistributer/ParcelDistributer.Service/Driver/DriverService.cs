using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ParcelDistributer.DataAccess;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.Driver.Response;
using System.Data;

namespace ParcelDistributer.Service.Driver
{
    public class DriverService : IDriverRepository
    {
        private readonly DistributerContext _context;
        private readonly IMapper _autoMapper;

        public DriverService(DistributerContext context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<DriverListResponse> Get()
        {
            try
            {
                var driverList = _context.Driver.Where(i => i.bitActive == true).ToList();
                return new DriverListResponse()
                {
                    Drivers = _autoMapper.Map<List<ParcelDistributer.DataAccess.Models.Driver.Models.Driver>>(driverList),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DriverListResponse() { Error = ValidateDriver(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.Driver.Models.Driver driver)
        {
            try
            {
                var _driver = new ParcelDistributer.DataAccess.Models.Driver.Models.Driver()
                {
                    varDriverName = driver.varDriverName,
                    varDriverAddress = driver.varDriverAddress,
                    varDriverNIC = driver.varDriverNIC,
                    varDriverContactNo = driver.varDriverContactNo,
                    varDriverUserName = driver.varDriverUserName,
                    varDriverUserPassword = driver.varDriverUserPassword,
                    bitActive = true,
                    dtCreatedDate = DateTime.Now,
                };
                _context.Driver.Add(_driver);
                _context.SaveChanges();

                return new BaseResponse()
                {
                    bitSuccess = true,
                    numCreatedID = _driver.numDriverID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateDriver(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.Driver.Models.Driver driver)
        {
            try
            {
                var resulktSet = _context.Driver.FirstOrDefault(x => x.numDriverID.Equals(driver.numDriverID));
                resulktSet.varDriverName = driver.varDriverName;
                resulktSet.varDriverAddress = driver.varDriverAddress;
                resulktSet.varDriverNIC = driver.varDriverNIC;
                resulktSet.varDriverContactNo = driver.varDriverContactNo;
                resulktSet.varDriverUserName = driver.varDriverUserName;
                resulktSet.varDriverUserPassword = driver.varDriverUserPassword;
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
                    numCreatedID = driver.numDriverID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateDriver(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numDriverID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Delete(int numDriverID)
        {
            try
            {
                var resulktSet = _context.Driver.FirstOrDefault(x => x.numDriverID.Equals(numDriverID));
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
                    numCreatedID = numDriverID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateDriver(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// GetAvailableDrivers
        /// </summary>
        /// <param>dtDeliveryDate</param>
        /// <returns></returns>
        public async Task<DriverAvailablityListResponse> GetAvailableDrivers(string dtDeliveryDate)
        {
            try
            {
                var parameter = new SqlParameter();
                parameter.ParameterName = "@dtDeliveryDate";
                parameter.SqlDbType = SqlDbType.DateTime;
                parameter.IsNullable = true;
                parameter.SqlValue = (object)Convert.ToDateTime(dtDeliveryDate) ?? DBNull.Value;

                var driverLists = _context.AvailableDriverListResponse.FromSqlRaw("EXEC spFindAvailableDriver @dtDeliveryDate", parameter).ToList();

                return new DriverAvailablityListResponse()
                {
                    Drivers = _autoMapper.Map<List<AvailableDriverListResponse>>(driverLists),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DriverAvailablityListResponse() { Error = ValidateDriver(ex), bitSuccess = false };
            }
        }

        private ErrorDTO ValidateDriver(Exception exception)
        {
            return new ErrorDTO()
            {
                ErrorType = exception.GetType().Name,
                ErrorMessage = exception.Message
            };
        }
    }
}