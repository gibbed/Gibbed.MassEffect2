using System;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldOffsetAttribute : Attribute
    {
        public readonly uint Offset;

        public UnrealFieldOffsetAttribute(uint offset)
        {
            this.Offset = offset;
        }
    }
}
