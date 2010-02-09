using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats
{
    public class UnrealStream : IUnrealStream
    {
        private Stream Stream;
        private bool Loading;
        public uint Version { get; private set; }

        public UnrealStream(Stream stream, bool loading, uint version)
        {
            this.Stream = stream;
            this.Loading = loading;
            this.Version = version;
        }

        public void Serialize(ref bool value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueB32();
            }
            else
            {
                this.Stream.WriteValueB32(value);
            }
        }

        public void Serialize(ref byte value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueU8();
            }
            else
            {
                this.Stream.WriteValueU8(value);
            }
        }

        public void Serialize(ref int value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueS32();
            }
            else
            {
                this.Stream.WriteValueS32(value);
            }
        }

        public void Serialize(ref uint value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueU32();
            }
            else
            {
                this.Stream.WriteValueU32(value);
            }
        }

        public void Serialize(ref float value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueF32();
            }
            else
            {
                this.Stream.WriteValueF32(value);
            }
        }

        public void Serialize(ref string value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadStringUnreal();
            }
            else
            {
                this.Stream.WriteStringUnreal(value);
            }
        }

        public void Serialize(ref Guid value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueGuid();
            }
            else
            {
                this.Stream.WriteValueGuid(value);
            }
        }

        public void SerializeEnum<TEnum>(ref TEnum value)
        {
            if (this.Loading == true)
            {
                value = this.Stream.ReadValueEnum<TEnum>();
            }
            else
            {
                this.Stream.WriteValueEnum<TEnum>(value);
            }
        }

        public void Serialize(ref List<bool> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<bool> list = new List<bool>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadValueB32());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (bool value in values)
                {
                    this.Stream.WriteValueB32(value);
                }
            }
        }

        public void Serialize(ref List<int> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<int> list = new List<int>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadValueS32());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (int value in values)
                {
                    this.Stream.WriteValueS32(value);
                }
            }
        }

        public void Serialize(ref List<uint> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<uint> list = new List<uint>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadValueU32());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (uint value in values)
                {
                    this.Stream.WriteValueU32(value);
                }
            }
        }

        public void Serialize(ref List<float> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<float> list = new List<float>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadValueF32());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (float value in values)
                {
                    this.Stream.WriteValueF32(value);
                }
            }
        }

        public void Serialize(ref List<string> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<string> list = new List<string>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadStringUnreal());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (string value in values)
                {
                    this.Stream.WriteStringUnreal(value);
                }
            }
        }

        public void Serialize(ref List<Guid> values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<Guid> list = new List<Guid>();

                for (uint i = 0; i < count; i++)
                {
                    list.Add(this.Stream.ReadValueGuid());
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (Guid value in values)
                {
                    this.Stream.WriteValueGuid(value);
                }
            }
        }

        public void Serialize(ref BitArray values)
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                BitArray list = new BitArray((int)(count * 32));

                for (uint i = 0; i < count; i++)
                {
                    uint offset = i * 32;
                    int value = this.Stream.ReadValueS32();

                    for (int bit = 0; bit < 32; bit++)
                    {
                        list.Set((int)(offset + bit), (value & (1 << bit)) != 0);
                    }
                }

                values = list;
            }
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                uint count = ((uint)values.Count + 31) / 32;
                this.Stream.WriteValueU32(count);

                for (uint i = 0; i < count; i++)
                {
                    uint offset = i * 32;
                    int value = 0;
                    
                    for (int bit = 0; bit < 32 && offset + bit < values.Count; bit++)
                    {
                        value |= (values.Get((int)(offset + bit)) ? 1 : 0) << bit;
                    }

                    this.Stream.WriteValueS32(value);
                }
            }
        }

        public void Serialize<TFormat>(ref TFormat value)
            where TFormat : IUnrealSerializable, new()
        {
            if (this.Loading == false && value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (this.Loading == true)
            {
                value = new TFormat();
            }

            value.Serialize(this);
        }

        public void Serialize<TFormat>(ref List<TFormat> values)
            where TFormat : IUnrealSerializable, new()
        {
            if (this.Loading == true)
            {
                uint count = this.Stream.ReadValueU32();

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
            else
            {
                if (values == null)
                {
                    throw new ArgumentNullException("values");
                }

                this.Stream.WriteValueS32(values.Count);
                foreach (TFormat value in values)
                {
                    value.Serialize(this);
                }
            }
        }
    }
}
