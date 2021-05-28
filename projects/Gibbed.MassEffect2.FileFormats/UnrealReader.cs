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
using System.IO;
using Gibbed.IO;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealReader : IUnrealStream
    {
        private readonly Endian _Endian;
        private readonly Stream _Stream;

        public uint Version { get; private set; }

        public UnrealReader(Stream stream, uint version, Endian endian)
        {
            this._Stream = stream;
            this._Endian = endian;
            this.Version = version;
        }

        public void Serialize(ref bool value)
        {
            value = this._Stream.ReadValueB32(this._Endian);
        }

        public void Serialize(ref byte value)
        {
            value = this._Stream.ReadValueU8();
        }

        public void Serialize(ref int value)
        {
            value = this._Stream.ReadValueS32(this._Endian);
        }

        public void Serialize(ref uint value)
        {
            value = this._Stream.ReadValueU32(this._Endian);
        }

        public void Serialize(ref float value)
        {
            value = this._Stream.ReadValueF32(this._Endian);
        }

        public void Serialize(ref string value)
        {
            value = this._Stream.ReadStringUnreal(this._Endian);
        }

        public void Serialize(ref Guid value)
        {
            value = this._Stream.ReadValueGuid(this._Endian);
        }

        public void SerializeEnum<TEnum>(ref TEnum value)
        {
            value = this._Stream.ReadValueEnum<TEnum>(this._Endian);
        }

        public void Serialize(ref List<bool> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFFu)
            {
                throw new Exception("sanity check");
            }

            List<bool> list = new List<bool>();
            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadValueB32(endian));
            }

            values = list;
        }

        public void Serialize(ref List<int> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFFu)
            {
                throw new Exception("sanity check");
            }

            List<int> list = new List<int>();

            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadValueS32(endian));
            }

            values = list;
        }

        public void Serialize(ref List<uint> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);
            if (count >= 0x7FFFFFu)
            {
                throw new Exception("sanity check");
            }

            List<uint> list = new List<uint>();

            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadValueU32(endian));
            }

            values = list;
        }

        public void Serialize(ref List<float> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFF)
            {
                throw new Exception("sanity check");
            }

            List<float> list = new List<float>();

            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadValueF32(endian));
            }

            values = list;
        }

        public void Serialize(ref List<string> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFF)
            {
                throw new Exception("sanity check");
            }

            List<string> list = new List<string>();

            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadStringUnreal(endian));
            }

            values = list;
        }

        public void Serialize(ref List<Guid> values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFF)
            {
                throw new Exception("sanity check");
            }

            List<Guid> list = new List<Guid>();

            for (uint i = 0; i < count; i++)
            {
                list.Add(stream.ReadValueGuid(endian));
            }

            values = list;
        }

        public void Serialize(ref BitArray values)
        {
            var stream = this._Stream;
            var endian = this._Endian;

            uint count = stream.ReadValueU32(endian);

            if (count >= 0x7FFFFF)
            {
                throw new Exception("sanity check");
            }

            BitArray list = new BitArray((int)(count * 32));

            for (uint i = 0; i < count; i++)
            {
                uint offset = i * 32;
                int value = stream.ReadValueS32(endian);

                for (int bit = 0; bit < 32; bit++)
                {
                    list.Set((int)(offset + bit), (value & (1 << bit)) != 0);
                }
            }

            values = list;
        }

        public void Serialize<TFormat>(ref TFormat value)
            where TFormat : IUnrealSerializable, new()
        {
            value = new TFormat();
            value.Serialize(this);
        }

        public void Serialize<TFormat>(ref List<TFormat> values)
            where TFormat : IUnrealSerializable, new()
        {
            uint count = this._Stream.ReadValueU32(this._Endian);

            if (count >= 0x7FFFFF)
            {
                throw new Exception("sanity check");
            }

            List<TFormat> list = new List<TFormat>();

            for (uint i = 0; i < count; i++)
            {
                TFormat value = new TFormat();
                value.Serialize(this);
                list.Add(value);
            }

            values = list;
        }
    }
}
