using System;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldCategoryAttribute : Attribute
    {
        public readonly string Category;

        public UnrealFieldCategoryAttribute(string category)
        {
            this.Category = category;
        }
    }
}
