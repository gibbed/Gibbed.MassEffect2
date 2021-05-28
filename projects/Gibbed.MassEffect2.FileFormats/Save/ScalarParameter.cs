using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class ScalarParameter : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Name")]
        public string Name;

        [UnrealFieldDisplayName("Value")]
        public float Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Value);
        }

        public override string ToString()
        {
            return $"{this.Name} = {this.Value}";
        }
    }
}
