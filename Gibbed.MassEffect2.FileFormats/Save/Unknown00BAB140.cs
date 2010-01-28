using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAB140 : IUnrealSerializable
    {
        public Guid Unknown0;
        public byte Unknown1;
        public byte Unknown2;

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
