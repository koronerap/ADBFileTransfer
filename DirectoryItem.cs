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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADBFileTransfer
{
    public partial class DirectoryItem : UserControl
    {
        public string Target = "";

        public Item Info;

        public DirectoryItem()
        {
            InitializeComponent();
        }

        public void Set(Item item)
        {
            Info = item;
            Target = item.Name;
            targetLabel.Text = Target + (Info.IsDirectory ? "" : $" - {SizeSuffix(Info.Bytes)}");

            iconPictureBox.Image = Info.IsDirectory ? Properties.Resources.folder : Extensions.FromExtension(Path.GetExtension(item.Name));
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }


        #region Events

        private void DirectoryItem_MouseClick(object sender, MouseEventArgs e)
        {
            Main.Instance.Select(this);

            if (e.Button == MouseButtons.Right)
            {
                //Main.Instance.currentSelected = this;

                for(int i =  0; i < Main.Instance.itemContextMenuStrip.Items.Count; i++)
                {
                    var item = Main.Instance.itemContextMenuStrip.Items[i];

                    if(item != null && item.Tag != null)
                    {
                        if (item.Tag == "Edit")
                        {
                            item.Enabled = Info.Editable;
                        }
                    }

                    
                }

                Main.Instance.itemContextMenuStrip.Show(Cursor.Position);

            }
        }

        private void targetLabel_MouseClick(object sender, MouseEventArgs e)
        {
            DirectoryItem_MouseClick(sender, e);
        }

        private void iconPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            DirectoryItem_MouseClick(sender, e);
        }

        private void DirectoryItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Main.Instance.Go(Target);
            }
        }

        private void targetLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DirectoryItem_MouseDoubleClick(sender, e);
        }

        private void iconPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DirectoryItem_MouseDoubleClick(sender, e);
        }

        #endregion
    }
}
