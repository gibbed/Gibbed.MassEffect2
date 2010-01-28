using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Rotator : IUnrealSerializable
    {
        public int Pitch;
        public int Yaw;
        public int Roll;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Pitch);
            stream.Serialize(ref this.Yaw);
            stream.Serialize(ref this.Roll);
        }
    }
}
