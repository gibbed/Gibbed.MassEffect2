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

        public string DebugName; // +054
        public float SecondsPlayed; // +07C  Time played in seconds
        public int Disc; // +090
        public string BaseLevelName; // +094
        public Save.DifficultyOptions Difficulty; // +0A0
        public int EndGameState; // +0A4
        public Save.SaveTimeStamp TimeStamp; // +080
        public Save.Vector SaveLocation; // +0A8
        public Save.Rotator SaveRotation; // +0B4
        public int CurrentLoadingTip; // +344
        public List<Save.Level> LevelRecords; // +0C0
        public List<Save.StreamingState> StreamingRecords; // +0CC
        public List<Save.KismetBool> KismetRecords; // +0D8
        public List<Save.Door> DoorRecords; // +0E4
        public List<Guid> PawnRecords; // +0F0
        public Save.Player PlayerRecord; // +0FC
        public List<Save.Henchman> HenchmanRecords; // +2B0
        public Save.PlotTable PlotRecord; // +2C8
        public Save.ME1PlotTable ME1PlotRecord; // +320
        public Save.GalaxyMap GalaxyMapRecord; // +2BC
        public List<Save.DependentDLC> DependentDLC; // +03C

        protected void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.DebugName);
            stream.Serialize(ref this.SecondsPlayed);
            stream.Serialize(ref this.Disc);
            stream.Serialize(ref this.BaseLevelName);
            stream.SerializeEnum(ref this.Difficulty);
            stream.Serialize(ref this.EndGameState);
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
