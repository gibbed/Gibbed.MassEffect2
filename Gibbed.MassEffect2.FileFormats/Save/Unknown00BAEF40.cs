using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAEF40 : IUnrealSerializable
    {
        public uint Unknown0;
        public bool Unknown4;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown4);
        }
    }
}
