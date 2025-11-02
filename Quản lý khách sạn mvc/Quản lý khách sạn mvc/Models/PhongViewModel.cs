using System.Text.Json.Serialization;
namespace Quản_lý_khách_sạn_mvc.Models
{
    public class PhongViewModel
    {
        [JsonPropertyName("maPhong")]
        public int MaPhong { get; set; }

        [JsonPropertyName("soPhong")]
        public string SoPhong { get; set; }

        [JsonPropertyName("maLoaiPhong")]
        public int MaLoaiPhong { get; set; }

        [JsonPropertyName("tinhTrang")]
        public string TinhTrang { get; set; }
    }
}
