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
            this.TargetFilePathTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AboutButton = new FontAwesomeIcons.IconButton();
            this.TarGetFolderLabel = new System.Windows.Forms.Label();
            this.outPutFolderTextBox = new System.Windows.Forms.TextBox();
            this.OutPutFolderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsSizeSpinner)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutButton)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFolderButton.Location = new System.Drawing.Point(422, 20);
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
            this.FolderPathTextbox.Location = new System.Drawing.Point(104, 25);
            this.FolderPathTextbox.Name = "FolderPathTextbox";
            this.FolderPathTextbox.Size = new System.Drawing.Size(312, 21);
            this.FolderPathTextbox.TabIndex = 2;
            this.FolderPathTextbox.Text = "No target folder selected";
            // 
            // WindowsSizeSpinner
            // 
            this.WindowsSizeSpinner.Location = new System.Drawing.Point(104, 122);
            this.WindowsSizeSpinner.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WindowsSizeSpinner.Name = "WindowsSizeSpinner";
            this.WindowsSizeSpinner.Size = new System.Drawing.Size(312, 21);
            this.WindowsSizeSpinner.TabIndex = 3;
            this.WindowsSizeSpinner.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folder Path :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Window Size :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LogBox);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 194);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.Location = new System.Drawing.Point(6, 19);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(510, 169);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "...";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ExecuteButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExecuteButton.Location = new System.Drawing.Point(422, 119);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(87, 26);
            this.ExecuteButton.TabIndex = 9;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLogButton.Location = new System.Drawing.Point(447, 467);
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
            this.ExportLogButton.Location = new System.Drawing.Point(354, 467);
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
            this.FilesLeft.Location = new System.Drawing.Point(15, 467);
            this.FilesLeft.Name = "FilesLeft";
            this.FilesLeft.Size = new System.Drawing.Size(16, 15);
            this.FilesLeft.TabIndex = 12;
            this.FilesLeft.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Target file :";
            // 
            // TargetFilePathTextBox
            // 
            this.TargetFilePathTextBox.Location = new System.Drawing.Point(104, 55);
            this.TargetFilePathTextBox.Name = "TargetFilePathTextBox";
            this.TargetFilePathTextBox.Size = new System.Drawing.Size(312, 21);
            this.TargetFilePathTextBox.TabIndex = 14;
            this.TargetFilePathTextBox.Text = "No target file selected";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(422, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Select file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.ActiveColor = System.Drawing.Color.Black;
            this.AboutButton.BackColor = System.Drawing.Color.Transparent;
            this.AboutButton.IconType = FontAwesomeIcons.IconType.RuestionCircle;
            this.AboutButton.InActiveColor = System.Drawing.Color.DimGray;
            this.AboutButton.Location = new System.Drawing.Point(502, 12);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(28, 31);
            this.AboutButton.TabIndex = 20;
            this.AboutButton.TabStop = false;
            this.AboutButton.ToolTipText = null;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // TarGetFolderLabel
            // 
            this.TarGetFolderLabel.AutoSize = true;
            this.TarGetFolderLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TarGetFolderLabel.Location = new System.Drawing.Point(6, 94);
            this.TarGetFolderLabel.Name = "TarGetFolderLabel";
            this.TarGetFolderLabel.Size = new System.Drawing.Size(87, 15);
            this.TarGetFolderLabel.TabIndex = 21;
            this.TarGetFolderLabel.Text = "Output Folder :";
            // 
            // outPutFolderTextBox
            // 
            this.outPutFolderTextBox.Location = new System.Drawing.Point(104, 89);
            this.outPutFolderTextBox.Name = "outPutFolderTextBox";
            this.outPutFolderTextBox.Size = new System.Drawing.Size(312, 21);
            this.outPutFolderTextBox.TabIndex = 22;
            this.outPutFolderTextBox.Text = "No output folder selected";
            // 
            // OutPutFolderButton
            // 
            this.OutPutFolderButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutPutFolderButton.Location = new System.Drawing.Point(422, 86);
            this.OutPutFolderButton.Name = "OutPutFolderButton";
            this.OutPutFolderButton.Size = new System.Drawing.Size(87, 27);
            this.OutPutFolderButton.TabIndex = 23;
            this.OutPutFolderButton.Text = "Select Folder";
            this.OutPutFolderButton.UseVisualStyleBackColor = true;
            this.OutPutFolderButton.Click += new System.EventHandler(this.OutPutFolderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Make Processed files ?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OutPutFolderButton);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.ThresholdTextBox);
            this.groupBox2.Controls.Add(this.outPutFolderTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TargetFilePathTextBox);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.OpenFolderButton);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.ExecuteButton);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TarGetFolderLabel);
            this.groupBox2.Controls.Add(this.FolderPathTextbox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.WindowsSizeSpinner);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 222);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // ThresholdTextBox
            // 
            this.ThresholdTextBox.Location = new System.Drawing.Point(104, 156);
            this.ThresholdTextBox.Name = "ThresholdTextBox";
            this.ThresholdTextBox.Size = new System.Drawing.Size(312, 21);
            this.ThresholdTextBox.TabIndex = 28;
            this.ThresholdTextBox.Text = "0.0";
            this.ThresholdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ThresholdTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Threshold :";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(210, 189);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 19);
            this.radioButton2.TabIndex = 26;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "No";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(159, 189);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 19);
            this.radioButton1.TabIndex = 25;
            this.radioButton1.Text = "Yes";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(542, 518);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.FilesLeft);
            this.Controls.Add(this.ExportLogButton);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainHeading);
            this.Controls.Add(this.groupBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.AboutButton)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox TargetFilePathTextBox;
        private System.Windows.Forms.Button button1;
        private FontAwesomeIcons.IconButton AboutButton;
        private System.Windows.Forms.Label TarGetFolderLabel;
        private System.Windows.Forms.TextBox outPutFolderTextBox;
        private System.Windows.Forms.Button OutPutFolderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox ThresholdTextBox;
        private System.Windows.Forms.Label label4;
    }
}