using Microsoft.AspNetCore.Mvc;
using CoreApi.BLL;
using CoreApi.Models;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiPhongController : ControllerBase
    {
        private readonly LoaiPhongBLL_Ado _loaiPhongBLL;

        public LoaiPhongController(LoaiPhongBLL_Ado loaiPhongBLL)
        {
            _loaiPhongBLL = loaiPhongBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_loaiPhongBLL.LayTatCa());
    }
}
