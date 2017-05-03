namespace iRacingSegmentController
{
    partial class Form1
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
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.lblCurrentFlag = new System.Windows.Forms.Label();
            this.lblDriverInfo = new System.Windows.Forms.Label();
            this.lstDriverList = new System.Windows.Forms.ListBox();
            this.lvlVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.Location = new System.Drawing.Point(12, 9);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(90, 13);
            this.lblIsConnected.TabIndex = 0;
            this.lblIsConnected.Text = "Connected: False";
            // 
            // lblCurrentFlag
            // 
            this.lblCurrentFlag.AutoSize = true;
            this.lblCurrentFlag.Location = new System.Drawing.Point(12, 31);
            this.lblCurrentFlag.Name = "lblCurrentFlag";
            this.lblCurrentFlag.Size = new System.Drawing.Size(67, 13);
            this.lblCurrentFlag.TabIndex = 1;
            this.lblCurrentFlag.Text = "Current Flag:";
            // 
            // lblDriverInfo
            // 
            this.lblDriverInfo.AutoSize = true;
            this.lblDriverInfo.Location = new System.Drawing.Point(30, 437);
            this.lblDriverInfo.Name = "lblDriverInfo";
            this.lblDriverInfo.Size = new System.Drawing.Size(35, 13);
            this.lblDriverInfo.TabIndex = 1;
            this.lblDriverInfo.Text = "Driver";
            // 
            // lstDriverList
            // 
            this.lstDriverList.FormattingEnabled = true;
            this.lstDriverList.Location = new System.Drawing.Point(157, 9);
            this.lstDriverList.Name = "lstDriverList";
            this.lstDriverList.Size = new System.Drawing.Size(426, 381);
            this.lstDriverList.TabIndex = 2;
            // 
            // lvlVersion
            // 
            this.lvlVersion.AutoSize = true;
            this.lvlVersion.Location = new System.Drawing.Point(562, 492);
            this.lvlVersion.Name = "lvlVersion";
            this.lvlVersion.Size = new System.Drawing.Size(28, 13);
            this.lvlVersion.TabIndex = 3;
            this.lvlVersion.Text = "v.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 514);
            this.Controls.Add(this.lvlVersion);
            this.Controls.Add(this.lstDriverList);
            this.Controls.Add(this.lblDriverInfo);
            this.Controls.Add(this.lblCurrentFlag);
            this.Controls.Add(this.lblIsConnected);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lblDriverInfo;
        private System.Windows.Forms.ListBox lstDriverList;
        private System.Windows.Forms.Label lvlVersion;
    }
}

