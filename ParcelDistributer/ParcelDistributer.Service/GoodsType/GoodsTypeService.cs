using AutoMapper;
using ParcelDistributer.DataAccess;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.GoodsType.DTOs;
using ParcelDistributer.DataAccess.Models.GoodsType.Response;

namespace ParcelDistributer.Service.GoodsType
{
    public class GoodsTypeService : IGoodsTypeRepository
    {
        private readonly DistributerContext _context;
        private readonly IMapper _autoMapper;

        public GoodsTypeService(DistributerContext context, IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public async Task<GoodsTypeListResponse> Get()
        {
            try
            {
                var itemList = _context.GoodsType.Where(i => i.bitActive == true).ToList();
                return new GoodsTypeListResponse()
                {
                    GoodsTypes = _autoMapper.Map<List<GoodsTypeDTO>>(itemList),
                    bitSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GoodsTypeListResponse() { Error = ValidateGoodsType(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.GoodsType.Models.GoodsType item)
        {
            try
            {
                var _item = new ParcelDistributer.DataAccess.Models.GoodsType.Models.GoodsType()
                {
                    varGoodsTypeName = item.varGoodsTypeName,
                    varGoodsTypeDescription = item.varGoodsTypeDescription,
                    bitActive = true,
                    dtCreatedDate = DateTime.Now,
                };
                _context.GoodsType.Add(_item);
                _context.SaveChanges();

                return new BaseResponse()
                {
                    bitSuccess = true,
                    numCreatedID = _item.numGoodsTypeID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateGoodsType(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.GoodsType.Models.GoodsType item)
        {
            try
            {
                var resulktSet = _context.GoodsType.FirstOrDefault(x => x.numGoodsTypeID.Equals(item.numGoodsTypeID));
                resulktSet.varGoodsTypeName = item.varGoodsTypeName;
                resulktSet.varGoodsTypeDescription = item.varGoodsTypeDescription;
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
                    numCreatedID = item.numGoodsTypeID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateGoodsType(ex), bitSuccess = false };
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="numGoodsTypeID"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Delete(int numGoodsTypeID)
        {
            try
            {
                var resulktSet = _context.GoodsType.FirstOrDefault(x => x.numGoodsTypeID.Equals(numGoodsTypeID));
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
                    numCreatedID = numGoodsTypeID
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse() { Error = ValidateGoodsType(ex), bitSuccess = false };
            }
        }

        private ErrorDTO ValidateGoodsType(Exception exception)
        {
            return new ErrorDTO()
            {
                ErrorType = exception.GetType().Name,
                ErrorMessage = exception.Message
            };
        }
    }
}