using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class NamedString : IUnrealSerializable
    {
        public string Name;
        public string Value;

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
