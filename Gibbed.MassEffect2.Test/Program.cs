using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gibbed.MassEffect2.FileFormats;
using Save = Gibbed.MassEffect2.FileFormats.Save;

namespace Gibbed.MassEffect2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = File.Open("Default_Male.pcsav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var save1 = SaveFile.Load(input1);
            input1.Close();

            var input2 = File.Open("Default_Female.pcsav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var save2 = SaveFile.Load(input2);
            input2.Close();

            var input3 = File.Open("Save_0060.pcsav", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var save3 = SaveFile.Load(input3);
            input3.Close();

            save2.BaseLevelName = save3.BaseLevelName;
            save2.SaveLocation = save3.SaveLocation;
            save2.SaveRotation = save3.SaveRotation;

            save2.PlayerRecord.Appearance.MorphHead.HairMesh = "None";
            foreach (var vertice in save2.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
            {
                vertice.X *= 6;
                vertice.Y *= 6;
                vertice.Z += (vertice.Z - 160) * 2;
            }

            var output = File.Open("Save_0002.pcsav", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            save2.Save(output);
            output.Close();
        }
    }
}
