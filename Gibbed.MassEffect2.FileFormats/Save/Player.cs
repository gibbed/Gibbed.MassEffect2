using System;
using System.IO;
using System.Collections.Generic;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BAF1D0
    public class Player : IUnrealSerializable
    {
        public bool Unknown000;
        public string Unknown004;
        public uint Unknown018;
        public float Unknown01C;
        public string Unknown020;
        public uint Unknown02C;
        public byte Unknown030;
        public byte Unknown031;
        public uint Unknown034;
        public string Unknown038;
        public string Unknown044;
        public string Unknown050;
        public Unknown00BAF8E0 Unknown05C;
        public List<Unknown00BAF170> Unknown11C; // 00BAF330 maybe skills
        public List<Unknown00BB0B60> Unknown128; // 00BAF3E0 maybe ammo
        public string[] Unknown134 = new string[6]; // 00BAF4F8 loadout?
        public List<Unknown00BB0C10> Unknown17C; // 00BAF5A1
        public uint Unknown188;
        public uint Unknown18C;
        public uint Unknown190;
        public uint Unknown194;
        public uint Unknown198;
        public uint Unknown19C;
        public uint Unknown1A0;
        public float Unknown1A4;
        public string Unknown1A8;
        public uint Unknown014;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown000);
            stream.Serialize(ref this.Unknown004);
            stream.Serialize(ref this.Unknown018);
            stream.Serialize(ref this.Unknown01C);
            stream.Serialize(ref this.Unknown020);
            stream.Serialize(ref this.Unknown02C);
            stream.Serialize(ref this.Unknown030);
            stream.Serialize(ref this.Unknown031);
            stream.Serialize(ref this.Unknown034);
            stream.Serialize(ref this.Unknown038);
            stream.Serialize(ref this.Unknown044);
            stream.Serialize(ref this.Unknown050);
            stream.Serialize<Unknown00BAF8E0>(ref this.Unknown05C);
            stream.Serialize<Unknown00BAF170>(ref this.Unknown11C);
            stream.Serialize<Unknown00BB0B60>(ref this.Unknown128);

            if (stream.Version >= 18)
            {
                for (int i = 0; i < 6; i++)
                {
                    stream.Serialize(ref this.Unknown134[i]);
                }
            }

            if (stream.Version >= 19)
            {
                stream.Serialize<Unknown00BB0C10>(ref this.Unknown17C);
            }

            stream.Serialize(ref this.Unknown188);
            stream.Serialize(ref this.Unknown18C);
            stream.Serialize(ref this.Unknown190);
            stream.Serialize(ref this.Unknown194);
            stream.Serialize(ref this.Unknown198);
            stream.Serialize(ref this.Unknown19C);
            stream.Serialize(ref this.Unknown1A0);
            stream.Serialize(ref this.Unknown1A4);

            if (stream.Version >= 25)
            {
                stream.Serialize(ref this.Unknown1A8);
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
