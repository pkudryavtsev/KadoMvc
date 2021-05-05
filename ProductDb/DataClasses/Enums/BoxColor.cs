using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses.Enums
{
    public enum BoxColor
    {
        [EnumMember(Value = "black")]
        Black = 1,
        [EnumMember(Value = "red")]
        Red,
        [EnumMember(Value = "blue")]
        Blue,
        [EnumMember(Value = "green")]
        Green
    }
}
