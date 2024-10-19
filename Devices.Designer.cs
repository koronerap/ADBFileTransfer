namespace ADBFileTransfer
{
    partial class Devices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Devices));
            headerPanel = new Panel();
            reloadButton = new Button();
            label1 = new Label();
            containerPanel = new Panel();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(32, 32, 29);
            headerPanel.Controls.Add(reloadButton);
            headerPanel.Controls.Add(label1);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(10);
            headerPanel.Size = new Size(800, 50);
            headerPanel.TabIndex = 0;
            // 
            // reloadButton
            // 
            reloadButton.Dock = DockStyle.Right;
            reloadButton.FlatAppearance.BorderSize = 0;
            reloadButton.FlatStyle = FlatStyle.Flat;
            reloadButton.Font = new Font("Segoe UI", 20.25F);
            reloadButton.ForeColor = Color.White;
            reloadButton.Location = new Point(760, 10);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(30, 30);
            reloadButton.TabIndex = 1;
            reloadButton.Text = "↻";
            reloadButton.UseCompatibleTextRendering = true;
            reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += reloadButton_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(254, 30);
            label1.TabIndex = 0;
            label1.Text = "Connected Devices";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // containerPanel
            // 
            containerPanel.AutoScroll = true;
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(0, 50);
            containerPanel.Name = "containerPanel";
            containerPanel.Size = new Size(800, 400);
            containerPanel.TabIndex = 1;
            // 
            // Devices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(containerPanel);
            Controls.Add(headerPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Devices";
            Text = "Devices";
            Load += Devices_Load;
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Panel containerPanel;
        private Label label1;
        private Button reloadButton;
    }
}