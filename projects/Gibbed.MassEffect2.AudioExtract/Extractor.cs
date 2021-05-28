using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.XPath;
using Gibbed.IO;
using Registry = Microsoft.Win32.Registry;

namespace Gibbed.MassEffect2.AudioExtract
{
    public partial class Extractor : Form
    {
        public Extractor()
        {
            this.InitializeComponent();
            this.DoubleBuffered = true;
            this.LoadWwiseStreams();
        }

        private static string PackagePath
        {
            get
            {
                string path;
                path = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BioWare\Mass Effect 2", "Path", null);
                path = Path.Combine(path, "BioGame", "CookedPC");
                return path;
            }
        }

        private string ConverterPath = null;

        private void OnLoad(object sender, EventArgs e)
        {
            //this.LoadWwiseStreams();

            string path = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(Path.Combine(path, "ww2ogg.exe")) == false)
            {
                this._ConvertCheckBox.Checked = false;
                this._ConvertCheckBox.Enabled = false;
                this.LogError("ww2ogg.exe is not present in \"{0}\"!", path);
            }
            else
            {
                this.ConverterPath = Path.Combine(path, "ww2ogg.exe");
            }
        }

        private List<WwiseContainer> WwiseContainers;

        delegate void SetProgressDelegate(int percent);
        private void SetProgress(int percent)
        {
            if (this._ProgressBar.InvokeRequired)
            {
                SetProgressDelegate callback = new SetProgressDelegate(SetProgress);
                this.Invoke(callback, new object[] { percent });
                return;
            }

            this._ProgressBar.Value = percent;
        }

