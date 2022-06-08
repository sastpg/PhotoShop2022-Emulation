// Image Processing Lab
//
// Copyright ?Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

namespace IPLab
{
    /// <summary>
    /// Summary description for ImageDoc.
    /// </summary>
    public class ImageDoc : Content
    {
        private System.Drawing.Bitmap backup = null;
        private System.Drawing.Bitmap image = null;
        private string fileName = null;
        private int width;
        private int height;
        private float zoom = 1;
        private IDocumentsHost host = null;

        private bool cropping = false;
        private bool dragging = false;
        private Point start, end, startW, endW;
        private Panel panel18;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 图像ToolStripMenuItem;
        private ToolStripMenuItem 返回ToolStripMenuItem;
        private ToolStripMenuItem 克隆ToolStripMenuItem;
        private ToolStripMenuItem 缩放ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem 放大显示ToolStripMenuItem;
        private ToolStripMenuItem 缩小显示ToolStripMenuItem;
        private ToolStripMenuItem 适应屏幕ToolStripMenuItem;
        private ToolStripMenuItem 垂直翻转ToolStripMenuItem;
        private ToolStripMenuItem 水平翻转ToolStripMenuItem;
        private ToolStripMenuItem 旋转90ToolStripMenuItem;
        private ToolStripMenuItem 裁剪ToolStripMenuItem;
        private ToolStripMenuItem 滤镜ToolStripMenuItem;
        private ToolStripMenuItem 颜色ToolStripMenuItem;
        private ToolStripMenuItem 灰度ToolStripMenuItem;
        private ToolStripMenuItem 灰度到RGBToolStripMenuItem;
        private ToolStripMenuItem 棕褐色ToolStripMenuItem;
        private ToolStripMenuItem 反色ToolStripMenuItem;
        private ToolStripMenuItem rotateToolStripMenuItem;
        private ToolStripMenuItem 滤色ToolStripMenuItem;
        private ToolStripMenuItem 欧几里得颜色滤波ToolStripMenuItem;
        private ToolStripMenuItem 通道滤波ToolStripMenuItem;
        private ToolStripMenuItem 提取红色通道ToolStripMenuItem;
        private ToolStripMenuItem 提取红色通道ToolStripMenuItem1;
        private ToolStripMenuItem 提取红色通道ToolStripMenuItem2;
        private ToolStripMenuItem 更换红色通道ToolStripMenuItem;
        private ToolStripMenuItem 更换红色通道ToolStripMenuItem1;
        private ToolStripMenuItem 更换红色通道ToolStripMenuItem2;
        private ToolStripMenuItem 红ToolStripMenuItem;
        private ToolStripMenuItem 绿ToolStripMenuItem;
        private ToolStripMenuItem 蓝ToolStripMenuItem;
        private ToolStripMenuItem 青色ToolStripMenuItem;
        private ToolStripMenuItem 洋红色ToolStripMenuItem;
        private ToolStripMenuItem 黄色ToolStripMenuItem;
        private ToolStripMenuItem hSL颜色空间ToolStripMenuItem;
        private ToolStripMenuItem 亮度ToolStripMenuItem;
        private ToolStripMenuItem 对比度ToolStripMenuItem;
        private ToolStripMenuItem 饱和度ToolStripMenuItem;
        private ToolStripMenuItem HSL线性ToolStripMenuItem;
        private ToolStripMenuItem hSL滤波ToolStripMenuItem;
        private ToolStripMenuItem 色调调节ToolStripMenuItem;
        private ToolStripMenuItem yCbCr颜色空间ToolStripMenuItem;
        private ToolStripMenuItem yCbCr线性ToolStripMenuItem;
        private ToolStripMenuItem yCbCr滤波ToolStripMenuItem;
        private ToolStripMenuItem 提取Y通道ToolStripMenuItem;
        private ToolStripMenuItem 提取Cb通道ToolStripMenuItem;
        private ToolStripMenuItem 提取Cr通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Y通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Cb通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Cr通道ToolStripMenuItem;
        private ToolStripMenuItem 二值化ToolStripMenuItem;
        private ToolStripMenuItem 图像阈值ToolStripMenuItem;
        private ToolStripMenuItem 带错误进位的阈值ToolStripMenuItem;
        private ToolStripMenuItem 有序抖动ToolStripMenuItem;
        private ToolStripMenuItem bayer有序抖动ToolStripMenuItem;
        private ToolStripMenuItem 弗洛伊德斯坦伯格抖动ToolStripMenuItem;
        private ToolStripMenuItem 伯克斯抖动ToolStripMenuItem;
        private ToolStripMenuItem stucki抖动ToolStripMenuItem;
        private ToolStripMenuItem jarvisJudiceNinke抖动ToolStripMenuItem;
        private ToolStripMenuItem sierra抖动ToolStripMenuItem;
        private ToolStripMenuItem stevensonAndArce抖动ToolStripMenuItem;
        private ToolStripMenuItem sIS阈值ToolStripMenuItem;
        private ToolStripMenuItem 形态ToolStripMenuItem;
        private ToolStripMenuItem 腐蚀ToolStripMenuItem;
        private ToolStripMenuItem 膨胀ToolStripMenuItem;
        private ToolStripMenuItem 开运算ToolStripMenuItem;
        private ToolStripMenuItem 闭运算ToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem hitAndMissTHickeningThinningToolStripMenuItem;
        private ToolStripMenuItem 卷积相关ToolStripMenuItem;
        private ToolStripMenuItem meanToolStripMenuItem;
        private ToolStripMenuItem blurToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem edgesToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem1;
        private ToolStripMenuItem gaussianToolStripMenuItem;
        private ToolStripMenuItem sharpenExToolStripMenuItem;
        private ToolStripMenuItem 双源滤波器ToolStripMenuItem;
        private ToolStripMenuItem mergeToolStripMenuItem;
        private ToolStripMenuItem intersectToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem subtractToolStripMenuItem;
        private ToolStripMenuItem differenceToolStripMenuItem;
        private ToolStripMenuItem moveTowardsToolStripMenuItem;
        private ToolStripMenuItem morphToolStripMenuItem;
        private ToolStripMenuItem 边缘检测器ToolStripMenuItem;
        private ToolStripMenuItem homogenityToolStripMenuItem;
        private ToolStripMenuItem differenceToolStripMenuItem1;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem cannyToolStripMenuItem;
        private ToolStripMenuItem 其他ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem 大小ToolStripMenuItem;
        private ToolStripMenuItem 旋转ToolStripMenuItem;
        private ToolStripMenuItem 层次ToolStripMenuItem;
        private ToolStripMenuItem 中位数ToolStripMenuItem;
        private ToolStripMenuItem 伽玛校正ToolStripMenuItem;
        private ToolStripMenuItem 傅里叶变换ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private Panel panel1;
        private System.ComponentModel.IContainer components;

        // Image property
        public Bitmap Image
        {
            get { return image; }
        }
        // Width property
        public int ImageWidth
        {
            get { return width; }
        }
        // Height property
        public int ImageHeight
        {
            get { return height; }
        }
        // Zoom property
        public float Zoom
        {
            get { return zoom; }
        }
        // FileName property
        // return file name if the document was created from file or null
        public string FileName
        {
            get { return fileName; }
        }


        // Events
        public delegate void SelectionEventHandler( object sender, SelectionEventArgs e );

        public event EventHandler DocumentChanged;
        public event EventHandler ZoomChanged;
        public event SelectionEventHandler MouseImagePosition;
        public event SelectionEventHandler SelectionChanged;


        // Constructors
        public ImageDoc( IDocumentsHost host )
        {
            this.host = host;
        }
        // Construct from file
        public ImageDoc( string fileName, IDocumentsHost host, MainForm mainform)
            : this( host )
        {
            try
            {
                // load image
                image = (Bitmap) Bitmap.FromFile( fileName );

                // format image
                AForge.Imaging.Image.FormatImage( ref image );

                this.fileName = fileName;
            }
            catch ( Exception )
            {
                throw new ApplicationException( "Failed loading image" );
            }
            mainform.MenuEvent += new MenuEventHandler(mainform_MenuEvent);
            Init( );
        }
        // Construct from image
        public ImageDoc( Bitmap image, IDocumentsHost host )
            : this( host )
        {
            this.image = image;
            AForge.Imaging.Image.FormatImage( ref this.image );

            Init( );
        }


