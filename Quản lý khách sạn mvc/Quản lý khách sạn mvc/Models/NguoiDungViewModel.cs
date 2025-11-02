using System.Text.Json.Serialization;

namespace Quản_lý_khách_sạn_mvc.Models
{
    public class NguoiDungViewModel
    {
        [JsonPropertyName("tenDangNhap")]
        public string TenDangNhap { get; set; }

        [JsonPropertyName("hoTen")]
        public string HoTen { get; set; }

        [JsonPropertyName("vaiTro")]
        public string VaiTro { get; set; }
    }
}