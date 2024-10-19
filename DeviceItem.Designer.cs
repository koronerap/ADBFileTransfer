namespace ADBFileTransfer
{
    partial class DeviceItem
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            iconPictureBox = new PictureBox();
            propertiesLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // iconPictureBox
            // 
            iconPictureBox.Dock = DockStyle.Left;
            iconPictureBox.Image = Properties.Resources.android;
            iconPictureBox.Location = new Point(10, 10);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(55, 55);
            iconPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            iconPictureBox.MouseClick += iconPictureBox_MouseClick;
            iconPictureBox.MouseDoubleClick += iconPictureBox_MouseDoubleClick;
            // 
            // propertiesLabel
            // 
            propertiesLabel.Dock = DockStyle.Fill;
            propertiesLabel.ForeColor = Color.White;
            propertiesLabel.Location = new Point(65, 10);
            propertiesLabel.Name = "propertiesLabel";
            propertiesLabel.Padding = new Padding(5, 0, 0, 0);
            propertiesLabel.Size = new Size(382, 55);
            propertiesLabel.TabIndex = 1;
            propertiesLabel.TextAlign = ContentAlignment.MiddleLeft;
            propertiesLabel.MouseClick += propertiesLabel_MouseClick;
            propertiesLabel.MouseDoubleClick += propertiesLabel_MouseDoubleClick;
            // 
            // DeviceItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(propertiesLabel);
            Controls.Add(iconPictureBox);
            Name = "DeviceItem";
            Padding = new Padding(10);
            Size = new Size(457, 75);
            MouseClick += DeviceItem_MouseClick;
            MouseDoubleClick += DeviceItem_MouseDoubleClick;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox iconPictureBox;
        private Label propertiesLabel;
    }
}
