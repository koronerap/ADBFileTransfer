using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBFileTransfer
{
    public partial class DeviceItem : UserControl
    {
        public Device Info {get; private set;}

        public DeviceItem()
        {
            InitializeComponent();
        }
        
        public void SetDevice(Device device)
        {
            Info = device;

            propertiesLabel.Text = $"{device.Manufacturer} {device.Model}\n{device.SerialNumber}\nAndroid: {device.AndroidVersion}, SDK:{device.SdkVersion}";
        }

        private void DeviceItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Main main = new Main();
            main.SetDeviceInfo(Info);
            main.Show();
            Devices.Instance.Hide();
        }

        private void DeviceItem_MouseClick(object sender, MouseEventArgs e)
        {
            Devices.Instance.Select(this);
        }

        private void propertiesLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeviceItem_MouseDoubleClick(sender, e);
        }

        private void propertiesLabel_MouseClick(object sender, MouseEventArgs e)
        {
            DeviceItem_MouseClick(sender, e);
        }

        private void iconPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeviceItem_MouseDoubleClick(sender, e);
        }

        private void iconPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            DeviceItem_MouseClick(sender, e);
        }
    }
}
