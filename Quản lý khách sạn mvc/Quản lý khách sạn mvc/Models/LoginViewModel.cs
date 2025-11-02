using System.ComponentModel.DataAnnotations;

namespace Quản_lý_khách_sạn_mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        public string TenDangNhap { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
    }
}