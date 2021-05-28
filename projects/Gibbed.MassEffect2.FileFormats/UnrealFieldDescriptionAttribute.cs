using System;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldDescriptionAttribute : Attribute
    {
        public readonly string Description;

        public UnrealFieldDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}
