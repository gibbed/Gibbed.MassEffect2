using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF170
    public class Power : IUnrealSerializable
    {
        public string PowerName; // +00
        public float CurrentRank; // +0C
        public string PowerClassName; // +10
        public int WheelDisplayIndex; // +1C

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.PowerName);
            stream.Serialize(ref this.CurrentRank);
            stream.Serialize(ref this.PowerClassName);
            stream.Serialize(ref this.WheelDisplayIndex);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1} ({2})",
                this.PowerName,
                this.CurrentRank,
                this.WheelDisplayIndex);
        }
    }
}
