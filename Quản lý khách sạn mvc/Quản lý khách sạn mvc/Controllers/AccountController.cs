using Microsoft.AspNetCore.Mvc;
using Quản_lý_khách_sạn_mvc.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Quản_lý_khách_sạn_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:44355/api/NguoiDung/Login";

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // ===================== ĐĂNG NHẬP =====================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Chuẩn bị dữ liệu gửi đến API Login
            var loginData = new
            {
                TenDangNhap = model.TenDangNhap,
                MatKhau = model.MatKhau
            };

            var content = new StringContent(
                JsonSerializer.Serialize(loginData),
                Encoding.UTF8,
                "application/json"
            );

            // Gọi API POST /api/NguoiDung/Login
            var response = await _httpClient.PostAsync(_apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                return View(model);
            }

            // Đọc dữ liệu người dùng trả về
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<NguoiDungApiModel>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Lưu session đăng nhập
            HttpContext.Session.SetString("VaiTro", user.vaiTro);
            HttpContext.Session.SetString("TenDangNhap", user.tenDangNhap);

            return RedirectToAction("Index", "Home");
        }

        // ===================== MODEL TỪ API =====================
        public class NguoiDungApiModel
        {
            public int maND { get; set; }
            public string tenDangNhap { get; set; }
            public string hoTen { get; set; }
            public string vaiTro { get; set; }
        }

        // ===================== ĐĂNG XUẤT =====================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // ===================== ĐĂNG KÝ =====================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var content = new StringContent(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:44355/api/NguoiDung", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Đăng ký thất bại!");
                return View(model);
            }

            TempData["RegisterSuccess"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }

        // ===================== QUÊN MẬT KHẨU =====================
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Demo: không thật sự gửi email
            TempData["ForgotSuccess"] = "Yêu cầu đã được gửi. Vui lòng kiểm tra email.";
            return View();
        }
    }
}
