using System.Collections.Generic;
using ProductDb.DataClasses;
using ProductDb.DataClasses.Enums;
using Services.Dtos.Boxes;

namespace Services.Dtos.Boxes
{
    public class BoxToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BoxSize Size { get; set; } = BoxSize.Small;
        public List<BoxProductToReturnDto> Products { get; set; }
        
    }
}