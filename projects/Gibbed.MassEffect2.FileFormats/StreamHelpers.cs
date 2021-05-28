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
