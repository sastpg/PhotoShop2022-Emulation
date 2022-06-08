/*
 * AForge All Right
 * author:ching
 * date:2015-9-13
 * description:本demo使用Aforgenet框架，功能有连接摄像头，拍照，录像，调整大小和视频帧率等
 * 还有很多需要完善，如果有哪位朋友热心完善后请上传源码供交流学习使用
 * ===使用本程序请保留此段声明===
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace IPLab
{
    public partial class VideoForm : Form
    {
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private VideoCapabilities _videoCapability;
        private int _selectedDeviceIndex = 0;

        private bool _stopREC = true;
        private string drawDate = string.Empty;
        private bool _createNewFile = true;
        private string _videoFileName = string.Empty;  //视频文件名
        private string _videoFileFullPath = string.Empty;  //视频文件全路径
        private int _frameRate = 8;  //默认帧率
        private string _videoPath = AppDomain.CurrentDomain.BaseDirectory + "Video\\"; //视频文件路径
        private string _capturePath = AppDomain.CurrentDomain.BaseDirectory + "Capture\\";

        private Stopwatch stopWatch = null;
        private IVideoSource iVideoSource = null;
        private ImageFormat _imageFormat;
        private string _imageExt;


        public VideoForm()
        {
            InitializeComponent();
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            AllowTransparency = false;
            
            InitUI();
            InitDevice();
            InitEvent();
        }

        private void InitUI()
        {
            btnCloseVideo.Enabled = false;

            if (!Directory.Exists(_capturePath))
                Directory.CreateDirectory(_capturePath);
            if (!Directory.Exists(_videoPath))
                Directory.CreateDirectory(_videoPath);

            lbFrameRate.Text = string.Empty;
            lbMessage.Text = string.Empty;
            txtFrameRate.Text = _frameRate.ToString();

            //加载图片格式并且设置默认格式
            string[] formats = new string[] { "jpg", "png", "bmp", "icon", "emf", "tiff", "wmf", "exif", "gif" };  //, "memorybmp"
            cmbImageFormat.Items.AddRange(formats);
            cmbImageFormat.SelectedIndex = 0;
            _imageFormat = ImageFormat.Jpeg;
            _imageExt = ".jpg";

            MessageShow("设备已找到，但是未打开");
        }

        private void InitDevice()
        {
            _videoDevices = GetDevices();
            if (_videoDevices == null || _videoDevices.Count <= 0)
                return;
            cmbVideoDevices.Items.Clear();
            foreach (FilterInfo device in _videoDevices)
            {
                cmbVideoDevices.Items.Add(device.Name);
            }

            cmbVideoDevices.SelectedIndex = 0;

            _videoSource = VideoConnect();

            if (_videoSource == null)
                return;

            lbFrameRate.Text = _videoSource.FramesReceived.ToString() + "fps";

            //加载图片分辨率并且设置默认值
            foreach (VideoCapabilities videoCap in _videoSource.VideoCapabilities)
            {
                cmbResulotion.Items.Add(videoCap.FrameSize.Width + "x" + videoCap.FrameSize.Height);
            }

            cmbResulotion.SelectedIndex = 0;
            _videoCapability = _videoSource.VideoCapabilities[0];

        }

        private void InitEvent()
        { 
            //
        }

        /// <summary>
        /// 获取所有摄像头设备
        /// </summary>
        /// <returns></returns>
        public FilterInfoCollection GetDevices()
        {
            try
            {
                //枚举所有视频输入设备
                FilterInfoCollection videoDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevice.Count != 0)
                {
                    return videoDevice;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 连接视频摄像头
        /// </summary>
        /// <param name="deviceIndex"></param>
        /// <param name="resolutionIndex"></param>
        /// <returns></returns>
        public VideoCaptureDevice VideoConnect(int deviceIndex = 0, int resolutionIndex = 0)
        {
            if (_videoDevices.Count <= 0)
                return null;
            _selectedDeviceIndex = deviceIndex;
            VideoCaptureDevice videoSource = new VideoCaptureDevice(_videoDevices[deviceIndex].MonikerString);
            //videoCapability = videoSource.VideoCapabilities[resolutionIndex];
            //videoSource.VideoResolution = videoCapability;
            videoSource.VideoResolution = videoSource.VideoCapabilities[resolutionIndex];

            return videoSource;
        }

        private void VideoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_videoSource != null)
                _videoSource.Stop();

            if (videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.Stop();
            }

        }

        //打开视频设备
        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            if (_videoDevices == null || _videoDevices.Count <= 0)
                return;

            _videoSource = VideoConnect();
            //打开视频设备
            if (_videoSource == null)
                return;

            if (!videoSourcePlayer1.IsRunning)
            {
                _videoSource.VideoResolution = _videoCapability;
                videoSourcePlayer1.VideoSource = _videoSource;
                videoSourcePlayer1.Start();

                timer1.Start();
            }

            btnOpenVideo.Enabled = false;
            btnCloseVideo.Enabled = true;
            cmbResulotion.Enabled = false;
            cmbVideoDevices.Enabled = false;

            MessageShow("视频已打开");
        }

        //关闭视频设备
        private void btnCloseVideo_Click(object sender, EventArgs e)
        {
            //关闭视频设备
            if (videoSourcePlayer1.IsRunning)
                videoSourcePlayer1.Stop();

            btnOpenVideo.Enabled = true;
            btnCloseVideo.Enabled = false;
            cmbResulotion.Enabled = true;
            cmbVideoDevices.Enabled = true;

            MessageShow("视频已关闭");
        }

        private void btnVideoSourceSet_Click(object sender, EventArgs e)
        {
            //视频源设置
            _videoSource.DisplayPropertyPage(videoSourcePlayer1.Handle);

            //bool bResult = _videoSource.CheckIfCrossbarAvailable();
            //MessageBox.Show("是否有Cross：" + bResult);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //拍照
            if (videoSourcePlayer1.IsRunning)
            {
                _videoSource.VideoResolution = _videoCapability;
                
                Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
                string fileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-ff") + _imageExt;
                bitmap.Save(_capturePath + fileName, _imageFormat);
                bitmap.Dispose();

                MessageShow("照片已保存");
            }


        }

        private void btnStartVideotape_Click(object sender, EventArgs e)
        {
            //开始录像
            _stopREC = false;
            btnSetFrameRate.Enabled = false;

            MessageShow("正在录像中...");
        }

        private void btnStopVideotape_Click(object sender, EventArgs e)
        {
            //停止录像
            _stopREC = true;
            btnSetFrameRate.Enabled = true;

            MessageShow("录像已停止，文件已保存");
        }

        private void btnViewCapture_Click(object sender, EventArgs e)
        {
            //查看拍照
            string[] temp = Directory.GetFiles(_capturePath);
            if (temp.Length <= 0)
            {
                MessageBox.Show("没有图像！", "提示");
                return;
            }
            //打开所有采集到的图像位置
            Process.Start("Explorer.exe", _capturePath);
        }

        /// <summary>
        /// 查看录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewVideotape_Click(object sender, EventArgs e)
        {
            //查看录像
            string[] temp = Directory.GetFiles(_videoPath);
            if (temp.Length <= 0)
            {
                MessageBox.Show("没有图像！", "提示");
                return;
            }
            //打开所有采集到的视频位置
            Process.Start("Explorer.exe", _videoPath);
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            //放大前进
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //缩小后退
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            //左转
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            //右转
        }

        private void cmbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImageFormat.Items.Count <= 0)
                return;
            //cmbImageFormat.Items[cmbImageFormat.SelectedIndex].ToString();
            //cmbImageFormat.SelectedItem.ToString();

            string formatType = cmbImageFormat.SelectedItem.ToString();
            SelectedImageFormat(formatType);
        }

        private void SelectedImageFormat(string formatType)
        {
            switch (formatType)
            {
                case "jpg":
                    _imageFormat = ImageFormat.Jpeg;
                    _imageExt = ".jpg";
                    break;
                case "bmp":
                    _imageFormat = ImageFormat.Bmp;
                    _imageExt = ".bmp";
                    break;
                case "gif":
                    _imageFormat = ImageFormat.Gif;
                    _imageExt = ".gif";
                    break;
                case "png":
                    _imageFormat = ImageFormat.Png;
                    _imageExt = ".png";
                    break;
                case "tiff":
                    _imageFormat = ImageFormat.Tiff;
                    _imageExt = ".tiff";
                    break;
                case "icon":
                    _imageFormat = ImageFormat.Icon;
                    _imageExt = ".ico";
                    break;
                case "emf":
                    _imageFormat = ImageFormat.Emf;
                    _imageExt = ".emf";
                    break;
                case "wmf":
                    _imageFormat = ImageFormat.Wmf;
                    _imageExt = ".wmf";
                    break;
                case "exif":
                    _imageFormat = ImageFormat.Exif;
                    _imageExt = ".exif";
                    break;
                //case "memorybmp":
                //    _imageFormat = ImageFormat.MemoryBmp;
                //    _ext = ".jpg";
                //    break;
                default:
                    _imageFormat = ImageFormat.Jpeg;
                    _imageExt = ".jpg";
                    break;

            }
        }

        private void cmbResulotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResulotion.Items.Count <= 0)
                return;

            _videoCapability = _videoSource.VideoCapabilities[cmbResulotion.SelectedIndex];
        }

        

        /// <summary>
        /// 显示摄像头的平均帧率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            iVideoSource = videoSourcePlayer1.VideoSource;
            if (iVideoSource != null)
            {
                int framesReceived = _videoSource.FramesReceived;
                if (stopWatch == null)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();
                    float fps = 1000f * framesReceived / stopWatch.ElapsedMilliseconds;
                    lbFrameRate.Text = fps.ToString() + " fps";  //"平均帧数：" + 

                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }

        private delegate void MyInvoke();
        private void UpdateMessage(string value)
        {
            MyInvoke myInvoke = delegate
            {
                lbFrameRate.Text = _videoSource.FramesReceived.ToString() + "fps";
            };
            this.Invoke(myInvoke);
        }

        private void MessageShow(string value)
        {
            lbMessage.Text = value;
        }

        private void btnSetFrameRate_Click(object sender, EventArgs e)
        {
            //帧率设定
            if (string.IsNullOrEmpty(txtFrameRate.Text.Trim()))
                return;

            int frameRate = _frameRate;
            try
            {
                frameRate = Convert.ToInt32(txtFrameRate.Text.Trim());
                _frameRate = frameRate;
            }
            catch (Exception)
            {
                MessageBox.Show("您输入的帧率非法字符，请重新输入");
            }
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            //播放窗口
            
        }

    }
}
