using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using Registry = Microsoft.Win32.Registry;

namespace Gibbed.MassEffect2.AudioExtract
{
    internal static class Helper
    {
        [DllImport("shlwapi.dll", ExactSpelling = true, EntryPoint = "StrFormatByteSizeW", CharSet = CharSet.Unicode)]
        private static extern IntPtr StrFormatByteSizeW(
            long dw,
            [MarshalAs(UnmanagedType.LPTStr)]
            StringBuilder pszBuf,
            int cchBuf);

        public static string FormatByteSize(long size)
        {
            var builder = new StringBuilder(128);
            StrFormatByteSizeW(size, builder, builder.Capacity);
            return builder.ToString();
        }
    }
}
