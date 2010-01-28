using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAEFF0
    public class Henchman : IUnrealSerializable
    {
        public string Tag; // +00
        public List<Power> Powers; // +0C
        public int CharacterLevel; // +18
        public int TalentPoints; // +1C
        public Loadout LoadoutWeapons; // +20
        public string MappedPower; // +68

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Tag);
            stream.Serialize(ref this.Powers);
            stream.Serialize(ref this.CharacterLevel);
            stream.Serialize(ref this.TalentPoints);

            if (stream.Version >= 23)
            {
                stream.Serialize(ref this.LoadoutWeapons);
            }

            if (stream.Version >= 29)
            {
                stream.Serialize(ref this.MappedPower);
            }
        }

        public override string ToString()
        {
            return this.Tag;
        }
    }
}
