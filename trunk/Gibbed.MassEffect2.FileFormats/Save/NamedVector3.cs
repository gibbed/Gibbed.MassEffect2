using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class NamedVector3 : IUnrealSerializable
    {
        public string Name;
        public Vector3 Value;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize<Vector3>(ref this.Value);
        }

        public override string ToString()
        {
            return String.Format("{0} = {1}",
                this.Name,
                this.Value);
        }
    }
}
