using System;
using System.IO;
using System.Text;
using Gibbed.IO;

namespace Gibbed.MassEffect2.FileFormats
{
    public static partial class StreamHelpers
    {
        public static string ReadStringUnreal(this Stream stream, Endian endian)
        {
            var length = stream.ReadValueS32(endian);
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
                var encoding = endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;
                return stream.ReadString(length * 2, true, encoding);
            }
            else
            {
                return stream.ReadString(length, true, Encoding.ASCII);
            }
        }

        public static void WriteStringUnreal(this Stream stream, string value, Endian endian)
        {
            if (value == null || value.Length == 0)
            {
                stream.WriteValueS32(0, endian);
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
                var encoding = endian == Endian.Little ? Encoding.Unicode : Encoding.BigEndianUnicode;
                var bytes = encoding.GetBytes(value);
                stream.WriteValueS32(-((bytes.Length / 2) + 1), endian);
                stream.WriteBytes(bytes);
                stream.WriteValueU16(0, endian);
            }
            else
            {
                var bytes = Encoding.ASCII.GetBytes(value);
                stream.WriteValueS32(bytes.Length + 1, endian);
                stream.WriteBytes(bytes);
                stream.WriteValueU8(0);
            }
        }
    }
}
