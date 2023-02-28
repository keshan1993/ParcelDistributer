using Microsoft.AspNetCore.Mvc;
using ParcelDistributer.API.Extensions;
using ParcelDistributer.DataAccess.Models.Base;
using ParcelDistributer.DataAccess.Models.GoodsType.Models;
using ParcelDistributer.DataAccess.Models.GoodsType.Response;
using ParcelDistributer.Service.GoodsType;

namespace ParcelDistributer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoodsTypeController : ControllerBase
    {
        private IGoodsTypeRepository _goodsTypeService;

        public GoodsTypeController(IGoodsTypeRepository goodsTypeService)
        {
            _goodsTypeService = goodsTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GoodsTypeListResponse response = await _goodsTypeService.Get();
            return this.Send(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GoodsType goodsType)
        {
            BaseResponse response = await _goodsTypeService.Post(goodsType);
            return this.Send(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GoodsType goodsType)
        {
            BaseResponse response = await _goodsTypeService.Put(goodsType);
            return this.Send(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int numGoodsTypeID)
        {
            BaseResponse response = await _goodsTypeService.Delete(numGoodsTypeID);
            return this.Send(response);
        }
    }
}