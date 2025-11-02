using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class HoaDonChiTiet
    {
        [Key]
        public int MaCTHD { get; set; }

        [Required]
        public int MaHD { get; set; }
        [ForeignKey(nameof(MaHD))]
        public HoaDon HoaDon { get; set; }

        public int? MaDatPhong { get; set; }
        [ForeignKey(nameof(MaDatPhong))]
        public DatPhong DatPhong { get; set; }

        public int? MaDV { get; set; }
        [ForeignKey(nameof(MaDV))]
        public DichVu DichVu { get; set; }

        [Required]
        public int SoLuong { get; set; } = 1;

        [Required]
        public decimal DonGia { get; set; }

        [NotMapped]
        public decimal ThanhTien => SoLuong * DonGia;
    }
}