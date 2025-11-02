using System.ComponentModel.DataAnnotations;

namespace Quản_lý_khách_sạn_mvc.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string TenDangNhap { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public string VaiTro { get; set; } // Admin, LeTan, KeToan, Khach
    }
}