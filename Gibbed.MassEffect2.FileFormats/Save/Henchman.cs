using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEFF0
    public class Henchman : IUnrealSerializable
    {
        public string Name; // +00
        public List<Power> Powers; // +0C
        public uint Level; // +18
        public uint SquadPoints; // +1C
        public WeaponLoadout Loadout; // +20
        public string Unknown68;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Name);
            stream.Serialize<Power>(ref this.Powers);
            stream.Serialize(ref this.Level);
            stream.Serialize(ref this.SquadPoints);

            if (stream.Version >= 23)
            {
                stream.Serialize<WeaponLoadout>(ref this.Loadout);
            }

            if (stream.Version >= 29)
            {
                stream.Serialize(ref this.Unknown68);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
