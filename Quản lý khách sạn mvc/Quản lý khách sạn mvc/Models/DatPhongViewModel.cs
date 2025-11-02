using System.Text.Json.Serialization;
namespace Quản_lý_khách_sạn_mvc.Models
{
    public class DatPhongViewModel
    {
        [JsonPropertyName("maDatPhong")]
        public int MaDatPhong { get; set; }

        [JsonPropertyName("maDat")]
        public string MaDat { get; set; }

        [JsonPropertyName("maKhach")]
        public int MaKhach { get; set; }

        [JsonPropertyName("maPhong")]
        public int MaPhong { get; set; }

        [JsonPropertyName("maLoaiPhong")]
        public int MaLoaiPhong { get; set; }

        [JsonPropertyName("ngayNhan")]
        public DateTime NgayNhan { get; set; }

        [JsonPropertyName("ngayTra")]
        public DateTime NgayTra { get; set; }

        [JsonPropertyName("soKhach")]
        public int SoKhach { get; set; }

        [JsonPropertyName("trangThai")]
        public string TrangThai { get; set; }

        [JsonPropertyName("nguoiTao")]
        public int? NguoiTao { get; set; }

        [JsonPropertyName("ngayTao")]
        public DateTime? NgayTao { get; set; }

        [JsonPropertyName("ghiChu")]
        public string GhiChu { get; set; }
    }
}