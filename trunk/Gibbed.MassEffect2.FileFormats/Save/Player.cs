using System;
using System.Collections.Generic;
using System.IO;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF1D0
    public class Player : IUnrealSerializable
    {
        public bool IsFemale; // +000
        public string PlayerClassName; // +004
        public int Level; // +018
        public float CurrentXP; // +01C
        public string FirstName; // +020
        public int LastName; // +02C
        public OriginType Origin; // +030
        public NotorietyType Notoriety; // +031
        public int TalentPoints; // +034
        public string MappedPower1; // +038
        public string MappedPower2; // +044
        public string MappedPower3; // +058
        public Appearance Appearance; // +05C
        public List<Power> Powers; // +11C 00BAF330
        public List<Weapon> Weapons; // +128 00BAF3E0
        public Loadout LoadoutWeapons; // +134 00BAF4F8
        public List<HotKey> HotKeys; // +17C 00BAF5A1
        public int Credits; // +188
        public int Medigel; // +18C
        public int Eezo; // +190
        public int Iridium; // +194
        public int Palladium; // +198
        public int Platinum; // +19C
        public int Probes; // +1A0
        public float CurrentFuel; // +1A4
        public string FaceCode; // +1A8
        public int ClassFriendlyName; // +014

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.IsFemale);
            stream.Serialize(ref this.PlayerClassName);
            stream.Serialize(ref this.Level);
            stream.Serialize(ref this.CurrentXP);
            stream.Serialize(ref this.FirstName);
            stream.Serialize(ref this.LastName);
            stream.SerializeEnum(ref this.Origin);
            stream.SerializeEnum(ref this.Notoriety);
            stream.Serialize(ref this.TalentPoints);
            stream.Serialize(ref this.MappedPower1);
            stream.Serialize(ref this.MappedPower2);
            stream.Serialize(ref this.MappedPower3);
            stream.Serialize(ref this.Appearance);
            stream.Serialize(ref this.Powers);
            stream.Serialize(ref this.Weapons);

            if (stream.Version >= 18)
            {
                stream.Serialize(ref this.LoadoutWeapons);
            }

            if (stream.Version >= 19)
            {
                stream.Serialize(ref this.HotKeys);
            }

            stream.Serialize(ref this.Credits);
            stream.Serialize(ref this.Medigel);
            stream.Serialize(ref this.Eezo);
            stream.Serialize(ref this.Iridium);
            stream.Serialize(ref this.Palladium);
            stream.Serialize(ref this.Platinum);
            stream.Serialize(ref this.Probes);
            stream.Serialize(ref this.CurrentFuel);

            if (stream.Version >= 25)
            {
                stream.Serialize(ref this.FaceCode);
            }
            else
            {
                throw new Exception();
            }

            if (stream.Version >= 26)
            {
                stream.Serialize(ref this.ClassFriendlyName);
            }
        }

        public void Serialize(Stream output)
        {
            throw new NotImplementedException();
        }
    }
}
