using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE380 : IUnrealSerializable
    {
        public List<Unknown00BAE400> Unknown0;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize<Unknown00BAE400>(ref this.Unknown0);
        }
    }
}
