using System;

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

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",
                this.Pitch,
                this.Yaw,
                this.Roll);
        }
    }
}
