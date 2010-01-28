using System;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAB3B0
    public class DownloadableContent : IUnrealSerializable
    {
        public uint Id;
        public string Name;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Id);
            stream.Serialize(ref this.Name);
        }

        public override string ToString()
        {
            return String.Format("{1} ({0})",
                this.Id,
                this.Name);
        }
    }
}
