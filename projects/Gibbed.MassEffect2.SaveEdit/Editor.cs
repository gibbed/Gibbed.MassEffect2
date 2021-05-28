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
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using Gibbed.IO;

namespace Gibbed.MassEffect2.SaveEdit
{
    public partial class Editor : Form
    {
        private FileFormats.SaveFile SaveFile
        {
            get { return (FileFormats.SaveFile)this.rawPropertyGrid.SelectedObject; }
            set
            {
                this.rawPropertyGrid.SelectedObject = value;
                this.saveFileBindingSource.DataSource = value;
            }
        }

        private List<CheckedListBox> PlotLists = new List<CheckedListBox>();
        private List<NumericUpDown> PlotNumerics = new List<NumericUpDown>();

        private static string GetTitleSuffix()
        {
            var sb = new StringBuilder();

            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            if (string.IsNullOrEmpty(VersionInfo.Configuration) == false)
            {
                sb.Append(" [");
                sb.Append(VersionInfo.Configuration.ToUpperInvariant());
                sb.Append("]");
            }

            if (VersionInfo.Version != null)
            {
                sb.Append(" ");
                sb.Append(VersionInfo.Version.ToString(3));
            }

            if (string.IsNullOrEmpty(VersionInfo.Commit) == false)
            {
                sb.Append(" (");
                sb.Append(VersionInfo.Commit.Substring(0, 7));
                if (string.IsNullOrEmpty(VersionInfo.Timestamp) == false)
                {
                    sb.Append(" @ ");
                    sb.Append(MakeFriendlyTimestamp(VersionInfo.Timestamp));
                }
                sb.Append(")");
            }
            else if (string.IsNullOrEmpty(VersionInfo.Timestamp) == false)
            {
                sb.Append(" (@ ");
                sb.Append(MakeFriendlyTimestamp(VersionInfo.Timestamp));
                sb.Append(")");
            }
            // ReSharper restore ConditionIsAlwaysTrueOrFalse

            return sb.ToString();
        }

        private static string MakeFriendlyTimestamp(string s)
        {
            var datetime = DateTime.Parse(s, null, DateTimeStyles.RoundtripKind).ToLocalTime();
            return datetime.ToString("g");
        }

        public Editor()
        {
            this.InitializeComponent();

            this.Text += GetTitleSuffix();

            var savePath = GetSavePath();
            if (Directory.Exists(savePath) == true)
            {
                this.openFileDialog.InitialDirectory = savePath;
                this.saveFileDialog.InitialDirectory = savePath;
            }

            this.AddPlotEditors();

            this.playerPlayerClassNameComboBox.ValueMember = "Type";
            this.playerPlayerClassNameComboBox.DisplayMember = "Name";
            this.playerPlayerClassNameComboBox.DataSource = PlayerClass.GetList();

            this.playerOriginComboBox.ValueMember = "Type";
            this.playerOriginComboBox.DisplayMember = "Name";
            this.playerOriginComboBox.DataSource = PlayerOrigin.GetList();

            this.playerNotorietyComboBox.ValueMember = "Type";
            this.playerNotorietyComboBox.DisplayMember = "Name";
            this.playerNotorietyComboBox.DataSource = PlayerNotoriety.GetList();

            MemoryStream memory = new MemoryStream(Resources.DefaultMale);
            this.LoadSaveFromStream(memory);
            memory.Close();

            //this.mainTabControl.SelectedTab = this.rawTabPage;
        }

