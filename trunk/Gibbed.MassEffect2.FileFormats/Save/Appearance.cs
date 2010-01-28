using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF8E0
    public class Appearance : IUnrealSerializable
    {
        public byte ArmorType; // +00
        public uint CasualOutfit; // +04
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
        public bool HasIdentity; // +38
        public Identity Identity; // +3C  Head / Face appearance

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.ArmorType);
            stream.Serialize(ref this.CasualOutfit);
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
            stream.Serialize(ref this.HasIdentity);
            
            if (this.HasIdentity == true)
            {
                stream.Serialize<Identity>(ref this.Identity);
            }
        }
    }
}
