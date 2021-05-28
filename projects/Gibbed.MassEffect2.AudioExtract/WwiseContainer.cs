using System.Collections.Generic;

namespace Gibbed.MassEffect2.AudioExtract
{
    public class WwiseContainer
    {
        public string Name;
        public List<WwiseStream> Streams;

        public WwiseContainer(string name)
        {
            this.Name = name;
            this.Streams = new List<WwiseStream>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
