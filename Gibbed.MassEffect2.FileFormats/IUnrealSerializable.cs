using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gibbed.MassEffect2.FileFormats
{
    public interface IUnrealSerializable
    {
        void Serialize(IUnrealStream stream);
    }
}
