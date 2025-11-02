using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class Khach
    {
        [Key]
        public int MaKhach { get; set; }

        [Required, MaxLength(200)]
        public string HoTen { get; set; }

        [MaxLength(50)]
        public string DienThoai { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string CMND { get; set; }

        [MaxLength(300)]
        public string DiaChi { get; set; }
    }
}

