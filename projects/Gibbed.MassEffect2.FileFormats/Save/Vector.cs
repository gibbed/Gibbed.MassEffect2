using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Vector : IUnrealSerializable
    {
        [UnrealFieldDisplayName("X")]
        public float X;

        [UnrealFieldDisplayName("Y")]
        public float Y;

        [UnrealFieldDisplayName("Z")]
        public float Z;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
            stream.Serialize(ref this.Z);
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}, {this.Z}";
        }
    }
}
