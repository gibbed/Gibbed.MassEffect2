using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Gibbed.IO;

namespace Gibbed.MassEffect2.FileFormats
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract partial class SaveFileBase
    {
        public const int MassEffect2LegendaryVersionSave = 30;

        public uint Version; // ME2 1.0 (release) has saves of version 29; ME2 Legendary has version 30 (0x1D)
        public uint Checksum; // CRC32 of save data (from start) to before CRC32 value

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Debug Name")]
        public string DebugName;

        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Seconds Played")]
        public float SecondsPlayed;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Disc")]
        public int Disc;

        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Base Level Name")]
        public string BaseLevelName;

        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Difficulty")]
        public Save.DifficultyOptions Difficulty;

        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("End Game State")]
        public Save.EndGameType EndGameState;

        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Time Stamp")]
        public Save.SaveTimeStamp TimeStamp;

        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Position")]
        public Save.Vector SaveLocation;

        [UnrealFieldCategory("3. Location")]
        [UnrealFieldDisplayName("Rotation")]
        public Save.Rotator SaveRotation;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Current Loading Tip")]
        public int CurrentLoadingTip;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Levels")]
        public List<Save.Level> LevelRecords;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Streaming")]
        public List<Save.StreamingState> StreamingRecords;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Kismet")]
        public List<Save.KismetBool> KismetRecords;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Doors")]
        public List<Save.Door> DoorRecords;

        [UnrealFieldCategory("5. Other")]
        [UnrealFieldDisplayName("Pawns")]
        public List<Guid> PawnRecords;

        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Player")]
        public Save.Player PlayerRecord;

        [UnrealFieldCategory("2. Squad")]
        [UnrealFieldDisplayName("Henchmen")]
        public List<Save.Henchman> HenchmanRecords;

        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("ME2 Plot Table")]
        public Save.PlotTable PlotRecord;

        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("ME1 Plot Table")]
        public Save.ME1PlotTable ME1PlotRecord;

        [UnrealFieldCategory("4. Plot")]
        [UnrealFieldDisplayName("Galaxy Map")]
        public Save.GalaxyMap GalaxyMapRecord;

        [UnrealFieldCategory("1. Information")]
        [UnrealFieldDisplayName("Dependent DLC")]
        public List<Save.DependentDLC> DependentDLC;

        protected abstract void Serialize(IUnrealStream stream);

        public abstract void Save(Stream output);

        public static SaveFileBase Load(Stream input)
        {
            const Endian endian = Endian.Little;

            var saveFileVersion = input.ReadValueU32();

            var save = saveFileVersion == MassEffect2LegendaryVersionSave
                ? new LegendarySaveFile()
                : (SaveFileBase)new SaveFile();

            save.Version = saveFileVersion;

            var reader = new UnrealReader(input, saveFileVersion, endian);
            save.Serialize(reader);

            // sanity check, cos if we read a strange crc it'll break anyway
            if (input.Position != input.Length - 4)
            {
                throw new FormatException("bad checksum position");
            }

            save.Checksum = input.ReadValueU32();

            // did we consume the entire save file?
            if (input.Position != input.Length)
            {
                throw new FormatException("did not consume entire file");
            }

            return save;
        }
    }
}
