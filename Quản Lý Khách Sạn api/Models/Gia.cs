using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class Gia
    {
        [Key]
        public int MaGia { get; set; }

        [Required]
        public int MaLoaiPhong { get; set; }

        [ForeignKey(nameof(MaLoaiPhong))]
        public LoaiPhong LoaiPhong { get; set; }

        [Required]
        public DateTime TuNgay { get; set; }

        [Required]
        public DateTime DenNgay { get; set; }

        [Required]
        public decimal GiaMoiDem { get; set; }

        public decimal? GiaMoiGio { get; set; }

        [MaxLength(300)]
        public string GhiChu { get; set; }
    }
}