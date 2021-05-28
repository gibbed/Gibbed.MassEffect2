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
using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class SaveTimeStamp : IUnrealSerializable
    {
        [UnrealFieldDisplayName("Seconds Since Midnight")]
        public int SecondsSinceMidnight;

        [UnrealFieldDisplayName("Day")]
        public int Day;

        [UnrealFieldDisplayName("Month")]
        public int Month;

        [UnrealFieldDisplayName("Year")]
        public int Year;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.SecondsSinceMidnight);
            stream.Serialize(ref this.Day);
            stream.Serialize(ref this.Month);
            stream.Serialize(ref this.Year);
        }

        public override string ToString()
        {
            var hours = (int)Math.Round((this.SecondsSinceMidnight / 60.0) / 60.0);
            var minutes = (int)Math.Round(this.SecondsSinceMidnight / 60.0) % 60;
            return $"{this.Day}/{this.Month}/{this.Year} {hours}:{minutes:D2}";
                
        }
    }
}
