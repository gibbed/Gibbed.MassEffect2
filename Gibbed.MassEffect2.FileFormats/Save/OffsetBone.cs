using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class OffsetBone : IUnrealSerializable
    {
        public string Name;
        public Vector Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize<Vector>(ref this.Offset);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Offset);
        }
    }
}
