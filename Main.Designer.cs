namespace ADBFileTransfer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel1 = new Panel();
            uploadButton = new Button();
            pathLabel = new Label();
            reloadButton = new Button();
            upButton = new Button();
            button2 = new Button();
            button1 = new Button();
            containerPanel = new Panel();
            itemContextMenuStrip = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            itemContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 32, 29);
            panel1.Controls.Add(uploadButton);
            panel1.Controls.Add(pathLabel);
            panel1.Controls.Add(reloadButton);
            panel1.Controls.Add(upButton);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1284, 50);
            panel1.TabIndex = 0;
            // 
            // uploadButton
            // 
            uploadButton.Dock = DockStyle.Right;
            uploadButton.FlatAppearance.BorderSize = 0;
            uploadButton.FlatStyle = FlatStyle.Flat;
            uploadButton.Font = new Font("Segoe UI", 9F);
            uploadButton.ForeColor = Color.White;
            uploadButton.Location = new Point(1201, 10);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(73, 30);
            uploadButton.TabIndex = 5;
            uploadButton.Text = "Upload";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // pathLabel
            // 
            pathLabel.BackColor = Color.FromArgb(44, 44, 42);
            pathLabel.Dock = DockStyle.Fill;
            pathLabel.ForeColor = Color.White;
            pathLabel.Location = new Point(130, 10);
            pathLabel.Name = "pathLabel";
            pathLabel.Padding = new Padding(10, 0, 0, 0);
            pathLabel.Size = new Size(1144, 30);
            pathLabel.TabIndex = 1;
            pathLabel.Text = "PATH";
            pathLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // reloadButton
            // 
            reloadButton.Dock = DockStyle.Left;
            reloadButton.FlatAppearance.BorderSize = 0;
            reloadButton.FlatStyle = FlatStyle.Flat;
            reloadButton.Font = new Font("Microsoft Sans Serif", 20.25F);
            reloadButton.ForeColor = Color.White;
            reloadButton.Location = new Point(100, 10);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(30, 30);
            reloadButton.TabIndex = 0;
            reloadButton.Text = "↻";
            reloadButton.UseCompatibleTextRendering = true;
            reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += loadButton_Click;
            // 
            // upButton
            // 
            upButton.Dock = DockStyle.Left;
            upButton.FlatAppearance.BorderSize = 0;
            upButton.FlatStyle = FlatStyle.Flat;
            upButton.Font = new Font("Microsoft Sans Serif", 20.25F);
            upButton.ForeColor = Color.White;
            upButton.Location = new Point(70, 10);
            upButton.Name = "upButton";
            upButton.Size = new Size(30, 30);
            upButton.TabIndex = 4;
            upButton.Text = "⮬";
            upButton.UseCompatibleTextRendering = true;
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += upButton_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Left;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 20.25F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(40, 10);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 3;
            button2.Text = "⮞";
            button2.UseCompatibleTextRendering = true;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 20.25F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(10, 10);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 2;
            button1.Text = "⮜";
            button1.UseCompatibleTextRendering = true;
            button1.UseVisualStyleBackColor = true;
            // 
            // containerPanel
            // 
            containerPanel.AutoScroll = true;
            containerPanel.BackColor = Color.FromArgb(25, 25, 25);
            containerPanel.Dock = DockStyle.Fill;
            containerPanel.Location = new Point(0, 50);
            containerPanel.Name = "containerPanel";
            containerPanel.Size = new Size(1284, 811);
            containerPanel.TabIndex = 1;
            containerPanel.MouseDown += containerPanel_MouseDown;
            // 
            // itemContextMenuStrip
            // 
            itemContextMenuStrip.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem, renameToolStripMenuItem });
            itemContextMenuStrip.Name = "itemContextMenuStrip";
            itemContextMenuStrip.Size = new Size(118, 48);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(117, 22);
            deleteToolStripMenuItem.Tag = "Edit";
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click_1;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(117, 22);
            renameToolStripMenuItem.Tag = "Edit";
            renameToolStripMenuItem.Text = "Rename";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 861);
            Controls.Add(containerPanel);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quest 2 File Transfer";
            FormClosed += Main_FormClosed;
            Load += Main_Load;
            panel1.ResumeLayout(false);
            itemContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel containerPanel;
        private Button reloadButton;
        private Label pathLabel;
        private Button upButton;
        private Button button2;
        private Button button1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        public ContextMenuStrip itemContextMenuStrip;
        private Button uploadButton;
    }
}
