using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Quản_lý_khách_sạn_mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quản_lý_khách_sạn_mvc.Controllers
{
    public class DatPhongController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:44355/api/DatPhong";

        public DatPhongController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return View(new List<DatPhongViewModel>());

            var json = await response.Content.ReadAsStringAsync();
            var datPhongList = JsonSerializer.Deserialize<List<DatPhongViewModel>>(json);
            return View(datPhongList);
        }
    }
}
