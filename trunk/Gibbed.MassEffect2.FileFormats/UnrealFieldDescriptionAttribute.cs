using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldDescriptionAttribute : Attribute
    {
        public string Description;

        public UnrealFieldDescriptionAttribute(string description)
        {
            this.Description = description;
        }
    }
}
