namespace Quản_lý_khách_sạn_mvc.Models
{
    public class GiaViewModel
    {
        public int MaGia { get; set; }
        public int MaLoaiPhong { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public decimal GiaMoiDem { get; set; }
        public decimal? GiaMoiGio { get; set; }
        public string GhiChu { get; set; }
    }
}