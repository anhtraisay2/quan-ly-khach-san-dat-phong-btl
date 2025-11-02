
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Quản_lý_khách_sạn_mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quản_lý_khách_sạn_mvc.Controllers
{
    public class PhongController : Controller
    {
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "https://localhost:44355/api/Phong"; // Đổi thành API thật của bạn

        public PhongController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return View(new List<PhongViewModel>());

            var json = await response.Content.ReadAsStringAsync();
            var phongList = JsonSerializer.Deserialize<List<PhongViewModel>>(json);
            return View(phongList);
        }

            // GET: Phong/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Phong/Create
            [HttpPost]
            public async Task<IActionResult> Create(PhongViewModel model)
            {
                var response = await _httpClient.PostAsJsonAsync(_apiUrl, model);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Thêm phòng thất bại!");
                return View(model);
            }

            // GET: Phong/Edit/{id}
            public async Task<IActionResult> Edit(int id)
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                var json = await response.Content.ReadAsStringAsync();
                var phong = JsonSerializer.Deserialize<PhongViewModel>(json);
                return View(phong);
            }

            // POST: Phong/Edit/{id}
            [HttpPost]
            public async Task<IActionResult> Edit(PhongViewModel model)
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{model.MaPhong}", model);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Cập nhật phòng thất bại!");
                return View(model);
            }

            // GET: Phong/Delete/{id}
            public async Task<IActionResult> Delete(int id)
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                var json = await response.Content.ReadAsStringAsync();
                var phong = JsonSerializer.Deserialize<PhongViewModel>(json);
                return View(phong);
            }

            // POST: Phong/Delete/{id}
            [HttpPost]
            public async Task<IActionResult> Delete(PhongViewModel model)
            {
                var response = await _httpClient.DeleteAsync($"{_apiUrl}/{model.MaPhong}");
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Xóa phòng thất bại!");
                return View(model);
            }

            // GET: Phong/Details/{id}
            public async Task<IActionResult> Details(int id)
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                var json = await response.Content.ReadAsStringAsync();
                var phong = JsonSerializer.Deserialize<PhongViewModel>(json);
                return View(phong);
            }
    }
}
