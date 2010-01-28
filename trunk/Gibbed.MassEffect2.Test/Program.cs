using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gibbed.MassEffect2.FileFormats;

namespace Gibbed.MassEffect2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.Open("Save_0058.pcsav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var save = SaveFile.Load(input);
            input.Close();

            var output = File.Open("Save_0058_new.test", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            save.Save(output);
            output.Close();
        }
    }
}
