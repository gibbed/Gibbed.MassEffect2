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

namespace Gibbed.MassEffect2.FileFormats.Save
{
    // 00BB0CC0
    public class Level : IUnrealSerializable
    {
        public string LevelName;
        public bool Unknown1; // could be ShouldBeVisible or ShouldBeLoaded
        public bool Unknown2; // could be ShouldBeVisible or ShouldBeLoaded

        public void Serialize(IUnrealStream stream)
        {
            stream.Serialize(ref this.LevelName);
            stream.Serialize(ref this.Unknown1);
            stream.Serialize(ref this.Unknown2);
        }

        public override string ToString()
        {
            return $"{this.LevelName} = {this.Unknown1}, {this.Unknown2}";
        }
    }
}
