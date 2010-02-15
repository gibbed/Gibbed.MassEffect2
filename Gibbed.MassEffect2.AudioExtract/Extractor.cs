using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime;
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
                path = Path.Combine(path, "BioGame");
                path = Path.Combine(path, "CookedPC");
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
                this.convertCheckBox.Checked = false;
                this.convertCheckBox.Enabled = false;
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
            if (this.progressBar.InvokeRequired)
            {
                SetProgressDelegate callback = new SetProgressDelegate(SetProgress);
                this.Invoke(callback, new object[] { percent });
                return;
            }

            this.progressBar.Value = (int)percent;
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

            this.containerListBox.Enabled = isExtracting == false;
            this.fileListView.Enabled = isExtracting == false;
            this.selectResetButton.Enabled = isExtracting == false;
            this.selectAllButton.Enabled = isExtracting == false;
            this.selectMusicButton.Enabled = isExtracting == false;
            this.selectAmbienceButton.Enabled = isExtracting == false;
            this.convertCheckBox.Enabled =
                (this.ConverterPath != null) ?
                (isExtracting == false) :
                false;
            this.validateCheckBox.Enabled = isExtracting == false;
            this.cancelButton.Enabled = isExtracting == true;
            this.startButton.Enabled = isExtracting == false;
        }

        private delegate void LogMessageDelegate(Color color, string message, params object[] args);
        private void LogMessage(Color color, string message, params object[] args)
        {
            if (this.logTextBox.InvokeRequired == true)
            {
                this.logTextBox.Invoke(
                    new LogMessageDelegate(this.LogMessage),
                    color,
                    message,
                    args);
                return;
            }

            Color oldColor = this.logTextBox.SelectionColor;
            this.logTextBox.SelectionStart = this.logTextBox.Text.Length;
            this.logTextBox.SelectionColor = color;
            this.logTextBox.SelectedText = string.Format(message, args);
            this.logTextBox.SelectionStart = this.logTextBox.Text.Length;
            this.logTextBox.AppendText(Environment.NewLine);
            this.logTextBox.SelectionColor = oldColor;
            this.logTextBox.ScrollToCaret();
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

            var xml = new XPathDocument(Properties.Resources.WWiseStreams);
            var nav = xml.CreateNavigator();

            this.containerListBox.Items.Clear();

            uint count = 0;

            var containers = nav.Select("/containers/container");
            while (containers.MoveNext() == true)
            {
                var container = containers.Current;

                string cname = container.GetAttribute("name", string.Empty);
                if (cname == string.Empty)
                {
                    throw new InvalidOperationException("container missing name");
                }

                WwiseContainer wcontainer = new WwiseContainer(cname);

                var files = container.Select("file");
                while (files.MoveNext() == true)
                {
                    var file = files.Current;

                    string fname = file.GetAttribute("name", string.Empty);
                    string foffset = file.GetAttribute("offset", string.Empty);
                    string fsize = file.GetAttribute("size", string.Empty);
                    string fcrc = file.GetAttribute("crc", string.Empty);

                    if (fname == string.Empty ||
                        foffset == string.Empty ||
                        fsize == string.Empty ||
                        fcrc == string.Empty)
                    {
                        throw new InvalidOperationException("file missing attribute");
                    }

                    if (fname.EndsWith("_wav") == true)
                    {
                        fname = fname.Substring(0, fname.Length - 4);
                    }

                    var wstream = new WwiseStream()
                    {
                        Container = cname,
                        Name = fname,
                        Offset = uint.Parse(foffset),
                        Size = uint.Parse(fsize),
                        CRC = uint.Parse(fcrc),
                    };

                    wcontainer.Streams.Add(wstream);
                    count++;
                }

                this.WwiseContainers.Add(wcontainer);
            }

            this.UpdateContainerList();
            this.UpdateTotals();

            this.LogMessage("Loaded WwiseStream info, {0} files.", count);
        }

        private void UpdateContainerList()
        {
            this.containerListBox.BeginUpdate();
            this.containerListBox.Items.Clear();

            foreach (var container in this.WwiseContainers)
            {
                this.containerListBox.Items.Add(container);
            }

            this.containerListBox.EndUpdate();
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

            this.totalSizeLabel.Text = string.Format(
                "Selected {0} files, {1}",
                count,
                Helper.FormatByteSize(totalSize));
        }

        private void UpdateFileChecks()
        {
            this.fileListView.BeginUpdate();
            foreach (ListViewItem item in this.fileListView.Items)
            {
                var wstream = item.Tag as WwiseStream;
                if (wstream != null)
                {
                    item.Checked = wstream.WillExtract;
                }
            }
            this.fileListView.EndUpdate();
        }

        private void OnSelectContainer(object sender, EventArgs e)
        {
            this.fileListView.BeginUpdate();
            this.fileListView.Items.Clear();

            var wcontainer =
                this.containerListBox.SelectedItem as WwiseContainer;
            if (wcontainer != null)
            {
                foreach (var wstream in wcontainer.Streams)
                {
                    var item = new ListViewItem(wstream.Name);
                    item.Checked = wstream.WillExtract;
                    item.SubItems.Add(Helper.FormatByteSize(wstream.Size));
                    item.Tag = wstream;
                    this.fileListView.Items.Add(item);
                }
            }

            this.fileListView.EndUpdate();
        }

        private void OnFileChecked(object sender, ItemCheckedEventArgs e)
        {
            var wstream = e.Item.Tag as WwiseStream;
            if (wstream != null)
            {
                wstream.WillExtract = e.Item.Checked;
                this.UpdateTotals();
            }
        }

        private void OnSelectReset(object sender, EventArgs e)
        {
            foreach (var wcontainer in this.WwiseContainers)
            {
                wcontainer.Streams.ForEach(a => a.WillExtract = false);
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectAll(object sender, EventArgs e)
        {
            foreach (var wcontainer in this.WwiseContainers)
            {
                wcontainer.Streams.ForEach(a => a.WillExtract = true);
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectMusic(object sender, EventArgs e)
        {
            foreach (var wcontainer in this.WwiseContainers)
            {
                wcontainer.Streams.ForEach(a =>
                    a.WillExtract = a.WillExtract ||
                        a.Name.StartsWith("mus_") ||
                        a.Name.Contains("music"));
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnSelectAmbience(object sender, EventArgs e)
        {
            foreach (var wcontainer in this.WwiseContainers)
            {
                wcontainer.Streams.ForEach(a =>
                    a.WillExtract = a.WillExtract ||
                        a.Name.StartsWith("amb_") ||
                        a.Name.Contains("ambient"));
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

            foreach (var wcontainer in this.WwiseContainers)
            {
                wcontainer.Streams.ForEach(a =>
                    a.WillExtract = a.WillExtract ||
                        a.Name.Contains(text));
            }

            this.UpdateFileChecks();
            this.UpdateTotals();
        }

        private void OnStart(object sender, EventArgs e)
        {
            ExtractThreadInfo info = new ExtractThreadInfo();
            info.Convert = this.ConverterPath != null ? this.convertCheckBox.Checked : false;
            info.Converter = this.ConverterPath;
            info.Validate = this.validateCheckBox.Checked;

            foreach (var wcontainer in this.WwiseContainers)
            {
                info.Streams.AddRange(wcontainer.Streams.Where(w => w.WillExtract == true));
            }

            if (info.Streams.Count == 0)
            {
                this.LogError("No files selected.");
                return;
            }

            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = info.Streams.Count;
            this.progressBar.Value = 0;

            if (this.savePathDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            info.SavePath = this.savePathDialog.SelectedPath;

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
                    this.openContainerDialog.Title = "Open " + fileName;
                    this.openContainerDialog.Filter = fileName + "|" + fileName;
                    
                    if (this.openContainerDialog.ShowDialog() != DialogResult.OK)
                    {
                        this.LogError("Could not find \"{0}\"!", fileName);
                        continue;
                    }

                    filePath = this.openContainerDialog.FileName;
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
                foreach (Stream stream in this.Containers.Values)
                {
                    stream.Close();
                }
            }
        }

        public void ExtractFiles(object oinfo)
        {
            byte[] buffer = new byte[4096];

            int succeeded, failed, current;
            ExtractThreadInfo info = (ExtractThreadInfo)oinfo;

            succeeded = failed = current = 0;

            foreach (var wstream in info.Streams)
            {
                current++;
                this.SetProgress(current);

                if (info.Containers.ContainsKey(wstream.Container) == false)
                {
                    failed++;
                    continue;
                }

                string savePath = Path.Combine(info.SavePath, wstream.Container);
                string riffPath = Path.Combine(savePath, Path.ChangeExtension(wstream.Name, ".riff"));
                string oggPath = Path.Combine(savePath, Path.ChangeExtension(wstream.Name, ".ogg"));

                Directory.CreateDirectory(savePath);
                
                Stream input = info.Containers[wstream.Container];
                
                if (info.Validate == true)
                {
                    input.Seek(wstream.Offset, SeekOrigin.Begin);

                    uint checksum = 0;
                    int left = (int)wstream.Size;
                    while (left > 0)
                    {
                        int read = input.Read(buffer, 0, (int)Math.Min(left, buffer.Length));
                        if (read == 0)
                        {
                            break;
                        }
                        checksum = CRC32.Compute(buffer, 0, read, checksum);
                        left -= read;
                    }

                    if (checksum != wstream.CRC)
                    {
                        failed++;

                        this.LogError(
                            "CRC mismatch for \"{0}.{1}\"! ({2:X} vs {3:X})",
                            wstream.Container,
                            wstream.Name,
                            wstream.CRC,
                            checksum);

                        continue;
                    }
                }

                Stream output = File.Create(riffPath);
                {
                    input.Seek(wstream.Offset, SeekOrigin.Begin);

                    int left = (int)wstream.Size;
                    while (left > 0)
                    {
                        int read = input.Read(buffer, 0, (int)Math.Min(left, buffer.Length));
                        if (read == 0)
                        {
                            break;
                        }
                        output.Write(buffer, 0, buffer.Length);
                        left -= read;
                    }
                }
                output.Close();

                if (info.Convert == true)
                {
                    Process ogger = new Process();
                    ogger.StartInfo.UseShellExecute = false;
                    ogger.StartInfo.CreateNoWindow = true;
                    ogger.StartInfo.RedirectStandardOutput = true;
                    ogger.StartInfo.FileName = info.Converter;
                    ogger.StartInfo.Arguments = string.Format(
                        "-o \"{0}\" --full-setup \"{1}\"",
                        oggPath,
                        riffPath);

                    ogger.Start();
                    ogger.WaitForExit();

                    if (ogger.ExitCode != 0)
                    {
                        string stdout = ogger.StandardOutput.ReadToEnd();

                        this.LogError("Failed to convert \"{0}.{1}\"!",
                            wstream.Container,
                            wstream.Name);
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

        private void OnShepardIsMyHomeboy(object sender, EventArgs e)
        {
            Process.Start("http://gib.me/");
        }
    }
}
