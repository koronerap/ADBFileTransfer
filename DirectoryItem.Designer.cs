namespace ADBFileTransfer
{
    partial class DirectoryItem
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
            targetLabel = new Label();
            iconPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // targetLabel
            // 
            targetLabel.Dock = DockStyle.Fill;
            targetLabel.ForeColor = Color.White;
            targetLabel.Location = new Point(40, 10);
            targetLabel.Name = "targetLabel";
            targetLabel.Padding = new Padding(5, 0, 0, 0);
            targetLabel.Size = new Size(552, 30);
            targetLabel.TabIndex = 1;
            targetLabel.Text = "Label";
            targetLabel.TextAlign = ContentAlignment.MiddleLeft;
            targetLabel.MouseClick += targetLabel_MouseClick;
            targetLabel.MouseDoubleClick += targetLabel_MouseDoubleClick;
            // 
            // iconPictureBox
            // 
            iconPictureBox.Dock = DockStyle.Left;
            iconPictureBox.Image = Properties.Resources.unknown;
            iconPictureBox.Location = new Point(10, 10);
            iconPictureBox.Name = "iconPictureBox";
            iconPictureBox.Size = new Size(30, 30);
            iconPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox.TabIndex = 0;
            iconPictureBox.TabStop = false;
            iconPictureBox.MouseClick += iconPictureBox_MouseClick;
            iconPictureBox.MouseDoubleClick += iconPictureBox_MouseDoubleClick;
            // 
            // DirectoryItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            Controls.Add(targetLabel);
            Controls.Add(iconPictureBox);
            Name = "DirectoryItem";
            Padding = new Padding(10);
            Size = new Size(602, 50);
            MouseClick += DirectoryItem_MouseClick;
            MouseDoubleClick += DirectoryItem_MouseDoubleClick;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox iconPictureBox;
        private Label targetLabel;
    }
}
