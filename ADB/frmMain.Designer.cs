namespace ADB
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
            this.components = new System.ComponentModel.Container();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCloseAfterAdWindow = new System.Windows.Forms.Button();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWatchedAds = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoOfferInARow = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnKillProcesses = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRun3 = new System.Windows.Forms.Button();
            this.btnBackgoundWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 0);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(470, 654);
            this.lstLog.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(476, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(170, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "RUN";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(476, 619);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCloseAfterAdWindow
            // 
            this.btnCloseAfterAdWindow.Location = new System.Drawing.Point(557, 619);
            this.btnCloseAfterAdWindow.Name = "btnCloseAfterAdWindow";
            this.btnCloseAfterAdWindow.Size = new System.Drawing.Size(143, 23);
            this.btnCloseAfterAdWindow.TabIndex = 6;
            this.btnCloseAfterAdWindow.Text = "close after ad window";
            this.btnCloseAfterAdWindow.UseVisualStyleBackColor = true;
            this.btnCloseAfterAdWindow.Click += new System.EventHandler(this.btnCloseAfterAdWindow_Click);
            // 
            // btnPrepare
            // 
            this.btnPrepare.Location = new System.Drawing.Point(706, 590);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(170, 23);
            this.btnPrepare.TabIndex = 7;
            this.btnPrepare.Text = "Prepare";
            this.btnPrepare.UseVisualStyleBackColor = true;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // tmrLog
            // 
            this.tmrLog.Interval = 1000;
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(706, 503);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(169, 23);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "RUN 2";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(653, 16);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ads have been seen";
            // 
            // lblWatchedAds
            // 
            this.lblWatchedAds.AutoSize = true;
            this.lblWatchedAds.Location = new System.Drawing.Point(921, 22);
            this.lblWatchedAds.Name = "lblWatchedAds";
            this.lblWatchedAds.Size = new System.Drawing.Size(13, 13);
            this.lblWatchedAds.TabIndex = 12;
            this.lblWatchedAds.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "No Offers in a Row";
            // 
            // lblNoOfferInARow
            // 
            this.lblNoOfferInARow.AutoSize = true;
            this.lblNoOfferInARow.Location = new System.Drawing.Point(921, 46);
            this.lblNoOfferInARow.Name = "lblNoOfferInARow";
            this.lblNoOfferInARow.Size = new System.Drawing.Size(13, 13);
            this.lblNoOfferInARow.TabIndex = 12;
            this.lblNoOfferInARow.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 428);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "run app";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(477, 41);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(169, 23);
            this.btnClearLogs.TabIndex = 14;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnKillProcesses
            // 
            this.btnKillProcesses.Location = new System.Drawing.Point(707, 561);
            this.btnKillProcesses.Name = "btnKillProcesses";
            this.btnKillProcesses.Size = new System.Drawing.Size(169, 23);
            this.btnKillProcesses.TabIndex = 15;
            this.btnKillProcesses.Text = "Kill Processes";
            this.btnKillProcesses.UseVisualStyleBackColor = true;
            this.btnKillProcesses.Click += new System.EventHandler(this.btnKillProcesses_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(477, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Reset Ads Id";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRun3
            // 
            this.btnRun3.Location = new System.Drawing.Point(706, 532);
            this.btnRun3.Name = "btnRun3";
            this.btnRun3.Size = new System.Drawing.Size(170, 23);
            this.btnRun3.TabIndex = 17;
            this.btnRun3.Text = "Run 3";
            this.btnRun3.UseVisualStyleBackColor = true;
            this.btnRun3.Click += new System.EventHandler(this.btnRun3_Click);
            // 
            // btnBackgoundWorker
            // 
            this.btnBackgoundWorker.Location = new System.Drawing.Point(477, 99);
            this.btnBackgoundWorker.Name = "btnBackgoundWorker";
            this.btnBackgoundWorker.Size = new System.Drawing.Size(170, 23);
            this.btnBackgoundWorker.TabIndex = 18;
            this.btnBackgoundWorker.Text = "RUN 4";
            this.btnBackgoundWorker.UseVisualStyleBackColor = true;
            this.btnBackgoundWorker.Click += new System.EventHandler(this.btnBackgoundWorker_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 654);
            this.Controls.Add(this.btnBackgoundWorker);
            this.Controls.Add(this.btnRun3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnKillProcesses);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblNoOfferInARow);
            this.Controls.Add(this.lblWatchedAds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrepare);
            this.Controls.Add(this.btnCloseAfterAdWindow);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lstLog);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCloseAfterAdWindow;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.Timer tmrLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWatchedAds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoOfferInARow;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnKillProcesses;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRun3;
        private System.Windows.Forms.Button btnBackgoundWorker;
    }
}