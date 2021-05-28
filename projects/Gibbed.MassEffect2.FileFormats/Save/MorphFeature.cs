using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class MorphFeature : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Feature")]
        public string Feature;

        [UnrealFieldDisplayName("Offset")]
        public float Offset;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Feature);
            stream.Serialize(ref this.Offset);
        }

        public override string ToString()
        {
            return $"{this.Feature} = {this.Offset}";
        }
    }
}
