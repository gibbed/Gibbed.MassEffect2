using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAF170 : IUnrealSerializable
    {
        public string Unknown00;
        public float Unknown0C;
        public string Unknown10;
        public uint Unknown1C;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown10);
            stream.Serialize(ref this.Unknown1C);
        }
    }
}
