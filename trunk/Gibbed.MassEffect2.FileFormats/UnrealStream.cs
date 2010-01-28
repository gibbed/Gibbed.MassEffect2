﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gibbed.Helpers;
using System.IO;

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

        public void Serialize(ref List<int> values)
        {
            if (this.Loading == true)
            {
                UInt32 count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<int> list = new List<int>();

                for (UInt32 i = 0; i < count; i++)
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
                UInt32 count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<uint> list = new List<uint>();

                for (UInt32 i = 0; i < count; i++)
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
                UInt32 count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<float> list = new List<float>();

                for (UInt32 i = 0; i < count; i++)
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
                UInt32 count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<string> list = new List<string>();

                for (UInt32 i = 0; i < count; i++)
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
                UInt32 count = this.Stream.ReadValueU32();

                if (count >= 0x7FFFFF)
                {
                    throw new Exception("sanity check");
                }

                List<TFormat> list = new List<TFormat>();

                for (UInt32 i = 0; i < count; i++)
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