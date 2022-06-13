using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HPStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn")]
        public string Line1 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên thành phố ")]
        public string City { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số liên lạc")]
        public string Phonenumber { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
    }
}
