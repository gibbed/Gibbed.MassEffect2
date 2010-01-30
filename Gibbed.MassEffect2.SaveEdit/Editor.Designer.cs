namespace Gibbed.MassEffect2.SaveEdit
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newMaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFemaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.saveTabPage = new System.Windows.Forms.TabPage();
            this.playerTabPage = new System.Windows.Forms.TabPage();
            this.henchmentTabPage = new System.Windows.Forms.TabPage();
            this.toolboxTabPage = new System.Windows.Forms.TabPage();
            this.headMorphFunGroupBox = new System.Windows.Forms.GroupBox();
            this.headMorphFunButton = new System.Windows.Forms.Button();
            this.headMorphFunComboBox = new System.Windows.Forms.ComboBox();
            this.headMorphFunWarningLabel = new System.Windows.Forms.Label();
            this.headMorphGroupBox = new System.Windows.Forms.GroupBox();
            this.headMorphWarningLabel = new System.Windows.Forms.Label();
            this.headMorphImportButton = new System.Windows.Forms.Button();
            this.headMorphExportButton = new System.Windows.Forms.Button();
            this.rawTabPage = new System.Windows.Forms.TabPage();
            this.rawPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveHeadMorphDialog = new System.Windows.Forms.SaveFileDialog();
            this.openHeadMorphDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainToolStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.toolboxTabPage.SuspendLayout();
            this.headMorphFunGroupBox.SuspendLayout();
            this.headMorphGroupBox.SuspendLayout();
            this.rawTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(624, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMaleMenuItem,
            this.newFemaleMenuItem});
            this.newButton.Image = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.New;
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(29, 22);
            this.newButton.Text = "New";
            // 
            // newMaleMenuItem
            // 
            this.newMaleMenuItem.Name = "newMaleMenuItem";
            this.newMaleMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newMaleMenuItem.Text = "New &Male";
            this.newMaleMenuItem.Click += new System.EventHandler(this.OnNewMale);
            // 
            // newFemaleMenuItem
            // 
            this.newFemaleMenuItem.Name = "newFemaleMenuItem";
            this.newFemaleMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newFemaleMenuItem.Text = "New &Female";
            this.newFemaleMenuItem.Click += new System.EventHandler(this.OnNewFemale);
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.Open;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.OnOpen);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = global::Gibbed.MassEffect2.SaveEdit.Properties.Resources.Save;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.saveTabPage);
            this.mainTabControl.Controls.Add(this.playerTabPage);
            this.mainTabControl.Controls.Add(this.henchmentTabPage);
            this.mainTabControl.Controls.Add(this.toolboxTabPage);
            this.mainTabControl.Controls.Add(this.rawTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(12, 28);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(600, 402);
            this.mainTabControl.TabIndex = 1;
            // 
            // saveTabPage
            // 
            this.saveTabPage.Location = new System.Drawing.Point(4, 22);
            this.saveTabPage.Name = "saveTabPage";
            this.saveTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.saveTabPage.Size = new System.Drawing.Size(592, 376);
            this.saveTabPage.TabIndex = 3;
            this.saveTabPage.Text = "Save";
            this.saveTabPage.UseVisualStyleBackColor = true;
            // 
            // playerTabPage
            // 
            this.playerTabPage.Location = new System.Drawing.Point(4, 22);
            this.playerTabPage.Name = "playerTabPage";
            this.playerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.playerTabPage.Size = new System.Drawing.Size(592, 376);
            this.playerTabPage.TabIndex = 0;
            this.playerTabPage.Text = "Player";
            this.playerTabPage.UseVisualStyleBackColor = true;
            // 
            // henchmentTabPage
            // 
            this.henchmentTabPage.Location = new System.Drawing.Point(4, 22);
            this.henchmentTabPage.Name = "henchmentTabPage";
            this.henchmentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.henchmentTabPage.Size = new System.Drawing.Size(592, 376);
            this.henchmentTabPage.TabIndex = 2;
            this.henchmentTabPage.Text = "Henchmen";
            this.henchmentTabPage.UseVisualStyleBackColor = true;
            // 
            // toolboxTabPage
            // 
            this.toolboxTabPage.Controls.Add(this.headMorphFunGroupBox);
            this.toolboxTabPage.Controls.Add(this.headMorphGroupBox);
            this.toolboxTabPage.Location = new System.Drawing.Point(4, 22);
            this.toolboxTabPage.Name = "toolboxTabPage";
            this.toolboxTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.toolboxTabPage.Size = new System.Drawing.Size(592, 376);
            this.toolboxTabPage.TabIndex = 4;
            this.toolboxTabPage.Text = "Toolbox";
            this.toolboxTabPage.UseVisualStyleBackColor = true;
            // 
            // headMorphFunGroupBox
            // 
            this.headMorphFunGroupBox.Controls.Add(this.headMorphFunButton);
            this.headMorphFunGroupBox.Controls.Add(this.headMorphFunComboBox);
            this.headMorphFunGroupBox.Controls.Add(this.headMorphFunWarningLabel);
            this.headMorphFunGroupBox.Location = new System.Drawing.Point(186, 12);
            this.headMorphFunGroupBox.Name = "headMorphFunGroupBox";
            this.headMorphFunGroupBox.Size = new System.Drawing.Size(266, 114);
            this.headMorphFunGroupBox.TabIndex = 1;
            this.headMorphFunGroupBox.TabStop = false;
            this.headMorphFunGroupBox.Text = "Head Morph Fun Stuff!";
            // 
            // headMorphFunButton
            // 
            this.headMorphFunButton.Location = new System.Drawing.Point(213, 18);
            this.headMorphFunButton.Name = "headMorphFunButton";
            this.headMorphFunButton.Size = new System.Drawing.Size(44, 21);
            this.headMorphFunButton.TabIndex = 3;
            this.headMorphFunButton.Text = "Do It!";
            this.headMorphFunButton.UseVisualStyleBackColor = true;
            this.headMorphFunButton.Click += new System.EventHandler(this.OnHeadMorphFun);
            // 
            // headMorphFunComboBox
            // 
            this.headMorphFunComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.headMorphFunComboBox.FormattingEnabled = true;
            this.headMorphFunComboBox.Items.AddRange(new object[] {
            "Delete",
            "Expand (Big Head Mode!!)",
            "Shrink",
            "Flatten X",
            "Flatten Y",
            "Flatten Z"});
            this.headMorphFunComboBox.Location = new System.Drawing.Point(6, 19);
            this.headMorphFunComboBox.Name = "headMorphFunComboBox";
            this.headMorphFunComboBox.Size = new System.Drawing.Size(201, 21);
            this.headMorphFunComboBox.TabIndex = 2;
            // 
            // headMorphFunWarningLabel
            // 
            this.headMorphFunWarningLabel.Location = new System.Drawing.Point(6, 45);
            this.headMorphFunWarningLabel.Name = "headMorphFunWarningLabel";
            this.headMorphFunWarningLabel.Size = new System.Drawing.Size(251, 66);
            this.headMorphFunWarningLabel.TabIndex = 1;
            this.headMorphFunWarningLabel.Text = "These operations are irreversible, so keep a backup of the save you\'re modifying." +
                " Unfortunately they only affect the head mesh, hair, accessories and helmets rem" +
                "ain unaffected.";
            // 
            // headMorphGroupBox
            // 
            this.headMorphGroupBox.Controls.Add(this.headMorphWarningLabel);
            this.headMorphGroupBox.Controls.Add(this.headMorphImportButton);
            this.headMorphGroupBox.Controls.Add(this.headMorphExportButton);
            this.headMorphGroupBox.Location = new System.Drawing.Point(12, 12);
            this.headMorphGroupBox.Name = "headMorphGroupBox";
            this.headMorphGroupBox.Size = new System.Drawing.Size(168, 117);
            this.headMorphGroupBox.TabIndex = 0;
            this.headMorphGroupBox.TabStop = false;
            this.headMorphGroupBox.Text = "Head Morph";
            // 
            // headMorphWarningLabel
            // 
            this.headMorphWarningLabel.Location = new System.Drawing.Point(6, 45);
            this.headMorphWarningLabel.Name = "headMorphWarningLabel";
            this.headMorphWarningLabel.Size = new System.Drawing.Size(156, 69);
            this.headMorphWarningLabel.TabIndex = 2;
            this.headMorphWarningLabel.Text = "Exporting / importing face morph data works on a raw level, problems could occur," +
                " so keep a backup of the save you\'re modifying.";
            // 
            // headMorphImportButton
            // 
            this.headMorphImportButton.Location = new System.Drawing.Point(87, 19);
            this.headMorphImportButton.Name = "headMorphImportButton";
            this.headMorphImportButton.Size = new System.Drawing.Size(75, 23);
            this.headMorphImportButton.TabIndex = 1;
            this.headMorphImportButton.Text = "Import";
            this.headMorphImportButton.UseVisualStyleBackColor = true;
            this.headMorphImportButton.Click += new System.EventHandler(this.OnHeadMorphImport);
            // 
            // headMorphExportButton
            // 
            this.headMorphExportButton.Location = new System.Drawing.Point(6, 19);
            this.headMorphExportButton.Name = "headMorphExportButton";
            this.headMorphExportButton.Size = new System.Drawing.Size(75, 23);
            this.headMorphExportButton.TabIndex = 0;
            this.headMorphExportButton.Text = "Export";
            this.headMorphExportButton.UseVisualStyleBackColor = true;
            this.headMorphExportButton.Click += new System.EventHandler(this.OnHeadMorphExport);
            // 
            // rawTabPage
            // 
            this.rawTabPage.Controls.Add(this.rawPropertyGrid);
            this.rawTabPage.Location = new System.Drawing.Point(4, 22);
            this.rawTabPage.Name = "rawTabPage";
            this.rawTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.rawTabPage.Size = new System.Drawing.Size(592, 376);
            this.rawTabPage.TabIndex = 1;
            this.rawTabPage.Text = "Raw";
            this.rawTabPage.UseVisualStyleBackColor = true;
            // 
            // rawPropertyGrid
            // 
            this.rawPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.rawPropertyGrid.Name = "rawPropertyGrid";
            this.rawPropertyGrid.Size = new System.Drawing.Size(586, 370);
            this.rawPropertyGrid.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sav";
            this.openFileDialog.Filter = "Mass Effect 2 Saves (*.pcsav)|*.pcsav|All Files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Mass Effect 2 Saves (*.pcsav)|*.pcsav|All Files (*.*)|*.*";
            // 
            // saveHeadMorphDialog
            // 
            this.saveHeadMorphDialog.Filter = "Mass Effect 2 Head Morphs (*.me2headmorph)|*.me2headmorph";
            // 
            // openHeadMorphDialog
            // 
            this.openHeadMorphDialog.DefaultExt = "sav";
            this.openHeadMorphDialog.Filter = "Mass Effect 2 Head Morphs (*.me2headmorph)|*.me2headmorph";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.Text = "Gibbed\'s Mass Effect 2 Save Editor";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.toolboxTabPage.ResumeLayout(false);
            this.headMorphFunGroupBox.ResumeLayout(false);
            this.headMorphGroupBox.ResumeLayout(false);
            this.rawTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage playerTabPage;
        private System.Windows.Forms.TabPage rawTabPage;
        private System.Windows.Forms.TabPage henchmentTabPage;
        private System.Windows.Forms.PropertyGrid rawPropertyGrid;
        private System.Windows.Forms.TabPage saveTabPage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem newMaleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFemaleMenuItem;
        private System.Windows.Forms.TabPage toolboxTabPage;
        private System.Windows.Forms.GroupBox headMorphGroupBox;
        private System.Windows.Forms.GroupBox headMorphFunGroupBox;
        private System.Windows.Forms.Label headMorphWarningLabel;
        private System.Windows.Forms.Button headMorphImportButton;
        private System.Windows.Forms.Button headMorphExportButton;
        private System.Windows.Forms.Label headMorphFunWarningLabel;
        private System.Windows.Forms.ComboBox headMorphFunComboBox;
        private System.Windows.Forms.Button headMorphFunButton;
        private System.Windows.Forms.SaveFileDialog saveHeadMorphDialog;
        private System.Windows.Forms.OpenFileDialog openHeadMorphDialog;
    }
}

