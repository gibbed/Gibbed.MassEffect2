using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldOffsetAttribute : Attribute
    {
        public uint Offset;

        public UnrealFieldOffsetAttribute(uint offset)
        {
            this.Offset = offset;
        }
    }
}
