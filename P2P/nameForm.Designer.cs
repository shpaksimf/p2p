namespace P2P
{
    partial class nameForm
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
            this.mtbName = new MetroFramework.Controls.MetroTextBox();
            this.mbtnAccept = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // mtbName
            // 
            // 
            // 
            // 
            this.mtbName.CustomButton.Image = null;
            this.mtbName.CustomButton.Location = new System.Drawing.Point(137, 1);
            this.mtbName.CustomButton.Name = "";
            this.mtbName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtbName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbName.CustomButton.TabIndex = 1;
            this.mtbName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbName.CustomButton.UseSelectable = true;
            this.mtbName.CustomButton.Visible = false;
            this.mtbName.Lines = new string[0];
            this.mtbName.Location = new System.Drawing.Point(23, 63);
            this.mtbName.MaxLength = 10;
            this.mtbName.Name = "mtbName";
            this.mtbName.PasswordChar = '\0';
            this.mtbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbName.SelectedText = "";
            this.mtbName.SelectionLength = 0;
            this.mtbName.SelectionStart = 0;
            this.mtbName.ShortcutsEnabled = true;
            this.mtbName.Size = new System.Drawing.Size(159, 23);
            this.mtbName.TabIndex = 2;
            this.mtbName.UseSelectable = true;
            this.mtbName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbName_KeyPress);
            // 
            // mbtnAccept
            // 
            this.mbtnAccept.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnAccept.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbtnAccept.Location = new System.Drawing.Point(188, 63);
            this.mbtnAccept.Name = "mbtnAccept";
            this.mbtnAccept.Size = new System.Drawing.Size(148, 23);
            this.mbtnAccept.TabIndex = 3;
            this.mbtnAccept.Text = "Accept";
            this.mbtnAccept.UseSelectable = true;
            this.mbtnAccept.Click += new System.EventHandler(this.mbtnAccept_Click);
            // 
            // nameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 101);
            this.Controls.Add(this.mbtnAccept);
            this.Controls.Add(this.mtbName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "nameForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Enter your name (10 ch max):";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mtbName;
        private MetroFramework.Controls.MetroButton mbtnAccept;
    }
}