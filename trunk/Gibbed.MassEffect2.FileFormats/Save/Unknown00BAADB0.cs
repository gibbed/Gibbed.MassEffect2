using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAADB0 : IUnrealSerializable
    {
        public string Unknown0;
        public uint Unknown1;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
        }

        public override string ToString()
        {
            return String.Format("{0} / {1}",
                this.Unknown0,
                this.Unknown1);
        }
    }
}
