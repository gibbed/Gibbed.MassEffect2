using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealFieldDisplayNameAttribute : Attribute
    {
        public string Name;

        public UnrealFieldDisplayNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
