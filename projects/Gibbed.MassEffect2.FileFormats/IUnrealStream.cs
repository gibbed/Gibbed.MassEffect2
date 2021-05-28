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
using System.Collections;
using System.Collections.Generic;

namespace Gibbed.MassEffect2.FileFormats
{
    public interface IUnrealStream
    {
        uint Version { get; }

        // Basic
        void Serialize(ref bool value);
        void Serialize(ref byte value);
        void Serialize(ref int value);
        void Serialize(ref uint value);
        void Serialize(ref float value);
        void Serialize(ref string value);
        void Serialize(ref Guid value);

        // Lists
        void Serialize(ref List<bool> values);
        void Serialize(ref List<int> values);
        void Serialize(ref List<uint> values);
        void Serialize(ref List<float> values);
        void Serialize(ref List<string> values);
        void Serialize(ref List<Guid> values);
        void Serialize(ref BitArray values);

        // Serializables
        void Serialize<TFormat>(ref TFormat value)
            where TFormat : IUnrealSerializable, new();
        
        // Serializable List
        void Serialize<TFormat>(ref List<TFormat> values)
            where TFormat : IUnrealSerializable, new();

        // void Serialize(ref IUnrealSerializable value);

        // Enum
        void SerializeEnum<TEnum>(ref TEnum value);
    }
}
