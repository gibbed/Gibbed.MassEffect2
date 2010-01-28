using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BB0CC0 : IUnrealSerializable
    {
        public string Unknown0;
        public uint Unknown1;
        public uint Unknown2;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
        }

        public override string ToString()
        {
            return String.Format("{0} / {1} / {2}",
                this.Unknown0,
                this.Unknown1,
                this.Unknown2);
        }
    }
}
