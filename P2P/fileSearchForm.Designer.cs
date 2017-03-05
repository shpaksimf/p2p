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
            this.mbtnDownoad = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // mbtnDownoad
            // 
            this.mbtnDownoad.BackColor = System.Drawing.Color.White;
            this.mbtnDownoad.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnDownoad.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.mbtnDownoad.Location = new System.Drawing.Point(23, 283);
            this.mbtnDownoad.Name = "mbtnDownoad";
            this.mbtnDownoad.Size = new System.Drawing.Size(136, 23);
            this.mbtnDownoad.Style = MetroFramework.MetroColorStyle.Blue;
            this.mbtnDownoad.TabIndex = 0;
            this.mbtnDownoad.Text = "Download";
            this.mbtnDownoad.UseSelectable = true;
            this.mbtnDownoad.Click += new System.EventHandler(this.mbtnDownoad_Click);
            // 
            // fileSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 329);
            this.Controls.Add(this.mbtnDownoad);
            this.MaximizeBox = false;
            this.Name = "fileSearchForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Search file";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtnDownoad;
    }
}