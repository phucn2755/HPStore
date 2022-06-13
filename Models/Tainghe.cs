using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace HPStore.Models
{
    public class Tainghe
    {
        public long TaingheID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên tai nghe")]
        public string TenTainghe { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Gia { get; set; }
        public string Hang { get; set; }
        public string Mota { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại tai nghe")]
        public string Loai { get; set; }
    }
}
