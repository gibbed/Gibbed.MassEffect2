using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class MorphFeature : IUnrealSerializable
    {
        public string Feature;
        public float Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Feature);
            stream.Serialize(ref this.Offset);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Feature,
                this.Offset);
        }
    }
}
