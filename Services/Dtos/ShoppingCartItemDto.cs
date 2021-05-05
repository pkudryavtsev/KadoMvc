using Services.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class ShoppingCartItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsCustom { get; set; }
        [Required]
        public string BoxName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be grater than zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        [RequiredIf("IsCustom", true)]
        public List<int> ProductIds{ get; set; }
    }
}
