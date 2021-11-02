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

using System.ComponentModel;

namespace Gibbed.MassEffect2.FileFormats.Save
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class Me1ImportRewards : IUnrealSerializable
    {
        [UnrealFieldDisplayName("ME1 Level")]
        public int ME1Level;

        [UnrealFieldDisplayName("ME2 Level")]
        public int ME2Level;

        [UnrealFieldDisplayName("Experience")]
        public float Experience;

        [UnrealFieldDisplayName("Credits")]
        public float Credits;

        [UnrealFieldDisplayName("Resources")]
        public float Resources;

        [UnrealFieldDisplayName("Paragon")]
        public float Paragon;

        [UnrealFieldDisplayName("Renegade")]
        public float Renegade;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.ME1Level);
            stream.Serialize(ref this.ME2Level);
            stream.Serialize(ref this.Experience);
            stream.Serialize(ref this.Credits);
            stream.Serialize(ref this.Resources);
            stream.Serialize(ref this.Paragon);
            stream.Serialize(ref this.Renegade);
        }

        public override string ToString()
        {
            return $"{this.ME1Level}, {this.ME2Level}, {this.Experience}, {this.Credits}, {this.Resources}, {this.Paragon}, {this.Renegade}";
        }
    }
}