        void mainform_MenuEvent(string operation)
        {
            switch (operation)
            {
                case "灰度":
                    ApplyFilter1(new GrayscaleBT709());
                    break;
                case "灰度到RGB":
                    if (image.PixelFormat == PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("The image is already RGB", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    ApplyFilter(new GrayscaleToRGB());
                    break;
                case "棕褐色":
                    ApplyFilter(new Sepia());
                    break;
                case "反色":
                    ApplyFilter(new Invert());
                    break;
                case "Rotate":
                    ApplyFilter(new RotateChannels());
                    break;
                case "滤色":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    ColorFilteringForm form = new ColorFilteringForm();
                    form.Image = image;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form.Filter);
                    }
                    break;
                case "欧几里得颜色滤波":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Euclidean color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    EuclideanColorFilteringForm form1 = new EuclideanColorFilteringForm();
                    form1.Image = image;

                    if (form1.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form1.Filter);
                    }
                    break;
                case "通道滤波":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    ChannelFilteringForm form2 = new ChannelFilteringForm();
                    form2.Image = image;

                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form2.Filter);
                    }
                    break;
                case "提取红色通道":
                    ApplyFilter(new ExtractChannel(RGB.R));
                    break;
                case "提取绿色通道":
                    ApplyFilter(new ExtractChannel(RGB.G));
                    break;
                case "提取蓝色通道":
                    ApplyFilter(new ExtractChannel(RGB.B));
                    break;
                case "更换红色通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage = host.GetImage(this, "Select an image which will replace the red channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage != null)
                        ApplyFilter(new ReplaceChannel(RGB.R, channelImage));
                    break;
                case "更换绿色通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage1 = host.GetImage(this, "Select an image which will replace the green channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage1 != null)
                        ApplyFilter(new ReplaceChannel(RGB.G, channelImage1));
                    break;
                case "更换蓝色通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage2 = host.GetImage(this, "Select an image which will replace the blue channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage2 != null)
                        ApplyFilter(new ReplaceChannel(RGB.B, channelImage2));
                    break;
                case "红色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0)));
                    break;
                case "绿色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0)));
                    break;
                case "蓝色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255)));
                    break;
                case "青色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 255)));
                    break;
                case "洋红色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 255)));
                    break;
                case "黄色":
                    ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 255), new IntRange(0, 0)));
                    break;
                case "亮度":
                    Brightness();
                    break;
                case "对比度":
                    Contrast();
                    break;
                case "饱和度":
                    Saturation();
                    break;
                case "HSL线性":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("HSL linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    HSLLinearForm form3 = new HSLLinearForm(new ImageStatisticsHSL(image));
                    form3.Image = image;

                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form3.Filter);
                    }
                    break;
                case "HSL滤波":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("HSL filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    HSLFilteringForm form4 = new HSLFilteringForm();
                    form4.Image = image;

                    if (form4.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form4.Filter);
                    }
                    break;
                case "色调调节":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Hue modifier is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    HueModifierForm form5 = new HueModifierForm();
                    form5.Image = image;

                    if (form5.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form5.Filter);
                    }
                    break;
                case "YCbCr线性":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("YCbCr linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    YCbCrLinearForm form6 = new YCbCrLinearForm(new ImageStatisticsYCbCr(image));
                    form6.Image = image;

                    if (form6.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form6.Filter);
                    }
                    break;
                case "YCbCr滤波":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("YCbCr filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    YCbCrFilteringForm form7 = new YCbCrFilteringForm();
                    form7.Image = image;

                    if (form7.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form7.Filter);
                    }
                    break;
                case "提取Y通道":
                    ApplyFilter(new YCbCrExtractChannel(YCbCr.YIndex));
                    break;
                case "提取Cb通道":
                    ApplyFilter(new YCbCrExtractChannel(YCbCr.CbIndex));
                    break;
                case "提取Cr通道":
                    ApplyFilter(new YCbCrExtractChannel(YCbCr.CrIndex));
                    break;
                case "更换Y通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage3 = host.GetImage(this, "Select an image which will replace the Y channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage3 != null)
                        ApplyFilter(new YCbCrReplaceChannel(YCbCr.YIndex, channelImage3));
                    break;
                case "更换Cb通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage4 = host.GetImage(this, "Select an image which will replace the Cb channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage4 != null)
                        ApplyFilter(new YCbCrReplaceChannel(YCbCr.CbIndex, channelImage4));
                    break;
                case "更换Cr通道":
                    if (image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                        MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Bitmap channelImage5 = host.GetImage(this, "Select an image which will replace the Cr channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

                    if (channelImage5 != null)
                        ApplyFilter(new YCbCrReplaceChannel(YCbCr.CrIndex, channelImage5));
                    break;
                case "图像阈值":
                    Threshold();
                    break;
                case "带错误进位的阈值":
                    ApplyFilter(new ThresholdWithCarry());
                    break;
                case "有序抖动":
                    ApplyFilter(new OrderedDithering());
                    break;
                case "bayer有序抖动":
                    ApplyFilter(new BayerDithering());
                    break;
                case "弗洛伊德斯坦伯格抖动":
                    ApplyFilter(new FloydSteinbergDithering());
                    break;
                case "伯克斯抖动":
                    ApplyFilter(new BurkesDithering());
                    break;
                case "stucki抖动":
                    ApplyFilter(new StuckiDithering());
                    break;
                case "jarvisJudiceNinke抖动":
                    ApplyFilter(new JarvisJudiceNinkeDithering());
                    break;
                case "sierra抖动":
                    ApplyFilter(new SierraDithering());
                    break;
                case "stevensonAndArce抖动":
                    ApplyFilter(new StevensonArceDithering());
                    break;
                case "SIS阈值":
                    ApplyFilter(new SISThreshold());
                    break;
                case "腐蚀":
                    ApplyFilter(new Erosion());
                    break;
                case "膨胀":
                    ApplyFilter(new Dilatation());
                    break;
                case "开运算":
                    ApplyFilter(new Opening());
                    break;
                case "闭运算":
                    ApplyFilter(new Closing());
                    break;
                case "custom":
                    Morphology();
                    break;
                case "hitAndMissTHickeningThinning":
                    if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                    {
                        MessageBox.Show("Hit & Miss morpholgy filters can by applied to binary image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MathMorphologyForm form8 = new MathMorphologyForm(MathMorphologyForm.FilterTypes.HitAndMiss);
                    form8.Image = image;

                    if (form8.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form8.Filter);
                    }
                    break;
                case "mean":
                    ApplyFilter(new Mean());
                    break;
                case "blur":
                    ApplyFilter(new Blur());
                    break;
                case "sharpen":
                    ApplyFilter(new Sharpen());
                    break;
                case "edges":
                    ApplyFilter(new Edges());
                    break;
                case "custom1":
                    Convolution();
                    break;
                case "gaussian":
                    GaussianForm form9 = new GaussianForm();

                    form9.Image = image;

                    if (form9.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form9.Filter);
                    }
                    break;
                case "sharpenEx":
                    SharpenExForm form10 = new SharpenExForm();

                    form10.Image = image;

                    if (form10.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form10.Filter);
                    }
                    break;
                case "merge":
                    Bitmap overlayImage = host.GetImage(this, "Select an image to merge with the curren image", new Size(-1, -1), image.PixelFormat);

                    if (overlayImage != null)
                        ApplyFilter(new Merge(overlayImage));
                    break;
                case "intersect":
                    Bitmap overlayImage1 = host.GetImage(this, "Select an image to intersect with the curren image", new Size(-1, -1), image.PixelFormat);

                    if (overlayImage1 != null)
                        ApplyFilter(new Intersect(overlayImage1));
                    break;
                case "add":
                    Bitmap overlayImage2 = host.GetImage(this, "Select an image to add to the curren image", new Size(-1, -1), image.PixelFormat);

                    if (overlayImage2 != null)
                        ApplyFilter(new Add(overlayImage2));
                    break;
                case "subtract":
                    Bitmap overlayImage3 = host.GetImage(this, "Select an image to subtract from the curren image", new Size(-1, -1), image.PixelFormat);

                    if (overlayImage3 != null)
                        ApplyFilter(new Subtract(overlayImage3));
                    break;
                case "difference":
                    Bitmap overlayImage4 = host.GetImage(this, "Select an image to get difference with the curren image", new Size(width, height), image.PixelFormat);

                    if (overlayImage4 != null)
                        ApplyFilter(new Difference(overlayImage4));
                    break;
                case "movetowards":
                    Bitmap overlayImage5 = host.GetImage(this, "Select an image to which the curren image will be moved", new Size(width, height), image.PixelFormat);

                    if (overlayImage5 != null)
                        ApplyFilter(new MoveTowards(overlayImage5, 10));
                    break;
                case "morph":
                    Bitmap overlayImage6 = host.GetImage(this, "Select an image to which the curren image will be morphed", new Size(width, height), image.PixelFormat);

                    if (overlayImage6 != null)
                    {
                        // show filter setting dialog
                        MorphForm form11 = new MorphForm(overlayImage6);

                        form11.Image = image;

                        // get filter settings
                        if (form11.ShowDialog() == DialogResult.OK)
                        {
                            ApplyFilter(form11.Filter);
                        }
                    }
                    break;
                case "homogenity":
                    ApplyFilter(new HomogenityEdgeDetector());
                    break;
                case "difference1":
                    ApplyFilter(new DifferenceEdgeDetector());
                    break;
                case "sobel":
                    ApplyFilter(new SobelEdgeDetector());
                    break;
                case "canny":
                    CannyDetectorForm form12 = new CannyDetectorForm();

                    form12.Image = image;

                    if (form12.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form12.Filter);
                    }
                    break;
                case "大小":
                    ResizeImage();
                    break;
                case "旋转":
                    RotateImage();
                    break;
                case "1":
                    AdaptiveSmoothForm form13 = new AdaptiveSmoothForm();

                    form13.Image = image;

                    if (form13.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form13.Filter);
                    }
                    break;
                case "2":
                    ApplyFilter(new ConservativeSmoothing());
                    break;
                case "3":
                    PerlinNoiseForm form14 = new PerlinNoiseForm();

                    form14.Image = image;

                    if (form14.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form14.Filter);
                    }
                    break;
                case "4":
                    OilPaintingForm form15 = new OilPaintingForm();

                    form15.Image = image;

                    if (form15.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form15.Filter);
                    }
                    break;
                case "5":
                    ApplyFilter(new Jitter(1));
                    break;
                case "6":
                    PixelateForm form16 = new PixelateForm();

                    form16.Image = image;

                    if (form16.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form16.Filter);
                    }
                    break;
                case "7":
                    ApplyFilter(new SimpleSkeletonization());
                    break;
                case "8":
                    ShrinkForm form17 = new ShrinkForm();

                    if (form17.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form17.Filter);
                    }
                    break;
                case "9":
                    if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                    {
                        MessageBox.Show("Connected components labeling can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    ApplyFilter(new ConnectedComponentsLabeling());
                    break;
                case "10":
                    if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                    {
                        MessageBox.Show("Blob extractor can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    BlobCounter blobCounter = new BlobCounter(image);
                    Blob[] blobs = blobCounter.GetObjects(image);

                    foreach (Blob blob in blobs)
                    {
                        host.NewDocument(blob.Image);
                    }
                    break;
                case "层次":
                    Levels();
                    break;
                case "中位数":
                    ApplyFilter(new Median());
                    break;
                case "伽玛校正":
                    GammaForm form18 = new GammaForm();

                    form18.Image = image;

                    if (form18.ShowDialog() == DialogResult.OK)
                    {
                        ApplyFilter(form18.Filter);
                    }
                    break;
                case "傅里叶变换":
                    ForwardFourierTransformation();
                    break;
                case "返回":
                    if (backup != null)
                    {
                        // release current image
                        image.Dispose();
                        // restore
                        image = backup;
                        backup = null;

                        // update
                        UpdateNewImage();
                    }
                    break;
                case "克隆":
                    Clone();
                    break;
                case "10%":
                    String t = "10%";
                    // parse it`s value
                    int i = int.Parse(t.Remove(t.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i / 100;

                    UpdateZoom();
                    break;
                case "25%":
                    String t1 = "25%";
                    // parse it`s value
                    int i1 = int.Parse(t1.Remove(t1.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i1 / 100;

                    UpdateZoom();
                    break;
                case "50%":
                    String t2 = "50%";
                    // parse it`s value
                    int i2 = int.Parse(t2.Remove(t2.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i2 / 100;

                    UpdateZoom();
                    break;
                case "75%":
                    String t3 = "75%";
                    // parse it`s value
                    int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i3 / 100;

                    UpdateZoom();
                    break;
                case "100%":
                    String t4 = "100%";
                    // parse it`s value
                    int i4 = int.Parse(t4.Remove(t4.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i4 / 100;

                    UpdateZoom();
                    break;
                case "150%":
                    String t5 = "150%";
                    // parse it`s value
                    int i5 = int.Parse(t5.Remove(t5.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i5 / 100;

                    UpdateZoom();
                    break;
                case "200%":
                    String t6 = "200%";
                    // parse it`s value
                    int i6 = int.Parse(t6.Remove(t6.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i6 / 100;

                    UpdateZoom();
                    break;
                case "400%":
                    String t7 = "400%";
                    // parse it`s value
                    int i7 = int.Parse(t7.Remove(t7.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i7 / 100;

                    UpdateZoom();
                    break;
                case "500%":
                    String t8 = "500%";
                    // parse it`s value
                    int i8 = int.Parse(t8.Remove(t8.Length - 1, 1));
                    // calc zoom factor
                    zoom = (float)i8 / 100;

                    UpdateZoom();
                    break;
                
                case "放大显示":
                    ZoomIn();
                    break;
                case "缩小显示":
                    ZoomOut();
                    break;
                case "适应屏幕":
                    FitToScreen();
                    break;
                case "垂直翻转":
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    Invalidate();
                    break;
                case "水平翻转":
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    Invalidate();
                    break;
                case "旋转90":
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // update
                    UpdateNewImage();
                    break;
                case "裁剪":
                    Crop();
                    break;
                case "返回1":
                    if (backup != null)
                    {
                        // release current image
                        image.Dispose();
                        // restore
                        image = backup;
                        backup = null;

                        // update
                        UpdateNewImage();
                    }
                    break;
                case "裁剪1":
                    Crop();
                    break;
                case "放大1":
                    zoom += (float)0.1;
                    UpdateZoom();
                    break;
                case "模糊1":
                    ApplyFilter(new Blur());
                    break;
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                if ( components != null )
                {
                    components.Dispose( );
                }
                if ( image != null )
                {
                    image.Dispose( );
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDoc));
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.克隆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.放大显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.适应屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.垂直翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.滤镜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度到RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.棕褐色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.反色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.滤色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.欧几里得颜色滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通道滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.提取红色通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取红色通道ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.提取红色通道ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.更换红色通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换红色通道ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.更换红色通道ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.红ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绿ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.蓝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.青色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.洋红色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.黄色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSL颜色空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.亮度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.对比度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.饱和度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.HSL线性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSL滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色调调节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr颜色空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr线性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.提取Y通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取Cb通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取Cr通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.更换Y通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换Cb通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换Cr通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二值化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.带错误进位的阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.有序抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bayer有序抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.伯克斯抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stucki抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisJudiceNinke抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierra抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stevensonAndArce抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.sIS阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.形态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.腐蚀ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.膨胀ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开运算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.闭运算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hitAndMissTHickeningThinningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.卷积相关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenExToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双源滤波器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intersectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTowardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.层次ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中位数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.伽玛校正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.傅里叶变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel18.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.SystemColors.Control;
            this.panel18.Controls.Add(this.panel1);
            this.panel18.Controls.Add(this.toolStrip1);
            this.panel18.Controls.Add(this.menuStrip1);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel18.Size = new System.Drawing.Size(556, 36);
            this.panel18.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(190, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 33);
            this.panel1.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(190, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(254, 30);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton1.Text = "大小";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(2, 2, 0, 3);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton2.Text = "旋转";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(2, 2, 0, 3);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton3.Text = "色阶";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(2, 2, 0, 3);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton4.Text = "撤销";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(2, 2, 0, 3);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton5.Text = "克隆";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像ToolStripMenuItem,
            this.滤镜ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 1, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(173, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 图像ToolStripMenuItem
            // 
            this.图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.返回ToolStripMenuItem,
            this.克隆ToolStripMenuItem,
            this.toolStripSeparator4,
            this.缩放ToolStripMenuItem,
            this.toolStripSeparator5,
            this.垂直翻转ToolStripMenuItem,
            this.水平翻转ToolStripMenuItem,
            this.旋转90ToolStripMenuItem,
            this.toolStripSeparator6,
            this.裁剪ToolStripMenuItem});
            this.图像ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.图像ToolStripMenuItem.Name = "图像ToolStripMenuItem";
            this.图像ToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.图像ToolStripMenuItem.Text = "图像[&I]";
            // 
            // 返回ToolStripMenuItem
            // 
            this.返回ToolStripMenuItem.Name = "返回ToolStripMenuItem";
            this.返回ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.返回ToolStripMenuItem.Text = "返回";
            this.返回ToolStripMenuItem.Click += new System.EventHandler(this.返回ToolStripMenuItem_Click);
            // 
            // 克隆ToolStripMenuItem
            // 
            this.克隆ToolStripMenuItem.Name = "克隆ToolStripMenuItem";
            this.克隆ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.克隆ToolStripMenuItem.Text = "克隆";
            this.克隆ToolStripMenuItem.Click += new System.EventHandler(this.克隆ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.放大显示ToolStripMenuItem,
            this.缩小显示ToolStripMenuItem,
            this.适应屏幕ToolStripMenuItem});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.缩放ToolStripMenuItem.Text = "缩放";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem12.Text = "10%";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem13.Text = "25%";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem14.Text = "50%";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem15.Text = "75%";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem16.Text = "100%";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem17.Text = "150%";
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem18.Text = "200%";
            this.toolStripMenuItem18.Click += new System.EventHandler(this.toolStripMenuItem18_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem19.Text = "400%";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem20.Text = "500%";
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
            // 
            // 放大显示ToolStripMenuItem
            // 
            this.放大显示ToolStripMenuItem.Name = "放大显示ToolStripMenuItem";
            this.放大显示ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.放大显示ToolStripMenuItem.Text = "放大显示";
            this.放大显示ToolStripMenuItem.Click += new System.EventHandler(this.放大显示ToolStripMenuItem_Click);
            // 
            // 缩小显示ToolStripMenuItem
            // 
            this.缩小显示ToolStripMenuItem.Name = "缩小显示ToolStripMenuItem";
            this.缩小显示ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.缩小显示ToolStripMenuItem.Text = "缩小显示";
            this.缩小显示ToolStripMenuItem.Click += new System.EventHandler(this.缩小显示ToolStripMenuItem_Click);
            // 
            // 适应屏幕ToolStripMenuItem
            // 
            this.适应屏幕ToolStripMenuItem.Name = "适应屏幕ToolStripMenuItem";
            this.适应屏幕ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.适应屏幕ToolStripMenuItem.Text = "适应屏幕";
            this.适应屏幕ToolStripMenuItem.Click += new System.EventHandler(this.适应屏幕ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(179, 6);
            // 
            // 垂直翻转ToolStripMenuItem
            // 
            this.垂直翻转ToolStripMenuItem.Name = "垂直翻转ToolStripMenuItem";
            this.垂直翻转ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.垂直翻转ToolStripMenuItem.Text = "垂直翻转";
            this.垂直翻转ToolStripMenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // 水平翻转ToolStripMenuItem
            // 
            this.水平翻转ToolStripMenuItem.Name = "水平翻转ToolStripMenuItem";
            this.水平翻转ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.水平翻转ToolStripMenuItem.Text = "水平翻转";
            this.水平翻转ToolStripMenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);
            // 
            // 旋转90ToolStripMenuItem
            // 
            this.旋转90ToolStripMenuItem.Name = "旋转90ToolStripMenuItem";
            this.旋转90ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.旋转90ToolStripMenuItem.Text = "旋转90°";
            this.旋转90ToolStripMenuItem.Click += new System.EventHandler(this.旋转90ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(179, 6);
            // 
            // 裁剪ToolStripMenuItem
            // 
            this.裁剪ToolStripMenuItem.Name = "裁剪ToolStripMenuItem";
            this.裁剪ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.裁剪ToolStripMenuItem.Text = "裁剪";
            this.裁剪ToolStripMenuItem.Click += new System.EventHandler(this.裁剪ToolStripMenuItem_Click);
            // 
            // 滤镜ToolStripMenuItem
            // 
            this.滤镜ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.颜色ToolStripMenuItem,
            this.hSL颜色空间ToolStripMenuItem,
            this.yCbCr颜色空间ToolStripMenuItem,
            this.二值化ToolStripMenuItem,
            this.形态ToolStripMenuItem,
            this.卷积相关ToolStripMenuItem,
            this.双源滤波器ToolStripMenuItem,
            this.边缘检测器ToolStripMenuItem,
            this.其他ToolStripMenuItem,
            this.toolStripSeparator1,
            this.大小ToolStripMenuItem,
            this.旋转ToolStripMenuItem,
            this.toolStripSeparator2,
            this.层次ToolStripMenuItem,
            this.中位数ToolStripMenuItem,
            this.伽玛校正ToolStripMenuItem,
            this.toolStripSeparator3,
            this.傅里叶变换ToolStripMenuItem});
            this.滤镜ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.滤镜ToolStripMenuItem.Name = "滤镜ToolStripMenuItem";
            this.滤镜ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.滤镜ToolStripMenuItem.Text = "滤镜[&T]";
            // 
            // 颜色ToolStripMenuItem
            // 
            this.颜色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.灰度ToolStripMenuItem,
            this.灰度到RGBToolStripMenuItem,
            this.toolStripSeparator7,
            this.棕褐色ToolStripMenuItem,
            this.toolStripSeparator8,
            this.反色ToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.toolStripSeparator9,
            this.滤色ToolStripMenuItem,
            this.欧几里得颜色滤波ToolStripMenuItem,
            this.通道滤波ToolStripMenuItem,
            this.toolStripSeparator10,
            this.提取红色通道ToolStripMenuItem,
            this.提取红色通道ToolStripMenuItem1,
            this.提取红色通道ToolStripMenuItem2,
            this.toolStripSeparator11,
            this.更换红色通道ToolStripMenuItem,
            this.更换红色通道ToolStripMenuItem1,
            this.更换红色通道ToolStripMenuItem2,
            this.toolStripSeparator12,
            this.红ToolStripMenuItem,
            this.绿ToolStripMenuItem,
            this.蓝ToolStripMenuItem,
            this.青色ToolStripMenuItem,
            this.洋红色ToolStripMenuItem,
            this.黄色ToolStripMenuItem});
            this.颜色ToolStripMenuItem.Name = "颜色ToolStripMenuItem";
            this.颜色ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.颜色ToolStripMenuItem.Text = "颜色";
            // 
            // 灰度ToolStripMenuItem
            // 
            this.灰度ToolStripMenuItem.Name = "灰度ToolStripMenuItem";
            this.灰度ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.灰度ToolStripMenuItem.Text = "灰度";
            this.灰度ToolStripMenuItem.Click += new System.EventHandler(this.灰度ToolStripMenuItem_Click);
            // 
            // 灰度到RGBToolStripMenuItem
            // 
            this.灰度到RGBToolStripMenuItem.Name = "灰度到RGBToolStripMenuItem";
            this.灰度到RGBToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.灰度到RGBToolStripMenuItem.Text = "灰度到RGB";
            this.灰度到RGBToolStripMenuItem.Click += new System.EventHandler(this.灰度到RGBToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(251, 6);
            // 
            // 棕褐色ToolStripMenuItem
            // 
            this.棕褐色ToolStripMenuItem.Name = "棕褐色ToolStripMenuItem";
            this.棕褐色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.棕褐色ToolStripMenuItem.Text = "棕褐色";
            this.棕褐色ToolStripMenuItem.Click += new System.EventHandler(this.棕褐色ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(251, 6);
            // 
            // 反色ToolStripMenuItem
            // 
            this.反色ToolStripMenuItem.Name = "反色ToolStripMenuItem";
            this.反色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.反色ToolStripMenuItem.Text = "反色";
            this.反色ToolStripMenuItem.Click += new System.EventHandler(this.反色ToolStripMenuItem_Click);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(251, 6);
            // 
            // 滤色ToolStripMenuItem
            // 
            this.滤色ToolStripMenuItem.Name = "滤色ToolStripMenuItem";
            this.滤色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.滤色ToolStripMenuItem.Text = "滤色";
            this.滤色ToolStripMenuItem.Click += new System.EventHandler(this.滤色ToolStripMenuItem_Click);
            // 
            // 欧几里得颜色滤波ToolStripMenuItem
            // 
            this.欧几里得颜色滤波ToolStripMenuItem.Name = "欧几里得颜色滤波ToolStripMenuItem";
            this.欧几里得颜色滤波ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.欧几里得颜色滤波ToolStripMenuItem.Text = "欧几里得颜色滤波";
            this.欧几里得颜色滤波ToolStripMenuItem.Click += new System.EventHandler(this.欧几里得颜色滤波ToolStripMenuItem_Click);
            // 
            // 通道滤波ToolStripMenuItem
            // 
            this.通道滤波ToolStripMenuItem.Name = "通道滤波ToolStripMenuItem";
            this.通道滤波ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.通道滤波ToolStripMenuItem.Text = "通道滤波";
            this.通道滤波ToolStripMenuItem.Click += new System.EventHandler(this.通道滤波ToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(251, 6);
            // 
            // 提取红色通道ToolStripMenuItem
            // 
            this.提取红色通道ToolStripMenuItem.Name = "提取红色通道ToolStripMenuItem";
            this.提取红色通道ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.提取红色通道ToolStripMenuItem.Text = "提取红色通道";
            this.提取红色通道ToolStripMenuItem.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem_Click);
            // 
            // 提取红色通道ToolStripMenuItem1
            // 
            this.提取红色通道ToolStripMenuItem1.Name = "提取红色通道ToolStripMenuItem1";
            this.提取红色通道ToolStripMenuItem1.Size = new System.Drawing.Size(254, 34);
            this.提取红色通道ToolStripMenuItem1.Text = "提取绿色通道";
            this.提取红色通道ToolStripMenuItem1.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem1_Click);
            // 
            // 提取红色通道ToolStripMenuItem2
            // 
            this.提取红色通道ToolStripMenuItem2.Name = "提取红色通道ToolStripMenuItem2";
            this.提取红色通道ToolStripMenuItem2.Size = new System.Drawing.Size(254, 34);
            this.提取红色通道ToolStripMenuItem2.Text = "提取蓝色通道";
            this.提取红色通道ToolStripMenuItem2.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(251, 6);
            // 
            // 更换红色通道ToolStripMenuItem
            // 
            this.更换红色通道ToolStripMenuItem.Name = "更换红色通道ToolStripMenuItem";
            this.更换红色通道ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.更换红色通道ToolStripMenuItem.Text = "更换红色通道";
            this.更换红色通道ToolStripMenuItem.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem_Click);
            // 
            // 更换红色通道ToolStripMenuItem1
            // 
            this.更换红色通道ToolStripMenuItem1.Name = "更换红色通道ToolStripMenuItem1";
            this.更换红色通道ToolStripMenuItem1.Size = new System.Drawing.Size(254, 34);
            this.更换红色通道ToolStripMenuItem1.Text = "更换绿色通道";
            this.更换红色通道ToolStripMenuItem1.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem1_Click);
            // 
            // 更换红色通道ToolStripMenuItem2
            // 
            this.更换红色通道ToolStripMenuItem2.Name = "更换红色通道ToolStripMenuItem2";
            this.更换红色通道ToolStripMenuItem2.Size = new System.Drawing.Size(254, 34);
            this.更换红色通道ToolStripMenuItem2.Text = "更换蓝色通道";
            this.更换红色通道ToolStripMenuItem2.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(251, 6);
            // 
            // 红ToolStripMenuItem
            // 
            this.红ToolStripMenuItem.Name = "红ToolStripMenuItem";
            this.红ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.红ToolStripMenuItem.Text = "红色";
            this.红ToolStripMenuItem.Click += new System.EventHandler(this.红ToolStripMenuItem_Click);
            // 
            // 绿ToolStripMenuItem
            // 
            this.绿ToolStripMenuItem.Name = "绿ToolStripMenuItem";
            this.绿ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.绿ToolStripMenuItem.Text = "绿色";
            this.绿ToolStripMenuItem.Click += new System.EventHandler(this.绿ToolStripMenuItem_Click);
            // 
            // 蓝ToolStripMenuItem
            // 
            this.蓝ToolStripMenuItem.Name = "蓝ToolStripMenuItem";
            this.蓝ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.蓝ToolStripMenuItem.Text = "蓝色";
            this.蓝ToolStripMenuItem.Click += new System.EventHandler(this.蓝ToolStripMenuItem_Click);
            // 
            // 青色ToolStripMenuItem
            // 
            this.青色ToolStripMenuItem.Name = "青色ToolStripMenuItem";
            this.青色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.青色ToolStripMenuItem.Text = "青色";
            this.青色ToolStripMenuItem.Click += new System.EventHandler(this.青色ToolStripMenuItem_Click);
            // 
            // 洋红色ToolStripMenuItem
            // 
            this.洋红色ToolStripMenuItem.Name = "洋红色ToolStripMenuItem";
            this.洋红色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.洋红色ToolStripMenuItem.Text = "洋红色";
            this.洋红色ToolStripMenuItem.Click += new System.EventHandler(this.洋红色ToolStripMenuItem_Click);
            // 
            // 黄色ToolStripMenuItem
            // 
            this.黄色ToolStripMenuItem.Name = "黄色ToolStripMenuItem";
            this.黄色ToolStripMenuItem.Size = new System.Drawing.Size(254, 34);
            this.黄色ToolStripMenuItem.Text = "黄色";
            this.黄色ToolStripMenuItem.Click += new System.EventHandler(this.黄色ToolStripMenuItem_Click);
            // 
            // hSL颜色空间ToolStripMenuItem
            // 
            this.hSL颜色空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.亮度ToolStripMenuItem,
            this.对比度ToolStripMenuItem,
            this.饱和度ToolStripMenuItem,
            this.toolStripSeparator13,
            this.HSL线性ToolStripMenuItem,
            this.hSL滤波ToolStripMenuItem,
            this.色调调节ToolStripMenuItem});
            this.hSL颜色空间ToolStripMenuItem.Name = "hSL颜色空间ToolStripMenuItem";
            this.hSL颜色空间ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.hSL颜色空间ToolStripMenuItem.Text = "HSL颜色空间";
            // 
            // 亮度ToolStripMenuItem
            // 
            this.亮度ToolStripMenuItem.Name = "亮度ToolStripMenuItem";
            this.亮度ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.亮度ToolStripMenuItem.Text = "亮度";
            this.亮度ToolStripMenuItem.Click += new System.EventHandler(this.亮度ToolStripMenuItem_Click);
            // 
            // 对比度ToolStripMenuItem
            // 
            this.对比度ToolStripMenuItem.Name = "对比度ToolStripMenuItem";
            this.对比度ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.对比度ToolStripMenuItem.Text = "对比度";
            this.对比度ToolStripMenuItem.Click += new System.EventHandler(this.对比度ToolStripMenuItem_Click);
            // 
            // 饱和度ToolStripMenuItem
            // 
            this.饱和度ToolStripMenuItem.Name = "饱和度ToolStripMenuItem";
            this.饱和度ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.饱和度ToolStripMenuItem.Text = "饱和度";
            this.饱和度ToolStripMenuItem.Click += new System.EventHandler(this.饱和度ToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(179, 6);
            // 
            // HSL线性ToolStripMenuItem
            // 
            this.HSL线性ToolStripMenuItem.Name = "HSL线性ToolStripMenuItem";
            this.HSL线性ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.HSL线性ToolStripMenuItem.Text = "HSL线性";
            this.HSL线性ToolStripMenuItem.Click += new System.EventHandler(this.HSL线性ToolStripMenuItem_Click);
            // 
            // hSL滤波ToolStripMenuItem
            // 
            this.hSL滤波ToolStripMenuItem.Name = "hSL滤波ToolStripMenuItem";
            this.hSL滤波ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.hSL滤波ToolStripMenuItem.Text = "HSL滤波";
            this.hSL滤波ToolStripMenuItem.Click += new System.EventHandler(this.hSL滤波ToolStripMenuItem_Click);
            // 
            // 色调调节ToolStripMenuItem
            // 
            this.色调调节ToolStripMenuItem.Name = "色调调节ToolStripMenuItem";
            this.色调调节ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.色调调节ToolStripMenuItem.Text = "色调调节";
            this.色调调节ToolStripMenuItem.Click += new System.EventHandler(this.色调调节ToolStripMenuItem_Click);
            // 
            // yCbCr颜色空间ToolStripMenuItem
            // 
            this.yCbCr颜色空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yCbCr线性ToolStripMenuItem,
            this.yCbCr滤波ToolStripMenuItem,
            this.toolStripSeparator14,
            this.提取Y通道ToolStripMenuItem,
            this.提取Cb通道ToolStripMenuItem,
            this.提取Cr通道ToolStripMenuItem,
            this.toolStripSeparator15,
            this.更换Y通道ToolStripMenuItem,
            this.更换Cb通道ToolStripMenuItem,
            this.更换Cr通道ToolStripMenuItem});
            this.yCbCr颜色空间ToolStripMenuItem.Name = "yCbCr颜色空间ToolStripMenuItem";
            this.yCbCr颜色空间ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.yCbCr颜色空间ToolStripMenuItem.Text = "YCbCr颜色空间";
            // 
            // yCbCr线性ToolStripMenuItem
            // 
            this.yCbCr线性ToolStripMenuItem.Name = "yCbCr线性ToolStripMenuItem";
            this.yCbCr线性ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.yCbCr线性ToolStripMenuItem.Text = "YCbCr线性";
            this.yCbCr线性ToolStripMenuItem.Click += new System.EventHandler(this.yCbCr线性ToolStripMenuItem_Click);
            // 
            // yCbCr滤波ToolStripMenuItem
            // 
            this.yCbCr滤波ToolStripMenuItem.Name = "yCbCr滤波ToolStripMenuItem";
            this.yCbCr滤波ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.yCbCr滤波ToolStripMenuItem.Text = "YCbCr滤波";
            this.yCbCr滤波ToolStripMenuItem.Click += new System.EventHandler(this.yCbCr滤波ToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(203, 6);
            // 
            // 提取Y通道ToolStripMenuItem
            // 
            this.提取Y通道ToolStripMenuItem.Name = "提取Y通道ToolStripMenuItem";
            this.提取Y通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.提取Y通道ToolStripMenuItem.Text = "提取Y通道";
            this.提取Y通道ToolStripMenuItem.Click += new System.EventHandler(this.提取Y通道ToolStripMenuItem_Click);
            // 
            // 提取Cb通道ToolStripMenuItem
            // 
            this.提取Cb通道ToolStripMenuItem.Name = "提取Cb通道ToolStripMenuItem";
            this.提取Cb通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.提取Cb通道ToolStripMenuItem.Text = "提取Cb通道";
            this.提取Cb通道ToolStripMenuItem.Click += new System.EventHandler(this.提取Cb通道ToolStripMenuItem_Click);
            // 
            // 提取Cr通道ToolStripMenuItem
            // 
            this.提取Cr通道ToolStripMenuItem.Name = "提取Cr通道ToolStripMenuItem";
            this.提取Cr通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.提取Cr通道ToolStripMenuItem.Text = "提取Cr通道";
            this.提取Cr通道ToolStripMenuItem.Click += new System.EventHandler(this.提取Cr通道ToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(203, 6);
            // 
            // 更换Y通道ToolStripMenuItem
            // 
            this.更换Y通道ToolStripMenuItem.Name = "更换Y通道ToolStripMenuItem";
            this.更换Y通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.更换Y通道ToolStripMenuItem.Text = "更换Y通道";
            this.更换Y通道ToolStripMenuItem.Click += new System.EventHandler(this.更换Y通道ToolStripMenuItem_Click);
            // 
            // 更换Cb通道ToolStripMenuItem
            // 
            this.更换Cb通道ToolStripMenuItem.Name = "更换Cb通道ToolStripMenuItem";
            this.更换Cb通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.更换Cb通道ToolStripMenuItem.Text = "更换Cb通道";
            this.更换Cb通道ToolStripMenuItem.Click += new System.EventHandler(this.更换Cb通道ToolStripMenuItem_Click);
            // 
            // 更换Cr通道ToolStripMenuItem
            // 
            this.更换Cr通道ToolStripMenuItem.Name = "更换Cr通道ToolStripMenuItem";
            this.更换Cr通道ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.更换Cr通道ToolStripMenuItem.Text = "更换Cr通道";
            this.更换Cr通道ToolStripMenuItem.Click += new System.EventHandler(this.更换Cr通道ToolStripMenuItem_Click);
            // 
            // 二值化ToolStripMenuItem
            // 
            this.二值化ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像阈值ToolStripMenuItem,
            this.toolStripSeparator16,
            this.带错误进位的阈值ToolStripMenuItem,
            this.有序抖动ToolStripMenuItem,
            this.bayer有序抖动ToolStripMenuItem,
            this.toolStripSeparator17,
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem,
            this.伯克斯抖动ToolStripMenuItem,
            this.stucki抖动ToolStripMenuItem,
            this.jarvisJudiceNinke抖动ToolStripMenuItem,
            this.sierra抖动ToolStripMenuItem,
            this.stevensonAndArce抖动ToolStripMenuItem,
            this.toolStripSeparator18,
            this.sIS阈值ToolStripMenuItem});
            this.二值化ToolStripMenuItem.Name = "二值化ToolStripMenuItem";
            this.二值化ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.二值化ToolStripMenuItem.Text = "二值化";
            // 
            // 图像阈值ToolStripMenuItem
            // 
            this.图像阈值ToolStripMenuItem.Name = "图像阈值ToolStripMenuItem";
            this.图像阈值ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.图像阈值ToolStripMenuItem.Text = "图像阈值";
            this.图像阈值ToolStripMenuItem.Click += new System.EventHandler(this.图像阈值ToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(312, 6);
            // 
            // 带错误进位的阈值ToolStripMenuItem
            // 
            this.带错误进位的阈值ToolStripMenuItem.Name = "带错误进位的阈值ToolStripMenuItem";
            this.带错误进位的阈值ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.带错误进位的阈值ToolStripMenuItem.Text = "带错误进位的阈值";
            this.带错误进位的阈值ToolStripMenuItem.Click += new System.EventHandler(this.带错误进位的阈值ToolStripMenuItem_Click);
            // 
            // 有序抖动ToolStripMenuItem
            // 
            this.有序抖动ToolStripMenuItem.Name = "有序抖动ToolStripMenuItem";
            this.有序抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.有序抖动ToolStripMenuItem.Text = "有序抖动";
            this.有序抖动ToolStripMenuItem.Click += new System.EventHandler(this.有序抖动ToolStripMenuItem_Click);
            // 
            // bayer有序抖动ToolStripMenuItem
            // 
            this.bayer有序抖动ToolStripMenuItem.Name = "bayer有序抖动ToolStripMenuItem";
            this.bayer有序抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.bayer有序抖动ToolStripMenuItem.Text = "Bayer有序抖动";
            this.bayer有序抖动ToolStripMenuItem.Click += new System.EventHandler(this.bayer有序抖动ToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(312, 6);
            // 
            // 弗洛伊德斯坦伯格抖动ToolStripMenuItem
            // 
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem.Name = "弗洛伊德斯坦伯格抖动ToolStripMenuItem";
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem.Text = "弗洛伊德-斯坦伯格抖动";
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem.Click += new System.EventHandler(this.弗洛伊德斯坦伯格抖动ToolStripMenuItem_Click);
            // 
            // 伯克斯抖动ToolStripMenuItem
            // 
            this.伯克斯抖动ToolStripMenuItem.Name = "伯克斯抖动ToolStripMenuItem";
            this.伯克斯抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.伯克斯抖动ToolStripMenuItem.Text = "伯克斯抖动";
            this.伯克斯抖动ToolStripMenuItem.Click += new System.EventHandler(this.伯克斯抖动ToolStripMenuItem_Click);
            // 
            // stucki抖动ToolStripMenuItem
            // 
            this.stucki抖动ToolStripMenuItem.Name = "stucki抖动ToolStripMenuItem";
            this.stucki抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.stucki抖动ToolStripMenuItem.Text = "Stucki抖动";
            this.stucki抖动ToolStripMenuItem.Click += new System.EventHandler(this.stucki抖动ToolStripMenuItem_Click);
            // 
            // jarvisJudiceNinke抖动ToolStripMenuItem
            // 
            this.jarvisJudiceNinke抖动ToolStripMenuItem.Name = "jarvisJudiceNinke抖动ToolStripMenuItem";
            this.jarvisJudiceNinke抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.jarvisJudiceNinke抖动ToolStripMenuItem.Text = "Jarvis-Judice-Ninke抖动";
            this.jarvisJudiceNinke抖动ToolStripMenuItem.Click += new System.EventHandler(this.jarvisJudiceNinke抖动ToolStripMenuItem_Click);
            // 
            // sierra抖动ToolStripMenuItem
            // 
            this.sierra抖动ToolStripMenuItem.Name = "sierra抖动ToolStripMenuItem";
            this.sierra抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.sierra抖动ToolStripMenuItem.Text = "Sierra抖动";
            this.sierra抖动ToolStripMenuItem.Click += new System.EventHandler(this.sierra抖动ToolStripMenuItem_Click);
            // 
            // stevensonAndArce抖动ToolStripMenuItem
            // 
            this.stevensonAndArce抖动ToolStripMenuItem.Name = "stevensonAndArce抖动ToolStripMenuItem";
            this.stevensonAndArce抖动ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.stevensonAndArce抖动ToolStripMenuItem.Text = "Stevenson and Arce抖动";
            this.stevensonAndArce抖动ToolStripMenuItem.Click += new System.EventHandler(this.stevensonAndArce抖动ToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(312, 6);
            // 
            // sIS阈值ToolStripMenuItem
            // 
            this.sIS阈值ToolStripMenuItem.Name = "sIS阈值ToolStripMenuItem";
            this.sIS阈值ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.sIS阈值ToolStripMenuItem.Text = "SIS阈值";
            this.sIS阈值ToolStripMenuItem.Click += new System.EventHandler(this.sIS阈值ToolStripMenuItem_Click);
            // 
            // 形态ToolStripMenuItem
            // 
            this.形态ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.腐蚀ToolStripMenuItem,
            this.膨胀ToolStripMenuItem,
            this.开运算ToolStripMenuItem,
            this.闭运算ToolStripMenuItem,
            this.customToolStripMenuItem,
            this.hitAndMissTHickeningThinningToolStripMenuItem});
            this.形态ToolStripMenuItem.Name = "形态ToolStripMenuItem";
            this.形态ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.形态ToolStripMenuItem.Text = "形态";
            // 
            // 腐蚀ToolStripMenuItem
            // 
            this.腐蚀ToolStripMenuItem.Name = "腐蚀ToolStripMenuItem";
            this.腐蚀ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.腐蚀ToolStripMenuItem.Text = "腐蚀";
            this.腐蚀ToolStripMenuItem.Click += new System.EventHandler(this.腐蚀ToolStripMenuItem_Click);
            // 
            // 膨胀ToolStripMenuItem
            // 
            this.膨胀ToolStripMenuItem.Name = "膨胀ToolStripMenuItem";
            this.膨胀ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.膨胀ToolStripMenuItem.Text = "膨胀";
            this.膨胀ToolStripMenuItem.Click += new System.EventHandler(this.膨胀ToolStripMenuItem_Click);
            // 
            // 开运算ToolStripMenuItem
            // 
            this.开运算ToolStripMenuItem.Name = "开运算ToolStripMenuItem";
            this.开运算ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.开运算ToolStripMenuItem.Text = "开运算";
            this.开运算ToolStripMenuItem.Click += new System.EventHandler(this.开运算ToolStripMenuItem_Click);
            // 
            // 闭运算ToolStripMenuItem
            // 
            this.闭运算ToolStripMenuItem.Name = "闭运算ToolStripMenuItem";
            this.闭运算ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.闭运算ToolStripMenuItem.Text = "闭运算";
            this.闭运算ToolStripMenuItem.Click += new System.EventHandler(this.闭运算ToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // hitAndMissTHickeningThinningToolStripMenuItem
            // 
            this.hitAndMissTHickeningThinningToolStripMenuItem.Name = "hitAndMissTHickeningThinningToolStripMenuItem";
            this.hitAndMissTHickeningThinningToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.hitAndMissTHickeningThinningToolStripMenuItem.Text = "Hit And Miss, THickening, Thinning";
            this.hitAndMissTHickeningThinningToolStripMenuItem.Click += new System.EventHandler(this.hitAndMissTHickeningThinningToolStripMenuItem_Click);
            // 
            // 卷积相关ToolStripMenuItem
            // 
            this.卷积相关ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.edgesToolStripMenuItem,
            this.customToolStripMenuItem1,
            this.gaussianToolStripMenuItem,
            this.sharpenExToolStripMenuItem});
            this.卷积相关ToolStripMenuItem.Name = "卷积相关ToolStripMenuItem";
            this.卷积相关ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.卷积相关ToolStripMenuItem.Text = "卷积&&相关";
            // 
            // meanToolStripMenuItem
            // 
            this.meanToolStripMenuItem.Name = "meanToolStripMenuItem";
            this.meanToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.meanToolStripMenuItem.Text = "中值";
            this.meanToolStripMenuItem.Click += new System.EventHandler(this.meanToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.blurToolStripMenuItem.Text = "模糊";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.sharpenToolStripMenuItem.Text = "锐化";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // edgesToolStripMenuItem
            // 
            this.edgesToolStripMenuItem.Name = "edgesToolStripMenuItem";
            this.edgesToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.edgesToolStripMenuItem.Text = "边缘";
            this.edgesToolStripMenuItem.Click += new System.EventHandler(this.edgesToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem1
            // 
            this.customToolStripMenuItem1.Name = "customToolStripMenuItem1";
            this.customToolStripMenuItem1.Size = new System.Drawing.Size(182, 34);
            this.customToolStripMenuItem1.Text = "Custom";
            this.customToolStripMenuItem1.Click += new System.EventHandler(this.customToolStripMenuItem1_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.gaussianToolStripMenuItem.Text = "高斯模糊";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // sharpenExToolStripMenuItem
            // 
            this.sharpenExToolStripMenuItem.Name = "sharpenExToolStripMenuItem";
            this.sharpenExToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.sharpenExToolStripMenuItem.Text = "锐化前";
            this.sharpenExToolStripMenuItem.Click += new System.EventHandler(this.sharpenExToolStripMenuItem_Click);
            // 
            // 双源滤波器ToolStripMenuItem
            // 
            this.双源滤波器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeToolStripMenuItem,
            this.intersectToolStripMenuItem,
            this.addToolStripMenuItem,
            this.subtractToolStripMenuItem,
            this.differenceToolStripMenuItem,
            this.moveTowardsToolStripMenuItem,
            this.morphToolStripMenuItem});
            this.双源滤波器ToolStripMenuItem.Name = "双源滤波器ToolStripMenuItem";
            this.双源滤波器ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.双源滤波器ToolStripMenuItem.Text = "双源滤波器";
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.mergeToolStripMenuItem.Text = "合并";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
            // 
            // intersectToolStripMenuItem
            // 
            this.intersectToolStripMenuItem.Name = "intersectToolStripMenuItem";
            this.intersectToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.intersectToolStripMenuItem.Text = "相交";
            this.intersectToolStripMenuItem.Click += new System.EventHandler(this.intersectToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.addToolStripMenuItem.Text = "相加";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // subtractToolStripMenuItem
            // 
            this.subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            this.subtractToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.subtractToolStripMenuItem.Text = "相减";
            this.subtractToolStripMenuItem.Click += new System.EventHandler(this.subtractToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // moveTowardsToolStripMenuItem
            // 
            this.moveTowardsToolStripMenuItem.Name = "moveTowardsToolStripMenuItem";
            this.moveTowardsToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.moveTowardsToolStripMenuItem.Text = "Move Towards";
            this.moveTowardsToolStripMenuItem.Click += new System.EventHandler(this.moveTowardsToolStripMenuItem_Click);
            // 
            // morphToolStripMenuItem
            // 
            this.morphToolStripMenuItem.Name = "morphToolStripMenuItem";
            this.morphToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.morphToolStripMenuItem.Text = "Morph";
            this.morphToolStripMenuItem.Click += new System.EventHandler(this.morphToolStripMenuItem_Click);
            // 
            // 边缘检测器ToolStripMenuItem
            // 
            this.边缘检测器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homogenityToolStripMenuItem,
            this.differenceToolStripMenuItem1,
            this.sobelToolStripMenuItem,
            this.cannyToolStripMenuItem});
            this.边缘检测器ToolStripMenuItem.Name = "边缘检测器ToolStripMenuItem";
            this.边缘检测器ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.边缘检测器ToolStripMenuItem.Text = "边缘检测器";
            // 
            // homogenityToolStripMenuItem
            // 
            this.homogenityToolStripMenuItem.Name = "homogenityToolStripMenuItem";
            this.homogenityToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.homogenityToolStripMenuItem.Text = "Homogenity";
            this.homogenityToolStripMenuItem.Click += new System.EventHandler(this.homogenityToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem1
            // 
            this.differenceToolStripMenuItem1.Name = "differenceToolStripMenuItem1";
            this.differenceToolStripMenuItem1.Size = new System.Drawing.Size(218, 34);
            this.differenceToolStripMenuItem1.Text = "Difference";
            this.differenceToolStripMenuItem1.Click += new System.EventHandler(this.differenceToolStripMenuItem1_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.cannyToolStripMenuItem.Text = "Canny";
            this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem2.Text = "自适应平滑";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem3.Text = "保守平滑";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem4.Text = "柏林噪声";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem5.Text = "油画";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem6.Text = "抖动";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem7.Text = "像素化";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem8.Text = "简单骨质化";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem9.Text = "皱缩";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem10.Text = "连通区域标记";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem11.Text = "斑点提取";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(233, 6);
            // 
            // 大小ToolStripMenuItem
            // 
            this.大小ToolStripMenuItem.Name = "大小ToolStripMenuItem";
            this.大小ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.大小ToolStripMenuItem.Text = "大小";
            this.大小ToolStripMenuItem.Click += new System.EventHandler(this.大小ToolStripMenuItem_Click);
            // 
            // 旋转ToolStripMenuItem
            // 
            this.旋转ToolStripMenuItem.Name = "旋转ToolStripMenuItem";
            this.旋转ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.旋转ToolStripMenuItem.Text = "旋转";
            this.旋转ToolStripMenuItem.Click += new System.EventHandler(this.旋转ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(233, 6);
            // 
            // 层次ToolStripMenuItem
            // 
            this.层次ToolStripMenuItem.Name = "层次ToolStripMenuItem";
            this.层次ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.层次ToolStripMenuItem.Text = "色阶";
            this.层次ToolStripMenuItem.Click += new System.EventHandler(this.层次ToolStripMenuItem_Click);
            // 
            // 中位数ToolStripMenuItem
            // 
            this.中位数ToolStripMenuItem.Name = "中位数ToolStripMenuItem";
            this.中位数ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.中位数ToolStripMenuItem.Text = "中位数";
            this.中位数ToolStripMenuItem.Click += new System.EventHandler(this.中位数ToolStripMenuItem_Click);
            // 
            // 伽玛校正ToolStripMenuItem
            // 
            this.伽玛校正ToolStripMenuItem.Name = "伽玛校正ToolStripMenuItem";
            this.伽玛校正ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.伽玛校正ToolStripMenuItem.Text = "伽玛校正";
            this.伽玛校正ToolStripMenuItem.Click += new System.EventHandler(this.伽玛校正ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(233, 6);
            // 
            // 傅里叶变换ToolStripMenuItem
            // 
            this.傅里叶变换ToolStripMenuItem.Name = "傅里叶变换ToolStripMenuItem";
            this.傅里叶变换ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.傅里叶变换ToolStripMenuItem.Text = "傅里叶变换";
            this.傅里叶变换ToolStripMenuItem.Click += new System.EventHandler(this.傅里叶变换ToolStripMenuItem_Click);
            // 
            // ImageDoc
            // 
            this.AllowedStates = WeifenLuo.WinFormsUI.ContentStates.Document;
            this.AutoScaleBaseSize = new System.Drawing.Size(10, 21);
            this.ClientSize = new System.Drawing.Size(556, 1440);
            this.Controls.Add(this.panel18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageDoc";
            this.Text = "Image";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseDown);
            this.MouseLeave += new System.EventHandler(this.ImageDoc_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageDoc_MouseUp);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Init the document
        private void Init( )
        {
            // init components
            InitializeComponent( );

            // form style
            SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true );

            // init scroll bars
            this.AutoScroll = true;

            UpdateSize( );
        }

        // Execute command
        public void ExecuteCommand( ImageDocCommands cmd )
        {
            switch ( cmd )
            {
                case ImageDocCommands.Clone:		// clone the image
                    Clone( );
                    break;
                case ImageDocCommands.Crop:			// crop the image
                    Crop( );
                    break;
                case ImageDocCommands.ZoomIn:		// zoom in
                    ZoomIn( );
                    break;
                case ImageDocCommands.ZoomOut:		// zoom out
                    ZoomOut( );
                    break;
                case ImageDocCommands.ZoomOriginal:	// original size
                    zoom = 1;
                    UpdateZoom( );
                    break;
                case ImageDocCommands.FitToSize:	// fit to screen
                    FitToScreen( );
                    break;
                case ImageDocCommands.Levels:		// levels
                    Levels( );
                    break;
                case ImageDocCommands.Grayscale:	// grayscale
                    Grayscale( );
                    break;
                case ImageDocCommands.Threshold:	// threshold
                    Threshold( );
                    break;
                case ImageDocCommands.Morphology:	// morphology
                    Morphology( );
                    break;
                case ImageDocCommands.Convolution:	// convolution
                    Convolution( );
                    break;
                case ImageDocCommands.Resize:		// resize the image
                    ResizeImage( );
                    break;
                case ImageDocCommands.Rotate:		// rotate the image
                    RotateImage( );
                    break;
                case ImageDocCommands.Brightness:	// adjust brightness
                    Brightness( );
                    break;
                case ImageDocCommands.Contrast:		// modify contrast
                    Contrast( );
                    break;
                case ImageDocCommands.Saturation:	// adjust saturation
                    Saturation( );
                    break;
                case ImageDocCommands.Fourier:		// fourier transformation
                    ForwardFourierTransformation( );
                    break;
            }
        }

        // Update document and notify client about changes
        private void UpdateNewImage( )
        {
            // update size
            UpdateSize( );
            // repaint
            Invalidate( );

            // notify host
            if ( DocumentChanged != null )
                DocumentChanged( this, null );
        }

        // Reload image from file
        public void Reload( )
        {
            if ( fileName != null )
            {
                try
                {
                    // load image
                    Bitmap newImage = (Bitmap) Bitmap.FromFile( fileName );

                    // Release current image
                    image.Dispose( );
                    // set document image to just loaded
                    image = newImage;

                    // format image
                    AForge.Imaging.Image.FormatImage( ref image );
                }
                catch ( Exception )
                {
                    throw new ApplicationException( "Failed reloading image" );
                }

                // update
                UpdateNewImage( );
            }
        }

        // Center image in the document
        public void Center( )
        {
            Rectangle rc = ClientRectangle;
            Point p = this.AutoScrollPosition;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );

            if ( rc.Width < width )
                p.X = ( width - rc.Width ) >> 1;
            if ( rc.Height < height )
                p.Y = ( height - rc.Height ) >> 1;

            this.AutoScrollPosition = p;
        }

        // Update document size 
        private void UpdateSize( )
        {
            // image dimension
            width = image.Width;
            height = image.Height;

            // scroll bar size
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
        }

        // Paint image
        protected override void OnPaint( PaintEventArgs e )
        {
            if ( image != null )
            {
                Graphics g = e.Graphics;
                Rectangle rc = ClientRectangle;
                Pen pen = new Pen( Color.FromArgb( 0, 0, 0 ) );

                int width = (int) ( this.width * zoom );
                int height = (int) ( this.height * zoom );
                int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                // draw rectangle around the image
                g.DrawRectangle( pen, x - 1, y - 1, width + 1, height + 1 );

                // set nearest neighbor interpolation to avoid image smoothing
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                // draw image
                g.DrawImage( image, x, y, width, height );

                pen.Dispose( );
            }
        }

        // Mouse click
        protected override void OnClick( EventArgs e )
        {
            Focus( );
        }

        // Apply filter on the image
        public void ApplyFilter( IFilter filter )
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply( image );

                if ( host.CreateNewDocumentOnChange )
                {
                    // open new image in new document
                    host.NewDocument( newImage );
                }
                else
                {
                    if ( host.RememberOnChange )
                    {
                        // backup current image
                        if ( backup != null )
                            backup.Dispose( );

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose( );
                    }

                    image = newImage;

                    // update
                    UpdateNewImage( );
                }
            }
            catch ( ArgumentException )
            {
                MessageBox.Show( "Selected filter can not be applied to the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }
        public void ApplyFilter1(IFilter filter)
        {
            try
            {
                // set wait cursor
                this.Cursor = Cursors.WaitCursor;

                // apply filter to the image
                Bitmap newImage = filter.Apply(image);

                if (host.CreateNewDocumentOnChange)
                {
                    // open new image in new document
                    host.NewDocument(newImage);
                }
                else
                {
                    if (host.RememberOnChange)
                    {
                        // backup current image
                        if (backup != null)
                            backup.Dispose();

                        backup = image;
                    }
                    else
                    {
                        // release current image
                        image.Dispose();
                    }

                    image = newImage;

                    // update
                    UpdateNewImage();
                }
            }
            catch (ArgumentException)
            {
                
            }
            finally
            {
                // restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        // on "Image" item popup
        private void imageItem_Popup( object sender, System.EventArgs e )
        {
            //this.backImageItem.Enabled = ( backup != null );
            //this.cropImageItem.Checked = cropping;
        }

        // Restore image to previous
        private void backImageItem_Click( object sender, System.EventArgs e )
        {
            if ( backup != null )
            {
                // release current image
                image.Dispose( );
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage( );
            }
        }

        // Clone the image
        private void Clone( )
        {
            if ( host != null )
            {
                Bitmap clone = AForge.Imaging.Image.Clone( image );

                if ( !host.NewDocument( clone ) )
                {
                    clone.Dispose( );
                }
            }
        }

        // On "Image->Clone" item click
        private void cloneImageItem_Click( object sender, System.EventArgs e )
        {
            Clone( );
        }

        // Update zoom factor
        public void UpdateZoom( )
        {
            this.AutoScrollMinSize = new Size( (int) ( width * zoom ), (int) ( height * zoom ) );
            this.Invalidate( );

            // notify host
            if ( ZoomChanged != null )
                ZoomChanged( this, null );
        }

        // Zoom image
        private void zoomItem_Click( object sender, System.EventArgs e )
        {
            // get menu item text
            String t = ( (MenuItem) sender ).Text;
            // parse it`s value
            int i = int.Parse( t.Remove( t.Length - 1, 1 ) );
            // calc zoom factor
            zoom = (float) i / 100;

            UpdateZoom( );
        }

        // Zoom In image
        public void ZoomIn( )
        {
            float z = zoom * 1.5f;

            if ( z <= 10 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom In" item click
        private void zoomInImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomIn( );
        }

        // Zoom Out image
        private void ZoomOut( )
        {
            float z = zoom / 1.5f;

            if ( z >= 0.05 )
            {
                zoom = z;
                UpdateZoom( );
            }
        }

        // On "Image->Zoom->Zoom out" item click
        private void zoomOutImageItem_Click( object sender, System.EventArgs e )
        {
            ZoomOut( );
        }

        // Fit to size
        private void FitToScreen( )
        {
            Rectangle rc = ClientRectangle;

            zoom = Math.Min( (float) rc.Width / ( width + 2 ), (float) rc.Height / ( height + 2 ) );

            UpdateZoom( );
        }

        // On "Image->Zoom->Fit To Screen" item click
        private void zoomFitImageItem_Click( object sender, System.EventArgs e )
        {
            FitToScreen( );
        }

        // Flip image
        private void flipImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipY );

            Invalidate( );
        }

        // Mirror image
        private void mirrorItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.RotateNoneFlipX );

            Invalidate( );
        }

        // Rotate image 90 degree
        private void rotateImageItem_Click( object sender, System.EventArgs e )
        {
            image.RotateFlip( RotateFlipType.Rotate90FlipNone );

            // update
            UpdateNewImage( );
        }

        // Invert image
        private void invertColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Invert( ) );
        }

        // Rotatet colors
        private void rotateColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new RotateChannels( ) );
        }

        // Sepia image
        private void sepiaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sepia( ) );
        }

        // Grayscale image
        public void Grayscale( )
        {
            if ( image.PixelFormat == PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "The image is already grayscale", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleBT709( ) );
        }

        // On "Filter->Color->Grayscale"
        private void grayscaleColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            Grayscale( );
        }

        // Converts grayscale image to RGB
        private void toRgbColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat == PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "The image is already RGB", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }
            ApplyFilter( new GrayscaleToRGB( ) );
        }

        // Remove green and blue channels
        private void redColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and blue channels
        private void greenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

        // Remove red and green channels
        private void blueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void cyanColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 0 ), new IntRange( 0, 255 ), new IntRange( 0, 255 ) ) );
        }

        // Remove green channel
        private void magentaColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 0 ), new IntRange( 0, 255 ) ) );
        }

        // Remove blue channel
        private void yellowColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ChannelFiltering( new IntRange( 0, 255 ), new IntRange( 0, 255 ), new IntRange( 0, 0 ) ) );
        }

        // Color filtering
        private void colorFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ColorFilteringForm form = new ColorFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Euclidean color filtering
        private void euclideanFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Euclidean color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            EuclideanColorFilteringForm form = new EuclideanColorFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Channels filtering
        private void channelsFilteringColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ChannelFilteringForm form = new ChannelFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extract red channel of image
        private void extractRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.R ) );
        }

        // Extract green channel of image
        private void extractGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.G ) );
        }

        // Extract blue channel of image
        private void extractRedBlueFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ExtractChannel( RGB.B ) );
        }

        // Replace red channel
        private void replaceRedColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the red channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.R, channelImage ) );
        }

        // Replace green channel
        private void replaceGreenColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the green channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.G, channelImage ) );
        }

        // Replace blue channel
        private void replaceBlueColorFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the blue channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new ReplaceChannel( RGB.B, channelImage ) );
        }

        // Adjust brighness using HSL
        private void Brightness( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Brightness filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            BrightnessForm form = new BrightnessForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Brighness" menu item click
        private void brightnessHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Brightness( );
        }

        // Modify contrast
        private void Contrast( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Contrast filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ContrastForm form = new ContrastForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Contrast" menu item click
        private void contrastHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Contrast( );
        }

        // Adjust saturation using HSL
        private void Saturation( )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Saturation filter using HSL color space is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            SaturationForm form = new SaturationForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->HSL Color space->Saturation" menu item click
        private void saturationHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            Saturation( );
        }

        // HSL linear correction
        private void linearHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "HSL linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HSLLinearForm form = new HSLLinearForm( new ImageStatisticsHSL( image ) );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // HSL filtering
        private void filteringHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "HSL filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HSLFilteringForm form = new HSLFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Hue modifier
        private void hueHslFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Hue modifier is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            HueModifierForm form = new HueModifierForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Linear correction of YCbCr channels
        private void linearYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "YCbCr linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            YCbCrLinearForm form = new YCbCrLinearForm( new ImageStatisticsYCbCr( image ) );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Filtering of YCbCr channels
        private void filteringYCbCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "YCbCr filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            YCbCrFilteringForm form = new YCbCrFilteringForm( );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extract Y channel of YCbCr color space
        private void extracYFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.YIndex ) );
        }

        // Extract Cb channel of YCbCr color space
        private void extracCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CbIndex ) );
        }

        // Extract Cr channel of YCbCr color space
        private void extracCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new YCbCrExtractChannel( YCbCr.CrIndex ) );
        }

        // Replace Y channel of YCbCr color space
        private void replaceYFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Y channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.YIndex, channelImage ) );
        }

        // Replace Cb channel of YCbCr color space
        private void replaceCbFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cb channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CbIndex, channelImage ) );
        }

        // Replace Cr channel of YCbCr color space
        private void replaceCrFiltersItem_Click( object sender, System.EventArgs e )
        {
            // check pixel format
            if ( image.PixelFormat != PixelFormat.Format24bppRgb )
            {
                MessageBox.Show( "Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            Bitmap channelImage = host.GetImage( this, "Select an image which will replace the Cr channel in the current image", new Size( width, height ), PixelFormat.Format8bppIndexed );

            if ( channelImage != null )
                ApplyFilter( new YCbCrReplaceChannel( YCbCr.CrIndex, channelImage ) );
        }

        // Threshold binarization
        private void Threshold( )
        {
            ThresholdForm form = new ThresholdForm( );

            // set image to preview
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Binarization->Threshold" menu item click
        private void thresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            Threshold( );
        }

        // Threshold binarization with carry
        private void thresholdCarryBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ThresholdWithCarry( ) );
        }

        // Ordered dithering
        private void orderedDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new OrderedDithering( ) );
        }

        // Bayer ordered dithering
        private void bayerDitherBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BayerDithering( ) );
        }

        // Binarization using Floyd-Steinverg dithering algorithm
        private void floydBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new FloydSteinbergDithering( ) );
        }

        // Binarization using Burkes dithering algorithm
        private void burkesBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new BurkesDithering( ) );
        }

        // Binarization using Stucki dithering algorithm
        private void stuckiBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new StuckiDithering( ) );
        }

        // Binarization using Jarvis, Judice and Ninke dithering algorithm
        private void jarvisBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new JarvisJudiceNinkeDithering( ) );
        }

        // Binarization using Sierra dithering algorithm
        private void sierraBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SierraDithering( ) );
        }

        // Binarization using Stevenson and Arce dithering algorithm
        private void stevensonBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new StevensonArceDithering( ) );
        }

        // Threshold using Simple Image Statistics
        private void sisThresholdBinaryFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SISThreshold( ) );
        }

        // Errosion (Mathematical Morphology)
        private void erosionMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Erosion( ) );
        }

        // Dilatation (Mathematical Morphology)
        private void dilatationMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Dilatation( ) );
        }

        // Opening (Mathematical Morphology)
        private void openingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Opening( ) );
        }

        // Closing (Mathematical Morphology)
        private void closingMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Closing( ) );
        }

        // Custom morphology operator
        private void Morphology( )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Mathematical morpholgy filters can by applied to grayscale image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.Simple );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Morphology->Custom" menu item click
        private void customMorphologyFiltersItem_Click( object sender, System.EventArgs e )
        {
            Morphology( );
        }

        // Hit & Miss mathematical morphology operator
        private void hitAndMissFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Hit & Miss morpholgy filters can by applied to binary image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm( MathMorphologyForm.FilterTypes.HitAndMiss );
            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Mean
        private void meanConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Mean( ) );
        }

        // Blur
        private void blurConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Blur( ) );
        }

        // Gaussian smoothing
        private void gaussianConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            GaussianForm form = new GaussianForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Extended sharpening
        private void sharpenExConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            SharpenExForm form = new SharpenExForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Sharpen
        private void sharpenConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Sharpen( ) );
        }

        // Edges
        private void edgesConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Edges( ) );
        }

        // Custom convolution filter
        private void Convolution( )
        {
            ConvolutionForm form = new ConvolutionForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Convolution & Correlation->Custom" menu item click
        private void customConvolutionFiltersItem_Click( object sender, System.EventArgs e )
        {
            Convolution( );
        }

        // Merge two images
        private void mergeTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to merge with the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Merge( overlayImage ) );
        }

        // Intersect
        private void intersectTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to intersect with the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Intersect( overlayImage ) );
        }

        // Add
        private void addTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to add to the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Add( overlayImage ) );
        }

        // Subtract
        private void subtractTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to subtract from the curren image", new Size( -1, -1 ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Subtract( overlayImage ) );
        }

        // Difference
        private void differenceTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to get difference with the curren image", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new Difference( overlayImage ) );
        }

        // Move towards
        private void moveTowardsTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the curren image will be moved", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
                ApplyFilter( new MoveTowards( overlayImage, 10 ) );
        }

        // Morph an image
        private void morphTwosrcFiltersItem_Click( object sender, System.EventArgs e )
        {
            // get overlay image
            Bitmap overlayImage = host.GetImage( this, "Select an image to which the curren image will be morphed", new Size( width, height ), image.PixelFormat );

            if ( overlayImage != null )
            {
                // show filter setting dialog
                MorphForm form = new MorphForm( overlayImage );

                form.Image = image;

                // get filter settings
                if ( form.ShowDialog( ) == DialogResult.OK )
                {
                    ApplyFilter( form.Filter );
                }
            }
        }

        // Homogenity edge detector
        private void homogenityEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new HomogenityEdgeDetector( ) );
        }

        // Difference edge detector
        private void differenceEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new DifferenceEdgeDetector( ) );
        }

        // Sobel edge detector
        private void sobelEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SobelEdgeDetector( ) );
        }

        // Canny edge detector
        private void cannyEdgeFiltersItem_Click( object sender, System.EventArgs e )
        {
            CannyDetectorForm form = new CannyDetectorForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Adaptive smoothing
        private void adaptiveSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            AdaptiveSmoothForm form = new AdaptiveSmoothForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conservative smoothing
        private void conservativeSmoothingFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new ConservativeSmoothing( ) );
        }

        // Perlin noise effects
        private void perlinNoiseFiltersItem_Click( object sender, System.EventArgs e )
        {
            PerlinNoiseForm form = new PerlinNoiseForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Oil painting filter
        private void oilPaintingFiltersItem_Click( object sender, System.EventArgs e )
        {
            OilPaintingForm form = new OilPaintingForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Random jitter filter
        private void jitterFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Jitter( 1 ) );
        }

        // Pixellate filter
        private void pixellateFiltersItem_Click( object sender, System.EventArgs e )
        {
            PixelateForm form = new PixelateForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Simple skeletonization
        private void simpleSkeletonizationFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new SimpleSkeletonization( ) );
        }

        // Shrink the image, removing specified color from it`s borders
        private void shrinkFiltersItem_Click( object sender, System.EventArgs e )
        {
            ShrinkForm form = new ShrinkForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Conected components labeling
        private void labelingFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Connected components labeling can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ApplyFilter( new ConnectedComponentsLabeling( ) );
        }

        // Extract separate blobs
        private void blobExtractorFiltersItem_Click( object sender, System.EventArgs e )
        {
            if ( image.PixelFormat != PixelFormat.Format8bppIndexed )
            {
                MessageBox.Show( "Blob extractor can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            BlobCounter blobCounter = new BlobCounter( image );
            Blob[] blobs = blobCounter.GetObjects( image );

            foreach ( Blob blob in blobs )
            {
                host.NewDocument( blob.Image );
            }
        }

        // Resize the image
        private void ResizeImage( )
        {
            ResizeForm form = new ResizeForm( );

            form.OriginalSize = new Size( width, height );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Resize" menu item click
        private void resizeFiltersItem_Click( object sender, System.EventArgs e )
        {
            ResizeImage( );
        }

        // Rotate the image
        private void RotateImage( )
        {
            RotateForm form = new RotateForm( );

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filters->Rotate" menu item click
        private void rotateFiltersItem_Click( object sender, System.EventArgs e )
        {
            RotateImage( );
        }

        // Levels
        private void Levels( )
        {
            LevelsLinearForm form = new LevelsLinearForm( new ImageStatistics( image ) );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // On "Filter->Levels" menu item click
        private void levelsFiltersItem_Click( object sender, System.EventArgs e )
        {
            Levels( );
        }

        // Median filter
        private void medianFiltersItem_Click( object sender, System.EventArgs e )
        {
            ApplyFilter( new Median( ) );
        }

        // Gamma correction
        private void gammaFiltersItem_Click( object sender, System.EventArgs e )
        {
            GammaForm form = new GammaForm( );

            form.Image = image;

            if ( form.ShowDialog( ) == DialogResult.OK )
            {
                ApplyFilter( form.Filter );
            }
        }

        // Fourier transformation
        private void ForwardFourierTransformation( )
        {
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Forward );
            System.Diagnostics.Debug.WriteLine( (int) FourierTransform.Direction.Backward );

            if ( ( !AForge.Math.Tools.IsPowerOf2( width ) ) ||
                ( !AForge.Math.Tools.IsPowerOf2( height ) ) )
            {
                MessageBox.Show( "Fourier trasformation can be applied to an image with width and height of power of 2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                return;
            }

            ComplexImage cImage = ComplexImage.FromBitmap( image );

            cImage.ForwardFourierTransform( );
            host.NewDocument( cImage );
        }

        // On "Filters->Fourier Transformation" click
        private void fourierFiltersItem_Click( object sender, System.EventArgs e )
        {
            ForwardFourierTransformation( );
        }

        // Calculate image and screen coordinates of the point
        private void GetImageAndScreenPoints( Point point, out Point imgPoint, out Point screenPoint )
        {
            Rectangle rc = this.ClientRectangle;
            int width = (int) ( this.width * zoom );
            int height = (int) ( this.height * zoom );
            int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
            int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

            int ix = Math.Min( Math.Max( x, point.X ), x + width - 1 );
            int iy = Math.Min( Math.Max( y, point.Y ), y + height - 1 );

            ix = (int) ( ( ix - x ) / zoom );
            iy = (int) ( ( iy - y ) / zoom );

            // image point
            imgPoint = new Point( ix, iy );
            // screen point
            screenPoint = this.PointToScreen( new Point( (int) ( ix * zoom + x ), (int) ( iy * zoom + y ) ) );
        }

        // Normalize points so, that pt1 becomes top-left point of rectangle
        // and pt2 becomes right-bottom
        private void NormalizePoints( ref Point pt1, ref Point pt2 )
        {
            Point t1 = pt1;
            Point t2 = pt2;

            pt1.X = Math.Min( t1.X, t2.X );
            pt1.Y = Math.Min( t1.Y, t2.Y );
            pt2.X = Math.Max( t1.X, t2.X );
            pt2.Y = Math.Max( t1.Y, t2.Y );
        }

        // Draw selection rectangle
        private void DrawSelectionFrame( Graphics g )
        {
            Point sp = startW;
            Point ep = endW;

            // Normalize points
            NormalizePoints( ref sp, ref ep );
            // Draw reversible frame
            ControlPaint.DrawReversibleFrame( new Rectangle( sp.X, sp.Y, ep.X - sp.X + 1, ep.Y - sp.Y + 1 ), Color.White, FrameStyle.Dashed );
        }

        // Crop the image
        private void Crop( )
        {
            if ( !cropping )
            {
                // turn on
                cropping = true;
                this.Cursor = Cursors.Cross;

            }
            else
            {
                // turn off
                cropping = false;
                this.Cursor = Cursors.Default;
            }
        }

        // On "Image->Crop" - turn on/off cropping mode
        private void cropImageItem_Click( object sender, System.EventArgs e )
        {
            Crop( );
        }

        // On mouse down
        private void ImageDoc_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                // turn off cropping mode
                if ( !dragging )
                {
                    cropping = false;
                    this.Cursor = Cursors.Default;
                }
            }
            else if ( e.Button == MouseButtons.Left )
            {
                if ( cropping )
                {
                    // start dragging
                    dragging = true;
                    // set mouse capture
                    this.Capture = true;

                    // get selection start point
                    GetImageAndScreenPoints( new Point( e.X, e.Y ), out start, out startW );

                    // end point is the same as start
                    end = start;
                    endW = startW;

                    // draw frame
                    Graphics g = this.CreateGraphics( );
                    DrawSelectionFrame( g );
                    g.Dispose( );
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backup != null)
            {
                // release current image
                image.Dispose();
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage();
            }
        }

        private void 克隆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clone();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            String t = "10%";
            // parse it`s value
            int i = int.Parse(t.Remove(t.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            String t1 = "25%";
            // parse it`s value
            int i1 = int.Parse(t1.Remove(t1.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i1 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            String t2 = "50%";
            // parse it`s value
            int i2 = int.Parse(t2.Remove(t2.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i2 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            String t3 = "75%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            String t3 = "100%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            String t3 = "150%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            String t3 = "200%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            String t3 = "400%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            String t3 = "500%";
            // parse it`s value
            int i3 = int.Parse(t3.Remove(t3.Length - 1, 1));
            // calc zoom factor
            zoom = (float)i3 / 100;

            UpdateZoom();
        }

        private void 放大显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void 缩小显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void 适应屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FitToScreen();
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Invalidate();
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Invalidate();
        }

        private void 旋转90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // update
            UpdateNewImage();
        }

        private void 裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Crop();
        }

        private void 灰度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter1(new GrayscaleBT709());
        }

        private void 灰度到RGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat == PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("The image is already RGB", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ApplyFilter(new GrayscaleToRGB());
        }

        private void 棕褐色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Sepia());
        }

        private void 反色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Invert());
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new RotateChannels());
        }

        private void 滤色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ColorFilteringForm form = new ColorFilteringForm();
            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void 欧几里得颜色滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Euclidean color filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EuclideanColorFilteringForm form1 = new EuclideanColorFilteringForm();
            form1.Image = image;

            if (form1.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form1.Filter);
            }
        }

        private void 通道滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels filtering can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ChannelFilteringForm form2 = new ChannelFilteringForm();
            form2.Image = image;

            if (form2.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form2.Filter);
            }
        }

        private void 提取红色通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ExtractChannel(RGB.R));
        }

        private void 提取红色通道ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ExtractChannel(RGB.G));
        }

        private void 提取红色通道ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ExtractChannel(RGB.B));
        }

        private void 更换红色通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage = host.GetImage(this, "Select an image which will replace the red channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage != null)
                ApplyFilter(new ReplaceChannel(RGB.R, channelImage));
        }

        private void 更换红色通道ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage1 = host.GetImage(this, "Select an image which will replace the green channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage1 != null)
                ApplyFilter(new ReplaceChannel(RGB.G, channelImage1));
        }

        private void 更换红色通道ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage2 = host.GetImage(this, "Select an image which will replace the blue channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage2 != null)
                ApplyFilter(new ReplaceChannel(RGB.B, channelImage2));
        }

        private void 红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 0)));
        }

        private void 绿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 0)));
        }

        private void 蓝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 0), new IntRange(0, 255)));
        }

        private void 青色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 0), new IntRange(0, 255), new IntRange(0, 255)));
        }

        private void 洋红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 0), new IntRange(0, 255)));
        }

        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ChannelFiltering(new IntRange(0, 255), new IntRange(0, 255), new IntRange(0, 0)));
        }

        private void 亮度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brightness();
        }

        private void 对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contrast();
        }

        private void 饱和度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Saturation();
        }

        private void HSL线性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("HSL linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            HSLLinearForm form3 = new HSLLinearForm(new ImageStatisticsHSL(image));
            form3.Image = image;

            if (form3.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form3.Filter);
            }
        }

        private void hSL滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("HSL filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            HSLFilteringForm form4 = new HSLFilteringForm();
            form4.Image = image;

            if (form4.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form4.Filter);
            }
        }

        private void 色调调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Hue modifier is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            HueModifierForm form5 = new HueModifierForm();
            form5.Image = image;

            if (form5.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form5.Filter);
            }
        }

        private void yCbCr线性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("YCbCr linear correction is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            YCbCrLinearForm form6 = new YCbCrLinearForm(new ImageStatisticsYCbCr(image));
            form6.Image = image;

            if (form6.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form6.Filter);
            }
        }

        private void yCbCr滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("YCbCr filtering is available for color images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            YCbCrFilteringForm form7 = new YCbCrFilteringForm();
            form7.Image = image;

            if (form7.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form7.Filter);
            }
        }

        private void 提取Y通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new YCbCrExtractChannel(YCbCr.YIndex));
        }

        private void 提取Cb通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new YCbCrExtractChannel(YCbCr.CbIndex));
        }

        private void 提取Cr通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new YCbCrExtractChannel(YCbCr.CrIndex));
        }

        private void 更换Y通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage3 = host.GetImage(this, "Select an image which will replace the Y channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage3 != null)
                ApplyFilter(new YCbCrReplaceChannel(YCbCr.YIndex, channelImage3));
        }

        private void 更换Cb通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(image.PixelFormat != PixelFormat.Format24bppRgb)
                    {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage4 = host.GetImage(this, "Select an image which will replace the Cb channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage4 != null)
                ApplyFilter(new YCbCrReplaceChannel(YCbCr.CbIndex, channelImage4));
        }

        private void 更换Cr通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show("Channels replacement can be applied to RGB images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap channelImage5 = host.GetImage(this, "Select an image which will replace the Cr channel in the current image", new Size(width, height), PixelFormat.Format8bppIndexed);

            if (channelImage5 != null)
                ApplyFilter(new YCbCrReplaceChannel(YCbCr.CrIndex, channelImage5));
        }

        private void 图像阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Threshold();
        }

        private void 带错误进位的阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ThresholdWithCarry());
        }

        private void 有序抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new OrderedDithering());
        }

        private void bayer有序抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new BayerDithering());
        }

        private void 弗洛伊德斯坦伯格抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new FloydSteinbergDithering());
        }

        private void 伯克斯抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new BurkesDithering());
        }

        private void stucki抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new StuckiDithering());
        }

        private void jarvisJudiceNinke抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new JarvisJudiceNinkeDithering());
        }

        private void sierra抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SierraDithering());
        }

        private void stevensonAndArce抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new StevensonArceDithering());
        }

        private void sIS阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SISThreshold());
        }

        private void 腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Erosion());
        }

        private void 膨胀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Dilatation());
        }

        private void 开运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Opening());
        }

        private void 闭运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Closing());
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Morphology();
        }

        private void hitAndMissTHickeningThinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                MessageBox.Show("Hit & Miss morpholgy filters can by applied to binary image only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MathMorphologyForm form = new MathMorphologyForm(MathMorphologyForm.FilterTypes.HitAndMiss);
            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void meanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Mean());
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Blur());
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Sharpen());
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Edges());
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Convolution();
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaussianForm form = new GaussianForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void sharpenExToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharpenExForm form = new SharpenExForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to merge with the curren image", new Size(-1, -1), image.PixelFormat);

            if (overlayImage != null)
                ApplyFilter(new Merge(overlayImage));
        }

        private void intersectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage1 = host.GetImage(this, "Select an image to intersect with the curren image", new Size(-1, -1), image.PixelFormat);

            if (overlayImage1 != null)
                ApplyFilter(new Intersect(overlayImage1));
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to add to the curren image", new Size(-1, -1), image.PixelFormat);

            if (overlayImage != null)
                ApplyFilter(new Add(overlayImage));
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to subtract from the curren image", new Size(-1, -1), image.PixelFormat);

            if (overlayImage != null)
                ApplyFilter(new Subtract(overlayImage));
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to get difference with the curren image", new Size(width, height), image.PixelFormat);

            if (overlayImage != null)
                ApplyFilter(new Difference(overlayImage));
        }

        private void moveTowardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to which the curren image will be moved", new Size(width, height), image.PixelFormat);

            if (overlayImage != null)
                ApplyFilter(new MoveTowards(overlayImage, 10));
        }

        private void morphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap overlayImage = host.GetImage(this, "Select an image to which the curren image will be morphed", new Size(width, height), image.PixelFormat);

            if (overlayImage != null)
            {
                // show filter setting dialog
                MorphForm form = new MorphForm(overlayImage);

                form.Image = image;

                // get filter settings
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ApplyFilter(form.Filter);
                }
            }
        }

        private void homogenityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new HomogenityEdgeDetector());
        }

        private void differenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ApplyFilter(new DifferenceEdgeDetector());
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SobelEdgeDetector());
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CannyDetectorForm form = new CannyDetectorForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void 大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeImage();
        }

        private void 旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AdaptiveSmoothForm form = new AdaptiveSmoothForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ApplyFilter(new ConservativeSmoothing());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PerlinNoiseForm form = new PerlinNoiseForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OilPaintingForm form = new OilPaintingForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Jitter(1));
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            PixelateForm form = new PixelateForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ApplyFilter(new SimpleSkeletonization());
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ShrinkForm form = new ShrinkForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                MessageBox.Show("Connected components labeling can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ApplyFilter(new ConnectedComponentsLabeling());
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                MessageBox.Show("Blob extractor can be applied to binary images only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BlobCounter blobCounter = new BlobCounter(image);
            Blob[] blobs = blobCounter.GetObjects(image);

            foreach (Blob blob in blobs)
            {
                host.NewDocument(blob.Image);
            }
        }

        private void 层次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Levels();
        }

        private void 中位数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyFilter(new Median());
        }

        private void 伽玛校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaForm form = new GammaForm();

            form.Image = image;

            if (form.ShowDialog() == DialogResult.OK)
            {
                ApplyFilter(form.Filter);
            }
        }

        private void 傅里叶变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForwardFourierTransformation();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                if (e.Delta > 0)
                {
                    zoom+=(float)0.01;
                }

                // Zoom -
                if (e.Delta < 0)
                {
                    zoom -= (float)0.01;
                }
                UpdateZoom();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ResizeImage();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RotateImage();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Levels();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (backup != null)
            {
                // release current image
                image.Dispose();
                // restore
                image = backup;
                backup = null;

                // update
                UpdateNewImage();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Clone();
        }

        // On mouse up
        private void ImageDoc_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {
                // stop dragging and cropping
                dragging = cropping = false;
                // release capture
                this.Capture = false;
                // set default mouse pointer
                this.Cursor = Cursors.Default;

                // erase frame
                Graphics g = this.CreateGraphics( );
                DrawSelectionFrame( g );
                g.Dispose( );

                // normalize start and end points
                NormalizePoints( ref start, ref end );

                // crop tge image
                ApplyFilter( new Crop( new Rectangle( start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1 ) ) );
            }
        }

        // On mouse move
        private void ImageDoc_MouseMove( object sender, System.Windows.Forms.MouseEventArgs e )
        {
            if ( dragging )
            {

                Graphics g = this.CreateGraphics( );

                // erase frame
                DrawSelectionFrame( g );

                // get selection end point
                GetImageAndScreenPoints( new Point( e.X, e.Y ), out end, out endW );

                // draw frame
                DrawSelectionFrame( g );

                g.Dispose( );

                if ( SelectionChanged != null )
                {
                    Point sp = start;
                    Point ep = end;

                    // normalize start and end points
                    NormalizePoints( ref sp, ref ep );

                    SelectionChanged( this, new SelectionEventArgs(
                        sp, new Size( ep.X - sp.X + 1, ep.Y - sp.Y + 1 ) ) );
                }
            }
            else
            {
                if ( MouseImagePosition != null )
                {
                    Rectangle rc = this.ClientRectangle;
                    int width = (int) ( this.width * zoom );
                    int height = (int) ( this.height * zoom );
                    int x = ( rc.Width < width ) ? this.AutoScrollPosition.X : ( rc.Width - width ) / 2;
                    int y = ( rc.Height < height ) ? this.AutoScrollPosition.Y : ( rc.Height - height ) / 2;

                    if ( ( e.X >= x ) && ( e.Y >= y ) &&
                        ( e.X < x + width ) && ( e.Y < y + height ) )
                    {
                        // mouse is over the image
                        MouseImagePosition( this, new SelectionEventArgs(
                            new Point( (int) ( ( e.X - x ) / zoom ), (int) ( ( e.Y - y ) / zoom ) ) ) );
                    }
                    else
                    {
                        // mouse is outside image region
                        MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
                    }
                }
            }
        }

        // On mouse leave
        private void ImageDoc_MouseLeave( object sender, System.EventArgs e )
        {
            if ( ( !dragging ) && ( MouseImagePosition != null ) )
            {
                MouseImagePosition( this, new SelectionEventArgs( new Point( -1, -1 ) ) );
            }
        }
    }

    // Selection arguments
    public class SelectionEventArgs : EventArgs
    {
        private Point location;
        private Size size;

        // Constructors
        public SelectionEventArgs( Point location )
        {
            this.location = location;
        }
        public SelectionEventArgs( Point location, Size size )
        {
            this.location = location;
            this.size = size;
        }

        // Location property
        public Point Location
        {
            get { return location; }
        }
        // Size property
        public Size Size
        {
            get { return size; }
        }
    }

    // Commands
    public enum ImageDocCommands
    {
        Clone,
        Crop,
        ZoomIn,
        ZoomOut,
        ZoomOriginal,
        FitToSize,
        Levels,
        Grayscale,
        Threshold,
        Morphology,
        Convolution,
        Resize,
        Rotate,
        Brightness,
        Contrast,
        Saturation,
        Fourier
    }
}
