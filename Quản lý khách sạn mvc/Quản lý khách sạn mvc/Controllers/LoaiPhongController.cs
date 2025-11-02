using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Quản_lý_khách_sạn_mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quản_lý_khách_sạn_mvc.Controllers
{
    public class LoaiPhongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:44355/api/LoaiPhong"; // Đổi thành API thật của bạn

        public LoaiPhongController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return View(new List<LoaiPhongViewModel>());

            var json = await response.Content.ReadAsStringAsync();
            var loaiPhongList = JsonSerializer.Deserialize<List<LoaiPhongViewModel>>(json, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
            return View(loaiPhongList);
        }
    }
}
