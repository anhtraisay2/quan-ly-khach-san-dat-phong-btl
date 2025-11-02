using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class LoaiPhong
    {
        [Key]
        public int MaLoaiPhong { get; set; }

        [Required, MaxLength(50)]
        public string Ma { get; set; }

        [Required, MaxLength(200)]
        public string Ten { get; set; }

        [MaxLength(500)]
        public string MoTa { get; set; }

        public int SoKhachToiDa { get; set; } = 2;

        public ICollection<Phong> Phongs { get; set; }
        public ICollection<Gia> BangGias { get; set; }
    }
}