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
            return String.Format("{0}/{1}/{2} {3}:{4:D2}",
                this.Day,
                this.Month,
                this.Year,
                (int)Math.Round((this.SecondsSinceMidnight / 60.0) / 60.0),
                (int)Math.Round(this.SecondsSinceMidnight / 60.0) % 60);
                
        }
    }
}
