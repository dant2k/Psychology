namespace Forge
{
    partial class Forge
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lstVideos = new System.Windows.Forms.ListView();
            this.chVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCoder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAccept = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNeedsBaseline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNatPlayStart = new System.Windows.Forms.TextBox();
            this.txtNatPlayEnd = new System.Windows.Forms.TextBox();
            this.txtFreePlayStart = new System.Windows.Forms.TextBox();
            this.txtFreePlayEnd = new System.Windows.Forms.TextBox();
            this.txtStillEnd = new System.Windows.Forms.TextBox();
            this.txtStillStart = new System.Windows.Forms.TextBox();
            this.txtReunionEnd = new System.Windows.Forms.TextBox();
            this.txtReunionStart = new System.Windows.Forms.TextBox();
            this.btnAccepted = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblVideoCount = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEpoch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReliability = new System.Windows.Forms.Button();
            this.btnSetBaseline = new System.Windows.Forms.Button();
            this.btnExportData = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTimepoint = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblErrorCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loaded Path:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(126, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(117, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "c:\\Users\\soal\\Desktop";
            // 
            // lstVideos
            // 
            this.lstVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVideos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVideo,
            this.chCoder,
            this.chAccept,
            this.chNeedsBaseline});
            this.lstVideos.Location = new System.Drawing.Point(15, 98);
            this.lstVideos.Name = "lstVideos";
            this.lstVideos.Size = new System.Drawing.Size(513, 184);
            this.lstVideos.TabIndex = 2;
            this.lstVideos.UseCompatibleStateImageBehavior = false;
            this.lstVideos.View = System.Windows.Forms.View.Details;
            this.lstVideos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstVideos_ColumnClick);
            this.lstVideos.SelectedIndexChanged += new System.EventHandler(this.lstVideos_SelectedIndexChanged);
            // 
            // chVideo
            // 
            this.chVideo.Text = "Video";
            this.chVideo.Width = 120;
            // 
            // chCoder
            // 
            this.chCoder.Text = "Coder";
            // 
            // chAccept
            // 
            this.chAccept.Text = "Accepted";
            // 
            // chNeedsBaseline
            // 
            this.chNeedsBaseline.Text = "Needs Baseline";
            this.chNeedsBaseline.Width = 108;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(537, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load Folder";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Errors:";
            // 
            // lstErrors
            // 
            this.lstErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.Location = new System.Drawing.Point(15, 301);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(513, 108);
            this.lstErrors.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Baseline Timespans:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Single Toy";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "6 Toys";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Still Face";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Reunion";
            this.label8.Visible = false;
            // 
            // txtNatPlayStart
            // 
            this.txtNatPlayStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNatPlayStart.Location = new System.Drawing.Point(53, 445);
            this.txtNatPlayStart.Name = "txtNatPlayStart";
            this.txtNatPlayStart.Size = new System.Drawing.Size(68, 20);
            this.txtNatPlayStart.TabIndex = 11;
            this.txtNatPlayStart.Leave += new System.EventHandler(this.txtNatPlayStart_Leave);
            // 
            // txtNatPlayEnd
            // 
            this.txtNatPlayEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNatPlayEnd.Location = new System.Drawing.Point(53, 471);
            this.txtNatPlayEnd.Name = "txtNatPlayEnd";
            this.txtNatPlayEnd.Size = new System.Drawing.Size(68, 20);
            this.txtNatPlayEnd.TabIndex = 12;
            this.txtNatPlayEnd.Leave += new System.EventHandler(this.txtNatPlayEnd_Leave);
            // 
            // txtFreePlayStart
            // 
            this.txtFreePlayStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFreePlayStart.Location = new System.Drawing.Point(127, 445);
            this.txtFreePlayStart.Name = "txtFreePlayStart";
            this.txtFreePlayStart.Size = new System.Drawing.Size(67, 20);
            this.txtFreePlayStart.TabIndex = 13;
            this.txtFreePlayStart.Leave += new System.EventHandler(this.txtFreePlayStart_Leave);
            // 
            // txtFreePlayEnd
            // 
            this.txtFreePlayEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFreePlayEnd.Location = new System.Drawing.Point(127, 471);
            this.txtFreePlayEnd.Name = "txtFreePlayEnd";
            this.txtFreePlayEnd.Size = new System.Drawing.Size(67, 20);
            this.txtFreePlayEnd.TabIndex = 14;
            this.txtFreePlayEnd.Leave += new System.EventHandler(this.txtFreePlayEnd_Leave);
            // 
            // txtStillEnd
            // 
            this.txtStillEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStillEnd.Location = new System.Drawing.Point(201, 471);
            this.txtStillEnd.Name = "txtStillEnd";
            this.txtStillEnd.Size = new System.Drawing.Size(67, 20);
            this.txtStillEnd.TabIndex = 16;
            this.txtStillEnd.Visible = false;
            this.txtStillEnd.Leave += new System.EventHandler(this.txtStillEnd_Leave);
            // 
            // txtStillStart
            // 
            this.txtStillStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStillStart.Location = new System.Drawing.Point(201, 445);
            this.txtStillStart.Name = "txtStillStart";
            this.txtStillStart.Size = new System.Drawing.Size(67, 20);
            this.txtStillStart.TabIndex = 15;
            this.txtStillStart.Visible = false;
            this.txtStillStart.Leave += new System.EventHandler(this.txtStillStart_Leave);
            // 
            // txtReunionEnd
            // 
            this.txtReunionEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReunionEnd.Location = new System.Drawing.Point(277, 471);
            this.txtReunionEnd.Name = "txtReunionEnd";
            this.txtReunionEnd.Size = new System.Drawing.Size(67, 20);
            this.txtReunionEnd.TabIndex = 18;
            this.txtReunionEnd.Visible = false;
            this.txtReunionEnd.Leave += new System.EventHandler(this.txtReunionEnd_Leave);
            // 
            // txtReunionStart
            // 
            this.txtReunionStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReunionStart.Location = new System.Drawing.Point(277, 445);
            this.txtReunionStart.Name = "txtReunionStart";
            this.txtReunionStart.Size = new System.Drawing.Size(67, 20);
            this.txtReunionStart.TabIndex = 17;
            this.txtReunionStart.Visible = false;
            this.txtReunionStart.Leave += new System.EventHandler(this.txtReunionStart_Leave);
            // 
            // btnAccepted
            // 
            this.btnAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccepted.Location = new System.Drawing.Point(424, 419);
            this.btnAccepted.Name = "btnAccepted";
            this.btnAccepted.Size = new System.Drawing.Size(104, 23);
            this.btnAccepted.TabIndex = 19;
            this.btnAccepted.Text = "Set Accepted";
            this.btnAccepted.UseVisualStyleBackColor = true;
            this.btnAccepted.Click += new System.EventHandler(this.btnAccepted_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Video Count:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "File Count:";
            // 
            // lblVideoCount
            // 
            this.lblVideoCount.AutoSize = true;
            this.lblVideoCount.Location = new System.Drawing.Point(126, 44);
            this.lblVideoCount.Name = "lblVideoCount";
            this.lblVideoCount.Size = new System.Drawing.Size(13, 13);
            this.lblVideoCount.TabIndex = 22;
            this.lblVideoCount.Text = "0";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(126, 27);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(13, 13);
            this.lblFileCount.TabIndex = 23;
            this.lblFileCount.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Start";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 475);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "End";
            // 
            // txtEpoch
            // 
            this.txtEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEpoch.Location = new System.Drawing.Point(562, 475);
            this.txtEpoch.Name = "txtEpoch";
            this.txtEpoch.Size = new System.Drawing.Size(50, 20);
            this.txtEpoch.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(559, 459);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Epoch:";
            // 
            // btnReliability
            // 
            this.btnReliability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReliability.Location = new System.Drawing.Point(537, 314);
            this.btnReliability.Name = "btnReliability";
            this.btnReliability.Size = new System.Drawing.Size(75, 49);
            this.btnReliability.TabIndex = 28;
            this.btnReliability.Text = "Export Reliability";
            this.btnReliability.UseVisualStyleBackColor = true;
            this.btnReliability.Click += new System.EventHandler(this.btnReliability_Click);
            // 
            // btnSetBaseline
            // 
            this.btnSetBaseline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBaseline.Location = new System.Drawing.Point(424, 451);
            this.btnSetBaseline.Name = "btnSetBaseline";
            this.btnSetBaseline.Size = new System.Drawing.Size(104, 23);
            this.btnSetBaseline.TabIndex = 29;
            this.btnSetBaseline.Text = "Use As Baseline";
            this.btnSetBaseline.UseVisualStyleBackColor = true;
            this.btnSetBaseline.Click += new System.EventHandler(this.btnSetBaseline_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportData.Location = new System.Drawing.Point(539, 371);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(72, 53);
            this.btnExportData.TabIndex = 30;
            this.btnExportData.Text = "Export Data";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Detected Timepoint:";
            // 
            // lblTimepoint
            // 
            this.lblTimepoint.AutoSize = true;
            this.lblTimepoint.Location = new System.Drawing.Point(126, 61);
            this.lblTimepoint.Name = "lblTimepoint";
            this.lblTimepoint.Size = new System.Drawing.Size(0, 13);
            this.lblTimepoint.TabIndex = 32;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(16, 78);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(63, 13);
            this.lblError.TabIndex = 33;
            this.lblError.Text = "Error Count:";
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.AutoSize = true;
            this.lblErrorCount.Location = new System.Drawing.Point(127, 77);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(13, 13);
            this.lblErrorCount.TabIndex = 34;
            this.lblErrorCount.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(465, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Version: .90";
            // 
            // Forge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 504);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblErrorCount);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblTimepoint);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.btnSetBaseline);
            this.Controls.Add(this.btnReliability);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEpoch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblVideoCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAccepted);
            this.Controls.Add(this.txtReunionEnd);
            this.Controls.Add(this.txtReunionStart);
            this.Controls.Add(this.txtStillEnd);
            this.Controls.Add(this.txtStillStart);
            this.Controls.Add(this.txtFreePlayEnd);
            this.Controls.Add(this.txtFreePlayStart);
            this.Controls.Add(this.txtNatPlayEnd);
            this.Controls.Add(this.txtNatPlayStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lstVideos);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(640, 543);
            this.Name = "Forge";
            this.Text = "Forge - Clearfield";
            this.Load += new System.EventHandler(this.Forge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ListView lstVideos;
        private System.Windows.Forms.ColumnHeader chVideo;
        private System.Windows.Forms.ColumnHeader chCoder;
        private System.Windows.Forms.ColumnHeader chAccept;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ColumnHeader chNeedsBaseline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstErrors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNatPlayStart;
        private System.Windows.Forms.TextBox txtNatPlayEnd;
        private System.Windows.Forms.TextBox txtFreePlayStart;
        private System.Windows.Forms.TextBox txtFreePlayEnd;
        private System.Windows.Forms.TextBox txtStillEnd;
        private System.Windows.Forms.TextBox txtStillStart;
        private System.Windows.Forms.TextBox txtReunionEnd;
        private System.Windows.Forms.TextBox txtReunionStart;
        private System.Windows.Forms.Button btnAccepted;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblVideoCount;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEpoch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReliability;
        private System.Windows.Forms.Button btnSetBaseline;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTimepoint;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblErrorCount;
        private System.Windows.Forms.Label label14;
    }
}

