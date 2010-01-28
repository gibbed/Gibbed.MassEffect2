using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class WeaponLoadout : IUnrealSerializable
    {
        public string Unknown0;
        public string Unknown1;
        public string Unknown2;
        public string Unknown3;
        public string Unknown4;
        public string Unknown5;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown0);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
            stream.Serialize(ref this.Unknown3);
            stream.Serialize(ref this.Unknown4);
            stream.Serialize(ref this.Unknown5);
        }
    }
}
