using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }

        [Required, MaxLength(50)]
        public string SoHD { get; set; }

        [Required]
        public int MaKhach { get; set; }
        [ForeignKey(nameof(MaKhach))]

        [Required]
        public int MaND { get; set; }
        [ForeignKey(nameof(MaND))]

        [Required]
        public DateTime NgayLap { get; set; } = DateTime.Now;

        public decimal TongTien { get; set; } = 0;
        public string HinhThucThanhToan { get; set; }
        public decimal SoTienDaTra { get; set; } = 0;

        [NotMapped]
        public decimal SoTienConNo => TongTien - SoTienDaTra;
    }
}
