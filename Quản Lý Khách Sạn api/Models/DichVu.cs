using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class DichVu
    {
        [Key]
        public int MaDV { get; set; }

        [Required, MaxLength(50)]
        public string Ma { get; set; }

        [Required, MaxLength(200)]
        public string Ten { get; set; }

        [Required]
        public decimal DonGia { get; set; }

        public decimal Thue { get; set; } = 0;
    }
}
