using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BB0C50 : IUnrealSerializable
    {
        public uint Unknown0;
        public uint Unknown1;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
            stream.Serialize(ref this.Unknown3);
            stream.Serialize(ref this.Unknown4);
        }

        public override string ToString()
        {
            return String.Format("{0} / {1} / {2} / {3} / {4}",
                this.Unknown0,
                this.Unknown1,
                this.Unknown2,
                this.Unknown3,
                this.Unknown4);
        }
    }
}
