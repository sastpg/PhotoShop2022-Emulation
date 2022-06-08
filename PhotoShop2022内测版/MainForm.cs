// Image Processing Lab
//
// Copyright ?Andrew Kirillov, 2005
// andrew.kirillov@gmail.com
//

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Windows.Media.Imaging;
using WeifenLuo.WinFormsUI;
using rpaulo.toolbar;
using AForge.Imaging;
using ConmajiaColorPicker;


namespace IPLab
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    /// 
    public delegate void MenuEventHandler(string operation);

    public class MainForm : System.Windows.Forms.Form, IDocumentsHost
	{
        private static string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "app.config");
		private static string dockManagerConfigFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockManager.config");

		private int unnamedNumber = 0;
		private Configuration config = new Configuration();
		private HistogramWindow histogramWin = new HistogramWindow();
		private ImageStatisticsWindow statisticsWin = new ImageStatisticsWindow();

		private ToolBarManager toolBarManager;
		private System.Windows.Forms.StatusBarPanel zoomPanel;
		private System.Windows.Forms.StatusBarPanel sizePanel;
		private System.Windows.Forms.StatusBarPanel infoPanel;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel selectionPanel;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.StatusBarPanel colorPanel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.StatusBarPanel hslPanel;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.StatusBarPanel ycbcrPanel;
        private DockManager dockManager;
        private Panel panel1;
        private Panel panel2;
        private Panel panel15;
        private Panel panelThird;
        private Panel panel16;
        private Panel panel13;
        private ComboBox comboBox4;
        private Label label9;
        private Label label10;
        private Panel panel11;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private Label label8;
        private Panel panel12;
        private ComboBox comboBox1;
        private Panel panel14;
        private Button button15;
        private Button button12;
        private Button button13;
        private Button button14;
        private Panel plSecond;
        private Panel panel10;
        private Button button9;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label2;
        private Panel panel9;
        private Label label1;
        private Button button8;
        private Panel panel8;
        private Button button5;
        private Button button6;
        private Button button7;
        private Panel panel6;
        private Panel panel3;
        private Panel panel4;
        private Button btnBoard;
        private Button button4;
        private Button btnColor;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton12;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton13;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButton26;
        private ToolStripButton toolStripButton11;
        private Panel panel17;
        private Button button2;
        private Button button1;
        private Panel panel5;
        private Button button3;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton10;
        private ToolStripButton toolStripButton14;
        private ToolStripButton toolStripButton15;
        private ToolStripButton toolStripButton16;
        private ToolStripButton toolStripButton17;
        private ToolStripButton toolStripButton18;
        private ToolStripButton toolStripButton19;
        private ToolStripButton toolStripButton20;
        private ToolStripButton toolStripButton21;
        private ToolStripButton toolStripButton22;
        private ToolStripButton toolStripButton23;
        private ToolStripButton toolStripButton24;
        private ToolStripButton toolStripButton25;
        private Panel plToolFunction;
        private Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Panel panel18;
        private Button btnMin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 新建ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 在Bridge中浏览ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 图像ToolStripMenuItem;
        private ToolStripMenuItem 图层ToolStripMenuItem;
        private ToolStripMenuItem 文字ToolStripMenuItem;
        private ToolStripMenuItem 选择ToolStripMenuItem;
        private ToolStripMenuItem 滤镜ToolStripMenuItem;
        private ToolStripMenuItem 颜色ToolStripMenuItem;
        private ToolStripMenuItem 灰度ToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem 视图ToolStripMenuItem;
        private ToolStripMenuItem 窗口ToolStripMenuItem;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Button btnMax;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Panel panel19;
        private ToolStripMenuItem 重新加载ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 复制ToolStripMenuItem;
        private ToolStripMenuItem 粘贴ToolStripMenuItem;
        private ToolStripMenuItem 关闭当前ToolStripMenuItem;
        private ToolStripMenuItem 关闭所有ToolStripMenuItem;
        private ToolStripMenuItem 页面设置ToolStripMenuItem;
        private ToolStripMenuItem 打印ToolStripMenuItem;
        private ToolStripMenuItem 打印预览ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
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
        private ToolStripMenuItem 二值化ToolStripMenuItem;
        private ToolStripMenuItem 形态ToolStripMenuItem;
        private ToolStripMenuItem 卷积相关ToolStripMenuItem;
        private ToolStripMenuItem 双源滤波器ToolStripMenuItem;
        private ToolStripMenuItem 边缘检测器ToolStripMenuItem;
        private ToolStripMenuItem 其他ToolStripMenuItem;
        private ToolStripMenuItem 大小ToolStripMenuItem;
        private ToolStripMenuItem 旋转ToolStripMenuItem;
        private ToolStripMenuItem yCbCr线性ToolStripMenuItem;
        private ToolStripMenuItem yCbCr滤波ToolStripMenuItem;
        private ToolStripMenuItem 提取Y通道ToolStripMenuItem;
        private ToolStripMenuItem 提取Cb通道ToolStripMenuItem;
        private ToolStripMenuItem 提取Cr通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Y通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Cb通道ToolStripMenuItem;
        private ToolStripMenuItem 更换Cr通道ToolStripMenuItem;
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
        private ToolStripMenuItem 腐蚀ToolStripMenuItem;
        private ToolStripMenuItem 膨胀ToolStripMenuItem;
        private ToolStripMenuItem 开运算ToolStripMenuItem;
        private ToolStripMenuItem 闭运算ToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem;
        private ToolStripMenuItem hitAndMissTHickeningThinningToolStripMenuItem;
        private ToolStripMenuItem meanToolStripMenuItem;
        private ToolStripMenuItem blurToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem edgesToolStripMenuItem;
        private ToolStripMenuItem customToolStripMenuItem1;
        private ToolStripMenuItem gaussianToolStripMenuItem;
        private ToolStripMenuItem sharpenExToolStripMenuItem;
        private ToolStripMenuItem mergeToolStripMenuItem;
        private ToolStripMenuItem intersectToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem subtractToolStripMenuItem;
        private ToolStripMenuItem differenceToolStripMenuItem;
        private ToolStripMenuItem moveTowardsToolStripMenuItem;
        private ToolStripMenuItem morphToolStripMenuItem;
        private ToolStripMenuItem homogenityToolStripMenuItem;
        private ToolStripMenuItem differenceToolStripMenuItem1;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem cannyToolStripMenuItem;
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
        private Panel panel20;
        private ToolStripMenuItem 层次ToolStripMenuItem;
        private ToolStripMenuItem 中位数ToolStripMenuItem;
        private ToolStripMenuItem 伽玛校正ToolStripMenuItem;
        private ToolStripMenuItem 傅里叶变换ToolStripMenuItem;
        private ToolStripMenuItem 返回ToolStripMenuItem;
        private ToolStripMenuItem 克隆ToolStripMenuItem;
        private ToolStripMenuItem 缩放ToolStripMenuItem;
        private ToolStripMenuItem 垂直翻转ToolStripMenuItem;
        private ToolStripMenuItem 水平翻转ToolStripMenuItem;
        private ToolStripMenuItem 旋转90ToolStripMenuItem;
        private ToolStripMenuItem 裁剪ToolStripMenuItem;
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
        private ToolStripMenuItem photoShop帮助ToolStripMenuItem;
        private ToolStripMenuItem photoShop教程ToolStripMenuItem;
        private ToolStripMenuItem 系统信息ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem 直方图ToolStripMenuItem;
        private ToolStripMenuItem 统计ToolStripMenuItem;
        private ToolStripMenuItem rToolStripMenuItem;
        private ToolStripMenuItem gToolStripMenuItem;
        private ToolStripMenuItem bToolStripMenuItem;
        private ToolStripMenuItem 中央ToolStripMenuItem;
        private ToolStripMenuItem 在新更改文档中打开ToolStripMenuItem;
        private ToolStripMenuItem 记住变化ToolStripMenuItem;
        private Panel panel21;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem 与作者联系ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripMenuItem 拍照ToolStripMenuItem;

        //private ColorBar colorBar1;
        private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			toolBarManager = new ToolBarManager(this, this);

			// add toolbars
			//ToolBarDockHolder holder;

			// main tool bar
			//mainToolBar.Text = "Main Tool Bar";
			//holder = toolBarManager.AddControl(mainToolBar);
			//holder.AllowedBorders = AllowedBorders.Top | AllowedBorders.Left | AllowedBorders.Right;

			// image toolbar
			//imageToolBar.Text = "Image Tool Bar";
			//holder = toolBarManager.AddControl(imageToolBar);
			//holder.AllowedBorders = AllowedBorders.Top | AllowedBorders.Left | AllowedBorders.Right;

			histogramWin.DockStateChanged += new EventHandler(histogram_DockStateChanged);
			statisticsWin.DockStateChanged += new EventHandler(statistics_DockStateChanged);

			histogramWin.VisibleChanged += new EventHandler( histogram_VisibleChanged );
			statisticsWin.VisibleChanged += new EventHandler( statistics_VisibleChanged );
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.zoomPanel = new System.Windows.Forms.StatusBarPanel();
            this.sizePanel = new System.Windows.Forms.StatusBarPanel();
            this.selectionPanel = new System.Windows.Forms.StatusBarPanel();
            this.colorPanel = new System.Windows.Forms.StatusBarPanel();
            this.hslPanel = new System.Windows.Forms.StatusBarPanel();
            this.ycbcrPanel = new System.Windows.Forms.StatusBarPanel();
            this.infoPanel = new System.Windows.Forms.StatusBarPanel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.dockManager = new WeifenLuo.WinFormsUI.DockManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panelThird = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.button15 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.plSecond = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnBoard = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton26 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.panel17 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton17 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton18 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton19 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton21 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton23 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton24 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton25 = new System.Windows.Forms.ToolStripButton();
            this.plToolFunction = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在Bridge中浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.重新加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭当前ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.页面设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.克隆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.缩放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.放大显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩小显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.适应屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.垂直翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.裁剪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在新更改文档中打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.记住变化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.滤镜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度到RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.棕褐色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.反色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.滤色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.欧几里得颜色滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通道滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.提取红色通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取红色通道ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.提取红色通道ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.更换红色通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换红色通道ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.更换红色通道ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.HSL线性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSL滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色调调节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr颜色空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr线性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.提取Y通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取Cb通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提取Cr通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.更换Y通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换Cb通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换Cr通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二值化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.带错误进位的阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.有序抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bayer有序抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.伯克斯抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stucki抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisJudiceNinke抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierra抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stevensonAndArce抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.大小ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.层次ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中位数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.伽玛校正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.傅里叶变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中央ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.拍照ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoShop帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoShop教程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.系统信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.与作者联系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnMax = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel19 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelThird.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel14.SuspendLayout();
            this.plSecond.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.plToolFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel19.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.Location = new System.Drawing.Point(64, 1368);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.zoomPanel,
            this.sizePanel,
            this.selectionPanel,
            this.colorPanel,
            this.hslPanel,
            this.ycbcrPanel,
            this.infoPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1550, 36);
            this.statusBar.TabIndex = 1;
            // 
            // zoomPanel
            // 
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.ToolTipText = "Zoom coefficient";
            this.zoomPanel.Width = 50;
            // 
            // sizePanel
            // 
            this.sizePanel.Name = "sizePanel";
            this.sizePanel.ToolTipText = "Image size";
            this.sizePanel.Width = 90;
            // 
            // selectionPanel
            // 
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.ToolTipText = "Current point and selection size";
            this.selectionPanel.Width = 90;
            // 
            // colorPanel
            // 
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.ToolTipText = "Current color";
            this.colorPanel.Width = 120;
            // 
            // hslPanel
            // 
            this.hslPanel.Name = "hslPanel";
            this.hslPanel.Width = 150;
            // 
            // ycbcrPanel
            // 
            this.ycbcrPanel.Name = "ycbcrPanel";
            this.ycbcrPanel.Width = 180;
            // 
            // infoPanel
            // 
            this.infoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Width = 845;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            // 
            // ofd
            // 
            this.ofd.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.ofd.Title = "Open image";
            // 
            // sfd
            // 
            this.sfd.Filter = "JPG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp";
            this.sfd.Title = "Save image";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // dockManager
            // 
            this.dockManager.ActiveAutoHideContent = null;
            this.dockManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dockManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockManager.Location = new System.Drawing.Point(0, 0);
            this.dockManager.Name = "dockManager";
            this.dockManager.Size = new System.Drawing.Size(1550, 1312);
            this.dockManager.TabIndex = 2;
            this.dockManager.ActiveDocumentChanged += new System.EventHandler(this.dockManager_ActiveDocumentChanged);
            this.dockManager.Paint += new System.Windows.Forms.PaintEventHandler(this.dockManager_Paint);
            this.dockManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dockManager_MouseDown);
            this.dockManager.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dockManager_MouseMove);
            this.dockManager.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dockManager_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.panel21);
            this.panel1.Controls.Add(this.statusBar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.plToolFunction);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2186, 1404);
            this.panel1.TabIndex = 2;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.dockManager);
            this.panel21.Location = new System.Drawing.Point(64, 56);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(1550, 1312);
            this.panel21.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.panelThird);
            this.panel2.Controls.Add(this.plSecond);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.panel17);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1646, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 1352);
            this.panel2.TabIndex = 10;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel15.Location = new System.Drawing.Point(59, 1317);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(483, 35);
            this.panel15.TabIndex = 12;
            // 
            // panelThird
            // 
            this.panelThird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelThird.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panelThird.Controls.Add(this.panel16);
            this.panelThird.Controls.Add(this.panel13);
            this.panelThird.Controls.Add(this.panel11);
            this.panelThird.Controls.Add(this.panel12);
            this.panelThird.Controls.Add(this.panel14);
            this.panelThird.Location = new System.Drawing.Point(59, 884);
            this.panelThird.Name = "panelThird";
            this.panelThird.Size = new System.Drawing.Size(483, 431);
            this.panelThird.TabIndex = 11;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.panel16.Location = new System.Drawing.Point(0, 178);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(483, 253);
            this.panel16.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel13.Controls.Add(this.comboBox4);
            this.panel13.Controls.Add(this.label9);
            this.panel13.Controls.Add(this.label10);
            this.panel13.Location = new System.Drawing.Point(0, 133);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(483, 43);
            this.panel13.TabIndex = 3;
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.ForeColor = System.Drawing.Color.White;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(336, 10);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(72, 26);
            this.comboBox4.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("华文宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "锁定：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("华文宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(279, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "填充：";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel11.Controls.Add(this.comboBox3);
            this.panel11.Controls.Add(this.comboBox2);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Location = new System.Drawing.Point(0, 88);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(483, 43);
            this.panel11.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.ForeColor = System.Drawing.Color.White;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(318, 9);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(90, 26);
            this.comboBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.ForeColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(19, 9);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 26);
            this.comboBox2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("华文宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(226, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "不透明度：";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel12.Controls.Add(this.comboBox1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 44);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(483, 43);
            this.panel12.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownWidth = 100;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 26);
            this.comboBox1.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel14.Controls.Add(this.button15);
            this.panel14.Controls.Add(this.button12);
            this.panel14.Controls.Add(this.button13);
            this.panel14.Controls.Add(this.button14);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(483, 44);
            this.panel14.TabIndex = 0;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button15.Dock = System.Windows.Forms.DockStyle.Left;
            this.button15.FlatAppearance.BorderSize = 0;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(162, 0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(83, 44);
            this.button15.TabIndex = 8;
            this.button15.Text = "路径";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button12.Dock = System.Windows.Forms.DockStyle.Left;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(79, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(83, 44);
            this.button12.TabIndex = 0;
            this.button12.Text = "通道";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.Location = new System.Drawing.Point(430, 9);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(20, 20);
            this.button13.TabIndex = 7;
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button14.Dock = System.Windows.Forms.DockStyle.Left;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(0, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(79, 44);
            this.button14.TabIndex = 0;
            this.button14.Text = "图层";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // plSecond
            // 
            this.plSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.plSecond.Controls.Add(this.panel10);
            this.plSecond.Controls.Add(this.panel9);
            this.plSecond.Controls.Add(this.panel8);
            this.plSecond.Location = new System.Drawing.Point(59, 507);
            this.plSecond.Name = "plSecond";
            this.plSecond.Size = new System.Drawing.Size(483, 371);
            this.plSecond.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel10.Controls.Add(this.button9);
            this.panel10.Controls.Add(this.textBox4);
            this.panel10.Controls.Add(this.textBox2);
            this.panel10.Controls.Add(this.textBox3);
            this.panel10.Controls.Add(this.textBox1);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.label4);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Location = new System.Drawing.Point(0, 91);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(480, 323);
            this.panel10.TabIndex = 2;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(30, 75);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(24, 24);
            this.button9.TabIndex = 3;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(297, 99);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 21);
            this.textBox4.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(120, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 21);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(297, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 21);
            this.textBox3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(120, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(252, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(252, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(75, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "W";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(116, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "分辨率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "画布";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.button8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 44);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(483, 45);
            this.panel9.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "文档";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(19, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(35, 35);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel8.Controls.Add(this.button5);
            this.panel8.Controls.Add(this.button6);
            this.panel8.Controls.Add(this.button7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(483, 44);
            this.panel8.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(79, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 44);
            this.button5.TabIndex = 0;
            this.button5.Text = "调整";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(430, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(20, 20);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button7.Dock = System.Windows.Forms.DockStyle.Left;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 44);
            this.button7.TabIndex = 0;
            this.button7.Text = "属性";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel6.Location = new System.Drawing.Point(0, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(56, 10);
            this.panel6.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel3.Controls.Add(this.panel20);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(59, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(483, 476);
            this.panel3.TabIndex = 8;
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(0, 44);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(483, 432);
            this.panel20.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel4.Controls.Add(this.btnBoard);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.btnColor);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(483, 44);
            this.panel4.TabIndex = 0;
            // 
            // btnBoard
            // 
            this.btnBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBoard.FlatAppearance.BorderSize = 0;
            this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoard.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBoard.ForeColor = System.Drawing.Color.White;
            this.btnBoard.Location = new System.Drawing.Point(79, 0);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(83, 44);
            this.btnBoard.TabIndex = 0;
            this.btnBoard.Text = "色板";
            this.btnBoard.UseVisualStyleBackColor = false;
            this.btnBoard.Click += new System.EventHandler(this.btnBoard_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(430, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(0, 0);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(79, 44);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton12,
            this.toolStripSeparator3,
            this.toolStripButton13,
            this.toolStripSeparator4,
            this.toolStripButton26,
            this.toolStripButton11});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(56, 1328);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.AutoSize = false;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(50, 36);
            this.toolStripButton12.Text = "返回历史记录";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(52, 6);
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.AutoSize = false;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(50, 36);
            this.toolStripButton13.Text = "属性";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(52, 6);
            // 
            // toolStripButton26
            // 
            this.toolStripButton26.AutoSize = false;
            this.toolStripButton26.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton26.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton26.Image")));
            this.toolStripButton26.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton26.Name = "toolStripButton26";
            this.toolStripButton26.Size = new System.Drawing.Size(50, 36);
            this.toolStripButton26.Text = "字符";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.AutoSize = false;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(50, 36);
            this.toolStripButton11.Text = "段落";
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel17.Controls.Add(this.button2);
            this.panel17.Controls.Add(this.button1);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(540, 24);
            this.panel17.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(511, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(20, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel5.Controls.Add(this.button3);
            this.panel5.Location = new System.Drawing.Point(0, 52);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(58, 24);
            this.panel5.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton10,
            this.toolStripButton14,
            this.toolStripButton15,
            this.toolStripButton16,
            this.toolStripButton17,
            this.toolStripButton18,
            this.toolStripButton19,
            this.toolStripButton20,
            this.toolStripButton21,
            this.toolStripButton22,
            this.toolStripButton23,
            this.toolStripButton24,
            this.toolStripButton25});
            this.toolStrip1.Location = new System.Drawing.Point(0, 52);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(58, 1352);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(6, 20, 6, 3);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "移动工具";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "矩形选框工具";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton3.Text = "保存文件";
            this.toolStripButton3.ToolTipText = "套索工具";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "快速选择工具";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "裁剪工具";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton6.Text = "吸管工具";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton7.Text = "污点修复画笔工具";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AutoSize = false;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton8.Text = "画笔工具";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.AutoSize = false;
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton10.Text = "仿制图章工具";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.AutoSize = false;
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton14.Text = "历史记录画笔工具";
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.AutoSize = false;
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton15.Text = "橡皮擦工具";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.AutoSize = false;
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton16.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton16.Text = "渐变工具";
            // 
            // toolStripButton17
            // 
            this.toolStripButton17.AutoSize = false;
            this.toolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton17.Image")));
            this.toolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton17.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton17.Name = "toolStripButton17";
            this.toolStripButton17.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton17.Text = "模糊工具";
            this.toolStripButton17.Click += new System.EventHandler(this.toolStripButton17_Click);
            // 
            // toolStripButton18
            // 
            this.toolStripButton18.AutoSize = false;
            this.toolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton18.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton18.Image")));
            this.toolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton18.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton18.Name = "toolStripButton18";
            this.toolStripButton18.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton18.Text = "加深工具";
            // 
            // toolStripButton19
            // 
            this.toolStripButton19.AutoSize = false;
            this.toolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton19.Image")));
            this.toolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton19.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton19.Name = "toolStripButton19";
            this.toolStripButton19.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton19.Text = "钢笔工具";
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.AutoSize = false;
            this.toolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton20.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton20.Image")));
            this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton20.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton20.Text = "文字工具";
            this.toolStripButton20.Click += new System.EventHandler(this.toolStripButton20_Click);
            // 
            // toolStripButton21
            // 
            this.toolStripButton21.AutoSize = false;
            this.toolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton21.Image")));
            this.toolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton21.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton21.Name = "toolStripButton21";
            this.toolStripButton21.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton21.Text = "路径选择工具";
            // 
            // toolStripButton22
            // 
            this.toolStripButton22.AutoSize = false;
            this.toolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton22.Image")));
            this.toolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton22.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton22.Name = "toolStripButton22";
            this.toolStripButton22.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton22.Text = "抓手工具";
            // 
            // toolStripButton23
            // 
            this.toolStripButton23.AutoSize = false;
            this.toolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton23.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton23.Image")));
            this.toolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton23.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton23.Name = "toolStripButton23";
            this.toolStripButton23.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton23.Text = "放大工具";
            this.toolStripButton23.Click += new System.EventHandler(this.toolStripButton23_Click);
            // 
            // toolStripButton24
            // 
            this.toolStripButton24.AutoSize = false;
            this.toolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton24.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton24.Image")));
            this.toolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton24.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton24.Name = "toolStripButton24";
            this.toolStripButton24.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton24.Text = "编辑工具栏";
            // 
            // toolStripButton25
            // 
            this.toolStripButton25.AutoSize = false;
            this.toolStripButton25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton25.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton25.Image")));
            this.toolStripButton25.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton25.Margin = new System.Windows.Forms.Padding(6, 2, 6, 3);
            this.toolStripButton25.Name = "toolStripButton25";
            this.toolStripButton25.Size = new System.Drawing.Size(26, 24);
            this.toolStripButton25.Text = "蒙版";
            // 
            // plToolFunction
            // 
            this.plToolFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.plToolFunction.Controls.Add(this.panel7);
            this.plToolFunction.Controls.Add(this.pictureBox2);
            this.plToolFunction.Controls.Add(this.pictureBox1);
            this.plToolFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.plToolFunction.Location = new System.Drawing.Point(0, 0);
            this.plToolFunction.Name = "plToolFunction";
            this.plToolFunction.Size = new System.Drawing.Size(2186, 52);
            this.plToolFunction.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2186, 2);
            this.panel7.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(2126, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2023, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel18.Controls.Add(this.btnMin);
            this.panel18.Controls.Add(this.pictureBox3);
            this.panel18.Controls.Add(this.menuStrip1);
            this.panel18.Controls.Add(this.pictureBox6);
            this.panel18.Controls.Add(this.btnClose);
            this.panel18.Controls.Add(this.pictureBox4);
            this.panel18.Controls.Add(this.btnMax);
            this.panel18.Controls.Add(this.pictureBox5);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel18.Size = new System.Drawing.Size(2186, 36);
            this.panel18.TabIndex = 3;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(2042, 1);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(42, 26);
            this.btnMin.TabIndex = 9;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(10, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.图像ToolStripMenuItem,
            this.图层ToolStripMenuItem,
            this.文字ToolStripMenuItem,
            this.选择ToolStripMenuItem,
            this.滤镜ToolStripMenuItem,
            this.dToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.窗口ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(38, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 1, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1116, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.在Bridge中浏览ToolStripMenuItem,
            this.toolStripSeparator1,
            this.重新加载ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.toolStripSeparator2,
            this.关闭当前ToolStripMenuItem,
            this.关闭所有ToolStripMenuItem,
            this.toolStripSeparator5,
            this.页面设置ToolStripMenuItem,
            this.打印ToolStripMenuItem,
            this.打印预览ToolStripMenuItem,
            this.toolStripSeparator6,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文件ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.文件ToolStripMenuItem.Text = "文件[&F]";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.新建ToolStripMenuItem.Enabled = false;
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 在Bridge中浏览ToolStripMenuItem
            // 
            this.在Bridge中浏览ToolStripMenuItem.Name = "在Bridge中浏览ToolStripMenuItem";
            this.在Bridge中浏览ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.在Bridge中浏览ToolStripMenuItem.Text = "在Bridge中浏览";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // 重新加载ToolStripMenuItem
            // 
            this.重新加载ToolStripMenuItem.Name = "重新加载ToolStripMenuItem";
            this.重新加载ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.重新加载ToolStripMenuItem.Text = "重新加载";
            this.重新加载ToolStripMenuItem.Click += new System.EventHandler(this.重新加载ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // 关闭当前ToolStripMenuItem
            // 
            this.关闭当前ToolStripMenuItem.Name = "关闭当前ToolStripMenuItem";
            this.关闭当前ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.关闭当前ToolStripMenuItem.Text = "关闭当前";
            this.关闭当前ToolStripMenuItem.Click += new System.EventHandler(this.关闭当前ToolStripMenuItem_Click);
            // 
            // 关闭所有ToolStripMenuItem
            // 
            this.关闭所有ToolStripMenuItem.Name = "关闭所有ToolStripMenuItem";
            this.关闭所有ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.关闭所有ToolStripMenuItem.Text = "关闭所有";
            this.关闭所有ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(236, 6);
            // 
            // 页面设置ToolStripMenuItem
            // 
            this.页面设置ToolStripMenuItem.Name = "页面设置ToolStripMenuItem";
            this.页面设置ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.页面设置ToolStripMenuItem.Text = "页面设置";
            this.页面设置ToolStripMenuItem.Click += new System.EventHandler(this.页面设置ToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // 打印预览ToolStripMenuItem
            // 
            this.打印预览ToolStripMenuItem.Name = "打印预览ToolStripMenuItem";
            this.打印预览ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.打印预览ToolStripMenuItem.Text = "打印预览 ";
            this.打印预览ToolStripMenuItem.Click += new System.EventHandler(this.打印预览ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(236, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.编辑ToolStripMenuItem.Text = "编辑[&E]";
            // 
            // 图像ToolStripMenuItem
            // 
            this.图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.返回ToolStripMenuItem,
            this.克隆ToolStripMenuItem,
            this.toolStripSeparator8,
            this.缩放ToolStripMenuItem,
            this.toolStripSeparator9,
            this.垂直翻转ToolStripMenuItem,
            this.水平翻转ToolStripMenuItem,
            this.旋转90ToolStripMenuItem,
            this.toolStripSeparator10,
            this.裁剪ToolStripMenuItem});
            this.图像ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.图像ToolStripMenuItem.Name = "图像ToolStripMenuItem";
            this.图像ToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.图像ToolStripMenuItem.Text = "图像[&I]";
            // 
            // 返回ToolStripMenuItem
            // 
            this.返回ToolStripMenuItem.Name = "返回ToolStripMenuItem";
            this.返回ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.返回ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.返回ToolStripMenuItem.Text = "返回";
            this.返回ToolStripMenuItem.Click += new System.EventHandler(this.返回ToolStripMenuItem_Click);
            // 
            // 克隆ToolStripMenuItem
            // 
            this.克隆ToolStripMenuItem.Name = "克隆ToolStripMenuItem";
            this.克隆ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.克隆ToolStripMenuItem.Text = "克隆";
            this.克隆ToolStripMenuItem.Click += new System.EventHandler(this.克隆ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(303, 6);
            // 
            // 缩放ToolStripMenuItem
            // 
            this.缩放ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15,
            this.toolStripSeparator11,
            this.toolStripMenuItem16,
            this.toolStripSeparator12,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18,
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.toolStripSeparator13,
            this.放大显示ToolStripMenuItem,
            this.缩小显示ToolStripMenuItem,
            this.适应屏幕ToolStripMenuItem});
            this.缩放ToolStripMenuItem.Name = "缩放ToolStripMenuItem";
            this.缩放ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
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
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(182, 34);
            this.toolStripMenuItem16.Text = "100%";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(179, 6);
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
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(179, 6);
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
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(303, 6);
            // 
            // 垂直翻转ToolStripMenuItem
            // 
            this.垂直翻转ToolStripMenuItem.Name = "垂直翻转ToolStripMenuItem";
            this.垂直翻转ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.垂直翻转ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.垂直翻转ToolStripMenuItem.Text = "垂直翻转";
            this.垂直翻转ToolStripMenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // 水平翻转ToolStripMenuItem
            // 
            this.水平翻转ToolStripMenuItem.Name = "水平翻转ToolStripMenuItem";
            this.水平翻转ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.水平翻转ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.水平翻转ToolStripMenuItem.Text = "水平翻转";
            this.水平翻转ToolStripMenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);
            // 
            // 旋转90ToolStripMenuItem
            // 
            this.旋转90ToolStripMenuItem.Name = "旋转90ToolStripMenuItem";
            this.旋转90ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.旋转90ToolStripMenuItem.Text = "旋转90°";
            this.旋转90ToolStripMenuItem.Click += new System.EventHandler(this.旋转90ToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(303, 6);
            // 
            // 裁剪ToolStripMenuItem
            // 
            this.裁剪ToolStripMenuItem.Name = "裁剪ToolStripMenuItem";
            this.裁剪ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.裁剪ToolStripMenuItem.Text = "裁剪";
            this.裁剪ToolStripMenuItem.Click += new System.EventHandler(this.裁剪ToolStripMenuItem_Click);
            // 
            // 图层ToolStripMenuItem
            // 
            this.图层ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.图层ToolStripMenuItem.Name = "图层ToolStripMenuItem";
            this.图层ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.图层ToolStripMenuItem.Text = "图层[&L]";
            // 
            // 文字ToolStripMenuItem
            // 
            this.文字ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文字ToolStripMenuItem.Name = "文字ToolStripMenuItem";
            this.文字ToolStripMenuItem.Size = new System.Drawing.Size(85, 28);
            this.文字ToolStripMenuItem.Text = "文字[&Y]";
            this.文字ToolStripMenuItem.Click += new System.EventHandler(this.文字ToolStripMenuItem_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在新更改文档中打开ToolStripMenuItem,
            this.记住变化ToolStripMenuItem});
            this.选择ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.选择ToolStripMenuItem.Text = "选择[&S]";
            // 
            // 在新更改文档中打开ToolStripMenuItem
            // 
            this.在新更改文档中打开ToolStripMenuItem.Name = "在新更改文档中打开ToolStripMenuItem";
            this.在新更改文档中打开ToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.在新更改文档中打开ToolStripMenuItem.Text = "在新更改文档中打开";
            this.在新更改文档中打开ToolStripMenuItem.Click += new System.EventHandler(this.在新更改文档中打开ToolStripMenuItem_Click);
            // 
            // 记住变化ToolStripMenuItem
            // 
            this.记住变化ToolStripMenuItem.Name = "记住变化ToolStripMenuItem";
            this.记住变化ToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.记住变化ToolStripMenuItem.Text = "记住变化";
            this.记住变化ToolStripMenuItem.Click += new System.EventHandler(this.记住变化ToolStripMenuItem_Click);
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
            this.toolStripSeparator14,
            this.大小ToolStripMenuItem,
            this.旋转ToolStripMenuItem,
            this.toolStripSeparator15,
            this.层次ToolStripMenuItem,
            this.中位数ToolStripMenuItem,
            this.伽玛校正ToolStripMenuItem,
            this.toolStripSeparator16,
            this.傅里叶变换ToolStripMenuItem});
            this.滤镜ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.滤镜ToolStripMenuItem.Name = "滤镜ToolStripMenuItem";
            this.滤镜ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.滤镜ToolStripMenuItem.Text = "滤镜[&T]";
            // 
            // 颜色ToolStripMenuItem
            // 
            this.颜色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.灰度ToolStripMenuItem,
            this.灰度到RGBToolStripMenuItem,
            this.toolStripSeparator17,
            this.棕褐色ToolStripMenuItem,
            this.toolStripSeparator18,
            this.反色ToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.toolStripSeparator19,
            this.滤色ToolStripMenuItem,
            this.欧几里得颜色滤波ToolStripMenuItem,
            this.通道滤波ToolStripMenuItem,
            this.toolStripSeparator20,
            this.提取红色通道ToolStripMenuItem,
            this.提取红色通道ToolStripMenuItem1,
            this.提取红色通道ToolStripMenuItem2,
            this.toolStripSeparator21,
            this.更换红色通道ToolStripMenuItem,
            this.更换红色通道ToolStripMenuItem1,
            this.更换红色通道ToolStripMenuItem2,
            this.toolStripSeparator22,
            this.红ToolStripMenuItem,
            this.绿ToolStripMenuItem,
            this.蓝ToolStripMenuItem,
            this.青色ToolStripMenuItem,
            this.洋红色ToolStripMenuItem,
            this.黄色ToolStripMenuItem});
            this.颜色ToolStripMenuItem.Name = "颜色ToolStripMenuItem";
            this.颜色ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.颜色ToolStripMenuItem.Text = "颜色";
            // 
            // 灰度ToolStripMenuItem
            // 
            this.灰度ToolStripMenuItem.Name = "灰度ToolStripMenuItem";
            this.灰度ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.灰度ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.灰度ToolStripMenuItem.Text = "灰度";
            this.灰度ToolStripMenuItem.Click += new System.EventHandler(this.灰度ToolStripMenuItem_Click);
            // 
            // 灰度到RGBToolStripMenuItem
            // 
            this.灰度到RGBToolStripMenuItem.Name = "灰度到RGBToolStripMenuItem";
            this.灰度到RGBToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.灰度到RGBToolStripMenuItem.Text = "灰度到RGB";
            this.灰度到RGBToolStripMenuItem.Click += new System.EventHandler(this.灰度到RGBToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(353, 6);
            // 
            // 棕褐色ToolStripMenuItem
            // 
            this.棕褐色ToolStripMenuItem.Name = "棕褐色ToolStripMenuItem";
            this.棕褐色ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.棕褐色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.棕褐色ToolStripMenuItem.Text = "棕褐色";
            this.棕褐色ToolStripMenuItem.Click += new System.EventHandler(this.棕褐色ToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(353, 6);
            // 
            // 反色ToolStripMenuItem
            // 
            this.反色ToolStripMenuItem.Name = "反色ToolStripMenuItem";
            this.反色ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.反色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.反色ToolStripMenuItem.Text = "反色";
            this.反色ToolStripMenuItem.Click += new System.EventHandler(this.反色ToolStripMenuItem_Click_1);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(353, 6);
            // 
            // 滤色ToolStripMenuItem
            // 
            this.滤色ToolStripMenuItem.Name = "滤色ToolStripMenuItem";
            this.滤色ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.滤色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.滤色ToolStripMenuItem.Text = "滤色";
            this.滤色ToolStripMenuItem.Click += new System.EventHandler(this.滤色ToolStripMenuItem_Click);
            // 
            // 欧几里得颜色滤波ToolStripMenuItem
            // 
            this.欧几里得颜色滤波ToolStripMenuItem.Name = "欧几里得颜色滤波ToolStripMenuItem";
            this.欧几里得颜色滤波ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.欧几里得颜色滤波ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.欧几里得颜色滤波ToolStripMenuItem.Text = "欧几里得颜色滤波";
            this.欧几里得颜色滤波ToolStripMenuItem.Click += new System.EventHandler(this.欧几里得颜色滤波ToolStripMenuItem_Click);
            // 
            // 通道滤波ToolStripMenuItem
            // 
            this.通道滤波ToolStripMenuItem.Name = "通道滤波ToolStripMenuItem";
            this.通道滤波ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.通道滤波ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.通道滤波ToolStripMenuItem.Text = "通道滤波";
            this.通道滤波ToolStripMenuItem.Click += new System.EventHandler(this.通道滤波ToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(353, 6);
            // 
            // 提取红色通道ToolStripMenuItem
            // 
            this.提取红色通道ToolStripMenuItem.Name = "提取红色通道ToolStripMenuItem";
            this.提取红色通道ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.提取红色通道ToolStripMenuItem.Text = "提取红色通道";
            this.提取红色通道ToolStripMenuItem.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem_Click);
            // 
            // 提取红色通道ToolStripMenuItem1
            // 
            this.提取红色通道ToolStripMenuItem1.Name = "提取红色通道ToolStripMenuItem1";
            this.提取红色通道ToolStripMenuItem1.Size = new System.Drawing.Size(356, 34);
            this.提取红色通道ToolStripMenuItem1.Text = "提取绿色通道";
            this.提取红色通道ToolStripMenuItem1.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem1_Click);
            // 
            // 提取红色通道ToolStripMenuItem2
            // 
            this.提取红色通道ToolStripMenuItem2.Name = "提取红色通道ToolStripMenuItem2";
            this.提取红色通道ToolStripMenuItem2.Size = new System.Drawing.Size(356, 34);
            this.提取红色通道ToolStripMenuItem2.Text = "提取蓝色通道";
            this.提取红色通道ToolStripMenuItem2.Click += new System.EventHandler(this.提取红色通道ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(353, 6);
            // 
            // 更换红色通道ToolStripMenuItem
            // 
            this.更换红色通道ToolStripMenuItem.Name = "更换红色通道ToolStripMenuItem";
            this.更换红色通道ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.更换红色通道ToolStripMenuItem.Text = "更换红色通道";
            this.更换红色通道ToolStripMenuItem.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem_Click);
            // 
            // 更换红色通道ToolStripMenuItem1
            // 
            this.更换红色通道ToolStripMenuItem1.Name = "更换红色通道ToolStripMenuItem1";
            this.更换红色通道ToolStripMenuItem1.Size = new System.Drawing.Size(356, 34);
            this.更换红色通道ToolStripMenuItem1.Text = "更换绿色通道";
            this.更换红色通道ToolStripMenuItem1.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem1_Click);
            // 
            // 更换红色通道ToolStripMenuItem2
            // 
            this.更换红色通道ToolStripMenuItem2.Name = "更换红色通道ToolStripMenuItem2";
            this.更换红色通道ToolStripMenuItem2.Size = new System.Drawing.Size(356, 34);
            this.更换红色通道ToolStripMenuItem2.Text = "更换蓝色通道";
            this.更换红色通道ToolStripMenuItem2.Click += new System.EventHandler(this.更换红色通道ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(353, 6);
            // 
            // 红ToolStripMenuItem
            // 
            this.红ToolStripMenuItem.Name = "红ToolStripMenuItem";
            this.红ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.红ToolStripMenuItem.Text = "红色";
            this.红ToolStripMenuItem.Click += new System.EventHandler(this.红ToolStripMenuItem_Click);
            // 
            // 绿ToolStripMenuItem
            // 
            this.绿ToolStripMenuItem.Name = "绿ToolStripMenuItem";
            this.绿ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.绿ToolStripMenuItem.Text = "绿色";
            this.绿ToolStripMenuItem.Click += new System.EventHandler(this.绿ToolStripMenuItem_Click);
            // 
            // 蓝ToolStripMenuItem
            // 
            this.蓝ToolStripMenuItem.Name = "蓝ToolStripMenuItem";
            this.蓝ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.蓝ToolStripMenuItem.Text = "蓝色";
            this.蓝ToolStripMenuItem.Click += new System.EventHandler(this.蓝ToolStripMenuItem_Click);
            // 
            // 青色ToolStripMenuItem
            // 
            this.青色ToolStripMenuItem.Name = "青色ToolStripMenuItem";
            this.青色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.青色ToolStripMenuItem.Text = "青色";
            this.青色ToolStripMenuItem.Click += new System.EventHandler(this.青色ToolStripMenuItem_Click);
            // 
            // 洋红色ToolStripMenuItem
            // 
            this.洋红色ToolStripMenuItem.Name = "洋红色ToolStripMenuItem";
            this.洋红色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.洋红色ToolStripMenuItem.Text = "洋红色";
            this.洋红色ToolStripMenuItem.Click += new System.EventHandler(this.洋红色ToolStripMenuItem_Click);
            // 
            // 黄色ToolStripMenuItem
            // 
            this.黄色ToolStripMenuItem.Name = "黄色ToolStripMenuItem";
            this.黄色ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.黄色ToolStripMenuItem.Text = "黄色";
            this.黄色ToolStripMenuItem.Click += new System.EventHandler(this.黄色ToolStripMenuItem_Click);
            // 
            // hSL颜色空间ToolStripMenuItem
            // 
            this.hSL颜色空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.亮度ToolStripMenuItem,
            this.对比度ToolStripMenuItem,
            this.饱和度ToolStripMenuItem,
            this.toolStripSeparator23,
            this.HSL线性ToolStripMenuItem,
            this.hSL滤波ToolStripMenuItem,
            this.色调调节ToolStripMenuItem});
            this.hSL颜色空间ToolStripMenuItem.Name = "hSL颜色空间ToolStripMenuItem";
            this.hSL颜色空间ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.hSL颜色空间ToolStripMenuItem.Text = "HSL颜色空间";
            // 
            // 亮度ToolStripMenuItem
            // 
            this.亮度ToolStripMenuItem.Name = "亮度ToolStripMenuItem";
            this.亮度ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.亮度ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.亮度ToolStripMenuItem.Text = "亮度";
            this.亮度ToolStripMenuItem.Click += new System.EventHandler(this.亮度ToolStripMenuItem_Click);
            // 
            // 对比度ToolStripMenuItem
            // 
            this.对比度ToolStripMenuItem.Name = "对比度ToolStripMenuItem";
            this.对比度ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.对比度ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.对比度ToolStripMenuItem.Text = "对比度";
            this.对比度ToolStripMenuItem.Click += new System.EventHandler(this.对比度ToolStripMenuItem_Click);
            // 
            // 饱和度ToolStripMenuItem
            // 
            this.饱和度ToolStripMenuItem.Name = "饱和度ToolStripMenuItem";
            this.饱和度ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.饱和度ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.饱和度ToolStripMenuItem.Text = "饱和度";
            this.饱和度ToolStripMenuItem.Click += new System.EventHandler(this.饱和度ToolStripMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(317, 6);
            // 
            // HSL线性ToolStripMenuItem
            // 
            this.HSL线性ToolStripMenuItem.Name = "HSL线性ToolStripMenuItem";
            this.HSL线性ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.HSL线性ToolStripMenuItem.Text = "HSL线性";
            this.HSL线性ToolStripMenuItem.Click += new System.EventHandler(this.HSL线性ToolStripMenuItem_Click);
            // 
            // hSL滤波ToolStripMenuItem
            // 
            this.hSL滤波ToolStripMenuItem.Name = "hSL滤波ToolStripMenuItem";
            this.hSL滤波ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.hSL滤波ToolStripMenuItem.Text = "HSL滤波";
            this.hSL滤波ToolStripMenuItem.Click += new System.EventHandler(this.hSL滤波ToolStripMenuItem_Click);
            // 
            // 色调调节ToolStripMenuItem
            // 
            this.色调调节ToolStripMenuItem.Name = "色调调节ToolStripMenuItem";
            this.色调调节ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.色调调节ToolStripMenuItem.Text = "色调调节";
            this.色调调节ToolStripMenuItem.Click += new System.EventHandler(this.色调调节ToolStripMenuItem_Click);
            // 
            // yCbCr颜色空间ToolStripMenuItem
            // 
            this.yCbCr颜色空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yCbCr线性ToolStripMenuItem,
            this.yCbCr滤波ToolStripMenuItem,
            this.toolStripSeparator24,
            this.提取Y通道ToolStripMenuItem,
            this.提取Cb通道ToolStripMenuItem,
            this.提取Cr通道ToolStripMenuItem,
            this.toolStripSeparator25,
            this.更换Y通道ToolStripMenuItem,
            this.更换Cb通道ToolStripMenuItem,
            this.更换Cr通道ToolStripMenuItem});
            this.yCbCr颜色空间ToolStripMenuItem.Name = "yCbCr颜色空间ToolStripMenuItem";
            this.yCbCr颜色空间ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(203, 6);
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
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(203, 6);
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
            this.toolStripSeparator26,
            this.带错误进位的阈值ToolStripMenuItem,
            this.有序抖动ToolStripMenuItem,
            this.bayer有序抖动ToolStripMenuItem,
            this.toolStripSeparator27,
            this.弗洛伊德斯坦伯格抖动ToolStripMenuItem,
            this.伯克斯抖动ToolStripMenuItem,
            this.stucki抖动ToolStripMenuItem,
            this.jarvisJudiceNinke抖动ToolStripMenuItem,
            this.sierra抖动ToolStripMenuItem,
            this.stevensonAndArce抖动ToolStripMenuItem,
            this.toolStripSeparator28,
            this.sIS阈值ToolStripMenuItem});
            this.二值化ToolStripMenuItem.Name = "二值化ToolStripMenuItem";
            this.二值化ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.二值化ToolStripMenuItem.Text = "二值化";
            // 
            // 图像阈值ToolStripMenuItem
            // 
            this.图像阈值ToolStripMenuItem.Name = "图像阈值ToolStripMenuItem";
            this.图像阈值ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.图像阈值ToolStripMenuItem.Text = "图像阈值";
            this.图像阈值ToolStripMenuItem.Click += new System.EventHandler(this.图像阈值ToolStripMenuItem_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(312, 6);
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
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(312, 6);
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
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(312, 6);
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
            this.形态ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            this.卷积相关ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            this.双源滤波器ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            this.边缘检测器ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            this.toolStripSeparator29,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripSeparator30,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
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
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(215, 6);
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
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(215, 6);
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
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(272, 6);
            // 
            // 大小ToolStripMenuItem
            // 
            this.大小ToolStripMenuItem.Name = "大小ToolStripMenuItem";
            this.大小ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.大小ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.大小ToolStripMenuItem.Text = "大小";
            this.大小ToolStripMenuItem.Click += new System.EventHandler(this.大小ToolStripMenuItem_Click);
            // 
            // 旋转ToolStripMenuItem
            // 
            this.旋转ToolStripMenuItem.Name = "旋转ToolStripMenuItem";
            this.旋转ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.旋转ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.旋转ToolStripMenuItem.Text = "旋转";
            this.旋转ToolStripMenuItem.Click += new System.EventHandler(this.旋转ToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(272, 6);
            // 
            // 层次ToolStripMenuItem
            // 
            this.层次ToolStripMenuItem.Name = "层次ToolStripMenuItem";
            this.层次ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.层次ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.层次ToolStripMenuItem.Text = "色阶";
            this.层次ToolStripMenuItem.Click += new System.EventHandler(this.层次ToolStripMenuItem_Click);
            // 
            // 中位数ToolStripMenuItem
            // 
            this.中位数ToolStripMenuItem.Name = "中位数ToolStripMenuItem";
            this.中位数ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.中位数ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.中位数ToolStripMenuItem.Text = "中位数";
            this.中位数ToolStripMenuItem.Click += new System.EventHandler(this.中位数ToolStripMenuItem_Click);
            // 
            // 伽玛校正ToolStripMenuItem
            // 
            this.伽玛校正ToolStripMenuItem.Name = "伽玛校正ToolStripMenuItem";
            this.伽玛校正ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.伽玛校正ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.伽玛校正ToolStripMenuItem.Text = "伽玛校正";
            this.伽玛校正ToolStripMenuItem.Click += new System.EventHandler(this.伽玛校正ToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(272, 6);
            // 
            // 傅里叶变换ToolStripMenuItem
            // 
            this.傅里叶变换ToolStripMenuItem.Name = "傅里叶变换ToolStripMenuItem";
            this.傅里叶变换ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.傅里叶变换ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.傅里叶变换ToolStripMenuItem.Text = "傅里叶变换";
            this.傅里叶变换ToolStripMenuItem.Click += new System.EventHandler(this.傅里叶变换ToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(77, 28);
            this.dToolStripMenuItem.Text = "3D[&D]";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.直方图ToolStripMenuItem,
            this.统计ToolStripMenuItem,
            this.rToolStripMenuItem,
            this.gToolStripMenuItem,
            this.bToolStripMenuItem,
            this.中央ToolStripMenuItem,
            this.toolStripSeparator31,
            this.拍照ToolStripMenuItem});
            this.视图ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.视图ToolStripMenuItem.Text = "视图[&V]";
            // 
            // 直方图ToolStripMenuItem
            // 
            this.直方图ToolStripMenuItem.Name = "直方图ToolStripMenuItem";
            this.直方图ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.直方图ToolStripMenuItem.Text = "直方图";
            this.直方图ToolStripMenuItem.Click += new System.EventHandler(this.直方图ToolStripMenuItem_Click);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.统计ToolStripMenuItem.Text = "统计";
            this.统计ToolStripMenuItem.Click += new System.EventHandler(this.统计ToolStripMenuItem_Click);
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.rToolStripMenuItem.Text = "R";
            this.rToolStripMenuItem.Visible = false;
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.gToolStripMenuItem.Text = "G";
            this.gToolStripMenuItem.Visible = false;
            this.gToolStripMenuItem.Click += new System.EventHandler(this.gToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.bToolStripMenuItem.Text = "B";
            this.bToolStripMenuItem.Visible = false;
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // 中央ToolStripMenuItem
            // 
            this.中央ToolStripMenuItem.Name = "中央ToolStripMenuItem";
            this.中央ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.中央ToolStripMenuItem.Text = "中央";
            this.中央ToolStripMenuItem.Click += new System.EventHandler(this.中央ToolStripMenuItem_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(161, 6);
            // 
            // 拍照ToolStripMenuItem
            // 
            this.拍照ToolStripMenuItem.Name = "拍照ToolStripMenuItem";
            this.拍照ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.拍照ToolStripMenuItem.Text = "拍照";
            this.拍照ToolStripMenuItem.Click += new System.EventHandler(this.拍照ToolStripMenuItem_Click);
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.窗口ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(92, 28);
            this.窗口ToolStripMenuItem.Text = "窗口[&W]";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoShop帮助ToolStripMenuItem,
            this.photoShop教程ToolStripMenuItem,
            this.toolStripSeparator7,
            this.系统信息ToolStripMenuItem,
            this.与作者联系ToolStripMenuItem});
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(88, 28);
            this.帮助ToolStripMenuItem.Text = "帮助[&H]";
            // 
            // photoShop帮助ToolStripMenuItem
            // 
            this.photoShop帮助ToolStripMenuItem.Name = "photoShop帮助ToolStripMenuItem";
            this.photoShop帮助ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.photoShop帮助ToolStripMenuItem.Text = "PhotoShop帮助";
            this.photoShop帮助ToolStripMenuItem.Click += new System.EventHandler(this.photoShop帮助ToolStripMenuItem_Click);
            // 
            // photoShop教程ToolStripMenuItem
            // 
            this.photoShop教程ToolStripMenuItem.Name = "photoShop教程ToolStripMenuItem";
            this.photoShop教程ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.photoShop教程ToolStripMenuItem.Text = "PhotoShop教程";
            this.photoShop教程ToolStripMenuItem.Click += new System.EventHandler(this.photoShop教程ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(238, 6);
            // 
            // 系统信息ToolStripMenuItem
            // 
            this.系统信息ToolStripMenuItem.Name = "系统信息ToolStripMenuItem";
            this.系统信息ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.系统信息ToolStripMenuItem.Text = "系统信息";
            this.系统信息ToolStripMenuItem.Click += new System.EventHandler(this.系统信息ToolStripMenuItem_Click);
            // 
            // 与作者联系ToolStripMenuItem
            // 
            this.与作者联系ToolStripMenuItem.Name = "与作者联系ToolStripMenuItem";
            this.与作者联系ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.与作者联系ToolStripMenuItem.Text = "与作者联系...";
            this.与作者联系ToolStripMenuItem.Click += new System.EventHandler(this.与作者联系ToolStripMenuItem_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.ErrorImage")));
            this.pictureBox6.ImageLocation = "1162, 0";
            this.pictureBox6.Location = new System.Drawing.Point(2040, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(44, 28);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(2127, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.ErrorImage")));
            this.pictureBox4.ImageLocation = "1162, 0";
            this.pictureBox4.Location = new System.Drawing.Point(2126, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 28);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(2081, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(50, 27);
            this.btnMax.TabIndex = 10;
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.ErrorImage")));
            this.pictureBox5.ImageLocation = "1162, 0";
            this.pictureBox5.Location = new System.Drawing.Point(2079, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 28);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.panel1);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 36);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(2186, 1404);
            this.panel19.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2186, 1440);
            this.Controls.Add(this.panel19);
            this.Controls.Add(this.panel18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Image Processing Lab";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hslPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ycbcrPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoPanel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelThird.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.plSecond.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.plToolFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel19.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region IDocumentsHost implementation

		// Create new document on change on existent or modify it
		public bool CreateNewDocumentOnChange
		{
			get { return config.openInNewDoc; }
		}

		// Remember or not an image, so we can back one step
		public bool RememberOnChange
		{
			get { return config.rememberOnChange; }
		}

		// Create new document
		public bool NewDocument(Bitmap image)
		{
			unnamedNumber++;

			ImageDoc imgDoc = new ImageDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			// set events
			SetupDocumentEvents(imgDoc);

			return true;
		}

		// Create new document for ComplexImage
		public bool NewDocument(ComplexImage image)
		{
			unnamedNumber++;

			FourierDoc imgDoc = new FourierDoc(image, (IDocumentsHost) this);

			imgDoc.Text = "Image " + unnamedNumber.ToString();
			imgDoc.Show(dockManager);
			imgDoc.Focus();

			return true;
		}

		// Get an image with specified dimension and pixel format
		public Bitmap GetImage(object sender, String text, Size size, PixelFormat format)
		{
			ArrayList	names = new ArrayList();
			ArrayList	images = new ArrayList();

			foreach (Content doc in dockManager.Documents)
			{
				if ((doc != sender) && (doc is ImageDoc))
				{
					Bitmap img = ((ImageDoc) doc).Image;

					// check pixel format, width and height
					if ((img.PixelFormat == format) &&
						((size.Width == -1) ||
						((img.Width == size.Width) && (img.Height == size.Height))))
					{
						names.Add(doc.Text);
						images.Add(img);
					}
				}
			}

			SelectImageForm form = new SelectImageForm();

			form.Description = text;
			form.ImageNames = names;

			// allow user to select an image
			if ((form.ShowDialog() == DialogResult.OK) && (form.SelectedItem != -1))
			{
				return (Bitmap) images[form.SelectedItem];
			}

			return null;
		}

		#endregion

		// On form closing
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// close all files
			foreach (Content c in dockManager.Documents)
				c.Close();

			// save configuration
			config.mainWindowLocation = this.Location;
			config.mainWindowSize = this.Size;
			config.Save(configFile);
			// save dock manager configuration
			dockManager.SaveAsXml(dockManagerConfigFile);
		}

		// On form load
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// load configuration
			if (config.Load(configFile))
			{
				this.Location = config.mainWindowLocation;
				this.Size = config.mainWindowSize;
			}

			try
			{
				// load dock manager configuration
				if (File.Exists(dockManagerConfigFile))
					dockManager.LoadFromXml(dockManagerConfigFile, new GetContentCallback(GetContentFromPersistString));
			}
			catch (Exception)
			{
			}

			// show histogram
			ShowHistogram(config.histogramVisible);
            UserControl2 uch = new UserControl2();
            uch.Dock = DockStyle.Fill;
            panel20.Controls.Clear();
            panel20.Controls.Add(uch);
            UC_Movetool uch1 = new UC_Movetool();
            AddControlsToPanel(uch1);
            btnColor.BackColor = Color.FromArgb(83, 83, 83);
            
        }

		// Callback for loading Dock Manager
		private Content GetContentFromPersistString(string persistString)
		{
			if (persistString == typeof(HistogramWindow).ToString())
				return histogramWin;
			if (persistString == typeof(ImageStatisticsWindow).ToString())
				return statisticsWin;

			return null;
		}

		// Main tool bar clicked


		// active document changed
		private void dockManager_ActiveDocumentChanged(object sender, System.EventArgs e)
		{
			Content		doc = dockManager.ActiveDocument;
			ImageDoc	imgDoc = (doc is ImageDoc) ? (ImageDoc) doc : null;

			UpdateHistogram(imgDoc);
			UpdateStatistics(imgDoc);
			UpdateZoomStatus(imgDoc);

			UpdateSizeStatus(doc);
		}

		private void fileItem_Popup(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;
			bool	docOpened = (doc != null);

			//closeFileItem.Enabled = docOpened;
			//closeAllFileItem.Enabled = (dockManager.Documents.Length > 0);
			//reloadFileItem.Enabled = ((docOpened) && (doc is ImageDoc) && (((ImageDoc) doc).FileName != null));

			//saveFileItem.Enabled = docOpened;
			//copyFileItem.Enabled = docOpened;
			//pasteFileItem.Enabled = (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap));

			//printFileItem.Enabled = docOpened;
			//printPreviewFileItem.Enabled = docOpened;
		}

		// Exit application
		private void exitFileItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		// Setup events
		private void SetupDocumentEvents(ImageDoc doc)
		{
			doc.DocumentChanged += new System.EventHandler(this.document_DocumentChanged);
			doc.ZoomChanged += new System.EventHandler(this.document_ZoomChanged);
			doc.MouseImagePosition += new ImageDoc.SelectionEventHandler(this.document_MouseImagePosition);
			doc.SelectionChanged += new ImageDoc.SelectionEventHandler(this.document_SelectionChanged);
		}
		private string _fileName;
		public string fileName
		{
			get { return this._fileName; }
			set { this._fileName = value; }
		}
		// Open file
		public void OpenFile()
		{
			
			ImageDoc imgDoc = null;
				
			try
			{
				// create image document
				imgDoc = new ImageDoc(fileName, (IDocumentsHost) this,this);
				imgDoc.Text = Path.GetFileName(fileName);
                
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (imgDoc != null)
			{
				imgDoc.Show(dockManager);
				imgDoc.Focus();
                // set events
                SetupDocumentEvents(imgDoc);
			}
		}

		// Show/hide histogram
		private void ShowHistogram(bool show)
		{
			config.histogramVisible = show;

			//histogramViewItem.Checked = show;
			//histogramButton.Pushed = show;

			if (show)
			{
				histogramWin.Show(dockManager);
			}
			else
			{
				histogramWin.Hide();
			}
		}

		// Show/hide statistics
		private void ShowStatistics(bool show)
		{
			config.statisticsVisible = show;

			//statisticsViewItem.Checked = show;

			if ( show )
			{
				statisticsWin.Show( dockManager );
			}
			else
			{
				statisticsWin.Hide( );
			}
		}



		// On "File->Open" item clicked
		private void OpenItem_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}

		// Reload file
		private void reloadFileItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
			{
				try
				{
					((ImageDoc) doc).Reload();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Save file
		private void SaveFile()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				// set initial file name
				if ((doc is ImageDoc) && (((ImageDoc) doc).FileName != null))
				{
					sfd.FileName = Path.GetFileName(((ImageDoc) doc).FileName);
				}
				else
				{
					sfd.FileName = doc.Text + ".jpg";
				}

				sfd.FilterIndex = 0;

				// show dialog
				if (sfd.ShowDialog(this) == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Jpeg;

					// resolve file format
					switch (Path.GetExtension(sfd.FileName).ToLower())
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						default:
							MessageBox.Show(this, "Unsupported image format was specified", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
					}

					// save the image
					try
					{
						if (doc is ImageDoc)
						{
							((ImageDoc) doc).Image.Save(sfd.FileName, format);
						}
						if (doc is FourierDoc)
						{
							((FourierDoc) doc).Image.Save(sfd.FileName, format);
						}
					}
					catch (Exception)
					{
						MessageBox.Show(this, "Failed writing image file", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		// On "File->Save" - save the file
		private void saveFileItem_Click(object sender, System.EventArgs e)
		{
			SaveFile();
		}

		// Copy image to clipboard
		private void CopyToClipboard()
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					Clipboard.SetDataObject(((ImageDoc) doc).Image, true);
				}
				if (doc is FourierDoc)
				{
					Clipboard.SetDataObject(((FourierDoc) doc).Image, true);
				}
			}
		}

		// On "File->Copy" - copy image to clipboard
		private void copyFileItem_Click(object sender, System.EventArgs e)
		{
			CopyToClipboard();
		}

		// Paste image from clipboard
		private void PasteFromClipboard()
		{
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Bitmap))
			{
				ImageDoc imgDoc = new ImageDoc((Bitmap) Clipboard.GetDataObject().GetData(DataFormats.Bitmap), (IDocumentsHost) this);

				imgDoc.Text = "Image " + unnamedNumber.ToString();
				imgDoc.Show(dockManager);
				imgDoc.Focus();

				// set events
				SetupDocumentEvents(imgDoc);
			}
		}

		// On "File->Paste" - paste image from clipboard
		private void pasteFileItem_Click(object sender, System.EventArgs e)
		{
			PasteFromClipboard();
		}

		// Close file
		private void closeFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
				dockManager.ActiveDocument.Close();
		}

		// Close all files
		private void closeAllFileItem_Click(object sender, System.EventArgs e)
		{
			foreach (Content c in dockManager.Documents)
				c.Close();
		}

		// Page setup
		private void pageSetupFileItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				pageSetupDialog.Document = printDocument;
				pageSetupDialog.ShowDialog();
			}
			catch (InvalidPrinterException)
			{
				MessageBox.Show(this, "Failed accessing printer device", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Print image
		private void printFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printDialog.Document = printDocument;
					if (printDialog.ShowDialog() == DialogResult.OK)
					{
						printDocument.Print();
					}
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		// Print preview
		private void printPreviewFileItem_Click(object sender, System.EventArgs e)
		{
			if (dockManager.ActiveDocument != null)
			{
				try
				{
					printPreviewDialog.Document = printDocument;
					printPreviewDialog.ShowDialog();
				}
				catch (InvalidPrinterException)
				{
					MessageBox.Show(this, "Failed accessing printer device", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}		
		}

		// On "Options" popup
		private void optionsItem_Popup(object sender, System.EventArgs e)
		{
			this.在新更改文档中打开ToolStripMenuItem.Checked = config.openInNewDoc;
			this.记住变化ToolStripMenuItem.Checked = config.rememberOnChange;
		}

		// On "Options->Open in new Document" click
		private void openInNewOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.openInNewDoc = !config.openInNewDoc;
		}

		// On "Options->Remember on change" click
		private void rememberOptionsItem_Click(object sender, System.EventArgs e)
		{
			config.rememberOnChange = !config.rememberOnChange;
		}

		// On "View" popup
		private void viewItem_Popup(object sender, System.EventArgs e)
		{
			//centerViewItem.Enabled = ((dockManager.ActiveDocument != null) && (dockManager.ActiveDocument is ImageDoc));

			//ToolBarDockHolder holder;
			// Main tool bar
			//holder = toolBarManager.GetHolder(mainToolBar);
			//mainBarViewItem.Checked = holder.Visible;
			// Image tool bar
			//holder = toolBarManager.GetHolder(imageToolBar);
			//imageBarViewItem.Checked = holder.Visible;
		}

		// On "View->Histogram" - show histogram
		private void histogramViewItem_Click(object sender, System.EventArgs e)
		{
			ShowHistogram( !config.histogramVisible );
		}

		// On "View->Statistics" - show histogram
		private void statisticsViewItem_Click(object sender, System.EventArgs e)
		{
			ShowStatistics( !config.statisticsVisible );
		}

		// Histogram visibility changed		
		private void histogram_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.Visible )
				histogramWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// Statistics visibility changed		
		private void statistics_VisibleChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.Visible )
				statisticsWin.GatherStatistics( ( ( dockManager.ActiveDocument == null ) || !( dockManager.ActiveDocument is ImageDoc ) ) ? null : ((ImageDoc) dockManager.ActiveDocument).Image );
		}

		// On "View->Center" - center image
		private void centerViewItem_Click(object sender, System.EventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if ((doc != null) && (doc is ImageDoc))
				((ImageDoc) doc).Center();
		}

		// Switch histogram to red channel
		private void redHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(0);
		}

		// Switch histogram to green channel
		private void greenHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(1);
		}

		// Switch histogram to blue channel
		private void blueHistogramViewItem_Click(object sender, System.EventArgs e)
		{
			if (histogramWin.Visible)
				histogramWin.SwitchChannel(2);
		}

		// On document changed
		private void document_DocumentChanged(object sender, System.EventArgs e)
		{
			UpdateHistogram((ImageDoc) sender);
			UpdateStatistics((ImageDoc) sender);
			UpdateSizeStatus((ImageDoc) sender);
		}

		// On zoom factor changed
		private void document_ZoomChanged(object sender, System.EventArgs e)
		{
			UpdateZoomStatus((ImageDoc) sender);
		}

		// On mouse position over image changed
		private void document_MouseImagePosition(object sender, SelectionEventArgs e)
		{
			if (e.Location.X >= 0)
			{
				this.selectionPanel.Text = string.Format( "({0}, {1})", e.Location.X, e.Location.Y );

				// get current color
				Bitmap image = ((ImageDoc) sender).Image;
				if (image.PixelFormat == PixelFormat.Format24bppRgb)
				{
					Color	color = image.GetPixel(e.Location.X, e.Location.Y);
					RGB		rgb = new RGB( color );
                    YCbCr ycbcr = new YCbCr( );

					AForge.Imaging.ColorConverter.RGB2YCbCr( rgb, ycbcr );
                    
					// RGB
					this.colorPanel.Text = string.Format( "RGB: {0}; {1}; {2}", color.R, color.G, color.B );
					// HSL
					this.hslPanel.Text = string.Format( "HSL: {0}; {1:F3}; {2:F3}", (int) color.GetHue(), color.GetSaturation(), color.GetBrightness() );
					// YCbCr
					this.ycbcrPanel.Text = string.Format( "YCbCr: {0:F3}; {1:F3}; {2:F3}", ycbcr.Y, ycbcr.Cb, ycbcr.Cr );
				}
				else if (image.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					Color color = image.GetPixel(e.Location.X, e.Location.Y);
					this.colorPanel.Text	= "Gray: " + color.R.ToString();
					this.hslPanel.Text		= "";
					this.ycbcrPanel.Text	= "";
				}
			}
			else
			{
				this.selectionPanel.Text	= "";
				this.colorPanel.Text		= "";
				this.hslPanel.Text			= "";
				this.ycbcrPanel.Text		= "";
			}
		}

		// On selection changed
		private void document_SelectionChanged(object sender, SelectionEventArgs e)
		{
			this.selectionPanel.Text = string.Format( "({0}, {1}) - {2} x {3}", e.Location.X, e.Location.Y, e.Size.Width, e.Size.Height );
		}

		// Update histogram
		private void UpdateHistogram(ImageDoc imgDoc)
		{
			if ( histogramWin.Visible )
				histogramWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

		private void UpdateStatistics( ImageDoc imgDoc )
		{
			if ( statisticsWin.Visible )
				statisticsWin.GatherStatistics( ( imgDoc == null ) ? null : imgDoc.Image );
		}

		// Update size status
		private void UpdateSizeStatus(Content doc)
		{
			if (doc != null)
			{
				int w = 0, h = 0;

				if (doc is ImageDoc)
				{
					w = ((ImageDoc) doc).ImageWidth;
					h = ((ImageDoc) doc).ImageHeight;
				}
				else if (doc is FourierDoc)
				{
					w = ((FourierDoc) doc).ImageWidth;
					h = ((FourierDoc) doc).ImageHeight;
				}

				sizePanel.Text = w.ToString() + " x " + h.ToString();
			}
			else
			{
				sizePanel.Text = String.Empty;
			}
		}

		// Update zoom status
		private void UpdateZoomStatus(ImageDoc imgDoc)
		{
			if (imgDoc != null)
			{
				int zoom = (int)(imgDoc.Zoom * 100);
				zoomPanel.Text = zoom.ToString() + "%";
			}
			else
			{
				zoomPanel.Text = String.Empty;
			}
		}

		// On image toolbar clicked
		private void imageToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				if (doc is ImageDoc)
				{
					ImageDocCommands[] cmd = new ImageDocCommands[]
					{
						ImageDocCommands.Clone, ImageDocCommands.Crop,
						ImageDocCommands.ZoomIn, ImageDocCommands.ZoomOut,
						ImageDocCommands.ZoomOriginal, ImageDocCommands.FitToSize,
						ImageDocCommands.Levels, ImageDocCommands.Grayscale,
						ImageDocCommands.Threshold, ImageDocCommands.Morphology,
						ImageDocCommands.Convolution, ImageDocCommands.Resize,
						ImageDocCommands.Rotate, ImageDocCommands.Saturation,
						ImageDocCommands.Fourier
					};

					((ImageDoc) doc).ExecuteCommand(cmd[e.Button.ImageIndex]);
				}
			}
		}

		// On "View->Main Tool bar" menu item click


		// On "View->Image Tool bar" menu item click
		private void imageBarViewItem_Click(object sender, System.EventArgs e)
		{
			//ToolBarDockHolder holder = toolBarManager.GetHolder(imageToolBar);
			//toolBarManager.ShowControl(imageToolBar, !holder.Visible);
		}

		// Histogram docking state changed
		private void histogram_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( histogramWin.DockState != DockState.Unknown )
			{
				bool visible = (histogramWin.DockState != DockState.Hidden);

				// save to config
				config.histogramVisible = visible;

				// update menu & tool bar
				//histogramViewItem.Checked = visible;
				//histogramButton.Pushed = visible;
			}
		}

		// Statistics docking state changed
		private void statistics_DockStateChanged(object sender, System.EventArgs e)
		{
			if ( statisticsWin.DockState != DockState.Unknown )
			{
				bool visible = (statisticsWin.DockState != DockState.Hidden);

				// save to config
				config.statisticsVisible = visible;

				// update menu & tool bar
				//statisticsViewItem.Checked = visible;
			}
		}

		// Print document page
		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Content	doc = dockManager.ActiveDocument;

			if (doc != null)
			{
				Bitmap image = null;

				// get an image to print
				if (doc is ImageDoc)
				{
					image = ((ImageDoc) doc).Image;
				}
				else if (doc is FourierDoc)
				{
					image = ((FourierDoc) doc).Image;
				}

				System.Diagnostics.Debug.WriteLine("X: " + e.MarginBounds.Left + ", Y = " + e.MarginBounds.Top + ", width = " + e.MarginBounds.Width + ", height = " + e.MarginBounds.Height);
				System.Diagnostics.Debug.WriteLine("X: " + e.PageBounds.Left + ", Y = " + e.PageBounds.Top + ", width = " + e.PageBounds.Width + ", height = " + e.PageBounds.Height);

				int		width = image.Width;
				int		height = image.Height;

				if ((width > e.MarginBounds.Width) || (height > e.MarginBounds.Height))
				{
					float f = Math.Min((float) e.MarginBounds.Width / width, (float) e.MarginBounds.Height / height);

					width = (int)(f * width);
					height = (int)(f * height);
				}

				e.Graphics.DrawImage(image, e.MarginBounds.Left, e.MarginBounds.Top, width, height);
			}
		}


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImageDoc imgDoc = null;

                try
                {
                    // create image document
                    imgDoc = new ImageDoc(ofd.FileName, (IDocumentsHost)this,this);
                    imgDoc.Text = Path.GetFileName(ofd.FileName);

                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (imgDoc != null)
                {
                    imgDoc.Show(dockManager);
                    imgDoc.Focus();
                    // set events
                    SetupDocumentEvents(imgDoc);
                }
            }
        }
        
        private void btnMax_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            if (frm2.WindowState == FormWindowState.Normal)
            {
                frm2.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                frm2.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Minimized;
        }
        
        public event MenuEventHandler MenuEvent;

        private void 灰度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("灰度");
            }
        }
        

        private void 重新加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Content doc = dockManager.ActiveDocument;

            if ((doc != null) && (doc is ImageDoc))
            {
                try
                {
                    ((ImageDoc)doc).Reload();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFromClipboard();
        }

        private void 关闭当前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
                dockManager.ActiveDocument.Close();
        }

        private void 关闭所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Content c in dockManager.Documents)
                c.Close();
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pageSetupDialog.Document = printDocument;
                pageSetupDialog.ShowDialog();
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show(this, "Failed accessing printer device", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
            {
                try
                {
                    printDialog.Document = printDocument;
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show(this, "Failed accessing printer device", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
            {
                try
                {
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.ShowDialog();
                }
                catch (InvalidPrinterException)
                {
                    MessageBox.Show(this, "Failed accessing printer device", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 灰度到RGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("灰度到RGB");
            }
        }

        private void 棕褐色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("棕褐色");
            }
        }



        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("Rotate");
            }
        }

        private void 滤色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("滤色");
            }
        }

        private void 欧几里得颜色滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("欧几里得颜色滤波");
            }
        }

        private void 通道滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("通道滤波");
            }
        }

        private void 提取红色通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取红色通道");
            }
        }

        private void 提取红色通道ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取绿色通道");
            }
        }

        private void 提取红色通道ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取蓝色通道");
            }
        }

        private void 更换红色通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换红色通道");
            }
        }

        private void 更换红色通道ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换绿色通道");
            }
        }

        private void 更换红色通道ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换蓝色通道");
            }
        }

        private void 红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("红色");
            }
        }

        private void 绿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("绿色");
            }
        }

        private void 蓝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("蓝色");
            }
        }

        private void 青色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("青色");
            }
        }

        private void 洋红色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("洋红色");
            }
        }

        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("黄色");
            }
        }

        private void 亮度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("亮度");
            }
        }

        private void 反色ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("反色");
            }
        }

        private void 对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("对比度");
            }
        }

        private void 饱和度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("饱和度");
            }
        }

        private void HSL线性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("HSL线性");
            }
        }

        private void hSL滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("HSL滤波");
            }
        }

        private void 色调调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("色调调节");
            }
        }

        private void yCbCr线性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("YCbCr线性");
            }
        }

        private void yCbCr滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("YCbCr滤波");
            }
        }

        private void 提取Y通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取Y通道");
            }
        }

        private void 提取Cb通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取Cb通道");
            }
        }

        private void 提取Cr通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("提取Cr通道");
            }
        }

        private void 更换Y通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换Y通道");
            }
        }

        private void 更换Cb通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换Cb通道");
            }
        }

        private void 更换Cr通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("更换Cr通道");
            }
        }

        private void 图像阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("图像阈值");
            }
        }

        private void 带错误进位的阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("带错误进位的阈值");
            }
        }

        private void 有序抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("有序抖动");
            }
        }

        private void bayer有序抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("bayer有序抖动");
            }
        }

        private void 弗洛伊德斯坦伯格抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("弗洛伊德斯坦伯格抖动");
            }
        }

        private void 伯克斯抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("伯克斯抖动");
            }
        }

        private void stucki抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("stucki抖动");
            }
        }

        private void jarvisJudiceNinke抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("jarvisJudiceNinke抖动");
            }
        }

        private void sierra抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("sierra抖动");
            }
        }

        private void stevensonAndArce抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("stevensonAndArce抖动");
            }
        }

        private void sIS阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("SIS阈值");
            }
        }

        private void 腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("腐蚀");
            }
        }

        private void 膨胀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("膨胀");
            }
        }

        private void 开运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("开运算");
            }
        }

        private void 闭运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("闭运算");
            }
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("custom");
            }
        }

        private void hitAndMissTHickeningThinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("hitAndMissTHickeningThinning");
            }
        }

        private void meanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("mean");
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("blur");
            }
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("sharpen");
            }
        }

        private void edgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("edges");
            }
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("custom1");
            }
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("gaussian");
            }
        }

        private void sharpenExToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("sharpenEx");
            }
        }

        private void btnBoard_Click(object sender, EventArgs e)
        {
            btnBoard.BackColor = Color.FromArgb(83, 83, 83);
            btnColor.BackColor = Color.FromArgb(66, 66, 66);
            UC_Palette uch = new UC_Palette();
            uch.Dock = DockStyle.Fill;
            panel20.Controls.Clear();
            panel20.Controls.Add(uch);
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("merge");
            }
        }

        private void intersectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("intersect");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("add");
            }
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("subtract");
            }
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("difference");
            }
        }

        private void moveTowardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("movetowards");
            }
        }

        private void morphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("morph");
            }
        }

        private void homogenityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("homogenity");
            }
        }

        private void differenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("difference");
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("sobel");
            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("canny");
            }
        }

        private void 大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("大小");
            }
        }

        private void 旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("旋转");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("1");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("2");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("3");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("4");
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("5");
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("6");
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("7");
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("8");
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("9");
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("10");
            }
        }

        private void 层次ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("层次");
            }
        }

        private void 中位数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("中位数");
            }
        }

        private void 伽玛校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("伽玛校正");
            }
        }

        private void 傅里叶变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("傅里叶变换");
            }
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("返回");
            }
        }

        private void 克隆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("克隆");
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("10%");
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("25%");
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("50%");
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("75%");
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("100%");
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("150%");
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("200%");
            }
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("400%");
            }
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("500%");
            }
        }

        private void 放大显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("放大显示");
            }
        }

        private void 缩小显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("缩小显示");
            }
        }

        private void 适应屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("适应屏幕");
            }
        }
        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("垂直翻转");
            }
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("水平翻转");
            }
        }

        private void 旋转90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("旋转90");
            }
        }

        private void 裁剪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("裁剪");
            }
        }

        private void photoShop帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://helpx.adobe.com/cn/support/photoshop-china.html?mv=product&mv2=ps");
        }

        private void photoShop教程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://helpx.adobe.com/cn/photoshop/tutorials.html?mv=product&mv2=ps");
        }

        private void 系统信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PhotoShop2022内测版2.2","版本信息");
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            plToolFunction.Controls.Clear();
            plToolFunction.Controls.Add(c);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UC_Movetool uch = new UC_Movetool();
            AddControlsToPanel(uch);
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHistogram(!config.histogramVisible);
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatistics(!config.statisticsVisible);
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (histogramWin.Visible)
                histogramWin.SwitchChannel(0);
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (histogramWin.Visible)
                histogramWin.SwitchChannel(1);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (histogramWin.Visible)
                histogramWin.SwitchChannel(2);
        }

        private void 中央ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Content doc = dockManager.ActiveDocument;

            if ((doc != null) && (doc is ImageDoc))
                ((ImageDoc)doc).Center();
        }

        private void 在新更改文档中打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            config.openInNewDoc = !config.openInNewDoc;
        }

        private void 记住变化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            config.rememberOnChange = !config.rememberOnChange;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            btnColor.BackColor = Color.FromArgb(83, 83, 83);
            btnBoard.BackColor = Color.FromArgb(66, 66, 66);
            UserControl2 uch = new UserControl2();
            uch.Dock = DockStyle.Fill;
            panel20.Controls.Clear();
            panel20.Controls.Add(uch);
        }
        Point start;  //起始点
        Point end;   //结束点
        bool blnDraw;   //在MouseMove事件中判断是否绘制矩形框
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                blnDraw = true;
            }
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                end = e.Location;
                blnDraw = false;
            }
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                if (e.Button != MouseButtons.Left) return;
                end = e.Location;
                dockManager.Invalidate();//此代码不可省略
            }
        }

        private void pictureBox7_Paint(object sender, PaintEventArgs e)
        {
            //PictureBox pictureBox7 = sender as PictureBox;
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;     //绘制线的格式
            if (blnDraw)
            {
                //此处是为了在绘制时可以由上向下绘制，也可以由下向上
                e.Graphics.DrawRectangle(pen, Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            }
            pen.Dispose();
        }

        private void dockManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                blnDraw = true;
            }
        }

        private void dockManager_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                end = e.Location;
                blnDraw = false;
            }
        }

        private void dockManager_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                if (e.Button != MouseButtons.Left) return;
                end = e.Location;
                dockManager.Invalidate();//此代码不可省略
            }
        }

        private void dockManager_Paint(object sender, PaintEventArgs e)
        {
            DockManager dockManager = sender as DockManager;
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;     //绘制线的格式
            if (blnDraw)
            {
                //此处是为了在绘制时可以由上向下绘制，也可以由下向上
                e.Graphics.DrawRectangle(pen, Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
            }
            pen.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("返回1");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("裁剪1");
            }
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("放大1");
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("模糊1");
            }
        }

        private void 与作者联系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panel21.Controls.Add(childForm);
            panel21.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void 拍照ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoForm plf = new VideoForm();
            plf.ShowDialog();
        }

        private void 文字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
    }
}