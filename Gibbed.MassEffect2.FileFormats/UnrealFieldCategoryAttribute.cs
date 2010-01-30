using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldCategoryAttribute : Attribute
    {
        public string Category;

        public UnrealFieldCategoryAttribute(string category)
        {
            this.Category = category;
        }
    }
}
