using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Gibbed.MassEffect2.AudioExtract
{
    internal static class ShellAPI
    {
        [DllImport("shlwapi.dll", ExactSpelling = true, EntryPoint = "StrFormatByteSizeW", CharSet = CharSet.Unicode)]
        private static extern IntPtr StrFormatByteSizeW(
            long size,
            [MarshalAs(UnmanagedType.LPTStr)]
            StringBuilder bufferBuilder,
            int bufferSize);

        public static string FormatByteSize(long size)
        {
            var builder = new StringBuilder(128);
            StrFormatByteSizeW(size, builder, builder.Capacity);
            return builder.ToString();
        }
    }
}
