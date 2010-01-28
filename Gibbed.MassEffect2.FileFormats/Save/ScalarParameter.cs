using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class ScalarParameter : IUnrealSerializable
    {
        public string Name;
        public float Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Value);
        }
    }
}
