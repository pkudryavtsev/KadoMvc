using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses
{
    [Table("Brands")]
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }
    }
}
