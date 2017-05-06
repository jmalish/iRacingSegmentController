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
            this.lblCarsOnLead = new System.Windows.Forms.Label();
            this.lblSegmentEnd1 = new System.Windows.Forms.Label();
            this.nudSegmentEnd1 = new System.Windows.Forms.NumericUpDown();
            this.lblSegmentEnd2 = new System.Windows.Forms.Label();
            this.nudSegmentEnd2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd2)).BeginInit();
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
            this.dgvDriverList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            // lblCarsOnLead
            // 
            this.lblCarsOnLead.AutoSize = true;
            this.lblCarsOnLead.Location = new System.Drawing.Point(25, 174);
            this.lblCarsOnLead.Name = "lblCarsOnLead";
            this.lblCarsOnLead.Size = new System.Drawing.Size(91, 13);
            this.lblCarsOnLead.TabIndex = 6;
            this.lblCarsOnLead.Text = "Cars on Lead Lap";
            // 
            // lblSegmentEnd1
            // 
            this.lblSegmentEnd1.AutoSize = true;
            this.lblSegmentEnd1.Location = new System.Drawing.Point(14, 295);
            this.lblSegmentEnd1.Name = "lblSegmentEnd1";
            this.lblSegmentEnd1.Size = new System.Drawing.Size(88, 13);
            this.lblSegmentEnd1.TabIndex = 7;
            this.lblSegmentEnd1.Text = "Segment 1 Ends:";
            // 
            // nudSegmentEnd1
            // 
            this.nudSegmentEnd1.Location = new System.Drawing.Point(108, 293);
            this.nudSegmentEnd1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSegmentEnd1.Name = "nudSegmentEnd1";
            this.nudSegmentEnd1.Size = new System.Drawing.Size(58, 20);
            this.nudSegmentEnd1.TabIndex = 8;
            this.nudSegmentEnd1.ValueChanged += new System.EventHandler(this.nudSegmentEnd1_ValueChanged);
            // 
            // lblSegmentEnd2
            // 
            this.lblSegmentEnd2.AutoSize = true;
            this.lblSegmentEnd2.Location = new System.Drawing.Point(14, 321);
            this.lblSegmentEnd2.Name = "lblSegmentEnd2";
            this.lblSegmentEnd2.Size = new System.Drawing.Size(88, 13);
            this.lblSegmentEnd2.TabIndex = 7;
            this.lblSegmentEnd2.Text = "Segment 2 Ends:";
            // 
            // nudSegmentEnd2
            // 
            this.nudSegmentEnd2.Location = new System.Drawing.Point(108, 319);
            this.nudSegmentEnd2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSegmentEnd2.Name = "nudSegmentEnd2";
            this.nudSegmentEnd2.Size = new System.Drawing.Size(58, 20);
            this.nudSegmentEnd2.TabIndex = 8;
            this.nudSegmentEnd2.ValueChanged += new System.EventHandler(this.nudSegmentEnd2_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 640);
            this.Controls.Add(this.nudSegmentEnd2);
            this.Controls.Add(this.lblSegmentEnd2);
            this.Controls.Add(this.nudSegmentEnd1);
            this.Controls.Add(this.lblSegmentEnd1);
            this.Controls.Add(this.lblCarsOnLead);
            this.Controls.Add(this.lblCurrentLap);
            this.Controls.Add(this.dgvDriverList);
            this.Controls.Add(this.lvlVersion);
            this.Controls.Add(this.lblCurrentFlag);
            this.Controls.Add(this.lblIsConnected);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lvlVersion;
        private System.Windows.Forms.DataGridView dgvDriverList;
        private System.Windows.Forms.Label lblCurrentLap;
        private System.Windows.Forms.Label lblCarsOnLead;
        private System.Windows.Forms.Label lblSegmentEnd1;
        private System.Windows.Forms.NumericUpDown nudSegmentEnd1;
        private System.Windows.Forms.Label lblSegmentEnd2;
        private System.Windows.Forms.NumericUpDown nudSegmentEnd2;
    }
}

