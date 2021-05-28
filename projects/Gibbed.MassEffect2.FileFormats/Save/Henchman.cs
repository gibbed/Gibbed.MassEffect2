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

using System.Collections.Generic;
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Henchman : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Tag")]
        public string Tag;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Powers")]
        public List<Power> Powers;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("Level")]
        public int CharacterLevel;

        [UnrealFieldOffset(0x1C)]
        [UnrealFieldDisplayName("Talent Points")]
        public int TalentPoints;

        [UnrealFieldOffset(0x20)]
        [UnrealFieldDisplayName("Loadout")]
        public Loadout LoadoutWeapons;

        [UnrealFieldOffset(0x68)]
        [UnrealFieldDisplayName("Mapped Power")]
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