        private delegate void ToggleControlsDelegate(bool isExtracting);
        private void ToggleControls(bool isExtracting)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(
                    new ToggleControlsDelegate(this.ToggleControls),
                    isExtracting);
                return;
            }

            this._ContainerListBox.Enabled = isExtracting == false;
            this._FileListView.Enabled = isExtracting == false;
            this._SelectResetButton.Enabled = isExtracting == false;
            this._SelectAllButton.Enabled = isExtracting == false;
            this._SelectMusicButton.Enabled = isExtracting == false;
            this._SelectAmbienceButton.Enabled = isExtracting == false;
            this._ConvertCheckBox.Enabled = this.ConverterPath != null
                ? isExtracting == false
                : false;
            this._ValidateCheckBox.Enabled = isExtracting == false;
            this._CancelButton.Enabled = isExtracting == true;
            this._StartButton.Enabled = isExtracting == false;
        }

        private delegate void LogMessageDelegate(Color color, string message, params object[] args);
        private void LogMessage(Color color, string message, params object[] args)
        {
            if (this._LogTextBox.InvokeRequired == true)
            {
                this._LogTextBox.Invoke(
                    new LogMessageDelegate(this.LogMessage),
                    color,
                    message,
                    args);
                return;
            }

            var oldColor = this._LogTextBox.SelectionColor;
            this._LogTextBox.SelectionStart = this._LogTextBox.Text.Length;
            this._LogTextBox.SelectionColor = color;
            this._LogTextBox.SelectedText = string.Format(message, args);
            this._LogTextBox.SelectionStart = this._LogTextBox.Text.Length;
            this._LogTextBox.AppendText(Environment.NewLine);
            this._LogTextBox.SelectionColor = oldColor;
            this._LogTextBox.ScrollToCaret();
        }

        private void LogMessage(string message, params object[] args)
        {
            this.LogMessage(Color.Black, message, args);
        }

        private void LogSuccess(string message, params object[] args)
        {
            this.LogMessage(Color.Green, message, args);
        }

        private void LogWarning(string message, params object[] args)
        {
            this.LogMessage(Color.Brown, message, args);
        }

        private void LogError(string message, params object[] args)
        {
            this.LogMessage(Color.Red, message, args);
        }

        private void LoadWwiseStreams()
        {
            this.WwiseContainers = new List<WwiseContainer>();

            var input = Properties.Resources.WWiseStreams;
            input.Position = 0;

            var xml = new XPathDocument(input);
            var nav = xml.CreateNavigator();

            this._ContainerListBox.Items.Clear();

            uint count = 0;

            var containers = nav.Select("/containers/container");
            while (containers.MoveNext() == true)
            {
                var containerNode = containers.Current;

                var containerName = containerNode.GetAttribute("name", string.Empty);
                if (containerName == string.Empty)
                {
                    throw new InvalidOperationException("container missing name");
                }

                var container = new WwiseContainer(containerName);

                var files = containerNode.Select("file");
                while (files.MoveNext() == true)
                {
                    var fileNode = files.Current;

                    string fileName = fileNode.GetAttribute("name", string.Empty);
                    string fileOffset = fileNode.GetAttribute("offset", string.Empty);
                    string fileSize = fileNode.GetAttribute("size", string.Empty);
                    string fileCRC = fileNode.GetAttribute("crc", string.Empty);

                    if (fileName == string.Empty ||
                        fileOffset == string.Empty ||
                        fileSize == string.Empty ||
                        fileCRC == string.Empty)
                    {
                        throw new InvalidOperationException("file missing attribute");
                    }

                    if (fileName.EndsWith("_wav") == true)
                    {
                        fileName = fileName.Substring(0, fileName.Length - 4);
                    }

                    var wstream = new WwiseStream()
                    {
                        Container = containerName,
                        Name = fileName,
                        Offset = uint.Parse(fileOffset),
                        Size = uint.Parse(fileSize),
                        CRC = uint.Parse(fileCRC),
                    };

                    container.Streams.Add(wstream);
                    count++;
                }

                this.WwiseContainers.Add(container);
            }

            this.UpdateContainerList();
            this.UpdateTotals();

            this.LogMessage("Loaded WwiseStream info, {0} files.", count);
        }

        private void UpdateContainerList()
        {
            this._ContainerListBox.BeginUpdate();
            this._ContainerListBox.Items.Clear();
            foreach (var container in this.WwiseContainers)
            {
                this._ContainerListBox.Items.Add(container);
            }
            this._ContainerListBox.EndUpdate();
        }

        private void UpdateTotals()
        {
            uint totalSize = 0;
            long count = 0;
            foreach (var wcontainer in this.WwiseContainers)
            {
                var willExtract = wcontainer.Streams
                    .Where(w => w.WillExtract == true);

                count += willExtract.Count();
                totalSize += (uint)willExtract.Sum(w => w.Size);
            }
            this._TotalSizeLabel.Text = $"Selected {count} files, {ShellAPI.FormatByteSize(totalSize)}";
        }

        private void UpdateFileChecks()
        {
            this._FileListView.BeginUpdate();
            foreach (ListViewItem item in this._FileListView.Items)
            {
                var wstream = item.Tag as WwiseStream;
                if (wstream != null)
                {
                    item.Checked = wstream.WillExtract;
                }
            }
            this._FileListView.EndUpdate();
        }

        private void OnSelectContainer(object sender, EventArgs e)
        {
            this._FileListView.BeginUpdate();
            this._FileListView.Items.Clear();
            if (this._ContainerListBox.SelectedItem is WwiseContainer container)
            {
                foreach (var stream in container.Streams)
                {
                    var item = new ListViewItem(stream.Name);
                    item.Checked = stream.WillExtract;
                    item.SubItems.Add(ShellAPI.FormatByteSize(stream.Size));
                    item.Tag = stream;
                    this._FileListView.Items.Add(item);
                }
            }
            this._FileListView.EndUpdate();
        }

        private void OnFileChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag is WwiseStream stream)
            {
                stream.WillExtract = e.Item.Checked;
                this.UpdateTotals();
            }
        }

        private void OnSelectReset(object sender, EventArgs e)
        {
            foreach (var container in this.WwiseContainers)
            {
                container.Streams.ForEach(a => a.WillExtract = false);
            }
            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            foreach (var container in this.WwiseContainers)
            {
                container.Streams.ForEach(a => a.WillExtract = true);
            }
            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectMusic(object sender, EventArgs e)
        {
            foreach (var container in this.WwiseContainers)
            {
                container.Streams.ForEach(
                    a => a.WillExtract =
                             a.WillExtract == true ||
                             a.Name.StartsWith("mus_") == true ||
                             a.Name.Contains("music") == true
                );
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectAmbience(object sender, EventArgs e)
        {
            foreach (var container in this.WwiseContainers)
            {
                container.Streams.ForEach(
                    a => a.WillExtract =
                             a.WillExtract == true ||
                             a.Name.StartsWith("amb_") == true ||
                             a.Name.Contains("ambient") == true
                );
            }
            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectSearch(object sender, EventArgs e)
        {
            var search = new SearchBox();
            search.InputText = "shit";

            if (search.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var text = search.InputText.Trim().ToLowerInvariant();

            foreach (var container in this.WwiseContainers)
            {
                container.Streams.ForEach(
                    a => a.WillExtract =
                             a.WillExtract == true ||
                             a.Name.Contains(text) == true
                );
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnStart(object sender, EventArgs e)
        {
            var info = new ExtractThreadInfo();
            info.Convert = this.ConverterPath != null
                ? this._ConvertCheckBox.Checked == true
                : false;
            info.Converter = this.ConverterPath;
            info.Validate = this._ValidateCheckBox.Checked;

            foreach (var container in this.WwiseContainers)
            {
                info.Streams.AddRange(container.Streams.Where(w => w.WillExtract == true));
            }

            if (info.Streams.Count == 0)
            {
                this.LogError("No files selected.");
                return;
            }

            this._ProgressBar.Minimum = 0;
            this._ProgressBar.Maximum = info.Streams.Count;
            this._ProgressBar.Value = 0;

            if (this._SavePathDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            info.SavePath = this._SavePathDialog.SelectedPath;

            if (Directory.GetFiles(info.SavePath).Length > 0 ||
                Directory.GetDirectories(info.SavePath).Length > 0)
            {
                if (MessageBox.Show(
                    this,
                    "Folder is not empty, continue anyway?",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            string basePath = PackagePath;
            foreach (var container in info.Streams
                .Select(w => w.Container)
                .Distinct())
            {
                string fileName = Path.ChangeExtension(container, ".afc");
                string filePath = Path.Combine(basePath, fileName);

                if (File.Exists(filePath) == false)
                {
                    this._OpenContainerDialog.Title = "Open " + fileName;
                    this._OpenContainerDialog.Filter = fileName + "|" + fileName;
                    
                    if (this._OpenContainerDialog.ShowDialog() != DialogResult.OK)
                    {
                        this.LogError("Could not find \"{0}\"!", fileName);
                        continue;
                    }

                    filePath = this._OpenContainerDialog.FileName;
                    basePath = Path.GetDirectoryName(filePath);
                }

                info.Containers.Add(container, File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read));
                this.LogSuccess("Opening \"{0}\"...", fileName);
            }

            this.ToggleControls(true);
            this.ExtractThread = new Thread(new ParameterizedThreadStart(ExtractFiles));
			this.ExtractThread.Start(info);
        }

        private void OnCancel(object sender, EventArgs e)
        {
            if (this.ExtractThread != null)
            {
                this.ExtractThread.Abort();
                this.ExtractThread = null;
                this.LogMessage("Extraction canceled.");
            }

            this.ToggleControls(false);
        }

        private Thread ExtractThread;
        private class ExtractThreadInfo
        {
            public string SavePath;
            public bool Convert = false;
            public string Converter = null;
            public bool Validate = true;
            public List<WwiseStream> Streams = new List<WwiseStream>();
            public Dictionary<string, Stream> Containers = new Dictionary<string, Stream>();

            public void CloseStreams()
            {
                foreach (var stream in this.Containers.Values)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public void ExtractFiles(object oinfo)
        {
            byte[] buffer = new byte[4096];

            int succeeded, failed, current;
            ExtractThreadInfo info = (ExtractThreadInfo)oinfo;

            succeeded = failed = current = 0;

            foreach (var stream in info.Streams)
            {
                current++;
                this.SetProgress(current);

                if (info.Containers.ContainsKey(stream.Container) == false)
                {
                    failed++;
                    continue;
                }

                string savePath = Path.Combine(info.SavePath, stream.Container);
                string riffPath = Path.Combine(savePath, Path.ChangeExtension(stream.Name, ".riff"));
                string oggPath = Path.Combine(savePath, Path.ChangeExtension(stream.Name, ".ogg"));

                Directory.CreateDirectory(savePath);
                
                var input = info.Containers[stream.Container];

                if (info.Validate == true)
                {
                    input.Seek(stream.Offset, SeekOrigin.Begin);

                    uint checksum = 0;
                    int remaining = (int)stream.Size;
                    while (remaining > 0)
                    {
                        int block = input.Read(buffer, 0, Math.Min(remaining, buffer.Length));
                        if (block == 0)
                        {
                            break;
                        }
                        checksum = FileFormats.CRC32.Compute(buffer, 0, block, checksum);
                        remaining -= block;
                    }

                    if (checksum != stream.CRC)
                    {
                        failed++;
                        this.LogError(
                            "CRC mismatch for \"{0}.{1}\"! ({2:X} vs {3:X})",
                            stream.Container,
                            stream.Name,
                            stream.CRC,
                            checksum);
                        continue;
                    }
                }

                using (var output = File.Create(riffPath))
                {
                    input.Seek(stream.Offset, SeekOrigin.Begin);
                    output.WriteFromStream(input, stream.Size);
                }

                if (info.Convert == true)
                {
                    var ogger = new Process();
                    ogger.StartInfo.UseShellExecute = false;
                    ogger.StartInfo.CreateNoWindow = true;
                    ogger.StartInfo.RedirectStandardOutput = true;
                    ogger.StartInfo.FileName = info.Converter;
                    ogger.StartInfo.Arguments = $"-o \"{oggPath}\" --full-setup \"{riffPath}\"";

                    ogger.Start();
                    ogger.WaitForExit();

                    if (ogger.ExitCode != 0)
                    {
                        string stdout = ogger.StandardOutput.ReadToEnd();

                        this.LogError("Failed to convert \"{0}.{1}\"!",
                            stream.Container,
                            stream.Name);
                        this.LogMessage(stdout);
                        File.Delete(oggPath);
                        failed++;
                        continue;
                    }

                    File.Delete(riffPath);
                }

                succeeded++;
            }

            info.CloseStreams();
            this.LogSuccess("Done, {0} succeeded, {1} failed, {2} total.", succeeded, failed, succeeded + failed);
            this.ToggleControls(false);
        }

        private void OnAbout(object sender, EventArgs e)
        {
            Process.Start("https://github.com/gibbed/Gibbed.MassEffect2");
        }
    }
}
