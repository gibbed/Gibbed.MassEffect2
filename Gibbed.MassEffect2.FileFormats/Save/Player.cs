using System;
using System.Collections.Generic;
using System.IO;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF1D0
    public class Player : IUnrealSerializable
    {
        public bool Unknown000;
        public string Unknown004;
        public uint Level; // +018
        public float Unknown01C;
        public string Name; // +020
        public uint Unknown02C;
        public byte Unknown030;
        public byte Unknown031;
        public uint SquadPoints; // +034
        public string Unknown038;
        public string Unknown044;
        public string Unknown050;
        public Unknown00BAF8E0 Unknown05C;
        public List<Power> Powers; // +11C 00BAF330
        public List<Unknown00BB0B60> Unknown128; // 00BAF3E0 maybe ammo
        public WeaponLoadout Loadout; // +134 00BAF4F8
        public List<Unknown00BB0C10> Unknown17C; // 00BAF5A1
        public uint Credits; // +188
        public uint Medigel; // +18C
        public uint ResourceElementZero; // +190
        public uint ResourceIridium; // +194
        public uint ResourcePalladium; // +198
        public uint ResourcePlatinum; // +19C
        public uint ShipProbes; // +1A0
        public float ShipFuel; // +1A4
        public string IdentityCode; // +1A8
        public uint Unknown014;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown000);
            stream.Serialize(ref this.Unknown004);
            stream.Serialize(ref this.Level);
            stream.Serialize(ref this.Unknown01C);
            stream.Serialize(ref this.Name);
            stream.Serialize(ref this.Unknown02C);
            stream.Serialize(ref this.Unknown030);
            stream.Serialize(ref this.Unknown031);
            stream.Serialize(ref this.SquadPoints);
            stream.Serialize(ref this.Unknown038);
            stream.Serialize(ref this.Unknown044);
            stream.Serialize(ref this.Unknown050);
            stream.Serialize<Unknown00BAF8E0>(ref this.Unknown05C);
            stream.Serialize<Power>(ref this.Powers);
            stream.Serialize<Unknown00BB0B60>(ref this.Unknown128);

            if (stream.Version >= 18)
            {
                stream.Serialize<WeaponLoadout>(ref this.Loadout);
            }

            if (stream.Version >= 19)
            {
                stream.Serialize<Unknown00BB0C10>(ref this.Unknown17C);
            }

            stream.Serialize(ref this.Credits);
            stream.Serialize(ref this.Medigel);
            stream.Serialize(ref this.ResourceElementZero);
            stream.Serialize(ref this.ResourceIridium);
            stream.Serialize(ref this.ResourcePalladium);
            stream.Serialize(ref this.ResourcePlatinum);
            stream.Serialize(ref this.ShipProbes);
            stream.Serialize(ref this.ShipFuel);

            if (stream.Version >= 25)
            {
                stream.Serialize(ref this.IdentityCode);
            }
            else
            {
                throw new Exception();
            }

            if (stream.Version >= 26)
            {
                stream.Serialize(ref this.Unknown014);
            }
        }

        public void Serialize(Stream output)
        {
            throw new NotImplementedException();
        }
    }
}
