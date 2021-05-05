using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public int Stock { get; set; }
        public double Depth { get; set; }
        public double Area { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int? ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public String Tags { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<BoxProduct> BoxProducts { get; set; }

    }
}
