using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEFF0
    public class Henchman : IUnrealSerializable
    {
        public string Unknown00;
        public List<Unknown00BAF170> Unknown0C;
        public uint Unknown18;
        public uint Unknown1C;
        public string[] Unknown20 = new string[6];
        public string Unknown68;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown00);
            stream.Serialize<Unknown00BAF170>(ref this.Unknown0C);
            stream.Serialize(ref this.Unknown18);
            stream.Serialize(ref this.Unknown1C);

            if (stream.Version >= 23)
            {
                for (int i = 0; i < 6; i++)
                {
                    stream.Serialize(ref this.Unknown20[i]);
                }
            }

            if (stream.Version >= 29)
            {
                stream.Serialize(ref this.Unknown68);
            }
        }
    }
}
