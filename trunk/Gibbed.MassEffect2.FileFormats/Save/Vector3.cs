using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Vector3 : IUnrealSerializable
    {
        public float X;
        public float Y;
        public float Z;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
            stream.Serialize(ref this.Z);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}",
                this.X,
                this.Y,
                this.Z);
        }
    }
}
