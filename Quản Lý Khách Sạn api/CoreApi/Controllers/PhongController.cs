using Microsoft.AspNetCore.Mvc;
// using BLL;
using CoreApi.Models;
using CoreApi.BLL;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhongController : ControllerBase
    {
    private readonly PhongBLL_Ado _phongBLL;

        public PhongController(PhongBLL_Ado phongBLL)
        {
            _phongBLL = phongBLL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _phongBLL.LayDanhSach()
                .Select(p => new {
                    maPhong = p.MaPhong,
                    soPhong = p.SoPhong,
                    maLoaiPhong = p.MaLoaiPhong,
                    tinhTrang = p.TinhTrang
                });
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _phongBLL.LayTheoId(id);
            if (p == null) return NotFound();
            var dto = new {
                maPhong = p.MaPhong,
                soPhong = p.SoPhong,
                maLoaiPhong = p.MaLoaiPhong,
                tinhTrang = p.TinhTrang
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(Phong phong)
        {
            var id = _phongBLL.ThemVaLayId(phong);
            var p = _phongBLL.LayTheoId(id);
            return Ok(new {
                maPhong = p.MaPhong,
                soPhong = p.SoPhong,
                maLoaiPhong = p.MaLoaiPhong,
                tinhTrang = p.TinhTrang
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Phong phong)
        {
            if (phong == null || id <= 0 || phong.MaPhong != id || string.IsNullOrWhiteSpace(phong.SoPhong) || phong.MaLoaiPhong <= 0 || string.IsNullOrWhiteSpace(phong.TinhTrang))
            {
                return BadRequest("Dữ liệu phòng không hợp lệ!");
            }
            try
            {
                _phongBLL.CapNhat(phong);
                return Ok(phong);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _phongBLL.Xoa(id);
            return Ok();
        }
    }
}
