using Microsoft.AspNetCore.Mvc;
using CoreApi.BLL;
// using BLL;
using CoreApi.Models;
using Microsoft.AspNetCore.Authorization;
namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DichVuController : ControllerBase
    {
    private readonly DichVuBLL_Ado _dichVuBLL;

        public DichVuController(DichVuBLL_Ado dichVuBLL)
        {
            _dichVuBLL = dichVuBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_dichVuBLL.LayDanhSach());

        [HttpPost]
        public IActionResult Them([FromBody] DichVu dichVu)
        {
            _dichVuBLL.Them(dichVu);
            return Ok("Đã thêm dịch vụ");
        }

        [HttpPut]
        public IActionResult CapNhat([FromBody] DichVu dichVu)
        {
            _dichVuBLL.CapNhat(dichVu);
            return Ok("Đã cập nhật dịch vụ");
        }

        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            _dichVuBLL.Xoa(id);
            return Ok("Đã xóa dịch vụ");
        }
    }
}
