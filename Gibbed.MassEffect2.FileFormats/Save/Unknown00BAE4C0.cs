using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE4C0 : IUnrealSerializable
    {
        public List<Unknown00BAE517> Unknown0;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize<Unknown00BAE517>(ref this.Unknown0);
        }
    }
}
