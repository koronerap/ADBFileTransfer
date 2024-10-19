namespace ADBFileTransfer
{
    partial class Progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
            panel1 = new Panel();
            destinationLabel = new Label();
            panel2 = new Panel();
            labelProgress = new Label();
            button2 = new Button();
            button1 = new Button();
            progressBar = new ProgressBar();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(destinationLabel);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(progressBar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(26, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(395, 74);
            panel1.TabIndex = 0;
            // 
            // destinationLabel
            // 
            destinationLabel.AutoEllipsis = true;
            destinationLabel.Dock = DockStyle.Bottom;
            destinationLabel.Location = new Point(0, 15);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(395, 17);
            destinationLabel.TabIndex = 1;
            destinationLabel.Text = "Destination";
            destinationLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelProgress);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(395, 27);
            panel2.TabIndex = 2;
            // 
            // labelProgress
            // 
            labelProgress.Dock = DockStyle.Fill;
            labelProgress.Font = new Font("Segoe UI", 11F);
            labelProgress.Location = new Point(0, 0);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(315, 27);
            labelProgress.TabIndex = 0;
            labelProgress.Text = "Progress";
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Black", 9F);
            button2.Location = new Point(315, 0);
            button2.Name = "button2";
            button2.Size = new Size(40, 27);
            button2.TabIndex = 2;
            button2.Text = "❚❚";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(355, 0);
            button1.Name = "button1";
            button1.Size = new Size(40, 27);
            button1.TabIndex = 1;
            button1.Text = "❌";
            button1.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Location = new Point(0, 59);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(395, 15);
            progressBar.TabIndex = 0;
            // 
            // Progress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(447, 133);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Progress";
            Padding = new Padding(26, 0, 26, 59);
            Text = "Progress";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ProgressBar progressBar;
        private Label destinationLabel;
        private Panel panel2;
        private Label labelProgress;
        private Button button2;
        private Button button1;
    }
}