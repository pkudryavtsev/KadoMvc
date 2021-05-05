using System.Runtime.Serialization;

namespace ProductDb.DataClasses.Enums
{
    public enum BoxSize
    {
        [EnumMember(Value = "small")]
        Small = 1,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "large")]
        Large
    }
}