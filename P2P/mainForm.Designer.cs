namespace P2P
{
    partial class formMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openShareFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSend = new MetroFramework.Controls.MetroButton();
            this.mgFiles = new MetroFramework.Controls.MetroGrid();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileCheckSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtbMessage = new MetroFramework.Controls.MetroTextBox();
            this.mbtnDownload = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mgUsers = new MetroFramework.Controls.MetroGrid();
            this.mgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mgUserIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUsers
            // 
            this.lbUsers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 15;
            this.lbUsers.Location = new System.Drawing.Point(291, 365);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(218, 64);
            this.lbUsers.TabIndex = 0;
            this.lbUsers.TabStop = false;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // rtbChat
            // 
            this.rtbChat.BackColor = System.Drawing.Color.GhostWhite;
            this.rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbChat.Location = new System.Drawing.Point(20, 88);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.Size = new System.Drawing.Size(265, 283);
            this.rtbChat.TabIndex = 2;
            this.rtbChat.TabStop = false;
            this.rtbChat.Text = "";
            this.rtbChat.TextChanged += new System.EventHandler(this.rtbChat_TextChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.GhostWhite;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbLog.Location = new System.Drawing.Point(829, 88);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(262, 341);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.searchFileToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openShareFolderToolStripMenuItem,
            this.changeNameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openShareFolderToolStripMenuItem
            // 
            this.openShareFolderToolStripMenuItem.Name = "openShareFolderToolStripMenuItem";
            this.openShareFolderToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openShareFolderToolStripMenuItem.Text = "Open share folder";
            this.openShareFolderToolStripMenuItem.Click += new System.EventHandler(this.openShareFolderToolStripMenuItem_Click);
            // 
            // changeNameToolStripMenuItem
            // 
            this.changeNameToolStripMenuItem.Name = "changeNameToolStripMenuItem";
            this.changeNameToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.changeNameToolStripMenuItem.Text = "Change name";
            this.changeNameToolStripMenuItem.Click += new System.EventHandler(this.changeNameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // searchFileToolStripMenuItem
            // 
            this.searchFileToolStripMenuItem.Name = "searchFileToolStripMenuItem";
            this.searchFileToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.searchFileToolStripMenuItem.Text = "Search file";
            this.searchFileToolStripMenuItem.Click += new System.EventHandler(this.searchFileToolStripMenuItem_Click);
            // 
            // mbtnSend
            // 
            this.mbtnSend.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnSend.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbtnSend.Location = new System.Drawing.Point(20, 406);
            this.mbtnSend.Name = "mbtnSend";
            this.mbtnSend.Size = new System.Drawing.Size(265, 23);
            this.mbtnSend.Style = MetroFramework.MetroColorStyle.Blue;
            this.mbtnSend.TabIndex = 10;
            this.mbtnSend.TabStop = false;
            this.mbtnSend.Text = "Send";
            this.mbtnSend.UseSelectable = true;
            this.mbtnSend.Click += new System.EventHandler(this.mbtnSend_Click);
            // 
            // mgFiles
            // 
            this.mgFiles.AllowUserToAddRows = false;
            this.mgFiles.AllowUserToDeleteRows = false;
            this.mgFiles.AllowUserToResizeRows = false;
            this.mgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.mgFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mgFiles.ColumnHeadersHeight = 20;
            this.mgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.fileSize,
            this.fileCheckSum});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.mgFiles.EnableHeadersVisualStyles = false;
            this.mgFiles.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mgFiles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgFiles.Location = new System.Drawing.Point(515, 110);
            this.mgFiles.MultiSelect = false;
            this.mgFiles.Name = "mgFiles";
            this.mgFiles.ReadOnly = true;
            this.mgFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mgFiles.RowHeadersVisible = false;
            this.mgFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgFiles.ShowCellErrors = false;
            this.mgFiles.ShowCellToolTips = false;
            this.mgFiles.ShowEditingIcon = false;
            this.mgFiles.ShowRowErrors = false;
            this.mgFiles.Size = new System.Drawing.Size(308, 290);
            this.mgFiles.Style = MetroFramework.MetroColorStyle.Blue;
            this.mgFiles.TabIndex = 11;
            this.mgFiles.TabStop = false;
            this.mgFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mgFiles_CellClick);
            this.mgFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mgFiles_KeyPress);
            // 
            // fileName
            // 
            this.fileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileName.HeaderText = "Name";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // fileSize
            // 
            this.fileSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fileSize.HeaderText = "Size (b)";
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            this.fileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fileSize.Width = 47;
            // 
            // fileCheckSum
            // 
            this.fileCheckSum.HeaderText = "CheckSum";
            this.fileCheckSum.Name = "fileCheckSum";
            this.fileCheckSum.ReadOnly = true;
            // 
            // mtbMessage
            // 
            // 
            // 
            // 
            this.mtbMessage.CustomButton.Image = null;
            this.mtbMessage.CustomButton.Location = new System.Drawing.Point(243, 1);
            this.mtbMessage.CustomButton.Name = "";
            this.mtbMessage.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtbMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbMessage.CustomButton.TabIndex = 1;
            this.mtbMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbMessage.CustomButton.UseSelectable = true;
            this.mtbMessage.CustomButton.Visible = false;
            this.mtbMessage.Lines = new string[0];
            this.mtbMessage.Location = new System.Drawing.Point(20, 377);
            this.mtbMessage.MaxLength = 32767;
            this.mtbMessage.Name = "mtbMessage";
            this.mtbMessage.PasswordChar = '\0';
            this.mtbMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbMessage.SelectedText = "";
            this.mtbMessage.SelectionLength = 0;
            this.mtbMessage.SelectionStart = 0;
            this.mtbMessage.ShortcutsEnabled = true;
            this.mtbMessage.Size = new System.Drawing.Size(265, 23);
            this.mtbMessage.TabIndex = 0;
            this.mtbMessage.UseSelectable = true;
            this.mtbMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtbMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbMessage_KeyPress);
            // 
            // mbtnDownload
            // 
            this.mbtnDownload.Enabled = false;
            this.mbtnDownload.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnDownload.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbtnDownload.Location = new System.Drawing.Point(515, 406);
            this.mbtnDownload.Name = "mbtnDownload";
            this.mbtnDownload.Size = new System.Drawing.Size(308, 23);
            this.mbtnDownload.TabIndex = 12;
            this.mbtnDownload.Text = "Download";
            this.mbtnDownload.UseSelectable = true;
            this.mbtnDownload.Click += new System.EventHandler(this.mbtnDownload_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(291, 88);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "Users online:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(515, 88);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(101, 19);
            this.metroLabel2.TabIndex = 14;
            this.metroLabel2.Text = "File list is empty";
            // 
            // mgUsers
            // 
            this.mgUsers.AllowUserToAddRows = false;
            this.mgUsers.AllowUserToDeleteRows = false;
            this.mgUsers.AllowUserToResizeRows = false;
            this.mgUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mgUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.mgUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.mgUsers.ColumnHeadersHeight = 20;
            this.mgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mgUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mgUserName,
            this.mgUserIP});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mgUsers.DefaultCellStyle = dataGridViewCellStyle5;
            this.mgUsers.EnableHeadersVisualStyles = false;
            this.mgUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mgUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgUsers.Location = new System.Drawing.Point(291, 110);
            this.mgUsers.Name = "mgUsers";
            this.mgUsers.ReadOnly = true;
            this.mgUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mgUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.mgUsers.RowHeadersVisible = false;
            this.mgUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mgUsers.Size = new System.Drawing.Size(218, 249);
            this.mgUsers.Style = MetroFramework.MetroColorStyle.Blue;
            this.mgUsers.TabIndex = 15;
            this.mgUsers.SelectionChanged += new System.EventHandler(this.mgUsers_SelectionChanged);
            this.mgUsers.Click += new System.EventHandler(this.mgUsers_SelectionChanged);
            // 
            // mgUserName
            // 
            this.mgUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mgUserName.HeaderText = "Name";
            this.mgUserName.Name = "mgUserName";
            this.mgUserName.ReadOnly = true;
            // 
            // mgUserIP
            // 
            this.mgUserIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.mgUserIP.HeaderText = "Address";
            this.mgUserIP.Name = "mgUserIP";
            this.mgUserIP.ReadOnly = true;
            this.mgUserIP.Width = 71;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 441);
            this.Controls.Add(this.mgUsers);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mbtnDownload);
            this.Controls.Add(this.mtbMessage);
            this.Controls.Add(this.mgFiles);
            this.Controls.Add(this.mbtnSend);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "P2P";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mgFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openShareFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchFileToolStripMenuItem;
        private MetroFramework.Controls.MetroButton mbtnSend;
        private MetroFramework.Controls.MetroGrid mgFiles;
        private MetroFramework.Controls.MetroTextBox mtbMessage;
        private MetroFramework.Controls.MetroButton mbtnDownload;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ToolStripMenuItem changeNameToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileCheckSum;
        private MetroFramework.Controls.MetroGrid mgUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn mgUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mgUserIP;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;

    }
}

