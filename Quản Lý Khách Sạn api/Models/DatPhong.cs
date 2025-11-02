using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApi.Models
{
    [Table("DatPhong")]
    public class DatPhong
    {
        [Key]
        public int MaDatPhong { get; set; }

        public string MaDat { get; set; } = string.Empty;

        public int MaKhach { get; set; }
        public int? MaPhong { get; set; }
        public int MaLoaiPhong { get; set; }

        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoKhach { get; set; }
        public string TrangThai { get; set; } = "DaDat";
        public int? NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public string? GhiChu { get; set; }

    }
}
