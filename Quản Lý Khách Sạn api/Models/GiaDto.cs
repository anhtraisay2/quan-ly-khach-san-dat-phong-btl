namespace CoreApi.Models
{
    public class GiaDto
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
