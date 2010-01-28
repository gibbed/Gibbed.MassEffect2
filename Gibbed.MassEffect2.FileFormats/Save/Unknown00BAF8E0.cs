using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAF8E0 : IUnrealSerializable
    {
        public byte Unknown00;
        public UInt32 Unknown04;
        public UInt32 Unknown08;
        public UInt32 Unknown0C;
        public UInt32 Unknown10;
        public UInt32 Unknown14;
        public UInt32 Unknown18;
        public UInt32 Unknown1C;
        public UInt32 Unknown20;
        public UInt32 Unknown24;
        public UInt32 Unknown28;
        public UInt32 Unknown2C;
        public UInt32 Unknown30;
        public UInt32 Unknown34;
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
