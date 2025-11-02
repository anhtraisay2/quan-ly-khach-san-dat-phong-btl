using Microsoft.AspNetCore.Mvc;
// using BLL;
using CoreApi.BLL;
using CoreApi.Models;


namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoaDonChiTietController : ControllerBase
    {
    private readonly HoaDonChiTietBLL_Ado _hoaDonChiTietBLL;

        public HoaDonChiTietController(HoaDonChiTietBLL_Ado hoaDonChiTietBLL)
        {
            _hoaDonChiTietBLL = hoaDonChiTietBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_hoaDonChiTietBLL.LayDanhSach());

        [HttpPost]
        public IActionResult Them([FromBody] HoaDonChiTiet hoaDonChiTiet)
        {
            _hoaDonChiTietBLL.Them(hoaDonChiTiet);
            return Ok("Đã thêm chi tiết hóa đơn");
        }

        [HttpPut]
        public IActionResult CapNhat([FromBody] HoaDonChiTiet hoaDonChiTiet)
        {
            _hoaDonChiTietBLL.CapNhat(hoaDonChiTiet);
            return Ok("Đã cập nhật chi tiết hóa đơn");
        }

        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            _hoaDonChiTietBLL.Xoa(id);
            return Ok("Đã xóa chi tiết hóa đơn");
        }
    }
}
