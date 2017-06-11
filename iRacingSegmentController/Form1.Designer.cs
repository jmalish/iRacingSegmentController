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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.lblCurrentFlag = new System.Windows.Forms.Label();
            this.lvlVersion = new System.Windows.Forms.Label();
            this.lblCurrentLap = new System.Windows.Forms.Label();
            this.lblCarsOnLead = new System.Windows.Forms.Label();
            this.lblSegmentEnd1 = new System.Windows.Forms.Label();
            this.nudSegmentEnd1 = new System.Windows.Forms.NumericUpDown();
            this.lblSegmentEnd2 = new System.Windows.Forms.Label();
            this.nudSegmentEnd2 = new System.Windows.Forms.NumericUpDown();
            this.dgvSeg2Results = new System.Windows.Forms.DataGridView();
            this.lblSegment1Results = new System.Windows.Forms.Label();
            this.lblSegment2Results = new System.Windows.Forms.Label();
            this.dgvSeg1Results = new System.Windows.Forms.DataGridView();
            this.lblIsAdmin = new System.Windows.Forms.Label();
            this.nudClosePits = new System.Windows.Forms.NumericUpDown();
            this.lblClosePits1 = new System.Windows.Forms.Label();
            this.lblClosePits2 = new System.Windows.Forms.Label();
            this.nudClosePitsMacro = new System.Windows.Forms.NumericUpDown();
            this.lblClosePitsMacro = new System.Windows.Forms.Label();
            this.nudThrowCautionMacro = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestMacros = new System.Windows.Forms.Button();
            this.btnOutputResults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeg2Results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeg1Results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePitsMacro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThrowCautionMacro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.Location = new System.Drawing.Point(10, 10);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(90, 13);
            this.lblIsConnected.TabIndex = 0;
            this.lblIsConnected.Text = "Connected: False";
            // 
            // lblCurrentFlag
            // 
            this.lblCurrentFlag.AutoSize = true;
            this.lblCurrentFlag.Location = new System.Drawing.Point(10, 45);
            this.lblCurrentFlag.Name = "lblCurrentFlag";
            this.lblCurrentFlag.Size = new System.Drawing.Size(67, 13);
            this.lblCurrentFlag.TabIndex = 0;
            this.lblCurrentFlag.Text = "Current Flag:";
            // 
            // lvlVersion
            // 
            this.lvlVersion.AutoSize = true;
            this.lvlVersion.Location = new System.Drawing.Point(16, 267);
            this.lvlVersion.Name = "lvlVersion";
            this.lvlVersion.Size = new System.Drawing.Size(34, 13);
            this.lvlVersion.TabIndex = 3;
            this.lvlVersion.Text = "v1.02";
            // 
            // lblCurrentLap
            // 
            this.lblCurrentLap.AutoSize = true;
            this.lblCurrentLap.Location = new System.Drawing.Point(10, 60);
            this.lblCurrentLap.Name = "lblCurrentLap";
            this.lblCurrentLap.Size = new System.Drawing.Size(74, 13);
            this.lblCurrentLap.TabIndex = 0;
            this.lblCurrentLap.Text = "Current Lap: 0";
            // 
            // lblCarsOnLead
            // 
            this.lblCarsOnLead.AutoSize = true;
            this.lblCarsOnLead.Location = new System.Drawing.Point(10, 75);
            this.lblCarsOnLead.Name = "lblCarsOnLead";
            this.lblCarsOnLead.Size = new System.Drawing.Size(91, 13);
            this.lblCarsOnLead.TabIndex = 0;
            this.lblCarsOnLead.Text = "Cars on Lead Lap";
            // 
            // lblSegmentEnd1
            // 
            this.lblSegmentEnd1.AutoSize = true;
            this.lblSegmentEnd1.Location = new System.Drawing.Point(10, 102);
            this.lblSegmentEnd1.Name = "lblSegmentEnd1";
            this.lblSegmentEnd1.Size = new System.Drawing.Size(88, 13);
            this.lblSegmentEnd1.TabIndex = 7;
            this.lblSegmentEnd1.Text = "Segment 1 Ends:";
            // 
            // nudSegmentEnd1
            // 
            this.nudSegmentEnd1.Location = new System.Drawing.Point(98, 98);
            this.nudSegmentEnd1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSegmentEnd1.Name = "nudSegmentEnd1";
            this.nudSegmentEnd1.Size = new System.Drawing.Size(58, 20);
            this.nudSegmentEnd1.TabIndex = 3;
            this.nudSegmentEnd1.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudSegmentEnd1.ValueChanged += new System.EventHandler(this.nudSegmentEnd1_ValueChanged);
            // 
            // lblSegmentEnd2
            // 
            this.lblSegmentEnd2.AutoSize = true;
            this.lblSegmentEnd2.Location = new System.Drawing.Point(10, 123);
            this.lblSegmentEnd2.Name = "lblSegmentEnd2";
            this.lblSegmentEnd2.Size = new System.Drawing.Size(88, 13);
            this.lblSegmentEnd2.TabIndex = 7;
            this.lblSegmentEnd2.Text = "Segment 2 Ends:";
            // 
            // nudSegmentEnd2
            // 
            this.nudSegmentEnd2.Location = new System.Drawing.Point(98, 120);
            this.nudSegmentEnd2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSegmentEnd2.Name = "nudSegmentEnd2";
            this.nudSegmentEnd2.Size = new System.Drawing.Size(58, 20);
            this.nudSegmentEnd2.TabIndex = 4;
            this.nudSegmentEnd2.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudSegmentEnd2.ValueChanged += new System.EventHandler(this.nudSegmentEnd2_ValueChanged);
            // 
            // dgvSeg2Results
            // 
            this.dgvSeg2Results.AllowUserToAddRows = false;
            this.dgvSeg2Results.AllowUserToDeleteRows = false;
            this.dgvSeg2Results.AllowUserToOrderColumns = true;
            this.dgvSeg2Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeg2Results.Location = new System.Drawing.Point(496, 28);
            this.dgvSeg2Results.Name = "dgvSeg2Results";
            this.dgvSeg2Results.ReadOnly = true;
            this.dgvSeg2Results.Size = new System.Drawing.Size(290, 253);
            this.dgvSeg2Results.TabIndex = 10;
            // 
            // lblSegment1Results
            // 
            this.lblSegment1Results.AutoSize = true;
            this.lblSegment1Results.Location = new System.Drawing.Point(198, 9);
            this.lblSegment1Results.Name = "lblSegment1Results";
            this.lblSegment1Results.Size = new System.Drawing.Size(99, 13);
            this.lblSegment1Results.TabIndex = 9;
            this.lblSegment1Results.Text = "Segment 1 Results:";
            // 
            // lblSegment2Results
            // 
            this.lblSegment2Results.AutoSize = true;
            this.lblSegment2Results.Location = new System.Drawing.Point(493, 9);
            this.lblSegment2Results.Name = "lblSegment2Results";
            this.lblSegment2Results.Size = new System.Drawing.Size(99, 13);
            this.lblSegment2Results.TabIndex = 9;
            this.lblSegment2Results.Text = "Segment 2 Results:";
            // 
            // dgvSeg1Results
            // 
            this.dgvSeg1Results.AllowUserToAddRows = false;
            this.dgvSeg1Results.AllowUserToDeleteRows = false;
            this.dgvSeg1Results.AllowUserToOrderColumns = true;
            this.dgvSeg1Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeg1Results.Location = new System.Drawing.Point(201, 28);
            this.dgvSeg1Results.Name = "dgvSeg1Results";
            this.dgvSeg1Results.ReadOnly = true;
            this.dgvSeg1Results.Size = new System.Drawing.Size(290, 253);
            this.dgvSeg1Results.TabIndex = 9;
            // 
            // lblIsAdmin
            // 
            this.lblIsAdmin.AutoSize = true;
            this.lblIsAdmin.Location = new System.Drawing.Point(10, 25);
            this.lblIsAdmin.Name = "lblIsAdmin";
            this.lblIsAdmin.Size = new System.Drawing.Size(102, 13);
            this.lblIsAdmin.TabIndex = 0;
            this.lblIsAdmin.Text = "User is Admin: False";
            // 
            // nudClosePits
            // 
            this.nudClosePits.Location = new System.Drawing.Point(63, 147);
            this.nudClosePits.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudClosePits.Name = "nudClosePits";
            this.nudClosePits.Size = new System.Drawing.Size(32, 20);
            this.nudClosePits.TabIndex = 5;
            this.nudClosePits.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudClosePits.ValueChanged += new System.EventHandler(this.nudClosePits_ValueChanged);
            // 
            // lblClosePits1
            // 
            this.lblClosePits1.AutoSize = true;
            this.lblClosePits1.Location = new System.Drawing.Point(10, 150);
            this.lblClosePits1.Name = "lblClosePits1";
            this.lblClosePits1.Size = new System.Drawing.Size(53, 13);
            this.lblClosePits1.TabIndex = 14;
            this.lblClosePits1.Text = "Close Pits";
            // 
            // lblClosePits2
            // 
            this.lblClosePits2.AutoSize = true;
            this.lblClosePits2.Location = new System.Drawing.Point(95, 150);
            this.lblClosePits2.Name = "lblClosePits2";
            this.lblClosePits2.Size = new System.Drawing.Size(100, 13);
            this.lblClosePits2.TabIndex = 16;
            this.lblClosePits2.Text = "laps before seg end";
            // 
            // nudClosePitsMacro
            // 
            this.nudClosePitsMacro.Location = new System.Drawing.Point(128, 178);
            this.nudClosePitsMacro.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudClosePitsMacro.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudClosePitsMacro.Name = "nudClosePitsMacro";
            this.nudClosePitsMacro.Size = new System.Drawing.Size(32, 20);
            this.nudClosePitsMacro.TabIndex = 6;
            this.nudClosePitsMacro.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudClosePitsMacro.ValueChanged += new System.EventHandler(this.nudClosePitsMacro_ValueChanged);
            // 
            // lblClosePitsMacro
            // 
            this.lblClosePitsMacro.AutoSize = true;
            this.lblClosePitsMacro.Location = new System.Drawing.Point(10, 180);
            this.lblClosePitsMacro.Name = "lblClosePitsMacro";
            this.lblClosePitsMacro.Size = new System.Drawing.Size(89, 13);
            this.lblClosePitsMacro.TabIndex = 17;
            this.lblClosePitsMacro.Text = "Close Pits Macro:";
            // 
            // nudThrowCautionMacro
            // 
            this.nudThrowCautionMacro.Location = new System.Drawing.Point(128, 200);
            this.nudThrowCautionMacro.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudThrowCautionMacro.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudThrowCautionMacro.Name = "nudThrowCautionMacro";
            this.nudThrowCautionMacro.Size = new System.Drawing.Size(32, 20);
            this.nudThrowCautionMacro.TabIndex = 7;
            this.nudThrowCautionMacro.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudThrowCautionMacro.ValueChanged += new System.EventHandler(this.nudThrowCautionMacro_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Throw Caution Macro:";
            // 
            // btnTestMacros
            // 
            this.btnTestMacros.Location = new System.Drawing.Point(19, 233);
            this.btnTestMacros.Name = "btnTestMacros";
            this.btnTestMacros.Size = new System.Drawing.Size(146, 23);
            this.btnTestMacros.TabIndex = 22;
            this.btnTestMacros.Text = "Test Macro Keys";
            this.btnTestMacros.UseVisualStyleBackColor = true;
            this.btnTestMacros.Click += new System.EventHandler(this.btnTestMacros_Click);
            // 
            // btnOutputResults
            // 
            this.btnOutputResults.Location = new System.Drawing.Point(689, 4);
            this.btnOutputResults.Name = "btnOutputResults";
            this.btnOutputResults.Size = new System.Drawing.Size(94, 23);
            this.btnOutputResults.TabIndex = 23;
            this.btnOutputResults.Text = "Output Results";
            this.btnOutputResults.UseVisualStyleBackColor = true;
            this.btnOutputResults.Click += new System.EventHandler(this.btnOutputResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 292);
            this.Controls.Add(this.btnOutputResults);
            this.Controls.Add(this.btnTestMacros);
            this.Controls.Add(this.nudThrowCautionMacro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudClosePitsMacro);
            this.Controls.Add(this.lblClosePitsMacro);
            this.Controls.Add(this.lblClosePits2);
            this.Controls.Add(this.nudClosePits);
            this.Controls.Add(this.lblClosePits1);
            this.Controls.Add(this.lblIsAdmin);
            this.Controls.Add(this.lblSegment2Results);
            this.Controls.Add(this.lblSegment1Results);
            this.Controls.Add(this.nudSegmentEnd2);
            this.Controls.Add(this.lblSegmentEnd2);
            this.Controls.Add(this.nudSegmentEnd1);
            this.Controls.Add(this.lblSegmentEnd1);
            this.Controls.Add(this.lblCarsOnLead);
            this.Controls.Add(this.lblCurrentLap);
            this.Controls.Add(this.dgvSeg1Results);
            this.Controls.Add(this.dgvSeg2Results);
            this.Controls.Add(this.lvlVersion);
            this.Controls.Add(this.lblCurrentFlag);
            this.Controls.Add(this.lblIsConnected);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "iRacing Segment Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSegmentEnd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeg2Results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeg1Results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClosePitsMacro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThrowCautionMacro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Label lblCurrentFlag;
        private System.Windows.Forms.Label lvlVersion;
        private System.Windows.Forms.Label lblCurrentLap;
        private System.Windows.Forms.Label lblCarsOnLead;
        private System.Windows.Forms.Label lblSegmentEnd1;
        private System.Windows.Forms.NumericUpDown nudSegmentEnd1;
        private System.Windows.Forms.Label lblSegmentEnd2;
        private System.Windows.Forms.NumericUpDown nudSegmentEnd2;
        private System.Windows.Forms.DataGridView dgvSeg2Results;
        private System.Windows.Forms.Label lblSegment1Results;
        private System.Windows.Forms.Label lblSegment2Results;
        private System.Windows.Forms.DataGridView dgvSeg1Results;
        private System.Windows.Forms.Label lblIsAdmin;
        private System.Windows.Forms.NumericUpDown nudClosePits;
        private System.Windows.Forms.Label lblClosePits1;
        private System.Windows.Forms.Label lblClosePits2;
        private System.Windows.Forms.NumericUpDown nudClosePitsMacro;
        private System.Windows.Forms.Label lblClosePitsMacro;
        private System.Windows.Forms.NumericUpDown nudThrowCautionMacro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestMacros;
        private System.Windows.Forms.Button btnOutputResults;
    }
}

