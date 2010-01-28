using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    public class Unknown00BAE5B0 : IUnrealSerializable
    {
        /* not floats but they don't feel like ints either */
        public List<int> Unknown00;
        /* game related flags probably index 313 in this list appears to be
         * if Jacob's alternate appearance is toggled on or not */
        public List<int> Unknown0C;
        public List<uint> Unknown18;
        public uint Unknown24;
        public List<Unknown00BAEDD0> Unknown28;
        public List<uint> Unknown34;
        public List<Unknown00BAEED0> Unknown40;
        public List<uint> Unknown4C;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown18);
            stream.Serialize(ref this.Unknown24);
            stream.Serialize<Unknown00BAEDD0>(ref this.Unknown28);
            stream.Serialize(ref this.Unknown34);
            stream.Serialize<Unknown00BAEED0>(ref this.Unknown40);
            stream.Serialize(ref this.Unknown4C);
        }
    }
}
