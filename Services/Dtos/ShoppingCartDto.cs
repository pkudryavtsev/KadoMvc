using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class ShoppingCartDto
    {
        [Required]
        public string Id { get; set; }
        public List<ShoppingCartItemDto> Items { get; set; }
    }
}
