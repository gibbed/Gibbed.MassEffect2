using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF170
    public class Power : IUnrealSerializable
    {
        public string DisplayName; // +00
        public float Level; // +0C
        public string Name; // +10
        public uint Unknown1C; // +1C Active?

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.DisplayName);
            stream.Serialize(ref this.Level);
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Unknown1C);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1} ({2})",
                this.DisplayName,
                this.Level,
                this.Unknown1C);
        }
    }
}
