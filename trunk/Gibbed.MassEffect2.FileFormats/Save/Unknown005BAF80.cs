using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown005BAF80 : IUnrealSerializable
    {
        public UInt32 Unknown0;
        public UInt32 Unknown1;
        public UInt32 Unknown2;
        public UInt32 Unknown3;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
            stream.Serialize(ref this.Unknown3);
        }

        public override string ToString()
        {
            return String.Format("{0} / {1} / {2} / {3}",
                this.Unknown0,
                this.Unknown1,
                this.Unknown2,
                this.Unknown3);
        }
    }
}
