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
    public partial class Vector : IUnrealSerializable
    {
        [UnrealFieldDisplayName("X")]
        public float X;

        [UnrealFieldDisplayName("Y")]
        public float Y;

        [UnrealFieldDisplayName("Z")]
        public float Z;

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.X);
            stream.Serialize(ref this.Y);
            stream.Serialize(ref this.Z);
        }

        public override string ToString()
        {
            return $"{this.X}, {this.Y}, {this.Z}";
        }
    }
}
