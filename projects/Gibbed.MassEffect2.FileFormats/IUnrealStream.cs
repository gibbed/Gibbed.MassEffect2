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
