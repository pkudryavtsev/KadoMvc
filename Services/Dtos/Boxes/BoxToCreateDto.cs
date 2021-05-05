using System.Collections.Generic;
using ProductDb.DataClasses.Enums;

namespace Services.Dtos.Boxes
{
    public class BoxToCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BoxSize Size { get; set; } 
        public BoxColor Color { get; set; }
        public List<int> ProductIds { get; set; }
    }
}