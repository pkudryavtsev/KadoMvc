using ProductDb.DataClasses.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses
{
    [Table("Boxes")]
    public class Box : BaseEntity
    {
        public string Name { get; set; }
        public BoxSize Size { get; set; } = BoxSize.Small;
        public BoxColor Color { get; set; } = BoxColor.Black;
        public double Price { get; set; }
        public int Stock { get; set; }
        public IList<BoxProduct> BoxProducts { get; set; }
    }
}
