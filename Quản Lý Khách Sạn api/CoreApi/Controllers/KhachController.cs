using Microsoft.AspNetCore.Mvc;
using CoreApi.BLL;
// using BLL;
using CoreApi.Models;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KhachController : ControllerBase
    {
    private readonly KhachBLL_Ado _khachBLL;

        public KhachController(KhachBLL_Ado khachBLL)
        {
            _khachBLL = khachBLL;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_khachBLL.LayTatCa());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var khach = _khachBLL.LayTheoId(id);
            if (khach == null) return NotFound();
            return Ok(khach);
        }

        [HttpPost]
        public IActionResult Create(Khach khach)
        {
            _khachBLL.Them(khach);
            return Ok(khach);
        }

        [HttpPut]
        public IActionResult Update(Khach khach)
        {
            _khachBLL.CapNhat(khach);
            return Ok(khach);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _khachBLL.Xoa(id);
            return Ok();
        }
    }
}


