namespace MidnightOilGames
{
    partial class Spanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spanner));
            this.Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblSpanStart = new System.Windows.Forms.Label();
            this.lblSpanEnd = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTrack = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTask1 = new System.Windows.Forms.Label();
            this.lblTask2 = new System.Windows.Forms.Label();
            this.lblTask3 = new System.Windows.Forms.Label();
            this.lblTask4 = new System.Windows.Forms.Label();
            this.lblBaby = new System.Windows.Forms.Label();
            this.lblMeasure1 = new System.Windows.Forms.Label();
            this.lblMeasure2 = new System.Windows.Forms.Label();
            this.lblMeasure3 = new System.Windows.Forms.Label();
            this.lblMeasure4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.txtCoder = new System.Windows.Forms.TextBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.lblAdding = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSexRevealed = new System.Windows.Forms.CheckBox();
            this.chkStillFaceAbort = new System.Windows.Forms.CheckBox();
            this.chkPaciNatPlay = new System.Windows.Forms.CheckBox();
            this.chkPaciFreePlay = new System.Windows.Forms.CheckBox();
            this.chkPaciStill = new System.Windows.Forms.CheckBox();
            this.chkPaciReunion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Player.Enabled = true;
            this.Player.Location = new System.Drawing.Point(91, 29);
            this.Player.Name = "Player";
            this.Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player.OcxState")));
            this.Player.Size = new System.Drawing.Size(640, 384);
            this.Player.TabIndex = 0;
            this.Player.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Player_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(737, 420);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(60, 13);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "0:00 / 0:00";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(91, 436);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(640, 19);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(108, 417);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 18);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(108, 476);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(607, 168);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblSpanStart
            // 
            this.lblSpanStart.AutoSize = true;
            this.lblSpanStart.Location = new System.Drawing.Point(57, 43);
            this.lblSpanStart.Name = "lblSpanStart";
            this.lblSpanStart.Size = new System.Drawing.Size(0, 13);
            this.lblSpanStart.TabIndex = 6;
            // 
            // lblSpanEnd
            // 
            this.lblSpanEnd.AutoSize = true;
            this.lblSpanEnd.Location = new System.Drawing.Point(57, 63);
            this.lblSpanEnd.Name = "lblSpanEnd";
            this.lblSpanEnd.Size = new System.Drawing.Size(0, 13);
            this.lblSpanEnd.TabIndex = 7;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar2.Location = new System.Drawing.Point(94, 647);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(637, 18);
            this.hScrollBar2.TabIndex = 8;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblTrack);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSpanEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSpanStart);
            this.groupBox1.Location = new System.Drawing.Point(742, 524);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Span";
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(56, 23);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(0, 13);
            this.lblTrack.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(78, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "End:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Track:";
            // 
            // lblTask1
            // 
            this.lblTask1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTask1.Location = new System.Drawing.Point(13, 476);
            this.lblTask1.Name = "lblTask1";
            this.lblTask1.Size = new System.Drawing.Size(93, 18);
            this.lblTask1.TabIndex = 10;
            this.lblTask1.Text = "Naturalistic Play";
            this.lblTask1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTask1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTask1_MouseClick);
            // 
            // lblTask2
            // 
            this.lblTask2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTask2.Location = new System.Drawing.Point(13, 494);
            this.lblTask2.Name = "lblTask2";
            this.lblTask2.Size = new System.Drawing.Size(93, 18);
            this.lblTask2.TabIndex = 11;
            this.lblTask2.Text = "Free Play";
            this.lblTask2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTask2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTask2_MouseClick);
            // 
            // lblTask3
            // 
            this.lblTask3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTask3.Location = new System.Drawing.Point(13, 512);
            this.lblTask3.Name = "lblTask3";
            this.lblTask3.Size = new System.Drawing.Size(93, 18);
            this.lblTask3.TabIndex = 12;
            this.lblTask3.Text = "Still Face";
            this.lblTask3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTask3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTask3_MouseClick);
            // 
            // lblTask4
            // 
            this.lblTask4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTask4.Location = new System.Drawing.Point(13, 530);
            this.lblTask4.Name = "lblTask4";
            this.lblTask4.Size = new System.Drawing.Size(93, 18);
            this.lblTask4.TabIndex = 13;
            this.lblTask4.Text = "Reunion";
            this.lblTask4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTask4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTask4_MouseClick);
            // 
            // lblBaby
            // 
            this.lblBaby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaby.Location = new System.Drawing.Point(13, 548);
            this.lblBaby.Name = "lblBaby";
            this.lblBaby.Size = new System.Drawing.Size(93, 18);
            this.lblBaby.TabIndex = 14;
            this.lblBaby.Text = "Baby Hidden";
            this.lblBaby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaby.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblBaby_MouseClick);
            // 
            // lblMeasure1
            // 
            this.lblMeasure1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMeasure1.Location = new System.Drawing.Point(13, 566);
            this.lblMeasure1.Name = "lblMeasure1";
            this.lblMeasure1.Size = new System.Drawing.Size(93, 18);
            this.lblMeasure1.TabIndex = 15;
            this.lblMeasure1.Text = "Orient: Object";
            this.lblMeasure1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeasure1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMeasure1_MouseClick);
            // 
            // lblMeasure2
            // 
            this.lblMeasure2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMeasure2.Location = new System.Drawing.Point(13, 584);
            this.lblMeasure2.Name = "lblMeasure2";
            this.lblMeasure2.Size = new System.Drawing.Size(93, 18);
            this.lblMeasure2.TabIndex = 16;
            this.lblMeasure2.Text = "Orient: Mother";
            this.lblMeasure2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeasure2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMeasure2_MouseClick);
            // 
            // lblMeasure3
            // 
            this.lblMeasure3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMeasure3.Location = new System.Drawing.Point(13, 602);
            this.lblMeasure3.Name = "lblMeasure3";
            this.lblMeasure3.Size = new System.Drawing.Size(93, 18);
            this.lblMeasure3.TabIndex = 17;
            this.lblMeasure3.Text = "Self Soothe";
            this.lblMeasure3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeasure3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMeasure3_MouseClick);
            // 
            // lblMeasure4
            // 
            this.lblMeasure4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMeasure4.Location = new System.Drawing.Point(13, 620);
            this.lblMeasure4.Name = "lblMeasure4";
            this.lblMeasure4.Size = new System.Drawing.Size(93, 18);
            this.lblMeasure4.TabIndex = 18;
            this.lblMeasure4.Text = "Escape";
            this.lblMeasure4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeasure4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMeasure4_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Coder";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideo.Location = new System.Drawing.Point(88, 9);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(39, 13);
            this.lblVideo.TabIndex = 20;
            this.lblVideo.Text = "Video";
            // 
            // txtCoder
            // 
            this.txtCoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoder.Location = new System.Drawing.Point(740, 51);
            this.txtCoder.Name = "txtCoder";
            this.txtCoder.Size = new System.Drawing.Size(72, 20);
            this.txtCoder.TabIndex = 21;
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Enabled = false;
            this.cmdExport.Location = new System.Drawing.Point(740, 78);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 22;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // lblAdding
            // 
            this.lblAdding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdding.AutoSize = true;
            this.lblAdding.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdding.Location = new System.Drawing.Point(739, 481);
            this.lblAdding.Name = "lblAdding";
            this.lblAdding.Size = new System.Drawing.Size(46, 13);
            this.lblAdding.TabIndex = 23;
            this.lblAdding.Text = "Adding";
            this.lblAdding.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(858, 652);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Version: 1.2";
            // 
            // chkSexRevealed
            // 
            this.chkSexRevealed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSexRevealed.AutoSize = true;
            this.chkSexRevealed.Location = new System.Drawing.Point(742, 157);
            this.chkSexRevealed.Name = "chkSexRevealed";
            this.chkSexRevealed.Size = new System.Drawing.Size(93, 17);
            this.chkSexRevealed.TabIndex = 25;
            this.chkSexRevealed.Text = "Sex Revealed";
            this.chkSexRevealed.UseVisualStyleBackColor = true;
            // 
            // chkStillFaceAbort
            // 
            this.chkStillFaceAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStillFaceAbort.AutoSize = true;
            this.chkStillFaceAbort.Location = new System.Drawing.Point(742, 181);
            this.chkStillFaceAbort.Name = "chkStillFaceAbort";
            this.chkStillFaceAbort.Size = new System.Drawing.Size(129, 17);
            this.chkStillFaceAbort.TabIndex = 26;
            this.chkStillFaceAbort.Text = "Still Face Ended Early";
            this.chkStillFaceAbort.UseVisualStyleBackColor = true;
            // 
            // chkPaciNatPlay
            // 
            this.chkPaciNatPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaciNatPlay.AutoSize = true;
            this.chkPaciNatPlay.Location = new System.Drawing.Point(742, 205);
            this.chkPaciNatPlay.Name = "chkPaciNatPlay";
            this.chkPaciNatPlay.Size = new System.Drawing.Size(128, 17);
            this.chkPaciNatPlay.TabIndex = 27;
            this.chkPaciNatPlay.Text = "Paci: Naturalistic Play";
            this.chkPaciNatPlay.UseVisualStyleBackColor = true;
            // 
            // chkPaciFreePlay
            // 
            this.chkPaciFreePlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaciFreePlay.AutoSize = true;
            this.chkPaciFreePlay.Location = new System.Drawing.Point(742, 229);
            this.chkPaciFreePlay.Name = "chkPaciFreePlay";
            this.chkPaciFreePlay.Size = new System.Drawing.Size(97, 17);
            this.chkPaciFreePlay.TabIndex = 28;
            this.chkPaciFreePlay.Text = "Paci: Free Play";
            this.chkPaciFreePlay.UseVisualStyleBackColor = true;
            // 
            // chkPaciStill
            // 
            this.chkPaciStill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaciStill.AutoSize = true;
            this.chkPaciStill.Location = new System.Drawing.Point(742, 253);
            this.chkPaciStill.Name = "chkPaciStill";
            this.chkPaciStill.Size = new System.Drawing.Size(96, 17);
            this.chkPaciStill.TabIndex = 29;
            this.chkPaciStill.Text = "Paci: Still Face";
            this.chkPaciStill.UseVisualStyleBackColor = true;
            // 
            // chkPaciReunion
            // 
            this.chkPaciReunion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPaciReunion.AutoSize = true;
            this.chkPaciReunion.Location = new System.Drawing.Point(740, 277);
            this.chkPaciReunion.Name = "chkPaciReunion";
            this.chkPaciReunion.Size = new System.Drawing.Size(93, 17);
            this.chkPaciReunion.TabIndex = 30;
            this.chkPaciReunion.Text = "Paci: Reunion";
            this.chkPaciReunion.UseVisualStyleBackColor = true;
            // 
            // Spanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 674);
            this.Controls.Add(this.chkPaciReunion);
            this.Controls.Add(this.chkPaciStill);
            this.Controls.Add(this.chkPaciFreePlay);
            this.Controls.Add(this.chkPaciNatPlay);
            this.Controls.Add(this.chkStillFaceAbort);
            this.Controls.Add(this.chkSexRevealed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAdding);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.txtCoder);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMeasure4);
            this.Controls.Add(this.lblMeasure3);
            this.Controls.Add(this.lblMeasure2);
            this.Controls.Add(this.lblMeasure1);
            this.Controls.Add(this.lblBaby);
            this.Controls.Add(this.lblTask4);
            this.Controls.Add(this.lblTask3);
            this.Controls.Add(this.lblTask2);
            this.Controls.Add(this.lblTask1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Player);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(949, 713);
            this.Name = "Spanner";
            this.Text = "Spanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Spanner_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Player;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblSpanStart;
        private System.Windows.Forms.Label lblSpanEnd;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTask1;
        private System.Windows.Forms.Label lblTask2;
        private System.Windows.Forms.Label lblTask3;
        private System.Windows.Forms.Label lblTask4;
        private System.Windows.Forms.Label lblBaby;
        private System.Windows.Forms.Label lblMeasure1;
        private System.Windows.Forms.Label lblMeasure2;
        private System.Windows.Forms.Label lblMeasure3;
        private System.Windows.Forms.Label lblMeasure4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.TextBox txtCoder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Label lblAdding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSexRevealed;
        private System.Windows.Forms.CheckBox chkStillFaceAbort;
        private System.Windows.Forms.CheckBox chkPaciNatPlay;
        private System.Windows.Forms.CheckBox chkPaciFreePlay;
        private System.Windows.Forms.CheckBox chkPaciStill;
        private System.Windows.Forms.CheckBox chkPaciReunion;
    }
}

