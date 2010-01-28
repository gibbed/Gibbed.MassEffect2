using System;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats
{
    public partial class SaveFile
    {
        public uint Version; // ME2 1.0 (release) has saves of version 29 (0x1D)
        public uint Checksum; // CRC32 of save data (from start) to before CRC32 value

        public string Unknown054;
        public uint Unknown07C;
        public uint Unknown090;
        public string Unknown094;
        public byte Unknown0A0;
        public uint Unknown0A4;
        public uint Unknown080;
        public uint Unknown084;
        public uint Unknown088;
        public uint Unknown08C;
        public uint Unknown0A8;
        public uint Unknown0AC;
        public uint Unknown0B0;
        public uint Unknown0B4;
        public uint Unknown0B8;
        public uint Unknown0BC;
        public uint Unknown344;
        public uint Unknown0C4;
        public List<Save.Unknown00BB0CC0> Unknown0C0;
        public List<Save.Unknown00BAADB0> Unknown0CC;
        public List<Save.Unknown00BB0C50> Unknown0D8;
        public List<Save.Unknown00BAB140> Unknown0E4;
        public Save.Unknown005BAF20 Unknown0F0;
        public Save.Player Player;
        public List<Save.Henchman> Henchmen;
        public Save.Unknown00BAE5B0 Unknown2C8;
        public Save.Unknown00BAE040 Unknown320;
        public Save.Unknown00BAE380 Unknown2BC;
        public List<Save.DownloadableContent> Unknown03C;

        protected void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.Unknown054);
            stream.Serialize(ref this.Unknown07C);
            stream.Serialize(ref this.Unknown090);
            stream.Serialize(ref this.Unknown094);
            stream.Serialize(ref this.Unknown0A0);
            stream.Serialize(ref this.Unknown0A4);
            stream.Serialize(ref this.Unknown080);
            stream.Serialize(ref this.Unknown084);
            stream.Serialize(ref this.Unknown088);
            stream.Serialize(ref this.Unknown08C);
            stream.Serialize(ref this.Unknown0A8);
            stream.Serialize(ref this.Unknown0AC);
            stream.Serialize(ref this.Unknown0B0);
            stream.Serialize(ref this.Unknown0B4);
            stream.Serialize(ref this.Unknown0B8);
            stream.Serialize(ref this.Unknown0BC);
            stream.Serialize(ref this.Unknown344);
            stream.Serialize<Save.Unknown00BB0CC0>(ref this.Unknown0C0);
            stream.Serialize<Save.Unknown00BAADB0>(ref this.Unknown0CC);
            stream.Serialize<Save.Unknown00BB0C50>(ref this.Unknown0D8);
            stream.Serialize<Save.Unknown00BAB140>(ref this.Unknown0E4);
            stream.Serialize<Save.Unknown005BAF20>(ref this.Unknown0F0);
            stream.Serialize<Save.Player>(ref this.Player);
            stream.Serialize<Save.Henchman>(ref this.Henchmen);
            stream.Serialize<Save.Unknown00BAE5B0>(ref this.Unknown2C8);
            stream.Serialize<Save.Unknown00BAE040>(ref this.Unknown320);
            stream.Serialize<Save.Unknown00BAE380>(ref this.Unknown2BC);
            stream.Serialize<Save.DownloadableContent>(ref this.Unknown03C);
        }

        public static SaveFile Load(Stream input)
        {
            SaveFile save = new SaveFile();
            save.Version = input.ReadValueU32();

            if (save.Version != 29)
            {
                throw new FormatException("todo: fix earlier save version support (not really important)");
            }

            UnrealStream stream = new UnrealStream(input, true, save.Version);
            save.Serialize(stream);

            if (save.Version >= 27)
            {
                // sanity check, cos if we read a strange crc it'll break anyway
                if (input.Position != input.Length - 4)
                {
                    throw new FormatException("bad checksum position");
                }

                save.Checksum = input.ReadValueU32();
            }

            // did we consume the entire save file?
            if (input.Position != input.Length)
            {
                throw new FormatException("did not consume entire file");
            }

            return save;
        }

        public void Save(Stream output)
        {
            MemoryStream memory = new MemoryStream();
            UnrealStream stream = new UnrealStream(memory, false, this.Version);

            memory.WriteValueU32(this.Version);

            this.Serialize(stream);

            if (this.Version >= 27)
            {
                memory.Position = 0;
                uint checksum = 0;
                byte[] data = new byte[1024];
                while (memory.Position < memory.Length)
                {
                    int read = memory.Read(data, 0, 1024);
                    checksum = CRC32.Compute(data, 0, read, checksum);
                }

                this.Checksum = checksum;
                memory.WriteValueU32(checksum);
            }

            // copy out
            {
                memory.Position = 0;
                byte[] data = new byte[1024];
                while (memory.Position < memory.Length)
                {
                    int read = memory.Read(data, 0, 1024);
                    output.Write(data, 0, read);
                }
            }
        }
    }
}
