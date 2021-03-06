﻿/* Copyright (c) 2021 Rick (rick 'at' gibbed 'dot' us)
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

using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Weapon : IUnrealSerializable
    {
        [UnrealFieldOffset(0x00)]
        [UnrealFieldDisplayName("Class Name")]
        public string WeaponClassName;

        [UnrealFieldOffset(0x0C)]
        [UnrealFieldDisplayName("Ammo Used Count")]
        public int AmmoUsedCount;

        [UnrealFieldOffset(0x10)]
        [UnrealFieldDisplayName("Ammo Total")]
        public int TotalAmmo;

        [UnrealFieldOffset(0x14)]
        [UnrealFieldIndex(0)]
        [UnrealFieldDisplayName("Current Weapon")]
        public bool CurrentWeapon;

        [UnrealFieldOffset(0x14)]
        [UnrealFieldIndex(1)]
        [UnrealFieldDisplayName("Last Weapon")]
        public bool LastWeapon;

        [UnrealFieldOffset(0x18)]
        [UnrealFieldDisplayName("Ammo Power Name")]
        public string AmmoPowerName;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.WeaponClassName);
            stream.Serialize(ref this.AmmoUsedCount);
            stream.Serialize(ref this.TotalAmmo);
            stream.Serialize(ref this.CurrentWeapon);
            stream.Serialize(ref this.LastWeapon);

            if (stream.Version >= 17)
            {
                stream.Serialize(ref this.AmmoPowerName);
            }
        }

        public override string ToString()
        {
            return this.WeaponClassName;
        }
    }
}
