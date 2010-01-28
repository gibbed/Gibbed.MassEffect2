using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAF8E0 : IUnrealSerializable
    {
        public byte Unknown00;
        public uint Unknown04;
        public uint Unknown08;
        public uint Unknown0C;
        public uint Unknown10;
        public uint Unknown14;
        public uint Unknown18;
        public uint Unknown1C;
        public uint Unknown20;
        public uint Unknown24;
        public uint Unknown28;
        public uint Unknown2C;
        public uint Unknown30;
        public uint Unknown34;
        public bool Unknown38;
        public Unknown00BAF9F0 Unknown3C;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown04);
            stream.Serialize(ref this.Unknown08);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown10);
            stream.Serialize(ref this.Unknown14);
            stream.Serialize(ref this.Unknown18);
            stream.Serialize(ref this.Unknown1C);
            stream.Serialize(ref this.Unknown20);
            stream.Serialize(ref this.Unknown24);
            stream.Serialize(ref this.Unknown28);
            stream.Serialize(ref this.Unknown2C);
            stream.Serialize(ref this.Unknown30);
            stream.Serialize(ref this.Unknown34);
            stream.Serialize(ref this.Unknown38);
            
            if (this.Unknown38 == true)
            {
                stream.Serialize<Unknown00BAF9F0>(ref this.Unknown3C);
            }
        }
    }
}
