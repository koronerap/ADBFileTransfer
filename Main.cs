using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace ADBFileTransfer
{
    public partial class Main : Form
    {
        public const string ROOT = "/sdcard/";
        public string currentPath { get; private set; } = "/sdcard/";

        public DirectoryItem CurrentSelected;

        public static Main Instance;

        public Device DeviceInfo { get; private set; }

        public Main()
        {
            InitializeComponent();
            Instance = this;
            CheckForIllegalCrossThreadCalls = false;
        }

        private DirectoryItem AddDirectoryItem(Item item)
        {
            DirectoryItem dirItem = new DirectoryItem();
            dirItem.Set(item);
            containerPanel.Controls.Add(dirItem);
            dirItem.Dock = DockStyle.Top;
            return dirItem;
        }


        public void Reload()
        {
            ListItems(GetDetailedDirectory(currentPath));
        }

        private Item[] GetDetailedDirectory(string target)
        {
            List<Item> items = new List<Item>();

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = Constants.ADB_EXECUTABLE_PATH, // ADB'nin bulunduðu dizin
                Arguments = $"-s {DeviceInfo.ID} shell ls -l \"{target}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };


            Process adbProcess = new Process() { StartInfo = startInfo };
            adbProcess.Start();
            string output = adbProcess.StandardOutput.ReadToEnd();
            adbProcess.WaitForExit();

            string[] details = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (string detail in details)
            {
                Item item = new Item(detail);
                if(item.Name.Length > 0)
                    items.Add(item);
            }

            return items.ToArray();
        }


        private void loadButton_Click(object sender, EventArgs e)
        {
            ListItems(GetDetailedDirectory(currentPath));
        }

        private void containerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //browserContextMenu.Show(e.Location);
            }
        }


        public void Select(DirectoryItem selection)
        {
            foreach (Control item in containerPanel.Controls)
            {
                bool selected = item == selection;
                item.BackColor = selected ? Color.FromArgb(36, 36, 36) : containerPanel.BackColor;

                if (selected) CurrentSelected = (DirectoryItem)item;
            }
        }

        public void Go(string target)
        {
            currentPath = Path.Combine(currentPath, target).Replace("\\", "/");
            ListItems(GetDetailedDirectory(currentPath));
        }

        public void Up()
        {
            string[] parts = currentPath.Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return;

            string path = "/";

            for (int i = 0; i < parts.Length - 1; i++)
            {
                path += parts[i] + "/";
            }

            currentPath = path;
            ListItems(GetDetailedDirectory(currentPath));
        }

        public void ListItems(Item[] output)
        {
            output = output.OrderByDescending(o => o.Name).ToArray();

            DirectoryItem[] items = containerPanel.Controls.OfType<DirectoryItem>().ToArray();

            foreach (var item in items)
                item.Dispose();


            int i = 0;
            foreach (var item in output)
            {
                Trace.WriteLine($"{i} {item.Name}");

                AddDirectoryItem(item);
                i++;
            }

            DirectoryItem[] ordered = containerPanel.Controls
    .OfType<DirectoryItem>()
    .OrderByDescending(x => x.Info.IsDirectory) // Dizinler önce gelir
    .ThenBy(x => x.Info.Name) // Daha sonra alfabetik sýralama
    .ToArray();

            foreach (var item in ordered)
                item.BringToFront();

            pathLabel.Text = currentPath;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ListItems(GetDetailedDirectory(ROOT));

            //MessageBox.Show(HttpUtility.UrlEncode("("));
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            Up();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (CurrentSelected == null) return;

            string path = $"{currentPath}/{CurrentSelected.Info.Name}";
            Trace.WriteLine("Delete: " + path);

            if (TryDeleteFile(path))
            {
                Reload();
            }
        }


        private bool TryDeleteFile(string filePath)
        {
            filePath = Regex.Escape(filePath);

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = Constants.ADB_EXECUTABLE_PATH,
                Arguments = $"-s {DeviceInfo.ID} shell rm \"{filePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                Process adbProcess = new Process() { StartInfo = startInfo };
                adbProcess.Start();

                string output = adbProcess.StandardOutput.ReadToEnd();
                string error = adbProcess.StandardError.ReadToEnd();
                adbProcess.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Hata: " + error + "\n" + startInfo.Arguments);
                    return false;
                }

                if (output.Contains("No such file or directory"))
                {
                    MessageBox.Show("Dosya bulunamadý.");
                    return false;
                }

                return true; // Baþarýyla silindi
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message + "\n" + startInfo.Arguments);
                return false;
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Upload file";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var filename in ofd.FileNames)
                    Upload(filename);
            }
        }

        private void Upload(string filename)
        {
            Progress progressItem = new Progress();
            progressItem.Dock = DockStyle.Top;

            // Dosya yükleme iþlemini baþlat
            string sourceFilePath = filename.Replace("\\", "/"); // Yüklemek istediðiniz dosyanýn yolu
            string targetFilePath = Path.Combine(currentPath, Path.GetFileName(filename)).Replace("\\", "/"); // Quest cihazýndaki hedef yol

            Trace.WriteLine($"Source: {sourceFilePath}, Target: {targetFilePath}");
            progressItem.StartUpload(DeviceInfo.ID, sourceFilePath, targetFilePath);
            progressItem.Show();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSelected == null) return;

            string path = $"{currentPath}/{CurrentSelected.Info.Name}";

            string ce = Path.GetExtension(CurrentSelected.Info.Name);

            string newName = Interaction.InputBox("Enter new file name:", "Rename", CurrentSelected.Info.Name);

            string ne = Path.GetExtension(newName);

            if (ne != ce && MessageBox.Show("Extensions are different. Are you sure?", "Rename", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            string newPath = $"{currentPath}/{newName}";

            ADBCommands.Rename(path, newPath);

            Reload();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
            Devices.Instance.Show();
        }

        public void SetDeviceInfo(Device item)
        {
            DeviceInfo = item;
            Text = $"{DeviceInfo.Manufacturer} {DeviceInfo.Model}";
        }
    }

    public class Item
    {
        public string Permissions { get; set; } = "";
        public int HardLinks = 0;
        public string Owner { get; set; } = "";
        public string Group { get; set; } = "";
        public long Bytes = 0;
        public DateTime LastEditTime = DateTime.Now;
        public string Name { get; set; } = "";
        public string Raw { get; set; } = "";
        public bool IsDirectory => Permissions.Length > 0 && Permissions[0] == 'd';
        public bool Editable => IsEditable();

        public Item(string raw)
        {
            Raw = raw;

            string[] parts = Raw.Split(' ',8,StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 5) return;

            Permissions = parts[0];
            bool hlParsed = int.TryParse(parts[1], out HardLinks);
            Owner = parts[2];
            Group = parts[3];
            bool bytesParsed = long.TryParse(parts[4], out Bytes);

            DateTime.TryParse($"{parts[5]} {parts[6]}", out LastEditTime);
            Name = parts[7];

            //Trace.WriteLine($"{hlParsed} {parts[1]}, {bytesParsed} {parts[4]}");
        }

        private bool IsEditable()
        {
            try
            {
                return Permissions[5] != '-';
            }
            catch
            {
                return false;
            }
        }
    }
}
