using Microsoft.AspNetCore.Mvc;
using Quản_lý_khách_sạn_mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Quản_lý_khách_sạn_mvc.Controllers
{
    public class HoaDonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HoaDonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44355/api/HoaDon");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<HoaDonViewModel>());
            }
            var json = await response.Content.ReadAsStringAsync();
            var hoaDonList = JsonConvert.DeserializeObject<List<HoaDonViewModel>>(json);
            return View(hoaDonList);
        }
    }
}
