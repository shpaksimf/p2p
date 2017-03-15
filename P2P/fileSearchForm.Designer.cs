namespace P2P
{
    partial class fileSearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mbtnDownoad = new MetroFramework.Controls.MetroButton();
            this.mgFoundFiles = new MetroFramework.Controls.MetroGrid();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCheckSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbFileName = new System.Windows.Forms.ComboBox();
            this.mbFind = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.mgFoundFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // mbtnDownoad
            // 
            this.mbtnDownoad.BackColor = System.Drawing.Color.White;
            this.mbtnDownoad.Enabled = false;
            this.mbtnDownoad.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnDownoad.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbtnDownoad.Location = new System.Drawing.Point(129, 248);
            this.mbtnDownoad.Name = "mbtnDownoad";
            this.mbtnDownoad.Size = new System.Drawing.Size(100, 23);
            this.mbtnDownoad.Style = MetroFramework.MetroColorStyle.Blue;
            this.mbtnDownoad.TabIndex = 0;
            this.mbtnDownoad.Text = "Download";
            this.mbtnDownoad.UseSelectable = true;
            this.mbtnDownoad.Click += new System.EventHandler(this.mbtnDownoad_Click);
            // 
            // mgFoundFiles
            // 
            this.mgFoundFiles.AllowUserToAddRows = false;
            this.mgFoundFiles.AllowUserToDeleteRows = false;
            this.mgFoundFiles.AllowUserToResizeColumns = false;
            this.mgFoundFiles.AllowUserToResizeRows = false;
            this.mgFoundFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgFoundFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgFoundFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.mgFoundFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgFoundFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mgFoundFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mgFoundFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.user,
            this.userIP,
            this.fileSize,
            this.fileCheckSum});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgFoundFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.mgFoundFiles.EnableHeadersVisualStyles = false;
            this.mgFoundFiles.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mgFoundFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgFoundFiles.Location = new System.Drawing.Point(235, 63);
            this.mgFoundFiles.MultiSelect = false;
            this.mgFoundFiles.Name = "mgFoundFiles";
            this.mgFoundFiles.ReadOnly = true;
            this.mgFoundFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgFoundFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mgFoundFiles.RowHeadersVisible = false;
            this.mgFoundFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mgFoundFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgFoundFiles.Size = new System.Drawing.Size(556, 221);
            this.mgFoundFiles.TabIndex = 1;
            this.mgFoundFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mgFoundFiles_CellClick);
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileName.HeaderText = "Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            this.fileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // user
            // 
            this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.user.HeaderText = "User";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 53;
            // 
            // userIP
            // 
            this.userIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.userIP.HeaderText = "Address";
            this.userIP.Name = "userIP";
            this.userIP.ReadOnly = true;
            this.userIP.Width = 71;
            // 
            // fileSize
            // 
            this.fileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fileSize.HeaderText = "Size (b)";
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            this.fileSize.Width = 66;
            // 
            // fileCheckSum
            // 
            this.fileCheckSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fileCheckSum.HeaderText = "Checksum";
            this.fileCheckSum.Name = "fileCheckSum";
            this.fileCheckSum.ReadOnly = true;
            this.fileCheckSum.Width = 82;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Search:";
            // 
            // cbFileName
            // 
            this.cbFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFileName.FormattingEnabled = true;
            this.cbFileName.ItemHeight = 15;
            this.cbFileName.Location = new System.Drawing.Point(23, 82);
            this.cbFileName.Name = "cbFileName";
            this.cbFileName.Size = new System.Drawing.Size(206, 23);
            this.cbFileName.TabIndex = 5;
            this.cbFileName.TextUpdate += new System.EventHandler(this.cbFileName_TextUpdate);
            this.cbFileName.TextChanged += new System.EventHandler(this.cbFileName_TextUpdate);
            this.cbFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFileName_KeyPress);
            // 
            // mbFind
            // 
            this.mbFind.BackColor = System.Drawing.Color.White;
            this.mbFind.Enabled = false;
            this.mbFind.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbFind.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbFind.Location = new System.Drawing.Point(23, 248);
            this.mbFind.Name = "mbFind";
            this.mbFind.Size = new System.Drawing.Size(100, 23);
            this.mbFind.Style = MetroFramework.MetroColorStyle.Blue;
            this.mbFind.TabIndex = 6;
            this.mbFind.Text = "Find...";
            this.mbFind.UseSelectable = true;
            this.mbFind.Click += new System.EventHandler(this.mbFind_Click);
            // 
            // fileSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 368);
            this.Controls.Add(this.mbFind);
            this.Controls.Add(this.cbFileName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mgFoundFiles);
            this.Controls.Add(this.mbtnDownoad);
            this.MaximizeBox = false;
            this.Name = "fileSearchForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Search file";
            this.Load += new System.EventHandler(this.fileSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mgFoundFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtnDownoad;
        private MetroFramework.Controls.MetroGrid mgFoundFiles;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox cbFileName;
        private MetroFramework.Controls.MetroButton mbFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCheckSum;
    }
}