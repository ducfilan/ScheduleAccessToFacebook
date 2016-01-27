namespace Facebook_Scheduler
{
    partial class FacebookScheduler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookScheduler));
            this.btnBem = new System.Windows.Forms.Button();
            this.dtPkEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPkStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.itmEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.itmDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStop = new System.Windows.Forms.Button();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridReasons = new System.Windows.Forms.DataGridView();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReasons)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBem
            // 
            this.btnBem.BackColor = System.Drawing.Color.Green;
            this.btnBem.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBem.Location = new System.Drawing.Point(176, 12);
            this.btnBem.Name = "btnBem";
            this.btnBem.Size = new System.Drawing.Size(86, 46);
            this.btnBem.TabIndex = 13;
            this.btnBem.Text = "BEM";
            this.btnBem.UseVisualStyleBackColor = false;
            this.btnBem.Click += new System.EventHandler(this.btnBem_Click);
            // 
            // dtPkEnd
            // 
            this.dtPkEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtPkEnd.Location = new System.Drawing.Point(64, 38);
            this.dtPkEnd.Name = "dtPkEnd";
            this.dtPkEnd.ShowUpDown = true;
            this.dtPkEnd.Size = new System.Drawing.Size(106, 20);
            this.dtPkEnd.TabIndex = 12;
            this.dtPkEnd.ValueChanged += new System.EventHandler(this.dtPkEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "End time";
            // 
            // dtPkStart
            // 
            this.dtPkStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtPkStart.Location = new System.Drawing.Point(64, 12);
            this.dtPkStart.Name = "dtPkStart";
            this.dtPkStart.ShowUpDown = true;
            this.dtPkStart.Size = new System.Drawing.Size(106, 20);
            this.dtPkStart.TabIndex = 10;
            this.dtPkStart.ValueChanged += new System.EventHandler(this.dtPkStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Start time";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Fuck FB!";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmExit,
            this.itmEnable,
            this.itmDisable});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 70);
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            this.itmExit.Size = new System.Drawing.Size(112, 22);
            this.itmExit.Text = "Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // itmEnable
            // 
            this.itmEnable.Name = "itmEnable";
            this.itmEnable.Size = new System.Drawing.Size(112, 22);
            this.itmEnable.Text = "Enable";
            this.itmEnable.Click += new System.EventHandler(this.itmEnable_Click);
            // 
            // itmDisable
            // 
            this.itmDisable.Name = "itmDisable";
            this.itmDisable.Size = new System.Drawing.Size(112, 22);
            this.itmDisable.Text = "Disable";
            this.itmDisable.Click += new System.EventHandler(this.itmDisable_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(268, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(86, 46);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lnkAbout
            // 
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Location = new System.Drawing.Point(316, 68);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(35, 13);
            this.lnkAbout.TabIndex = 16;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "About";
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = true;
            this.chkAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStart.Location = new System.Drawing.Point(64, 67);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(15, 14);
            this.chkAutoStart.TabIndex = 15;
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Auto start";
            // 
            // gridReasons
            // 
            this.gridReasons.AllowUserToAddRows = false;
            this.gridReasons.AllowUserToDeleteRows = false;
            this.gridReasons.AllowUserToOrderColumns = true;
            this.gridReasons.AllowUserToResizeColumns = false;
            this.gridReasons.AllowUserToResizeRows = false;
            this.gridReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReasons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTime,
            this.clmReason});
            this.gridReasons.Location = new System.Drawing.Point(10, 87);
            this.gridReasons.Name = "gridReasons";
            this.gridReasons.RowHeadersVisible = false;
            this.gridReasons.Size = new System.Drawing.Size(341, 248);
            this.gridReasons.TabIndex = 18;
            // 
            // clmTime
            // 
            this.clmTime.DataPropertyName = "Stop Time";
            this.clmTime.HeaderText = "Stop Time";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmReason
            // 
            this.clmReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmReason.DataPropertyName = "Reason";
            this.clmReason.HeaderText = "Reason";
            this.clmReason.Name = "clmReason";
            this.clmReason.ReadOnly = true;
            this.clmReason.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FacebookScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 347);
            this.Controls.Add(this.gridReasons);
            this.Controls.Add(this.btnBem);
            this.Controls.Add(this.dtPkEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPkStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lnkAbout);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FacebookScheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Scheduler";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReasons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBem;
        private System.Windows.Forms.DateTimePicker dtPkEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPkStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.LinkLabel lnkAbout;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.ToolStripMenuItem itmEnable;
        private System.Windows.Forms.ToolStripMenuItem itmDisable;
        private System.Windows.Forms.DataGridView gridReasons;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReason;

    }
}