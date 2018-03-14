namespace ADB
{
    partial class frmStableVersion
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
            this.btnBackgoundWorker = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.lblNoOfferInARow = new System.Windows.Forms.Label();
            this.lblWatchedAds = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnPrepare = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLoadingInARow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblElseInARow = new System.Windows.Forms.Label();
            this.lstWatchedAds = new System.Windows.Forms.ListBox();
            this.chkRun = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.baseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stt = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            this.mnu.SuspendLayout();
            this.stt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBackgoundWorker
            // 
            this.btnBackgoundWorker.Location = new System.Drawing.Point(476, 39);
            this.btnBackgoundWorker.Name = "btnBackgoundWorker";
            this.btnBackgoundWorker.Size = new System.Drawing.Size(170, 23);
            this.btnBackgoundWorker.TabIndex = 36;
            this.btnBackgoundWorker.Text = "RUN 4";
            this.btnBackgoundWorker.UseVisualStyleBackColor = true;
            this.btnBackgoundWorker.Click += new System.EventHandler(this.btnBackgoundWorker_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(475, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 23);
            this.button3.TabIndex = 34;
            this.button3.Text = "Reset Ads Id";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(475, 68);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(169, 23);
            this.btnClearLogs.TabIndex = 32;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // lblNoOfferInARow
            // 
            this.lblNoOfferInARow.AutoSize = true;
            this.lblNoOfferInARow.Location = new System.Drawing.Point(920, 63);
            this.lblNoOfferInARow.Name = "lblNoOfferInARow";
            this.lblNoOfferInARow.Size = new System.Drawing.Size(13, 13);
            this.lblNoOfferInARow.TabIndex = 30;
            this.lblNoOfferInARow.Text = "0";
            // 
            // lblWatchedAds
            // 
            this.lblWatchedAds.AutoSize = true;
            this.lblWatchedAds.Location = new System.Drawing.Point(920, 39);
            this.lblWatchedAds.Name = "lblWatchedAds";
            this.lblWatchedAds.Size = new System.Drawing.Size(13, 13);
            this.lblWatchedAds.TabIndex = 29;
            this.lblWatchedAds.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(748, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "No Offers in a Row";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(740, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ads have been seen";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(652, 40);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 26;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnPrepare
            // 
            this.btnPrepare.Location = new System.Drawing.Point(475, 126);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(170, 23);
            this.btnPrepare.TabIndex = 23;
            this.btnPrepare.Text = "Prepare";
            this.btnPrepare.UseVisualStyleBackColor = true;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 24);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(470, 588);
            this.lstLog.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(748, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Loading in a Row";
            // 
            // lblLoadingInARow
            // 
            this.lblLoadingInARow.AutoSize = true;
            this.lblLoadingInARow.Location = new System.Drawing.Point(920, 87);
            this.lblLoadingInARow.Name = "lblLoadingInARow";
            this.lblLoadingInARow.Size = new System.Drawing.Size(13, 13);
            this.lblLoadingInARow.TabIndex = 30;
            this.lblLoadingInARow.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Else in a Row";
            // 
            // lblElseInARow
            // 
            this.lblElseInARow.AutoSize = true;
            this.lblElseInARow.Location = new System.Drawing.Point(920, 121);
            this.lblElseInARow.Name = "lblElseInARow";
            this.lblElseInARow.Size = new System.Drawing.Size(13, 13);
            this.lblElseInARow.TabIndex = 30;
            this.lblElseInARow.Text = "0";
            // 
            // lstWatchedAds
            // 
            this.lstWatchedAds.FormattingEnabled = true;
            this.lstWatchedAds.Location = new System.Drawing.Point(751, 155);
            this.lstWatchedAds.Name = "lstWatchedAds";
            this.lstWatchedAds.Size = new System.Drawing.Size(182, 303);
            this.lstWatchedAds.TabIndex = 37;
            // 
            // chkRun
            // 
            this.chkRun.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chkRun.Location = new System.Drawing.Point(476, 551);
            this.chkRun.Name = "chkRun";
            this.chkRun.Size = new System.Drawing.Size(148, 71);
            this.chkRun.TabIndex = 38;
            this.chkRun.Text = "Stopped";
            this.chkRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRun.UseVisualStyleBackColor = true;
            this.chkRun.CheckedChanged += new System.EventHandler(this.chkRun_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(631, 522);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(537, 196);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(35, 13);
            this.lbl.TabIndex = 41;
            this.lbl.Text = "label5";
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(937, 24);
            this.mnu.TabIndex = 42;
            this.mnu.Text = "menuStrip1";
            // 
            // baseToolStripMenuItem
            // 
            this.baseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.baseToolStripMenuItem.Name = "baseToolStripMenuItem";
            this.baseToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.baseToolStripMenuItem.Text = "Base";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // stt
            // 
            this.stt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.stt.Location = new System.Drawing.Point(0, 612);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(937, 22);
            this.stt.TabIndex = 43;
            this.stt.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(39, 17);
            this.tsslStatus.Text = "Status";
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 10000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(592, 381);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 44;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(504, 380);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 45;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(475, 434);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 46;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(548, 319);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 47;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // frmStableVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 634);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRun);
            this.Controls.Add(this.lstWatchedAds);
            this.Controls.Add(this.btnBackgoundWorker);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.lblElseInARow);
            this.Controls.Add(this.lblLoadingInARow);
            this.Controls.Add(this.lblNoOfferInARow);
            this.Controls.Add(this.lblWatchedAds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnPrepare);
            this.Controls.Add(this.mnu);
            this.MainMenuStrip = this.mnu;
            this.Name = "frmStableVersion";
            this.Text = "frmStableVersion";
            this.Load += new System.EventHandler(this.frmStableVersion_Load);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.stt.ResumeLayout(false);
            this.stt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackgoundWorker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Label lblNoOfferInARow;
        private System.Windows.Forms.Label lblWatchedAds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoadingInARow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblElseInARow;
        private System.Windows.Forms.ListBox lstWatchedAds;
        private System.Windows.Forms.CheckBox chkRun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem baseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip stt;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Timer tmrStatus;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.Button button7;
    }
}