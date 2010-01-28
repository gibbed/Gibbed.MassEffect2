using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.FileFormats
{
    public static partial class StreamHelpers
    {
        public static string ReadStringUnreal(this Stream stream)
        {
            Int32 length = stream.ReadValueS32();

            if (length == 0)
            {
                return "";
            }

            bool isUnicode = false;

            if (length < 0)
            {
                length = Math.Abs(length);
                isUnicode = true;
            }

            if (length >= 1024 * 1024)
            {
                throw new InvalidOperationException("somehow I doubt there is a >1MB string to be read");
            }

            if (isUnicode == true)
            {
                return stream.ReadStringUTF16((uint)(length * 2), true);
            }
            else
            {
                return stream.ReadStringASCII((uint)(length), true);
            }
        }

        public static void WriteStringUnreal(this Stream stream, string value)
        {
            if (value == null || value.Length == 0)
            {
                stream.WriteValueS32(0);
                return;
            }

            bool isUnicode = false;

            // detect unicode
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] > 255)
                {
                    isUnicode = true;
                    break;
                }
            }

            if (isUnicode == true)
            {
                stream.WriteValueS32(-(value.Length + 1));
                stream.WriteStringUTF16(value);
                stream.WriteValueU16(0);
            }
            else
            {
                stream.WriteValueS32(value.Length + 1);
                stream.WriteStringASCII(value);
                stream.WriteValueU8(0);
            }
        }
    }
}
