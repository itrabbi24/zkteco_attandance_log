
namespace SEL_Att_Log
{
    partial class Att_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Att_Log));
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDeviceIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.txtRunTime = new System.Windows.Forms.Label();
            this.txtTimerCount = new System.Windows.Forms.Label();
            this.txtProcessBar = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtBranchCode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPCIPAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPCName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDownloadUser = new System.Windows.Forms.Button();
            this.txtLogData = new System.Windows.Forms.Label();
            this.txtUserProcess = new System.Windows.Forms.Label();
            this.btnDownloadLog = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtVerson = new System.Windows.Forms.Label();
            this.btnRestartDevice = new System.Windows.Forms.Button();
            this.btnPowerOff = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnLogClear = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(116)))), ((int)(((byte)(116)))));
            this.lblHeader.Location = new System.Drawing.Point(17, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(75, 19);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "ZKTECO";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device IP";
            // 
            // tbxDeviceIP
            // 
            this.tbxDeviceIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDeviceIP.Enabled = false;
            this.tbxDeviceIP.Location = new System.Drawing.Point(259, 17);
            this.tbxDeviceIP.Name = "tbxDeviceIP";
            this.tbxDeviceIP.Size = new System.Drawing.Size(99, 20);
            this.tbxDeviceIP.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbxPort
            // 
            this.tbxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPort.Enabled = false;
            this.tbxPort.Location = new System.Drawing.Point(396, 17);
            this.tbxPort.MaxLength = 6;
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(56, 20);
            this.tbxPort.TabIndex = 2;
            // 
            // txtRunTime
            // 
            this.txtRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunTime.AutoSize = true;
            this.txtRunTime.Location = new System.Drawing.Point(247, 63);
            this.txtRunTime.Name = "txtRunTime";
            this.txtRunTime.Size = new System.Drawing.Size(51, 13);
            this.txtRunTime.TabIndex = 113;
            this.txtRunTime.Text = "Timer: 10";
            // 
            // txtTimerCount
            // 
            this.txtTimerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimerCount.AutoSize = true;
            this.txtTimerCount.Location = new System.Drawing.Point(247, 82);
            this.txtTimerCount.Name = "txtTimerCount";
            this.txtTimerCount.Size = new System.Drawing.Size(85, 13);
            this.txtTimerCount.TabIndex = 114;
            this.txtTimerCount.Text = "Data Soruce: 10";
            // 
            // txtProcessBar
            // 
            this.txtProcessBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessBar.AutoSize = true;
            this.txtProcessBar.Location = new System.Drawing.Point(88, 63);
            this.txtProcessBar.Name = "txtProcessBar";
            this.txtProcessBar.Size = new System.Drawing.Size(57, 13);
            this.txtProcessBar.TabIndex = 115;
            this.txtProcessBar.Text = "Process: 0";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtBranchCode,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.txtPCIPAddress,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.txtPCName,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip.Location = new System.Drawing.Point(0, 209);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(670, 22);
            this.statusStrip.TabIndex = 111;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(78, 17);
            this.toolStripStatusLabel1.Text = "Branch Code:";
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(13, 17);
            this.txtBranchCode.Text = "\'\'";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel2.Text = "         ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel3.Text = "PC IP:";
            // 
            // txtPCIPAddress
            // 
            this.txtPCIPAddress.Name = "txtPCIPAddress";
            this.txtPCIPAddress.Size = new System.Drawing.Size(76, 17);
            this.txtPCIPAddress.Text = "192.168.3.200";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel6.Text = "        ";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel7.Text = "PC Name:";
            // 
            // txtPCName
            // 
            this.txtPCName.Name = "txtPCName";
            this.txtPCName.Size = new System.Drawing.Size(53, 17);
            this.txtPCName.Text = "RABBI-IT";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel4.Text = "        ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(224, 17);
            this.toolStripStatusLabel5.Text = "Developerd By: ARG RABBI - 01324719167";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDownloadUser);
            this.groupBox1.Controls.Add(this.txtLogData);
            this.groupBox1.Controls.Add(this.txtUserProcess);
            this.groupBox1.Controls.Add(this.btnDownloadLog);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtVerson);
            this.groupBox1.Controls.Add(this.lblHeader);
            this.groupBox1.Controls.Add(this.txtProcessBar);
            this.groupBox1.Controls.Add(this.txtTimerCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRunTime);
            this.groupBox1.Controls.Add(this.tbxPort);
            this.groupBox1.Controls.Add(this.tbxDeviceIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 110);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            // 
            // btnDownloadUser
            // 
            this.btnDownloadUser.Location = new System.Drawing.Point(546, 49);
            this.btnDownloadUser.Name = "btnDownloadUser";
            this.btnDownloadUser.Size = new System.Drawing.Size(111, 30);
            this.btnDownloadUser.TabIndex = 894;
            this.btnDownloadUser.Text = "Download User";
            this.btnDownloadUser.UseVisualStyleBackColor = true;
            this.btnDownloadUser.Click += new System.EventHandler(this.btnDownloadUser_Click);
            // 
            // txtLogData
            // 
            this.txtLogData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogData.AutoSize = true;
            this.txtLogData.Location = new System.Drawing.Point(393, 82);
            this.txtLogData.Name = "txtLogData";
            this.txtLogData.Size = new System.Drawing.Size(62, 13);
            this.txtLogData.TabIndex = 893;
            this.txtLogData.Text = "User Log: 0";
            // 
            // txtUserProcess
            // 
            this.txtUserProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserProcess.AutoSize = true;
            this.txtUserProcess.Location = new System.Drawing.Point(88, 82);
            this.txtUserProcess.Name = "txtUserProcess";
            this.txtUserProcess.Size = new System.Drawing.Size(82, 13);
            this.txtUserProcess.TabIndex = 892;
            this.txtUserProcess.Text = "User Process: 0";
            // 
            // btnDownloadLog
            // 
            this.btnDownloadLog.Location = new System.Drawing.Point(546, 13);
            this.btnDownloadLog.Name = "btnDownloadLog";
            this.btnDownloadLog.Size = new System.Drawing.Size(109, 30);
            this.btnDownloadLog.TabIndex = 890;
            this.btnDownloadLog.Text = "Download Log";
            this.btnDownloadLog.UseVisualStyleBackColor = true;
            this.btnDownloadLog.Click += new System.EventHandler(this.btnDownloadLog_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEL_Att_Log.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(110, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 891;
            this.pictureBox1.TabStop = false;
            // 
            // txtVerson
            // 
            this.txtVerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVerson.AutoSize = true;
            this.txtVerson.Location = new System.Drawing.Point(25, 63);
            this.txtVerson.Name = "txtVerson";
            this.txtVerson.Size = new System.Drawing.Size(52, 13);
            this.txtVerson.TabIndex = 116;
            this.txtVerson.Text = "Verson: 1";
            // 
            // btnRestartDevice
            // 
            this.btnRestartDevice.Location = new System.Drawing.Point(561, 174);
            this.btnRestartDevice.Name = "btnRestartDevice";
            this.btnRestartDevice.Size = new System.Drawing.Size(97, 25);
            this.btnRestartDevice.TabIndex = 888;
            this.btnRestartDevice.Text = "Restart Device";
            this.btnRestartDevice.UseVisualStyleBackColor = true;
            this.btnRestartDevice.Click += new System.EventHandler(this.btnRestartDevice_Click);
            // 
            // btnPowerOff
            // 
            this.btnPowerOff.Location = new System.Drawing.Point(490, 174);
            this.btnPowerOff.Name = "btnPowerOff";
            this.btnPowerOff.Size = new System.Drawing.Size(65, 25);
            this.btnPowerOff.TabIndex = 887;
            this.btnPowerOff.Text = "Power Off";
            this.btnPowerOff.UseVisualStyleBackColor = true;
            this.btnPowerOff.Click += new System.EventHandler(this.btnPowerOff_Click);
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.Green;
            this.lblState.Location = new System.Drawing.Point(238, 140);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(155, 25);
            this.lblState.TabIndex = 889;
            this.lblState.Text = "Disconnected";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Attandence Log";
            this.notifyIcon.BalloonTipTitle = "Attandence Log";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Attandance log by Shodagor Express";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btnLogClear
            // 
            this.btnLogClear.Location = new System.Drawing.Point(409, 176);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(75, 23);
            this.btnLogClear.TabIndex = 890;
            this.btnLogClear.Text = "Log Clear";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Visible = false;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // Att_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 231);
            this.Controls.Add(this.btnLogClear);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRestartDevice);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnPowerOff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Att_Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEL Attendance Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Att_Log_Load);
            this.Resize += new System.EventHandler(this.AttLogsMain_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDeviceIP;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtProcessBar;
        private System.Windows.Forms.Label txtTimerCount;
        private System.Windows.Forms.Label txtRunTime;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtBranchCode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel txtPCIPAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel txtPCName;
        private System.Windows.Forms.Button btnRestartDevice;
        private System.Windows.Forms.Button btnPowerOff;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label txtVerson;
        private System.Windows.Forms.Button btnDownloadLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Label txtUserProcess;
        private System.Windows.Forms.Label txtLogData;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnDownloadUser;
        private System.Windows.Forms.Button btnLogClear;
    }
}