        private static string GetSavePath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "BioWare", "Mass Effect 2", "Save");
            return path;
        }

        private void UpdatePlotEditors()
        {
            foreach (var checkedListBox in this.PlotLists)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (!(checkedListBox.Items[i] is Plot plot))
                    {
                        continue;
                    }

                    bool value = plot.Legacy == false
                        ? this.SaveFile.PlotRecord.GetBoolVariable(plot.Id)
                        : this.SaveFile.ME1PlotRecord.GetBoolVariable(plot.Id);
                    checkedListBox.SetItemChecked(i, value);
                }
            }

            foreach (var numericUpDown in this.PlotNumerics)
            {
                if (!(numericUpDown.Tag is Plot plot))
                {
                    continue;
                }

                if (plot.Legacy == false)
                {
                    numericUpDown.Value = this.SaveFile.PlotRecord.GetIntVariable(plot.Id);
                }
                else
                {
                    numericUpDown.Value = this.SaveFile.ME1PlotRecord.GetIntVariable(plot.Id);
                }
            }
        }

        private void OnPlotFlagCheck(object sender, ItemCheckEventArgs e)
        {
            if (!(sender is CheckedListBox checkedListBox))
            {
                e.NewValue = e.CurrentValue;
                return;
            }


            if (!(checkedListBox.Items[e.Index] is Plot plot))
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            var value = e.NewValue == CheckState.Checked;
            var setBoolVariable = plot.Legacy == false
                ? (Action<int, bool>)this.SaveFile.ME1PlotRecord.SetBoolVariable
                : this.SaveFile.PlotRecord.SetBoolVariable;
            setBoolVariable(plot.Id, value);
        }

        private void OnPlotValueChange(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown numericUpDown))
            {
                return;
            }

            if (!(numericUpDown.Tag is Plot plot))
            {
                return;
            }

            var value = (int)numericUpDown.Value;
            var setIntVariable = plot.Legacy == false
                ? (Action<int, int>)this.SaveFile.ME1PlotRecord.SetIntVariable
                : this.SaveFile.PlotRecord.SetIntVariable;
            setIntVariable(plot.Id, value);
        }

        private void AddPlotEditors()
        {
            var me1FlagIds = new List<int>();
            var me2FlagIds = new List<int>();
            var me1ValueIds = new List<int>();
            var me2ValueIds = new List<int>();

            using (var reader = new StringReader(Resources.Plots))
            {
                var doc = new XPathDocument(reader);
                var nav = doc.CreateNavigator();

                var categories = nav.Select("/categories/category");
                while (categories.MoveNext() == true)
                {
                    var category = categories.Current.GetAttribute("name", "");
                    var slegacy = categories.Current.GetAttribute("legacy", "");
                    bool legacy = slegacy == "" ? false : bool.Parse(slegacy);

                    bool multicolumn = false;

                    var notes = categories.Current.SelectSingleNode("notes");
                    var flags = new List<Plot>();
                    var values = new List<Plot>();

                    // bools
                    var bools = categories.Current.SelectSingleNode("bools");
                    if (bools != null)
                    {
                        string smulticolumn = bools.GetAttribute("multicolumn", "");
                        multicolumn = smulticolumn == "" ? true : bool.Parse(smulticolumn);

                        var plots = bools.Select("plot");
                        while (plots.MoveNext() == true)
                        {
                            int id = int.Parse(plots.Current.GetAttribute("id", ""));

                            if (legacy == true && me1FlagIds.Contains(id) == true)
                            {
                                throw new Exception();
                            }
                            else if (legacy == false && me2FlagIds.Contains(id) == true)
                            {
                                throw new Exception();
                            }

                            flags.Add(new Plot(id, plots.Current.Value.Trim(), legacy));

                            if (legacy == true)
                            {
                                me1FlagIds.Add(id);
                            }
                            else
                            {
                                me2FlagIds.Add(id);
                            }
                        }
                    }

                    // ints
                    var ints = categories.Current.SelectSingleNode("ints");
                    if (ints != null)
                    {
                        var plots = ints.Select("plot");
                        while (plots.MoveNext() == true)
                        {
                            int id = int.Parse(plots.Current.GetAttribute("id", ""));

                            if (legacy == true && me1ValueIds.Contains(id) == true)
                            {
                                throw new Exception();
                            }
                            else if (legacy == false && me2ValueIds.Contains(id) == true)
                            {
                                throw new Exception();
                            }

                            values.Add(new Plot(id, plots.Current.Value.Trim(), legacy));

                            if (legacy == true)
                            {
                                me1ValueIds.Add(id);
                            }
                            else
                            {
                                me2ValueIds.Add(id);
                            }
                        }
                    }

                    if (notes != null || flags.Count > 0 || values.Count > 0)
                    {
                        var masterTabPage = new TabPage();
                        masterTabPage.Text = category;
                        masterTabPage.UseVisualStyleBackColor = true;
                        this.plotTabControl.TabPages.Add(masterTabPage);

                        var masterTabControl = new TabControl();
                        masterTabControl.Dock = DockStyle.Fill;
                        masterTabPage.Controls.Add(masterTabControl);

                        if (notes != null)
                        {
                            var tabPage = new TabPage();
                            tabPage.Text = "Notes";
                            tabPage.UseVisualStyleBackColor = true;
                            masterTabControl.Controls.Add(tabPage);

                            var textBox = new TextBox();
                            textBox.Dock = DockStyle.Fill;
                            textBox.Multiline = true;
                            textBox.Text = notes.Value.Trim();
                            tabPage.Controls.Add(textBox);
                        }

                        if (flags.Count > 0)
                        {
                            var tabPage = new TabPage();
                            tabPage.Text = "Flags";
                            tabPage.UseVisualStyleBackColor = true;
                            masterTabControl.Controls.Add(tabPage);

                            var listBox = new CheckedListBox();
                            listBox.Dock = DockStyle.Fill;
                            listBox.MultiColumn = multicolumn;
                            listBox.ColumnWidth = 225;
                            listBox.Sorted = true;
                            listBox.ItemCheck += this.OnPlotFlagCheck;
                            listBox.IntegralHeight = false;

                            foreach (var plot in flags)
                            {
                                listBox.Items.Add(plot);
                            }

                            this.PlotLists.Add(listBox);
                            tabPage.Controls.Add(listBox);
                        }

                        if (values.Count > 0)
                        {
                            var tabPage = new TabPage();
                            tabPage.Text = "Values";
                            tabPage.UseVisualStyleBackColor = true;
                            masterTabControl.Controls.Add(tabPage);

                            var tableLayoutPanel = new TableLayoutPanel();
                            tableLayoutPanel.Dock = DockStyle.Fill;

                            tableLayoutPanel.ColumnCount = 2;
                            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
                            tableLayoutPanel.RowCount = values.Count + 1;

                            foreach (var value in values)
                            {
                                var label = new Label();
                                label.Text = value.Name + ":";
                                label.Dock = DockStyle.Fill;
                                label.AutoSize = true;
                                label.TextAlign = ContentAlignment.MiddleRight;
                                tableLayoutPanel.Controls.Add(label);

                                // I am a terrible person and this is a terrible
                                // way to do it. BUT OH WELL :)
                                var numericUpDown = new NumericUpDown();
                                numericUpDown.Minimum = int.MinValue;
                                numericUpDown.Maximum = int.MaxValue;
                                numericUpDown.Increment = 1;
                                numericUpDown.Tag = value;
                                numericUpDown.ValueChanged += this.OnPlotValueChange;
                                tableLayoutPanel.Controls.Add(numericUpDown);

                                this.PlotNumerics.Add(numericUpDown);
                            }

                            tabPage.Controls.Add(tableLayoutPanel);
                        }

                        if (legacy == true)
                        {
                            Label label = new Label();
                            label.Dock = DockStyle.Bottom;
                            label.AutoSize = true;
                            label.Text = "Editing these values will only affect anything if you import this save as a new game.";
                            masterTabPage.Controls.Add(label);
                        }
                    }
                }
            }
        }

        private void LoadSaveFromStream(Stream stream)
        {
            var saveFile = FileFormats.SaveFile.Load(stream);
            this.SaveFile = saveFile;
            this.UpdatePlotEditors();
        }

        private void OnNewMale(object sender, EventArgs e)
        {
            using (var input = new MemoryStream(Resources.DefaultMale))
            {
                this.LoadSaveFromStream(input);
            }
        }

        private void OnNewFemale(object sender, EventArgs e)
        {
            using (var input = new MemoryStream(Resources.DefaultFemale))
            {
                this.LoadSaveFromStream(input);
            }
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var input = this.openFileDialog.OpenFile())
            {
                this.LoadSaveFromStream(input);
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                this.SaveFile.Save(output);
            }
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

            using (var output = this.saveHeadMorphDialog.OpenFile())
            {
                const Endian endian = Endian.Little;

                output.WriteString(HeadMorphMagic, Encoding.ASCII);
                output.WriteValueU8(0); // "version" in case I break something in the future
                output.WriteValueU32(this.SaveFile.Version, endian);

                var writer = new FileFormats.UnrealWriter(
                    output, this.SaveFile.Version, endian);
                writer.Serialize(ref this.SaveFile.PlayerRecord.Appearance.MorphHead);
            }
        }

        private void OnHeadMorphImport(object sender, EventArgs e)
        {
            if (this.openHeadMorphDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var input = this.openHeadMorphDialog.OpenFile())
            {
                const Endian endian = Endian.Little;

                if (input.ReadString(HeadMorphMagic.Length, Encoding.ASCII) != HeadMorphMagic)
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

                var version = input.ReadValueU32(endian);
                if (version != this.SaveFile.Version)
                {
                    if (MessageBox.Show(
                        string.Format(
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

                var reader = new FileFormats.UnrealReader(
                    input, version, endian);
                reader.Serialize(ref this.SaveFile.PlayerRecord.Appearance.MorphHead);
                this.SaveFile.PlayerRecord.Appearance.HasMorphHead = true;
            }
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
                        $"Unhandled fun {op}!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void OnHenchmenResetPowers(object sender, EventArgs e)
        {
            int[] costs = new int[] { 1, 2, 3, 4 };
            foreach (var henchman in this.SaveFile.HenchmanRecords)
            {
                int refund = 0;
                foreach (var power in henchman.Powers.Where(p =>
                    p.PowerName != "LoyaltyRequirement" &&
                    p.CurrentRank >= 1 && p.CurrentRank <= 4))
                {
                    for (int i = 1; i < power.CurrentRank; i++)
                    {
                        refund += costs[i];
                    }
                }

                henchman.Powers.RemoveAll(p =>
                    p.PowerName != "LoyaltyRequirement" &&
                    p.CurrentRank >= 1 && p.CurrentRank <= 4);
                henchman.TalentPoints += refund;
            }
        }
    }
}
