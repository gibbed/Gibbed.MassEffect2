using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileFormats = Gibbed.MassEffect2.FileFormats;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.MassEffect2.SaveEdit
{
    public partial class Editor : Form
    {
        private FileFormats.SaveFile SaveFile
        {
            get { return (FileFormats.SaveFile)this.rawPropertyGrid.SelectedObject; }
            set { this.rawPropertyGrid.SelectedObject = value; }
        }

        public Editor()
        {
            this.InitializeComponent();

            this.Text += String.Format(
                " (Build revision {0} @ {1})",
                SVN.Revision,
                SVN.Date);

            string savePath;
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            savePath = Path.Combine(savePath, "BioWare");
            savePath = Path.Combine(savePath, "Mass Effect 2");
            savePath = Path.Combine(savePath, "Save");

            if (Directory.Exists(savePath) == true)
            {
                this.openFileDialog.InitialDirectory = savePath;
                this.saveFileDialog.InitialDirectory = savePath;
            }

            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(memory);
            this.SaveFile = saveFile;
        }

        private void OnNewMale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(memory);
            this.SaveFile = saveFile;
        }

        private void OnNewFemale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultFemale);
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(memory);
            this.SaveFile = saveFile;
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream input = this.openFileDialog.OpenFile();
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(input);
            this.SaveFile = saveFile;
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            this.SaveFile.Save(output);
            output.Close();
        }

        private const string HeadMorphMagic = "GIBBEDMASSEFFECT2HEADMORPH";

        private void OnHeadMorphExport(object sender, EventArgs e)
        {
            if (this.SaveFile.PlayerRecord.Appearance.HasMorphHead == false ||
                this.SaveFile.PlayerRecord.Appearance.MorphHead == null)
            {
                MessageBox.Show(
                    "This save does not have a non-default head morph.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (this.saveHeadMorphDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream output = this.saveHeadMorphDialog.OpenFile();
            output.WriteStringASCII(HeadMorphMagic);
            output.WriteValueU8(0); // "version" in case I break something in the future
            output.WriteValueU32(this.SaveFile.Version);

            FileFormats.UnrealStream stream = new FileFormats.UnrealStream(
                output, false, this.SaveFile.Version);
            stream.Serialize(ref this.SaveFile.PlayerRecord.Appearance.MorphHead);

            output.Close();
        }

        private void OnHeadMorphImport(object sender, EventArgs e)
        {
            if (this.openHeadMorphDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream input = this.openHeadMorphDialog.OpenFile();

            if (input.ReadStringASCII((uint)HeadMorphMagic.Length) != HeadMorphMagic)
            {
                MessageBox.Show(
                    "That file does not appear to be an exported head morph.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                input.Close();
                return;
            }

            if (input.ReadValueU8() != 0)
            {
                MessageBox.Show(
                    "Unsupported head morph export version.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                input.Close();
                return;
            }

            uint version = input.ReadValueU32();

            if (version != this.SaveFile.Version)
            {
                if (MessageBox.Show(
                    String.Format(
                        "The head morph you are importing has a different " +
                        "version ({0}) than your current save file ({1}).\n\n" +
                        "Import anyway?",
                        version,
                        this.SaveFile.Version),
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    input.Close();
                    return;
                }
            }

            FileFormats.UnrealStream stream = new FileFormats.UnrealStream(
                input, true, version);
            stream.Serialize(ref this.SaveFile.PlayerRecord.Appearance.MorphHead);
            this.SaveFile.PlayerRecord.Appearance.HasMorphHead = true;
            
            input.Close();
        }

        private void OnHeadMorphFun(object sender, EventArgs e)
        {
            if (this.headMorphFunComboBox.SelectedItem == null)
            {
                return;
            }

            if (this.SaveFile.PlayerRecord.Appearance.HasMorphHead == false ||
                this.SaveFile.PlayerRecord.Appearance.MorphHead == null)
            {
                MessageBox.Show(
                    "This save does not have a non-default head morph.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string op = this.headMorphFunComboBox.SelectedItem as string;

            switch (op)
            {
                case "Expand (Big Head Mode!!)":
                {
                    foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
                    {
                        vertice.X *= 6;
                        vertice.Y *= 6;
                        vertice.Z += (vertice.Z - 160) * 2;
                    }

                    break;
                }

                case "Shrink":
                {
                    foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
                    {
                        vertice.X /= 6;
                        vertice.Y /= 6;
                        vertice.Z -= (vertice.Z - 160) / 2;
                    }

                    break;
                }

                case "Flatten X":
                {
                    foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
                    {
                        vertice.X = 0;
                    }

                    break;
                }

                case "Flatten Y":
                {
                    foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
                    {
                        vertice.Y = 0;
                    }

                    break;
                }

                case "Flatten Z":
                {
                    foreach (var vertice in this.SaveFile.PlayerRecord.Appearance.MorphHead.LOD0Vertices)
                    {
                        vertice.Z = 160;
                    }

                    break;
                }

                case "Delete":
                {
                    this.SaveFile.PlayerRecord.Appearance.MorphHead = null;
                    this.SaveFile.PlayerRecord.Appearance.HasMorphHead = false;
                    break;
                }

                default:
                {
                    MessageBox.Show(
                        String.Format("Unhandled fun {0}!", op),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                }
            }
        }
    }
}
