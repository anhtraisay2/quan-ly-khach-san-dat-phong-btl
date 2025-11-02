using System.ComponentModel.DataAnnotations;

namespace Quản_lý_khách_sạn_mvc.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string TenDangNhap { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}