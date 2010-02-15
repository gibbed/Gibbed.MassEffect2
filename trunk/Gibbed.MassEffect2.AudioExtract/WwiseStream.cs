using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gibbed.MassEffect2.AudioExtract
{
    public class WwiseStream
    {
        public string Container;
        public string Name;
        public uint Offset;
        public uint Size;
        public uint CRC;
        public bool WillExtract;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
