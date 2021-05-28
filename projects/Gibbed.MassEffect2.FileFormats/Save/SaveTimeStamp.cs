using System;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveTimeStamp : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Seconds Since Midnight")]
        public int SecondsSinceMidnight;

        [UnrealFieldDisplayName("Day")]
        public int Day;

        [UnrealFieldDisplayName("Month")]
        public int Month;

        [UnrealFieldDisplayName("Year")]
        public int Year;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.SecondsSinceMidnight);
            stream.Serialize(ref this.Day);
            stream.Serialize(ref this.Month);
            stream.Serialize(ref this.Year);
        }

        public override string ToString()
        {
            var hours = (int)Math.Round((this.SecondsSinceMidnight / 60.0) / 60.0);
            var minutes = (int)Math.Round(this.SecondsSinceMidnight / 60.0) % 60;
            return $"{this.Day}/{this.Month}/{this.Year} {hours}:{minutes:D2}";
                
        }
    }
}
