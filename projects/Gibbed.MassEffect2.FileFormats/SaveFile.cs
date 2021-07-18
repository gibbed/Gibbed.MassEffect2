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
using System.IO;
using Gibbed.IO;

namespace Gibbed.MassEffect2.FileFormats
{
    public class SaveFile : SaveFileBase
    {
        protected override void Serialize(IUnrealStream stream)
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

        public override void Save(Stream output)
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
