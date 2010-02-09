using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveFile
    {
        public uint Version; // ME2 1.0 (release) has saves of version 29 (0x1D)
        public uint Checksum; // CRC32 of save data (from start) to before CRC32 value

        [UnrealFieldOffset(0x054)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Debug Name")]
        public string DebugName;

        [UnrealFieldOffset(0x07C)]
        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Seconds Played")]
        public float SecondsPlayed;

        [UnrealFieldOffset(0x090)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Disc")]
        public int Disc;

        [UnrealFieldOffset(0x094)]
        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Base Level Name")]
        public string BaseLevelName;

        [UnrealFieldOffset(0x0A0)]
        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Difficulty")]
        public Save.DifficultyOptions Difficulty;

        [UnrealFieldOffset(0x0A4)]
        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("End Game State")]
        public Save.EndGameType EndGameState;

        [UnrealFieldOffset(0x080)]
        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Time Stamp")]
        public Save.SaveTimeStamp TimeStamp;

        [UnrealFieldOffset(0x0A8)]
        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Position")]
        public Save.Vector SaveLocation;

        [UnrealFieldOffset(0x0B4)]
        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Rotation")]
        public Save.Rotator SaveRotation;

        [UnrealFieldOffset(0x344)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Current Loading Tip")]
        public int CurrentLoadingTip;

        [UnrealFieldOffset(0x0C0)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Levels")]
        public List<Save.Level> LevelRecords;

        [UnrealFieldOffset(0x0CC)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Streaming")]
        public List<Save.StreamingState> StreamingRecords;

        [UnrealFieldOffset(0x0D8)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Kismet")]
        public List<Save.KismetBool> KismetRecords;

        [UnrealFieldOffset(0x0E4)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Doors")]
        public List<Save.Door> DoorRecords;

        [UnrealFieldOffset(0x0F0)]
        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Pawns")]
        public List<Guid> PawnRecords;

        [UnrealFieldOffset(0x0FC)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Player")]
        public Save.Player PlayerRecord;

        [UnrealFieldOffset(0x2B0)]
        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Henchmen")]
        public List<Save.Henchman> HenchmanRecords;

        [UnrealFieldOffset(0x2C8)]
        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("ME2 Plot Table")]
        public Save.PlotTable PlotRecord;

        [UnrealFieldOffset(0x320)]
        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("ME1 Plot Table")]
        public Save.ME1PlotTable ME1PlotRecord;

        [UnrealFieldOffset(0x2BC)]
        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("Galaxy Map")]
        public Save.GalaxyMap GalaxyMapRecord;

        [UnrealFieldOffset(0x03C)]
        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Dependent DLC")]
        public List<Save.DependentDLC> DependentDLC;

        protected void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.DebugName);
            stream.Serialize(ref this.SecondsPlayed);
            stream.Serialize(ref this.Disc);
            stream.Serialize(ref this.BaseLevelName);
            stream.SerializeEnum(ref this.Difficulty);
            stream.SerializeEnum(ref this.EndGameState);
            stream.Serialize(ref this.TimeStamp);
            stream.Serialize(ref this.SaveLocation);
            stream.Serialize(ref this.SaveRotation);
            stream.Serialize(ref this.CurrentLoadingTip);
            stream.Serialize(ref this.LevelRecords);
            stream.Serialize(ref this.StreamingRecords);
            stream.Serialize(ref this.KismetRecords);
            stream.Serialize(ref this.DoorRecords);
            stream.Serialize(ref this.PawnRecords);
            stream.Serialize(ref this.PlayerRecord);
            stream.Serialize(ref this.HenchmanRecords);
            stream.Serialize(ref this.PlotRecord);
            stream.Serialize(ref this.ME1PlotRecord);
            stream.Serialize(ref this.GalaxyMapRecord);
            stream.Serialize(ref this.DependentDLC);
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
