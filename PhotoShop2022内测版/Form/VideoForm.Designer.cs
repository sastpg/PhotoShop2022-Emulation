namespace IPLab
{
    partial class VideoForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPlayVideo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbImageFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbResulotion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVideoSourceSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFrameRate = new System.Windows.Forms.TextBox();
            this.btnSetFrameRate = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnViewVideotape = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnViewCapture = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnStopVideotape = new System.Windows.Forms.Button();
            this.btnStartVideotape = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnCloseVideo = new System.Windows.Forms.Button();
            this.btnOpenVideo = new System.Windows.Forms.Button();
            this.cmbVideoDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbFrameRate = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 12);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(639, 485);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            //this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPlayVideo);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCloseVideo);
            this.groupBox1.Controls.Add(this.btnOpenVideo);
            this.groupBox1.Controls.Add(this.cmbVideoDevices);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(657, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 485);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "视频控制";
            // 
            // btnPlayVideo
            // 
            this.btnPlayVideo.Location = new System.Drawing.Point(181, 46);
            this.btnPlayVideo.Name = "btnPlayVideo";
            this.btnPlayVideo.Size = new System.Drawing.Size(75, 23);
            this.btnPlayVideo.TabIndex = 9;
            this.btnPlayVideo.Text = "播放视频";
            this.btnPlayVideo.UseVisualStyleBackColor = true;
            this.btnPlayVideo.Click += new System.EventHandler(this.btnPlayVideo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbImageFormat);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbResulotion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnVideoSourceSet);
            this.groupBox3.Location = new System.Drawing.Point(6, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 235);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "视频设置";
            // 
            // cmbImageFormat
            // 
            this.cmbImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageFormat.FormattingEnabled = true;
            this.cmbImageFormat.Location = new System.Drawing.Point(142, 48);
            this.cmbImageFormat.Name = "cmbImageFormat";
            this.cmbImageFormat.Size = new System.Drawing.Size(121, 20);
            this.cmbImageFormat.TabIndex = 3;
            this.cmbImageFormat.SelectedIndexChanged += new System.EventHandler(this.cmbImageFormat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "图格式：";
            // 
            // cmbResulotion
            // 
            this.cmbResulotion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResulotion.FormattingEnabled = true;
            this.cmbResulotion.Location = new System.Drawing.Point(142, 22);
            this.cmbResulotion.Name = "cmbResulotion";
            this.cmbResulotion.Size = new System.Drawing.Size(121, 20);
            this.cmbResulotion.TabIndex = 3;
            this.cmbResulotion.SelectedIndexChanged += new System.EventHandler(this.cmbResulotion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "分辨率：";
            // 
            // btnVideoSourceSet
            // 
            this.btnVideoSourceSet.Location = new System.Drawing.Point(7, 20);
            this.btnVideoSourceSet.Name = "btnVideoSourceSet";
            this.btnVideoSourceSet.Size = new System.Drawing.Size(75, 23);
            this.btnVideoSourceSet.TabIndex = 2;
            this.btnVideoSourceSet.Text = "视频源设置";
            this.btnVideoSourceSet.UseVisualStyleBackColor = true;
            this.btnVideoSourceSet.Click += new System.EventHandler(this.btnVideoSourceSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFrameRate);
            this.groupBox2.Controls.Add(this.btnSetFrameRate);
            this.groupBox2.Controls.Add(this.btnFront);
            this.groupBox2.Controls.Add(this.btnViewVideotape);
            this.groupBox2.Controls.Add(this.btnBack);
            this.groupBox2.Controls.Add(this.btnViewCapture);
            this.groupBox2.Controls.Add(this.btnLeft);
            this.groupBox2.Controls.Add(this.btnRight);
            this.groupBox2.Controls.Add(this.btnStopVideotape);
            this.groupBox2.Controls.Add(this.btnStartVideotape);
            this.groupBox2.Controls.Add(this.btnCapture);
            this.groupBox2.Location = new System.Drawing.Point(6, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 163);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "视频操作";
            // 
            // txtFrameRate
            // 
            this.txtFrameRate.Location = new System.Drawing.Point(175, 79);
            this.txtFrameRate.Name = "txtFrameRate";
            this.txtFrameRate.Size = new System.Drawing.Size(75, 21);
            this.txtFrameRate.TabIndex = 8;
            // 
            // btnSetFrameRate
            // 
            this.btnSetFrameRate.Location = new System.Drawing.Point(94, 78);
            this.btnSetFrameRate.Name = "btnSetFrameRate";
            this.btnSetFrameRate.Size = new System.Drawing.Size(75, 23);
            this.btnSetFrameRate.TabIndex = 7;
            this.btnSetFrameRate.Text = "帧率设定";
            this.btnSetFrameRate.UseVisualStyleBackColor = true;
            this.btnSetFrameRate.Click += new System.EventHandler(this.btnSetFrameRate_Click);
            // 
            // btnFront
            // 
            this.btnFront.Location = new System.Drawing.Point(27, 49);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(40, 23);
            this.btnFront.TabIndex = 2;
            this.btnFront.Text = "前进";
            this.btnFront.UseVisualStyleBackColor = true;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnViewVideotape
            // 
            this.btnViewVideotape.Location = new System.Drawing.Point(175, 49);
            this.btnViewVideotape.Name = "btnViewVideotape";
            this.btnViewVideotape.Size = new System.Drawing.Size(75, 23);
            this.btnViewVideotape.TabIndex = 6;
            this.btnViewVideotape.Text = "查看录像";
            this.btnViewVideotape.UseVisualStyleBackColor = true;
            this.btnViewVideotape.Click += new System.EventHandler(this.btnViewVideotape_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(27, 107);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "后退";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnViewCapture
            // 
            this.btnViewCapture.Location = new System.Drawing.Point(94, 49);
            this.btnViewCapture.Name = "btnViewCapture";
            this.btnViewCapture.Size = new System.Drawing.Size(75, 23);
            this.btnViewCapture.TabIndex = 6;
            this.btnViewCapture.Text = "查看拍照";
            this.btnViewCapture.UseVisualStyleBackColor = true;
            this.btnViewCapture.Click += new System.EventHandler(this.btnViewCapture_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(7, 78);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(40, 23);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "左转";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(48, 78);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(40, 23);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = "右转";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnStopVideotape
            // 
            this.btnStopVideotape.Location = new System.Drawing.Point(175, 20);
            this.btnStopVideotape.Name = "btnStopVideotape";
            this.btnStopVideotape.Size = new System.Drawing.Size(75, 23);
            this.btnStopVideotape.TabIndex = 1;
            this.btnStopVideotape.Text = "停止录像";
            this.btnStopVideotape.UseVisualStyleBackColor = true;
            this.btnStopVideotape.Click += new System.EventHandler(this.btnStopVideotape_Click);
            // 
            // btnStartVideotape
            // 
            this.btnStartVideotape.Location = new System.Drawing.Point(94, 20);
            this.btnStartVideotape.Name = "btnStartVideotape";
            this.btnStartVideotape.Size = new System.Drawing.Size(75, 23);
            this.btnStartVideotape.TabIndex = 1;
            this.btnStartVideotape.Text = "开始录像";
            this.btnStartVideotape.UseVisualStyleBackColor = true;
            this.btnStartVideotape.Click += new System.EventHandler(this.btnStartVideotape_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(13, 20);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "拍照";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnCloseVideo
            // 
            this.btnCloseVideo.Location = new System.Drawing.Point(100, 46);
            this.btnCloseVideo.Name = "btnCloseVideo";
            this.btnCloseVideo.Size = new System.Drawing.Size(75, 23);
            this.btnCloseVideo.TabIndex = 2;
            this.btnCloseVideo.Text = "关闭视频";
            this.btnCloseVideo.UseVisualStyleBackColor = true;
            this.btnCloseVideo.Click += new System.EventHandler(this.btnCloseVideo_Click);
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.Location = new System.Drawing.Point(19, 46);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.Size = new System.Drawing.Size(75, 23);
            this.btnOpenVideo.TabIndex = 2;
            this.btnOpenVideo.Text = "打开视频";
            this.btnOpenVideo.UseVisualStyleBackColor = true;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // cmbVideoDevices
            // 
            this.cmbVideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoDevices.FormattingEnabled = true;
            this.cmbVideoDevices.Location = new System.Drawing.Point(75, 20);
            this.cmbVideoDevices.Name = "cmbVideoDevices";
            this.cmbVideoDevices.Size = new System.Drawing.Size(194, 20);
            this.cmbVideoDevices.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "视频设备：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 508);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "帧率：";
            // 
            // lbFrameRate
            // 
            this.lbFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFrameRate.AutoSize = true;
            this.lbFrameRate.Location = new System.Drawing.Point(51, 508);
            this.lbFrameRate.Name = "lbFrameRate";
            this.lbFrameRate.Size = new System.Drawing.Size(53, 12);
            this.lbFrameRate.TabIndex = 2;
            this.lbFrameRate.Text = "23.00fps";
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(166, 508);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(53, 12);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "提示消息";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 529);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbFrameRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Name = "VideoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摄像头操作";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoForm_FormClosing);
            this.Load += new System.EventHandler(this.VideoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVideoDevices;
        private System.Windows.Forms.Button btnVideoSourceSet;
        private System.Windows.Forms.Button btnCloseVideo;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStartVideotape;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnStopVideotape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResulotion;
        private System.Windows.Forms.ComboBox cmbImageFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFrameRate;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnViewVideotape;
        private System.Windows.Forms.Button btnViewCapture;
        private System.Windows.Forms.Button btnSetFrameRate;
        private System.Windows.Forms.TextBox txtFrameRate;
        private System.Windows.Forms.Button btnPlayVideo;
    }
}

