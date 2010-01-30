using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldIndexAttribute : Attribute
    {
        public uint Index;

        public UnrealFieldIndexAttribute(uint index)
        {
            this.Index = index;
        }
    }
}
