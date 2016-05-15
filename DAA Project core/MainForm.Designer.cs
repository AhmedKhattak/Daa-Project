namespace DAA_Project_core
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.MainHeading = new System.Windows.Forms.Label();
            this.FolderPathTextbox = new System.Windows.Forms.TextBox();
            this.WindowsSizeSpinner = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.ExportLogButton = new System.Windows.Forms.Button();
            this.FilesLeft = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.iconButton1 = new FontAwesomeIcons.IconButton();
            this.AboutButton = new FontAwesomeIcons.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsSizeSpinner)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutButton)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFolderButton.Location = new System.Drawing.Point(443, 57);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(87, 27);
            this.OpenFolderButton.TabIndex = 0;
            this.OpenFolderButton.Text = "Open...";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // MainHeading
            // 
            this.MainHeading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainHeading.AutoSize = true;
            this.MainHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainHeading.ForeColor = System.Drawing.Color.Black;
            this.MainHeading.Location = new System.Drawing.Point(160, 12);
            this.MainHeading.Name = "MainHeading";
            this.MainHeading.Size = new System.Drawing.Size(220, 21);
            this.MainHeading.TabIndex = 1;
            this.MainHeading.Text = "Document Similarity Checker";
            // 
            // FolderPathTextbox
            // 
            this.FolderPathTextbox.Location = new System.Drawing.Point(113, 60);
            this.FolderPathTextbox.Name = "FolderPathTextbox";
            this.FolderPathTextbox.Size = new System.Drawing.Size(312, 21);
            this.FolderPathTextbox.TabIndex = 2;
            // 
            // WindowsSizeSpinner
            // 
            this.WindowsSizeSpinner.Location = new System.Drawing.Point(113, 125);
            this.WindowsSizeSpinner.Name = "WindowsSizeSpinner";
            this.WindowsSizeSpinner.Size = new System.Drawing.Size(312, 21);
            this.WindowsSizeSpinner.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder Path :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Window Size :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LogBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 254);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.Location = new System.Drawing.Point(6, 23);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(510, 225);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 23);
            this.label5.TabIndex = 7;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ExecuteButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExecuteButton.Location = new System.Drawing.Point(443, 121);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(87, 27);
            this.ExecuteButton.TabIndex = 9;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLogButton.Location = new System.Drawing.Point(447, 427);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(87, 25);
            this.ClearLogButton.TabIndex = 10;
            this.ClearLogButton.Text = "Clear Log";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // ExportLogButton
            // 
            this.ExportLogButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportLogButton.Location = new System.Drawing.Point(354, 427);
            this.ExportLogButton.Name = "ExportLogButton";
            this.ExportLogButton.Size = new System.Drawing.Size(87, 25);
            this.ExportLogButton.TabIndex = 11;
            this.ExportLogButton.Text = "Export Log";
            this.ExportLogButton.UseVisualStyleBackColor = true;
            this.ExportLogButton.Click += new System.EventHandler(this.ExportLogButton_Click);
            // 
            // FilesLeft
            // 
            this.FilesLeft.AutoSize = true;
            this.FilesLeft.Location = new System.Drawing.Point(16, 427);
            this.FilesLeft.Name = "FilesLeft";
            this.FilesLeft.Size = new System.Drawing.Size(16, 15);
            this.FilesLeft.TabIndex = 12;
            this.FilesLeft.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Target file :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 21);
            this.textBox1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(443, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Select file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.ActiveColor = System.Drawing.Color.Black;
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.IconType = FontAwesomeIcons.IconType.Cog;
            this.iconButton1.InActiveColor = System.Drawing.Color.DimGray;
            this.iconButton1.Location = new System.Drawing.Point(466, 12);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(28, 31);
            this.iconButton1.TabIndex = 19;
            this.iconButton1.TabStop = false;
            this.iconButton1.ToolTipText = null;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // AboutButton
            // 
            this.AboutButton.ActiveColor = System.Drawing.Color.Black;
            this.AboutButton.BackColor = System.Drawing.Color.Transparent;
            this.AboutButton.IconType = FontAwesomeIcons.IconType.RuestionCircle;
            this.AboutButton.InActiveColor = System.Drawing.Color.DimGray;
            this.AboutButton.Location = new System.Drawing.Point(500, 12);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(28, 31);
            this.AboutButton.TabIndex = 20;
            this.AboutButton.TabStop = false;
            this.AboutButton.ToolTipText = null;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(542, 474);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FilesLeft);
            this.Controls.Add(this.ExportLogButton);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WindowsSizeSpinner);
            this.Controls.Add(this.FolderPathTextbox);
            this.Controls.Add(this.MainHeading);
            this.Controls.Add(this.OpenFolderButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daa Project";
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            ((System.ComponentModel.ISupportInitialize)(this.WindowsSizeSpinner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AboutButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.Label MainHeading;
        private System.Windows.Forms.TextBox FolderPathTextbox;
        private System.Windows.Forms.NumericUpDown WindowsSizeSpinner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.Button ExportLogButton;
        private System.Windows.Forms.Label FilesLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private FontAwesomeIcons.IconButton iconButton1;
        private FontAwesomeIcons.IconButton AboutButton;
    }
}