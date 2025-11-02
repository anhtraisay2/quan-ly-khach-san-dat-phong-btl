using Microsoft.AspNetCore.Mvc;
// using BLL;
using CoreApi.BLL;
using CoreApi.Models;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoaDonController : ControllerBase
    {
    private readonly HoaDonBLL_Ado _hoaDonBLL;

        public HoaDonController(HoaDonBLL_Ado hoaDonBLL)
        {
            _hoaDonBLL = hoaDonBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_hoaDonBLL.LayDanhSach());

        [HttpPost]
        public IActionResult Them([FromBody] HoaDon hoaDon)
        {
            _hoaDonBLL.Them(hoaDon);
            return Ok("Đã thêm hóa đơn");
        }

        [HttpPut]
        public IActionResult CapNhat([FromBody] HoaDon hoaDon)
        {
            _hoaDonBLL.CapNhat(hoaDon);
            return Ok("Đã cập nhật hóa đơn");
        }

        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            _hoaDonBLL.Xoa(id);
            return Ok("Đã xóa hóa đơn");
        }
    }
}
