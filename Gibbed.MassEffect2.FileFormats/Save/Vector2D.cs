using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Vector2D : IUnrealSerializable
    {
        public float X;
        public float Y;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}",
                this.X,
                this.Y);
        }
    }
}
