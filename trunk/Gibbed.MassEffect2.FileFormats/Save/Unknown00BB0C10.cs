using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BB0C10 : IUnrealSerializable
    {
        public string Unknown00;
        public uint Unknown0C;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
        }
    }
}
