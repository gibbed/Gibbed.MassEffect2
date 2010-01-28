using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown005BAF20 : IUnrealSerializable
    {
        public List<Unknown005BAF80> Unknown0;

        public void Serialize(IUnrealStream output)
        {
            output.Serialize<Unknown005BAF80>(ref this.Unknown0);
        }
    }
}
