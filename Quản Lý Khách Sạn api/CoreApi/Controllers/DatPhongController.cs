using Microsoft.AspNetCore.Mvc;
// using BLL;
using CoreApi.BLL;
using CoreApi.Models;
// using CoreApi.DAL;
namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatPhongController : ControllerBase
    {
    private readonly DatPhongBLL_Ado _datPhongBLL;

        public DatPhongController(DatPhongBLL_Ado datPhongBLL)
        {
            _datPhongBLL = datPhongBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_datPhongBLL.LayDanhSach());

        [HttpPost]
        public IActionResult Them([FromBody] DatPhong datPhong)
        {
            _datPhongBLL.Them(datPhong);
            return Ok("Đã thêm đặt phòng");
        }

        [HttpPut]
        public IActionResult CapNhat([FromBody] DatPhong datPhong)
        {
            _datPhongBLL.CapNhat(datPhong);
            return Ok("Đã cập nhật đặt phòng");
        }

        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            _datPhongBLL.Xoa(id);
            return Ok("Đã xóa đặt phòng");
        }
    }
}
