using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE5B0 : IUnrealSerializable
    {
        public List<uint> Unknown00;
        public List<uint> Unknown0C;
        public List<uint> Unknown18;
        public uint Unknown24;
        public List<Unknown00BAEDD0> Unknown28;
        public List<uint> Unknown34;
        public List<Unknown00BAEED0> Unknown40;
        public List<uint> Unknown4C;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown18);
            stream.Serialize(ref this.Unknown24);
            stream.Serialize<Unknown00BAEDD0>(ref this.Unknown28);
            stream.Serialize(ref this.Unknown34);
            stream.Serialize<Unknown00BAEED0>(ref this.Unknown40);
            stream.Serialize(ref this.Unknown4C);
        }
    }
}
