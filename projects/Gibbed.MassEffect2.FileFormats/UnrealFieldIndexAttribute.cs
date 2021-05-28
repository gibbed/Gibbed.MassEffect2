using System;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldIndexAttribute : Attribute
    {
        public readonly uint Index;

        public UnrealFieldIndexAttribute(uint index)
        {
            this.Index = index;
        }
    }
}
