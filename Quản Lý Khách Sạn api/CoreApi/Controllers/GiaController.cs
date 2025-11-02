using Microsoft.AspNetCore.Mvc;
using CoreApi.BLL;
using CoreApi.Models;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiaController : ControllerBase
    {
        private readonly GiaBLL_Ado _giaBLL;

        public GiaController(GiaBLL_Ado giaBLL)
        {
            _giaBLL = giaBLL;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _giaBLL.LayTatCa()
                .Select(g => new GiaDto {
                    MaGia = g.MaGia,
                    MaLoaiPhong = g.MaLoaiPhong,
                    TuNgay = g.TuNgay,
                    DenNgay = g.DenNgay,
                    GiaMoiDem = g.GiaMoiDem,
                    GiaMoiGio = g.GiaMoiGio,
                    GhiChu = g.GhiChu
                });
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gia = _giaBLL.LayTheoId(id);
            if (gia == null) return NotFound();
            var dto = new GiaDto {
                MaGia = gia.MaGia,
                MaLoaiPhong = gia.MaLoaiPhong,
                TuNgay = gia.TuNgay,
                DenNgay = gia.DenNgay,
                GiaMoiDem = gia.GiaMoiDem,
                GiaMoiGio = gia.GiaMoiGio,
                GhiChu = gia.GhiChu
            };
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Create(Gia gia)
        {
            _giaBLL.Them(gia);
            var dto = new GiaDto {
                MaGia = gia.MaGia,
                MaLoaiPhong = gia.MaLoaiPhong,
                TuNgay = gia.TuNgay,
                DenNgay = gia.DenNgay,
                GiaMoiDem = gia.GiaMoiDem,
                GiaMoiGio = gia.GiaMoiGio,
                GhiChu = gia.GhiChu
            };
            return Ok(dto);
        }

        [HttpPut]
        public IActionResult Update(Gia gia)
        {
            _giaBLL.CapNhat(gia);
            var dto = new GiaDto {
                MaGia = gia.MaGia,
                MaLoaiPhong = gia.MaLoaiPhong,
                TuNgay = gia.TuNgay,
                DenNgay = gia.DenNgay,
                GiaMoiDem = gia.GiaMoiDem,
                GiaMoiGio = gia.GiaMoiGio,
                GhiChu = gia.GhiChu
            };
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _giaBLL.Xoa(id);
            return Ok();
        }
    }
}
