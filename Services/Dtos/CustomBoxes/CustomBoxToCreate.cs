using ProductDb.DataClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.CustomBoxes
{
    public class CustomBoxToCreate
    {
        public BoxSize Size { get; set; }
        public BoxColor Color { get; set; }
        public double Price { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
