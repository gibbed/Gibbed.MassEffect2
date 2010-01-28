using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAEDD0 : IUnrealSerializable
    {
        public uint Unknown00;
        public bool Unknown04;
        public List<uint> Unknown08;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown04);
            stream.Serialize(ref this.Unknown08);
        }
    }
}
