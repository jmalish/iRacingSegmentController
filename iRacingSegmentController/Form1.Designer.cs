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
            this.lvlVersion = new System.Windows.Forms.Label();
            this.dgvDriverList = new System.Windows.Forms.DataGridView();
            this.lblCurrentLap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverList)).BeginInit();
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
            // lvlVersion
            // 
            this.lvlVersion.AutoSize = true;
            this.lvlVersion.Location = new System.Drawing.Point(12, 618);
            this.lvlVersion.Name = "lvlVersion";
            this.lvlVersion.Size = new System.Drawing.Size(28, 13);
            this.lvlVersion.TabIndex = 3;
            this.lvlVersion.Text = "v.00";
            // 
            // dgvDriverList
            // 
            this.dgvDriverList.AllowUserToAddRows = false;
            this.dgvDriverList.AllowUserToDeleteRows = false;
            this.dgvDriverList.AllowUserToOrderColumns = true;
            this.dgvDriverList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriverList.Location = new System.Drawing.Point(185, 31);
            this.dgvDriverList.Name = "dgvDriverList";
            this.dgvDriverList.ReadOnly = true;
            this.dgvDriverList.Size = new System.Drawing.Size(406, 597);
            this.dgvDriverList.TabIndex = 4;
            // 
            // lblCurrentLap
            // 
            this.lblCurrentLap.AutoSize = true;
            this.lblCurrentLap.Location = new System.Drawing.Point(185, 9);
            this.lblCurrentLap.Name = "lblCurrentLap";
            this.lblCurrentLap.Size = new System.Drawing.Size(74, 13);
            this.lblCurrentLap.TabIndex = 5;
            this.lblCurrentLap.Text = "Current Lap: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 640);
            this.Controls.Add(this.lblCurrentLap);
            this.Controls.Add(this.dgvDriverList);
            this.Controls.Add(this.lvlVersion);
            this.Controls.Add(this.lblCurrentFlag);
            this.Controls.Add(this.lblIsConnected);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lvlVersion;
        private System.Windows.Forms.DataGridView dgvDriverList;
        private System.Windows.Forms.Label lblCurrentLap;
    }
}

