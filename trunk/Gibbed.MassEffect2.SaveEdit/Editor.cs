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
using System.Xml.XPath;

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

        public Editor()
        {
            this.InitializeComponent();

            this.Text += String.Format(
                " (Build revision {0} @ {1})",
                Version.Revision,
                Version.Date);

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

            this.AddPlotEditors();

            this.playerPlayerClassNameComboBox.ValueMember = "Type";
            this.playerPlayerClassNameComboBox.DisplayMember = "Name";
            this.playerPlayerClassNameComboBox.DataSource = PlayerClass.GetClasses();

            this.playerOriginComboBox.ValueMember = "Type";
            this.playerOriginComboBox.DisplayMember = "Name";
            this.playerOriginComboBox.DataSource = PlayerOrigin.GetOrigins();

            this.playerNotorietyComboBox.ValueMember = "Type";
            this.playerNotorietyComboBox.DisplayMember = "Name";
            this.playerNotorietyComboBox.DataSource = PlayerNotoriety.GetNotorieties();

            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            this.LoadSaveFromStream(memory);
            memory.Close();

            //this.mainTabControl.SelectedTab = this.rawTabPage;
        }

        private void UpdatePlotEditors()
        {
            foreach (var list in this.PlotLists)
            {
                for (int i = 0; i < list.Items.Count; i++)
                {
                    var plot = list.Items[i] as Plot;
                    if (plot == null)
                    {
                        continue;
                    }

                    bool value;

                    if (plot.Legacy == false)
                    {
                        value = this.SaveFile.PlotRecord.GetBoolVariable(plot.Id);
                    }
                    else
                    {
                        value = this.SaveFile.ME1PlotRecord.GetBoolVariable(plot.Id);
                    }

                    list.SetItemChecked(i, value);
                }
            }

            foreach (var numericUpDown in this.PlotNumerics)
            {
                var plot = numericUpDown.Tag as Plot;
                if (plot == null)
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
            CheckedListBox list = sender as CheckedListBox;
            
            if (list == null)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            Plot plot = list.Items[e.Index] as Plot;

            if (plot == null)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            if (plot.Legacy == true)
            {
                this.SaveFile.ME1PlotRecord.SetBoolVariable(plot.Id, e.NewValue == CheckState.Checked);
            }
            else
            {
                this.SaveFile.PlotRecord.SetBoolVariable(plot.Id, e.NewValue == CheckState.Checked);
            }
        }

        private void OnPlotValueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            if (numericUpDown == null)
            {
                return;
            }

            Plot plot = numericUpDown.Tag as Plot;

            if (plot == null)
            {
                return;
            }

            if (plot.Legacy == true)
            {
                this.SaveFile.ME1PlotRecord.SetIntVariable(plot.Id, (int)numericUpDown.Value);
            }
            else
            {
                this.SaveFile.PlotRecord.SetIntVariable(plot.Id, (int)numericUpDown.Value);
            }
        }

        private void AddPlotEditors()
        {
            var reader = new StringReader(Properties.Resources.Plots);
            var doc = new XPathDocument(reader);
            var nav = doc.CreateNavigator();

            List<int> me1FlagIds = new List<int>();
            List<int> me2FlagIds = new List<int>();
            List<int> me1ValueIds = new List<int>();
            List<int> me2ValueIds = new List<int>();

            var categories = nav.Select("/categories/category");
            while (categories.MoveNext() == true)
            {
                string category = categories.Current.GetAttribute("name", "");
                string slegacy = categories.Current.GetAttribute("legacy", "");
                bool legacy = slegacy == "" ? false : bool.Parse(slegacy);

                bool multicolumn = false;

                var notes = categories.Current.SelectSingleNode("notes");
                List<Plot> flags = new List<Plot>();
                List<Plot> values = new List<Plot>();

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
                    TabPage masterTabPage = new TabPage();
                    masterTabPage.Text = category;
                    masterTabPage.UseVisualStyleBackColor = true;
                    this.plotTabControl.TabPages.Add(masterTabPage);

                    TabControl masterTabControl = new TabControl();
                    masterTabControl.Dock = DockStyle.Fill;
                    masterTabPage.Controls.Add(masterTabControl);

                    if (notes != null)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Notes";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        TextBox textBox = new TextBox();
                        textBox.Dock = DockStyle.Fill;
                        textBox.Multiline = true;
                        textBox.Text = notes.Value.Trim();
                        tabPage.Controls.Add(textBox);
                    }

                    if (flags.Count > 0)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Flags";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        CheckedListBox listBox = new CheckedListBox();
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
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "Values";
                        tabPage.UseVisualStyleBackColor = true;
                        masterTabControl.Controls.Add(tabPage);

                        TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
                        tableLayoutPanel.Dock = DockStyle.Fill;

                        tableLayoutPanel.ColumnCount = 2;
                        tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
                        tableLayoutPanel.RowCount = values.Count + 1;

                        foreach (var value in values)
                        {
                            Label label = new Label();
                            label.Text = value.Name + ":";
                            label.Dock = DockStyle.Fill;
                            label.AutoSize = true;
                            label.TextAlign = ContentAlignment.MiddleRight;
                            tableLayoutPanel.Controls.Add(label);

                            // I am a terrible person and this is a terrible
                            // way to do it. BUT OH WELL :)
                            NumericUpDown numericUpDown = new NumericUpDown();
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

            reader.Close();
        }

        private void LoadSaveFromStream(Stream stream)
        {
            FileFormats.SaveFile saveFile = FileFormats.SaveFile.Load(stream);
            this.SaveFile = saveFile;
            this.UpdatePlotEditors();
        }

        private void OnNewMale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultMale);
            this.LoadSaveFromStream(memory);
            memory.Close();
        }

        private void OnNewFemale(object sender, EventArgs e)
        {
            MemoryStream memory = new MemoryStream(Properties.Resources.DefaultFemale);
            this.LoadSaveFromStream(memory);
            memory.Close();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Stream input = this.openFileDialog.OpenFile();
            this.LoadSaveFromStream(input);
            input.Close();
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
