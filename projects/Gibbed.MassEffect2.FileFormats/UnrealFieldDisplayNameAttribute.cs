using System;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldDisplayNameAttribute : Attribute
    {
        public readonly string Name;

        public UnrealFieldDisplayNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
