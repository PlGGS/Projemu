namespace Projemu
{
    partial class frmMain
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
            this.chkShowMenuStrip = new System.Windows.Forms.CheckBox();
            this.lblShowMenuStrip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxScreenNum = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkShowMenuStrip
            // 
            this.chkShowMenuStrip.AutoSize = true;
            this.chkShowMenuStrip.Checked = true;
            this.chkShowMenuStrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMenuStrip.Location = new System.Drawing.Point(151, 9);
            this.chkShowMenuStrip.Name = "chkShowMenuStrip";
            this.chkShowMenuStrip.Size = new System.Drawing.Size(15, 14);
            this.chkShowMenuStrip.TabIndex = 7;
            this.chkShowMenuStrip.UseVisualStyleBackColor = true;
            this.chkShowMenuStrip.CheckedChanged += new System.EventHandler(this.chkShowMenuStrip_CheckedChanged);
            // 
            // lblShowMenuStrip
            // 
            this.lblShowMenuStrip.AutoSize = true;
            this.lblShowMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowMenuStrip.Location = new System.Drawing.Point(10, 9);
            this.lblShowMenuStrip.Name = "lblShowMenuStrip";
            this.lblShowMenuStrip.Size = new System.Drawing.Size(110, 16);
            this.lblShowMenuStrip.TabIndex = 6;
            this.lblShowMenuStrip.Text = "Show Menu Strip:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gameplay Screen:";
            // 
            // cbxScreenNum
            // 
            this.cbxScreenNum.FormattingEnabled = true;
            this.cbxScreenNum.Location = new System.Drawing.Point(135, 32);
            this.cbxScreenNum.Name = "cbxScreenNum";
            this.cbxScreenNum.Size = new System.Drawing.Size(30, 21);
            this.cbxScreenNum.TabIndex = 9;
            this.cbxScreenNum.SelectionChangeCommitted += new System.EventHandler(this.cbxScreenNum_SelectionChangeCommitted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 63);
            this.Controls.Add(this.cbxScreenNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkShowMenuStrip);
            this.Controls.Add(this.lblShowMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projemu - By: Blake Boris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowMenuStrip;
        private System.Windows.Forms.Label lblShowMenuStrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxScreenNum;
    }
}

