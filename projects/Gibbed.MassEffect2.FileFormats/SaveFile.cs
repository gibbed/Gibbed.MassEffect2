/* Copyright (c) 2021 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using Gibbed.IO;

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
            const Endian endian = Endian.Little;

            var save = new SaveFile();
            save.Version = input.ReadValueU32();

            if (save.Version != 29)
            {
                throw new FormatException("todo: fix earlier save version support (not really important)");
            }

            var reader = new UnrealReader(input, save.Version, endian);
            save.Serialize(reader);

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
            const Endian endian = Endian.Little;

            using (var temp = new MemoryStream())
            {
                temp.WriteValueU32(this.Version, endian);

                var writer = new UnrealWriter(temp, this.Version, endian);
                this.Serialize(writer);
                temp.Flush();

                var position = 0;
                var length = temp.Length;
                var data = temp.GetBuffer();
                if (this.Version >= 27)
                {
                    uint checksum = 0u;
                    while (position < length)
                    {
                        var block = (int)Math.Min(0x40000, length);
                        output.Write(data, position, block);
                        checksum = CRC32.Compute(data, position, block, checksum);
                        position += block;
                    }
                    this.Checksum = checksum;
                    output.WriteValueU32(checksum, endian);
                }
                else
                {
                    while (position < length)
                    {
                        var block = (int)Math.Min(0x40000, length);
                        output.Write(data, position, block);
                        position += block;
                    }
                    this.Checksum = 0;
                }
            }
        }
    }
}
