namespace Gibbed.MassEffect2.AudioExtract
{
    partial class Extractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Extractor));
            this.startButton = new System.Windows.Forms.Button();
            this.validateCheckBox = new System.Windows.Forms.CheckBox();
            this.convertCheckBox = new System.Windows.Forms.CheckBox();
            this.selectResetButton = new System.Windows.Forms.Button();
            this.selectMusicButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.selectAmbienceButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.containerListBox = new System.Windows.Forms.ListBox();
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileNameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.fileSizeColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.totalSizeLabel = new System.Windows.Forms.Label();
            this.openContainerDialog = new System.Windows.Forms.OpenFileDialog();
            this.savePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.selectSearchButton = new System.Windows.Forms.Button();
            this.shepardBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shepardBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(537, 407);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.OnStart);
            // 
            // validateCheckBox
            // 
            this.validateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.validateCheckBox.AutoSize = true;
            this.validateCheckBox.Checked = true;
            this.validateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.validateCheckBox.Location = new System.Drawing.Point(317, 411);
            this.validateCheckBox.Name = "validateCheckBox";
            this.validateCheckBox.Size = new System.Drawing.Size(64, 17);
            this.validateCheckBox.TabIndex = 2;
            this.validateCheckBox.Text = "V&alidate";
            this.validateCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertCheckBox
            // 
            this.convertCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.convertCheckBox.AutoSize = true;
            this.convertCheckBox.Checked = true;
            this.convertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.convertCheckBox.Location = new System.Drawing.Point(387, 411);
            this.convertCheckBox.Name = "convertCheckBox";
            this.convertCheckBox.Size = new System.Drawing.Size(63, 17);
            this.convertCheckBox.TabIndex = 3;
            this.convertCheckBox.Text = "C&onvert";
            this.convertCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectResetButton
            // 
            this.selectResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectResetButton.Location = new System.Drawing.Point(12, 247);
            this.selectResetButton.Name = "selectResetButton";
            this.selectResetButton.Size = new System.Drawing.Size(75, 23);
            this.selectResetButton.TabIndex = 4;
            this.selectResetButton.Text = "Reset";
            this.selectResetButton.UseVisualStyleBackColor = true;
            this.selectResetButton.Click += new System.EventHandler(this.OnSelectReset);
            // 
            // selectMusicButton
            // 
            this.selectMusicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectMusicButton.Location = new System.Drawing.Point(174, 247);
            this.selectMusicButton.Name = "selectMusicButton";
            this.selectMusicButton.Size = new System.Drawing.Size(75, 23);
            this.selectMusicButton.TabIndex = 5;
            this.selectMusicButton.Text = "Music";
            this.selectMusicButton.UseVisualStyleBackColor = true;
            this.selectMusicButton.Click += new System.EventHandler(this.OnSelectMusic);
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(12, 305);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(600, 96);
            this.logTextBox.TabIndex = 6;
            this.logTextBox.Text = "";
            // 
            // selectAmbienceButton
            // 
            this.selectAmbienceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAmbienceButton.Location = new System.Drawing.Point(255, 247);
            this.selectAmbienceButton.Name = "selectAmbienceButton";
            this.selectAmbienceButton.Size = new System.Drawing.Size(75, 23);
            this.selectAmbienceButton.TabIndex = 7;
            this.selectAmbienceButton.Text = "Ambience";
            this.selectAmbienceButton.UseVisualStyleBackColor = true;
            this.selectAmbienceButton.Click += new System.EventHandler(this.OnSelectAmbience);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 276);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(600, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(456, 407);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.containerListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileListView);
            this.splitContainer1.Size = new System.Drawing.Size(600, 229);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 10;
            // 
            // containerListBox
            // 
            this.containerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerListBox.FormattingEnabled = true;
            this.containerListBox.IntegralHeight = false;
            this.containerListBox.Location = new System.Drawing.Point(0, 0);
            this.containerListBox.Name = "containerListBox";
            this.containerListBox.Size = new System.Drawing.Size(200, 229);
            this.containerListBox.TabIndex = 0;
            this.containerListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectContainer);
            // 
            // fileListView
            // 
            this.fileListView.CheckBoxes = true;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumnHeader,
            this.fileSizeColumnHeader});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.FullRowSelect = true;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(396, 229);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnFileChecked);
            // 
            // fileNameColumnHeader
            // 
            this.fileNameColumnHeader.Text = "Name";
            this.fileNameColumnHeader.Width = 281;
            // 
            // fileSizeColumnHeader
            // 
            this.fileSizeColumnHeader.Text = "Size";
            this.fileSizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fileSizeColumnHeader.Width = 81;
            // 
            // totalSizeLabel
            // 
            this.totalSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalSizeLabel.Location = new System.Drawing.Point(365, 252);
            this.totalSizeLabel.Name = "totalSizeLabel";
            this.totalSizeLabel.Size = new System.Drawing.Size(247, 13);
            this.totalSizeLabel.TabIndex = 11;
            this.totalSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openContainerDialog
            // 
            this.openContainerDialog.FileName = "Open WwiseStream Container";
            // 
            // savePathDialog
            // 
            this.savePathDialog.Description = "elect a directory for the files to be extracted to.";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectAllButton.Location = new System.Drawing.Point(93, 247);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 12;
            this.selectAllButton.Text = "All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // selectSearchButton
            // 
            this.selectSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectSearchButton.Location = new System.Drawing.Point(336, 247);
            this.selectSearchButton.Name = "selectSearchButton";
            this.selectSearchButton.Size = new System.Drawing.Size(23, 23);
            this.selectSearchButton.TabIndex = 13;
            this.selectSearchButton.Text = "@";
            this.selectSearchButton.UseVisualStyleBackColor = true;
            this.selectSearchButton.Click += new System.EventHandler(this.OnSelectSearch);
            // 
            // shepardBox
            // 
            this.shepardBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.shepardBox.Image = global::Gibbed.MassEffect2.AudioExtract.Properties.Resources.Shepard;
            this.shepardBox.Location = new System.Drawing.Point(0, 411);
            this.shepardBox.Name = "shepardBox";
            this.shepardBox.Size = new System.Drawing.Size(100, 31);
            this.shepardBox.TabIndex = 14;
            this.shepardBox.TabStop = false;
            this.shepardBox.Click += new System.EventHandler(this.OnShepardIsMyHomeboy);
            // 
            // Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.shepardBox);
            this.Controls.Add(this.selectSearchButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.totalSizeLabel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.selectAmbienceButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.selectMusicButton);
            this.Controls.Add(this.selectResetButton);
            this.Controls.Add(this.convertCheckBox);
            this.Controls.Add(this.validateCheckBox);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Extractor";
            this.Text = "Gibbed\'s Mass Effect 2 Audio Extractor (1)";
            this.Load += new System.EventHandler(this.OnLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shepardBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox validateCheckBox;
        private System.Windows.Forms.CheckBox convertCheckBox;
        private System.Windows.Forms.Button selectResetButton;
        private System.Windows.Forms.Button selectMusicButton;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button selectAmbienceButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox containerListBox;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader fileNameColumnHeader;
        private System.Windows.Forms.ColumnHeader fileSizeColumnHeader;
        private System.Windows.Forms.Label totalSizeLabel;
        private System.Windows.Forms.OpenFileDialog openContainerDialog;
        private System.Windows.Forms.FolderBrowserDialog savePathDialog;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button selectSearchButton;
        private System.Windows.Forms.PictureBox shepardBox;
    }
}

