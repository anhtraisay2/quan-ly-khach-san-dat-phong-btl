using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Quản_lý_khách_sạn_mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quản_lý_khách_sạn_mvc.Controllers
{

    public class GiaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:44355/api/Gia";

        public GiaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return View(new List<GiaViewModel>());

            var json = await response.Content.ReadAsStringAsync();
            var giaList = JsonSerializer.Deserialize<List<GiaViewModel>>(json, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
            return View(giaList);
        }

        public IActionResult Create()
        {
            // Lấy danh sách loại phòng từ API
            var response = _httpClient.GetAsync("https://localhost:44355/api/LoaiPhong").Result;
            var loaiPhongList = new List<LoaiPhongViewModel>();
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                loaiPhongList = JsonSerializer.Deserialize<List<LoaiPhongViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            ViewBag.LoaiPhongList = loaiPhongList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiaViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiUrl, model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Thêm giá thất bại!");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            var json = await response.Content.ReadAsStringAsync();
            var gia = JsonSerializer.Deserialize<GiaViewModel>(json);
            return View(gia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GiaViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{model.MaGia}", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Cập nhật giá thất bại!");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            var json = await response.Content.ReadAsStringAsync();
            var gia = JsonSerializer.Deserialize<GiaViewModel>(json);
            return View(gia);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GiaViewModel model)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{model.MaGia}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            ModelState.AddModelError("", "Xóa giá thất bại!");
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            var json = await response.Content.ReadAsStringAsync();
            var gia = JsonSerializer.Deserialize<GiaViewModel>(json);
            return View(gia);
        }
    }
}
