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
            this._StartButton = new System.Windows.Forms.Button();
            this._ValidateCheckBox = new System.Windows.Forms.CheckBox();
            this._ConvertCheckBox = new System.Windows.Forms.CheckBox();
            this._SelectResetButton = new System.Windows.Forms.Button();
            this._SelectMusicButton = new System.Windows.Forms.Button();
            this._LogTextBox = new System.Windows.Forms.RichTextBox();
            this._SelectAmbienceButton = new System.Windows.Forms.Button();
            this._ProgressBar = new System.Windows.Forms.ProgressBar();
            this._CancelButton = new System.Windows.Forms.Button();
            this._FileSplitContainer = new System.Windows.Forms.SplitContainer();
            this._ContainerListBox = new System.Windows.Forms.ListBox();
            this._FileListView = new System.Windows.Forms.ListView();
            this._FileNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._FileSizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._TotalSizeLabel = new System.Windows.Forms.Label();
            this._OpenContainerDialog = new System.Windows.Forms.OpenFileDialog();
            this._SavePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._SelectAllButton = new System.Windows.Forms.Button();
            this._SelectSearchButton = new System.Windows.Forms.Button();
            this._AboutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._FileSplitContainer)).BeginInit();
            this._FileSplitContainer.Panel1.SuspendLayout();
            this._FileSplitContainer.Panel2.SuspendLayout();
            this._FileSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _StartButton
            // 
            this._StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._StartButton.Location = new System.Drawing.Point(537, 407);
            this._StartButton.Name = "_StartButton";
            this._StartButton.Size = new System.Drawing.Size(75, 23);
            this._StartButton.TabIndex = 1;
            this._StartButton.Text = "&Start";
            this._StartButton.UseVisualStyleBackColor = true;
            this._StartButton.Click += new System.EventHandler(this.OnStart);
            // 
            // _ValidateCheckBox
            // 
            this._ValidateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._ValidateCheckBox.AutoSize = true;
            this._ValidateCheckBox.Checked = true;
            this._ValidateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ValidateCheckBox.Location = new System.Drawing.Point(317, 411);
            this._ValidateCheckBox.Name = "_ValidateCheckBox";
            this._ValidateCheckBox.Size = new System.Drawing.Size(64, 17);
            this._ValidateCheckBox.TabIndex = 2;
            this._ValidateCheckBox.Text = "V&alidate";
            this._ValidateCheckBox.UseVisualStyleBackColor = true;
            // 
            // _ConvertCheckBox
            // 
            this._ConvertCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._ConvertCheckBox.AutoSize = true;
            this._ConvertCheckBox.Checked = true;
            this._ConvertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ConvertCheckBox.Location = new System.Drawing.Point(387, 411);
            this._ConvertCheckBox.Name = "_ConvertCheckBox";
            this._ConvertCheckBox.Size = new System.Drawing.Size(63, 17);
            this._ConvertCheckBox.TabIndex = 3;
            this._ConvertCheckBox.Text = "C&onvert";
            this._ConvertCheckBox.UseVisualStyleBackColor = true;
            // 
            // _SelectResetButton
            // 
            this._SelectResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._SelectResetButton.Location = new System.Drawing.Point(12, 247);
            this._SelectResetButton.Name = "_SelectResetButton";
            this._SelectResetButton.Size = new System.Drawing.Size(75, 23);
            this._SelectResetButton.TabIndex = 4;
            this._SelectResetButton.Text = "Reset";
            this._SelectResetButton.UseVisualStyleBackColor = true;
            this._SelectResetButton.Click += new System.EventHandler(this.OnSelectReset);
            // 
            // _SelectMusicButton
            // 
            this._SelectMusicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._SelectMusicButton.Location = new System.Drawing.Point(174, 247);
            this._SelectMusicButton.Name = "_SelectMusicButton";
            this._SelectMusicButton.Size = new System.Drawing.Size(75, 23);
            this._SelectMusicButton.TabIndex = 5;
            this._SelectMusicButton.Text = "Music";
            this._SelectMusicButton.UseVisualStyleBackColor = true;
            this._SelectMusicButton.Click += new System.EventHandler(this.OnSelectMusic);
            // 
            // _LogTextBox
            // 
            this._LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._LogTextBox.Location = new System.Drawing.Point(12, 305);
            this._LogTextBox.Name = "_LogTextBox";
            this._LogTextBox.Size = new System.Drawing.Size(600, 96);
            this._LogTextBox.TabIndex = 6;
            this._LogTextBox.Text = "";
            // 
            // _SelectAmbienceButton
            // 
            this._SelectAmbienceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._SelectAmbienceButton.Location = new System.Drawing.Point(255, 247);
            this._SelectAmbienceButton.Name = "_SelectAmbienceButton";
            this._SelectAmbienceButton.Size = new System.Drawing.Size(75, 23);
            this._SelectAmbienceButton.TabIndex = 7;
            this._SelectAmbienceButton.Text = "Ambience";
            this._SelectAmbienceButton.UseVisualStyleBackColor = true;
            this._SelectAmbienceButton.Click += new System.EventHandler(this.OnSelectAmbience);
            // 
            // _ProgressBar
            // 
            this._ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ProgressBar.Location = new System.Drawing.Point(12, 276);
            this._ProgressBar.Name = "_ProgressBar";
            this._ProgressBar.Size = new System.Drawing.Size(600, 23);
            this._ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._ProgressBar.TabIndex = 8;
            // 
            // _CancelButton
            // 
            this._CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._CancelButton.Enabled = false;
            this._CancelButton.Location = new System.Drawing.Point(456, 407);
            this._CancelButton.Name = "_CancelButton";
            this._CancelButton.Size = new System.Drawing.Size(75, 23);
            this._CancelButton.TabIndex = 9;
            this._CancelButton.Text = "Cancel";
            this._CancelButton.UseVisualStyleBackColor = true;
            this._CancelButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // _FileSplitContainer
            // 
            this._FileSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._FileSplitContainer.Location = new System.Drawing.Point(12, 12);
            this._FileSplitContainer.Name = "_FileSplitContainer";
            // 
            // _FileSplitContainer.Panel1
            // 
            this._FileSplitContainer.Panel1.Controls.Add(this._ContainerListBox);
            // 
            // _FileSplitContainer.Panel2
            // 
            this._FileSplitContainer.Panel2.Controls.Add(this._FileListView);
            this._FileSplitContainer.Size = new System.Drawing.Size(600, 229);
            this._FileSplitContainer.SplitterDistance = 200;
            this._FileSplitContainer.TabIndex = 10;
            // 
            // _ContainerListBox
            // 
            this._ContainerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ContainerListBox.FormattingEnabled = true;
            this._ContainerListBox.IntegralHeight = false;
            this._ContainerListBox.Location = new System.Drawing.Point(0, 0);
            this._ContainerListBox.Name = "_ContainerListBox";
            this._ContainerListBox.Size = new System.Drawing.Size(200, 229);
            this._ContainerListBox.TabIndex = 0;
            this._ContainerListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectContainer);
            // 
            // _FileListView
            // 
            this._FileListView.CheckBoxes = true;
            this._FileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._FileNameColumnHeader,
            this._FileSizeColumnHeader});
            this._FileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._FileListView.FullRowSelect = true;
            this._FileListView.HideSelection = false;
            this._FileListView.Location = new System.Drawing.Point(0, 0);
            this._FileListView.Name = "_FileListView";
            this._FileListView.Size = new System.Drawing.Size(396, 229);
            this._FileListView.TabIndex = 0;
            this._FileListView.UseCompatibleStateImageBehavior = false;
            this._FileListView.View = System.Windows.Forms.View.Details;
            this._FileListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnFileChecked);
            // 
            // _FileNameColumnHeader
            // 
            this._FileNameColumnHeader.Text = "Name";
            this._FileNameColumnHeader.Width = 281;
            // 
            // _FileSizeColumnHeader
            // 
            this._FileSizeColumnHeader.Text = "Size";
            this._FileSizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._FileSizeColumnHeader.Width = 81;
            // 
            // _TotalSizeLabel
            // 
            this._TotalSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TotalSizeLabel.Location = new System.Drawing.Point(365, 252);
            this._TotalSizeLabel.Name = "_TotalSizeLabel";
            this._TotalSizeLabel.Size = new System.Drawing.Size(247, 13);
            this._TotalSizeLabel.TabIndex = 11;
            this._TotalSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _OpenContainerDialog
            // 
            this._OpenContainerDialog.FileName = "Open WwiseStream Container";
            // 
            // _SavePathDialog
            // 
            this._SavePathDialog.Description = "elect a directory for the files to be extracted to.";
            // 
            // _SelectAllButton
            // 
            this._SelectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._SelectAllButton.Location = new System.Drawing.Point(93, 247);
            this._SelectAllButton.Name = "_SelectAllButton";
            this._SelectAllButton.Size = new System.Drawing.Size(75, 23);
            this._SelectAllButton.TabIndex = 12;
            this._SelectAllButton.Text = "All";
            this._SelectAllButton.UseVisualStyleBackColor = true;
            this._SelectAllButton.Click += new System.EventHandler(this.OnSelectAll);
            // 
            // _SelectSearchButton
            // 
            this._SelectSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._SelectSearchButton.Location = new System.Drawing.Point(336, 247);
            this._SelectSearchButton.Name = "_SelectSearchButton";
            this._SelectSearchButton.Size = new System.Drawing.Size(23, 23);
            this._SelectSearchButton.TabIndex = 13;
            this._SelectSearchButton.Text = "@";
            this._SelectSearchButton.UseVisualStyleBackColor = true;
            this._SelectSearchButton.Click += new System.EventHandler(this.OnSelectSearch);
            // 
            // _AboutButton
            // 
            this._AboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._AboutButton.Location = new System.Drawing.Point(12, 407);
            this._AboutButton.Name = "_AboutButton";
            this._AboutButton.Size = new System.Drawing.Size(75, 23);
            this._AboutButton.TabIndex = 14;
            this._AboutButton.Text = "About";
            this._AboutButton.UseVisualStyleBackColor = true;
            this._AboutButton.Click += new System.EventHandler(this.OnAbout);
            // 
            // Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this._AboutButton);
            this.Controls.Add(this._SelectSearchButton);
            this.Controls.Add(this._SelectAllButton);
            this.Controls.Add(this._TotalSizeLabel);
            this.Controls.Add(this._FileSplitContainer);
            this.Controls.Add(this._CancelButton);
            this.Controls.Add(this._ProgressBar);
            this.Controls.Add(this._SelectAmbienceButton);
            this.Controls.Add(this._LogTextBox);
            this.Controls.Add(this._SelectMusicButton);
            this.Controls.Add(this._SelectResetButton);
            this.Controls.Add(this._ConvertCheckBox);
            this.Controls.Add(this._ValidateCheckBox);
            this.Controls.Add(this._StartButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Extractor";
            this.Text = "Gibbed\'s Mass Effect 2 Audio Extractor (1)";
            this.Load += new System.EventHandler(this.OnLoad);
            this._FileSplitContainer.Panel1.ResumeLayout(false);
            this._FileSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._FileSplitContainer)).EndInit();
            this._FileSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _StartButton;
        private System.Windows.Forms.CheckBox _ValidateCheckBox;
        private System.Windows.Forms.CheckBox _ConvertCheckBox;
        private System.Windows.Forms.Button _SelectResetButton;
        private System.Windows.Forms.Button _SelectMusicButton;
        private System.Windows.Forms.RichTextBox _LogTextBox;
        private System.Windows.Forms.Button _SelectAmbienceButton;
        private System.Windows.Forms.ProgressBar _ProgressBar;
        private System.Windows.Forms.Button _CancelButton;
        private System.Windows.Forms.SplitContainer _FileSplitContainer;
        private System.Windows.Forms.ListBox _ContainerListBox;
        private System.Windows.Forms.ListView _FileListView;
        private System.Windows.Forms.ColumnHeader _FileNameColumnHeader;
        private System.Windows.Forms.ColumnHeader _FileSizeColumnHeader;
        private System.Windows.Forms.Label _TotalSizeLabel;
        private System.Windows.Forms.OpenFileDialog _OpenContainerDialog;
        private System.Windows.Forms.FolderBrowserDialog _SavePathDialog;
        private System.Windows.Forms.Button _SelectAllButton;
        private System.Windows.Forms.Button _SelectSearchButton;
        private System.Windows.Forms.Button _AboutButton;
    }
}

