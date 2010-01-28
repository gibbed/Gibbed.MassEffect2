using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE040 : IUnrealSerializable
    {
        public List<uint> Unknown00;
        public List<uint> Unknown0C;
        public List<uint> Unknown18;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown18);
        }
    }
}
