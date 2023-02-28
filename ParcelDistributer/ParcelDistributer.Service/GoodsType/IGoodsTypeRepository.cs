using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.GoodsType.Response;

namespace ParcelDistributer.Service.GoodsType
{
    public interface IGoodsTypeRepository
    {
        public Task<GoodsTypeListResponse> Get();

        public Task<BaseResponse> Post(ParcelDistributer.DataAccess.Models.GoodsType.Models.GoodsType goodsType);

        public Task<BaseResponse> Put(ParcelDistributer.DataAccess.Models.GoodsType.Models.GoodsType goodsType);

        public Task<BaseResponse> Delete(int numGoodsTypeID);
    }
}