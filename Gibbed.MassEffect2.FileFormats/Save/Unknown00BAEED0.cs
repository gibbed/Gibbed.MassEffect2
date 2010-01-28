using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAEED0 : IUnrealSerializable
    {
        public List<Unknown00BAEF40> Unknown0;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize<Unknown00BAEF40>(ref this.Unknown0);
        }
    }
}
