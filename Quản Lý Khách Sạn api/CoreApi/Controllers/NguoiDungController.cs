using Microsoft.AspNetCore.Mvc;
// using BLL;
using CoreApi.BLL;
using CoreApi.Models;


namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NguoiDungController : ControllerBase
    {
    private readonly NguoiDungBLL_Ado _nguoiDungBLL;

        public NguoiDungController(NguoiDungBLL_Ado nguoiDungBLL)
        {
            _nguoiDungBLL = nguoiDungBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_nguoiDungBLL.LayDanhSach());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _nguoiDungBLL.LayTheoId(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // Đăng nhập chuyên nghiệp, trả về thông tin người dùng (không trả về mật khẩu)
        public class NguoiDungLoginModel {
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] NguoiDungLoginModel login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.TenDangNhap) || string.IsNullOrWhiteSpace(login.MatKhau))
                return BadRequest("Thiếu thông tin đăng nhập");
            var tenDangNhap = login.TenDangNhap.Trim().ToLower();
            var matKhau = login.MatKhau.Trim();
            var user = _nguoiDungBLL.LayDanhSach().FirstOrDefault(x =>
                x.TenDangNhap.Trim().ToLower() == tenDangNhap &&
                x.MatKhau.Trim() == matKhau
            );
            if (user == null)
                return Unauthorized();
            // Trả về thông tin cần thiết cho FE
            return Ok(new
            {
                tenDangNhap = user.TenDangNhap,
                hoTen = user.HoTen,
                vaiTro = user.VaiTro
            });
        }

        [HttpPost]
        public IActionResult Them([FromBody] NguoiDung nguoiDung)
        {
            _nguoiDungBLL.Them(nguoiDung);
            return Ok("Đã thêm người dùng");
        }

        [HttpPut]
        public IActionResult CapNhat([FromBody] NguoiDung nguoiDung)
        {
            _nguoiDungBLL.CapNhat(nguoiDung);
            return Ok("Đã cập nhật người dùng");
        }

        [HttpDelete("{id}")]
        public IActionResult Xoa(int id)
        {
            _nguoiDungBLL.Xoa(id);
            return Ok("Đã xóa người dùng");
        }
    }
}
