using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Vector2D : IUnrealSerializable
    {
        [UnrealFieldDisplayName("X")]
        public float X;

        [UnrealFieldDisplayName("Y")]
        public float Y;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}";
        }
    }
}
