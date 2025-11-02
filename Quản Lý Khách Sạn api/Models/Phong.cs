using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class Phong
    {
        [Key]
        public int MaPhong { get; set; }

        [Required, MaxLength(20)]
        public string SoPhong { get; set; }

        [Required]
        public int MaLoaiPhong { get; set; }
        [ForeignKey("MaLoaiPhong")]
        public virtual LoaiPhong? LoaiPhong { get; set; }  // thêm "virtual" và cho phép null để tránh vòng lặp JSON

        [Required, MaxLength(50)]
        public string TinhTrang { get; set; } = "SanSang";
    }
}