using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public bool IsCustom { get; set; }
        public string BoxName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
