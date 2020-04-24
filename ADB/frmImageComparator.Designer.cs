namespace ADB
{
    partial class frmImageComparator
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
            this.pct1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImage1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pct2 = new System.Windows.Forms.PictureBox();
            this.btnImage2 = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtSimilarityThreshold = new System.Windows.Forms.TextBox();
            this.txtCompareLevel = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pct1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pct1
            // 
            this.pct1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pct1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pct1.Location = new System.Drawing.Point(0, 0);
            this.pct1.Name = "pct1";
            this.pct1.Size = new System.Drawing.Size(322, 318);
            this.pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pct1.TabIndex = 0;
            this.pct1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pct1);
            this.panel1.Controls.Add(this.btnImage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 341);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblResult);
            this.panel2.Controls.Add(this.txtCompareLevel);
            this.panel2.Controls.Add(this.txtSimilarityThreshold);
            this.panel2.Controls.Add(this.btnProcess);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 39);
            this.panel2.TabIndex = 2;
            // 
            // btnImage1
            // 
            this.btnImage1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImage1.Location = new System.Drawing.Point(0, 318);
            this.btnImage1.Name = "btnImage1";
            this.btnImage1.Size = new System.Drawing.Size(322, 23);
            this.btnImage1.TabIndex = 1;
            this.btnImage1.Text = "Choose Base Image";
            this.btnImage1.UseVisualStyleBackColor = true;
            this.btnImage1.Click += new System.EventHandler(this.btnImage1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pct2);
            this.panel3.Controls.Add(this.btnImage2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(331, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(322, 341);
            this.panel3.TabIndex = 3;
            // 
            // pct2
            // 
            this.pct2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pct2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pct2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pct2.Location = new System.Drawing.Point(0, 0);
            this.pct2.Name = "pct2";
            this.pct2.Size = new System.Drawing.Size(322, 318);
            this.pct2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pct2.TabIndex = 0;
            this.pct2.TabStop = false;
            // 
            // btnImage2
            // 
            this.btnImage2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnImage2.Location = new System.Drawing.Point(0, 318);
            this.btnImage2.Name = "btnImage2";
            this.btnImage2.Size = new System.Drawing.Size(322, 23);
            this.btnImage2.TabIndex = 1;
            this.btnImage2.Text = "Take Screenshot";
            this.btnImage2.UseVisualStyleBackColor = true;
            this.btnImage2.Click += new System.EventHandler(this.btnImage2_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnProcess.Location = new System.Drawing.Point(0, 0);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 39);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "button1";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtSimilarityThreshold
            // 
            this.txtSimilarityThreshold.Location = new System.Drawing.Point(81, 10);
            this.txtSimilarityThreshold.Name = "txtSimilarityThreshold";
            this.txtSimilarityThreshold.Size = new System.Drawing.Size(100, 20);
            this.txtSimilarityThreshold.TabIndex = 1;
            // 
            // txtCompareLevel
            // 
            this.txtCompareLevel.Location = new System.Drawing.Point(187, 10);
            this.txtCompareLevel.Name = "txtCompareLevel";
            this.txtCompareLevel.Size = new System.Drawing.Size(100, 20);
            this.txtCompareLevel.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(500, 13);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(35, 13);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "label1";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 347);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frmImageComparator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmImageComparator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImageComparator";
            this.Load += new System.EventHandler(this.frmImageComparator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pct1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pct2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pct1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pct2;
        private System.Windows.Forms.Button btnImage2;
        private System.Windows.Forms.TextBox txtCompareLevel;
        private System.Windows.Forms.TextBox txtSimilarityThreshold;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}