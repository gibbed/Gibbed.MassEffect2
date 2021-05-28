using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Gibbed.IO;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealWriter : IUnrealStream
    {
        private readonly Endian _Endian;
        private readonly Stream _Stream;

        public uint Version { get; private set; }

        public UnrealWriter(Stream stream, uint version, Endian endian)
        {
            this._Endian = endian;
            this._Stream = stream;
            this.Version = version;
        }

        public void Serialize(ref bool value)
        {
            this._Stream.WriteValueB32(value, this._Endian);
        }

        public void Serialize(ref byte value)
        {
            this._Stream.WriteValueU8(value);
        }

        public void Serialize(ref int value)
        {
            this._Stream.WriteValueS32(value, this._Endian);
        }

        public void Serialize(ref uint value)
        {
            this._Stream.WriteValueU32(value, this._Endian);
        }

        public void Serialize(ref float value)
        {
            this._Stream.WriteValueF32(value, this._Endian);
        }

        public void Serialize(ref string value)
        {
            this._Stream.WriteStringUnreal(value, this._Endian);
        }

        public void Serialize(ref Guid value)
        {
            this._Stream.WriteValueGuid(value, this._Endian);
        }

        public void SerializeEnum<TEnum>(ref TEnum value)
        {
            this._Stream.WriteValueEnum<TEnum>(value, this._Endian);
        }

        public void Serialize(ref List<bool> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count, endian);
            foreach (bool value in values)
            {
                stream.WriteValueB32(value, endian);
            }
        }

        public void Serialize(ref List<int> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count);
            foreach (int value in values)
            {
                stream.WriteValueS32(value, endian);
            }
        }

        public void Serialize(ref List<uint> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count, endian);
            foreach (uint value in values)
            {
                stream.WriteValueU32(value, endian);
            }
        }

        public void Serialize(ref List<float> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count, endian);
            foreach (float value in values)
            {
                stream.WriteValueF32(value, endian);
            }
        }

        public void Serialize(ref List<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count, endian);
            foreach (string value in values)
            {
                stream.WriteStringUnreal(value, endian);
            }
        }

        public void Serialize(ref List<Guid> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            stream.WriteValueS32(values.Count, endian);
            foreach (Guid value in values)
            {
                stream.WriteValueGuid(value, endian);
            }
        }

        public void Serialize(ref BitArray values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            var stream = this._Stream;
            var endian = this._Endian;
            uint count = ((uint)values.Count + 31) / 32;
            stream.WriteValueU32(count, endian);
            for (uint i = 0; i < count; i++)
            {
                uint offset = i * 32;
                int value = 0;
                for (int bit = 0; bit < 32 && offset + bit < values.Count; bit++)
                {
                    value |= (values.Get((int)(offset + bit)) ? 1 : 0) << bit;
                }
                stream.WriteValueS32(value, endian);
            }
        }

        public void Serialize<TFormat>(ref TFormat value)
            where TFormat : IUnrealSerializable, new()
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            value.Serialize(this);
        }

        public void Serialize<TFormat>(ref List<TFormat> values)
            where TFormat : IUnrealSerializable, new()
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            this._Stream.WriteValueS32(values.Count, this._Endian);
            foreach (TFormat value in values)
            {
                value.Serialize(this);
            }
        }
    }
}
