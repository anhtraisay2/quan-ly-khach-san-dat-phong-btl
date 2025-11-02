using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class NguoiDung
    {
        [Key]
        public int MaND { get; set; }

        [Required, MaxLength(100)]
        public string TenDangNhap { get; set; }

        [Required, MaxLength(500)]
        public string MatKhau { get; set; }

        [MaxLength(200)]
        public string HoTen { get; set; }

        [Required, MaxLength(50)]
        public string VaiTro { get; set; } // Admin, LeTan, KeToan, Khach
    }
}

