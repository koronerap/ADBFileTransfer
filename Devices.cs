using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBFileTransfer
{
    public partial class Devices : Form
    {
        public static Devices Instance;

        public Devices()
        {
            InitializeComponent();
            Instance = this;
        }

        public static List<string> GetConnectedDevices()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = Constants.ADB_EXECUTABLE_PATH,
                Arguments = "devices",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            List<string> devices = new List<string>();

            using (Process adbProcess = Process.Start(startInfo))
            {
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                string[] lines = output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // İlk satır genellikle "List of devices attached" olur, bu yüzden ikinci satırdan itibaren cihazları alıyoruz
                for (int i = 1; i < lines.Length; i++)
                {
                    if (lines[i].Contains("device"))
                    {
                        // Cihaz ID'si ilk boşluk öncesinde yer alır
                        string deviceId = lines[i].Split('\t')[0];
                        devices.Add(deviceId);
                    }
                }
            }
            return devices;
        }

        private static void GetDevices()
        {
            List<string> devices = GetConnectedDevices();
        }

        private void Devices_Load(object sender, EventArgs e)
        {
            UpdateDevices();
        }

        private void UpdateDevices()
        {
            List<string> devices = GetConnectedDevices();

            containerPanel.Controls.Clear();

            foreach (var id in devices)
            {
                Device info = new Device(id);

                DeviceItem item = new DeviceItem();
                item.SetDevice(info);
                item.Dock = DockStyle.Top;

                containerPanel.Controls.Add(item);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateDevices();
        }

        public void Select(DeviceItem item)
        {
            foreach(Control control in containerPanel.Controls)
            {
                bool selected = control == item;
                control.BackColor = selected ? Color.FromArgb(44,44,42) : containerPanel.BackColor;
            }
        }
    }

    public class Device
    {
        public string ID { get; private set; } = "";
        public string Manufacturer { get; private set; } = "";
        public string Model { get; private set; } = "";
        public string AndroidVersion { get; private set; } = "";
        public string SdkVersion { get; private set; } = "";
        public string SerialNumber { get; private set; } = "";

        public Device(string id)
        {
            ID = id;
            Manufacturer = GetInfo(id, "ro.product.manufacturer");
            Model = GetInfo(id, "ro.product.model");
            AndroidVersion = GetInfo(id, "ro.build.version.release");
            SdkVersion = GetInfo(id, "ro.build.version.sdk");
            SerialNumber = GetInfo(id, "ro.serialno");

            if (Manufacturer.Length > 0) Manufacturer = Manufacturer[0].ToString().ToUpperInvariant() + Manufacturer.Substring(1, Manufacturer.Length - 1);
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}\nModel: {Model}\nAndroidVersion: {AndroidVersion}\nSdkVersion: {SdkVersion}\nSerialNumber: {SerialNumber}";
        }

        public static string GetInfo(string deviceId, string property)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = Constants.ADB_EXECUTABLE_PATH,
                Arguments = $"-s {deviceId} shell getprop {property}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process adbProcess = Process.Start(startInfo))
            {
                adbProcess.WaitForExit();
                string output = adbProcess.StandardOutput.ReadToEnd();
                return output.Trim();
            }
        }
    }
}
