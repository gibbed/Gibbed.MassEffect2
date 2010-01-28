using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Color : IUnrealSerializable
    {
        public float R;
        public float G;
        public float B;
        public float A;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.R);
            stream.Serialize(ref this.G);
            stream.Serialize(ref this.B);
            stream.Serialize(ref this.A);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}",
                this.R,
                this.G,
                this.B,
                this.A);
        }
    }
}
