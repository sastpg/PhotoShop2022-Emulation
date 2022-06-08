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
        private ToolStripMenuItem �ļ�ToolStripMenuItem;
        private ToolStripMenuItem �½�ToolStripMenuItem;
        private ToolStripMenuItem ��ToolStripMenuItem;
        private ToolStripMenuItem ��Bridge�����ToolStripMenuItem;
        private ToolStripMenuItem �༭ToolStripMenuItem;
        private ToolStripMenuItem ͼ��ToolStripMenuItem;
        private ToolStripMenuItem ͼ��ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ѡ��ToolStripMenuItem;
        private ToolStripMenuItem �˾�ToolStripMenuItem;
        private ToolStripMenuItem ��ɫToolStripMenuItem;
        private ToolStripMenuItem �Ҷ�ToolStripMenuItem;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem ��ͼToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox6;
        private Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Button btnMax;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Panel panel19;
        private ToolStripMenuItem ���¼���ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ճ��ToolStripMenuItem;
        private ToolStripMenuItem �رյ�ǰToolStripMenuItem;
        private ToolStripMenuItem �ر�����ToolStripMenuItem;
        private ToolStripMenuItem ҳ������ToolStripMenuItem;
        private ToolStripMenuItem ��ӡToolStripMenuItem;
        private ToolStripMenuItem ��ӡԤ��ToolStripMenuItem;
        private ToolStripMenuItem �˳�ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem �Ҷȵ�RGBToolStripMenuItem;
        private ToolStripMenuItem �غ�ɫToolStripMenuItem;
        private ToolStripMenuItem ��ɫToolStripMenuItem;
        private ToolStripMenuItem rotateToolStripMenuItem;
        private ToolStripMenuItem ��ɫToolStripMenuItem;
        private ToolStripMenuItem ŷ�������ɫ�˲�ToolStripMenuItem;
        private ToolStripMenuItem ͨ���˲�ToolStripMenuItem;
        private ToolStripMenuItem ��ȡ��ɫͨ��ToolStripMenuItem;
        private ToolStripMenuItem ��ȡ��ɫͨ��ToolStripMenuItem1;
        private ToolStripMenuItem ��ȡ��ɫͨ��ToolStripMenuItem2;
        private ToolStripMenuItem ������ɫͨ��ToolStripMenuItem;
        private ToolStripMenuItem ������ɫͨ��ToolStripMenuItem1;
        private ToolStripMenuItem ������ɫͨ��ToolStripMenuItem2;
        private ToolStripMenuItem ��ToolStripMenuItem;
        private ToolStripMenuItem ��ToolStripMenuItem;
        private ToolStripMenuItem ��ToolStripMenuItem;
        private ToolStripMenuItem ��ɫToolStripMenuItem;
        private ToolStripMenuItem ���ɫToolStripMenuItem;
        private ToolStripMenuItem ��ɫToolStripMenuItem;
        private ToolStripMenuItem hSL��ɫ�ռ�ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem �Աȶ�ToolStripMenuItem;
        private ToolStripMenuItem ���Ͷ�ToolStripMenuItem;
        private ToolStripMenuItem HSL����ToolStripMenuItem;
        private ToolStripMenuItem hSL�˲�ToolStripMenuItem;
        private ToolStripMenuItem ɫ������ToolStripMenuItem;
        private ToolStripMenuItem yCbCr��ɫ�ռ�ToolStripMenuItem;
        private ToolStripMenuItem ��ֵ��ToolStripMenuItem;
        private ToolStripMenuItem ��̬ToolStripMenuItem;
        private ToolStripMenuItem ������ToolStripMenuItem;
        private ToolStripMenuItem ˫Դ�˲���ToolStripMenuItem;
        private ToolStripMenuItem ��Ե�����ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ��СToolStripMenuItem;
        private ToolStripMenuItem ��תToolStripMenuItem;
        private ToolStripMenuItem yCbCr����ToolStripMenuItem;
        private ToolStripMenuItem yCbCr�˲�ToolStripMenuItem;
        private ToolStripMenuItem ��ȡYͨ��ToolStripMenuItem;
        private ToolStripMenuItem ��ȡCbͨ��ToolStripMenuItem;
        private ToolStripMenuItem ��ȡCrͨ��ToolStripMenuItem;
        private ToolStripMenuItem ����Yͨ��ToolStripMenuItem;
        private ToolStripMenuItem ����Cbͨ��ToolStripMenuItem;
        private ToolStripMenuItem ����Crͨ��ToolStripMenuItem;
        private ToolStripMenuItem ͼ����ֵToolStripMenuItem;
        private ToolStripMenuItem �������λ����ֵToolStripMenuItem;
        private ToolStripMenuItem ���򶶶�ToolStripMenuItem;
        private ToolStripMenuItem bayer���򶶶�ToolStripMenuItem;
        private ToolStripMenuItem ��������˹̹���񶶶�ToolStripMenuItem;
        private ToolStripMenuItem ����˹����ToolStripMenuItem;
        private ToolStripMenuItem stucki����ToolStripMenuItem;
        private ToolStripMenuItem jarvisJudiceNinke����ToolStripMenuItem;
        private ToolStripMenuItem sierra����ToolStripMenuItem;
        private ToolStripMenuItem stevensonAndArce����ToolStripMenuItem;
        private ToolStripMenuItem sIS��ֵToolStripMenuItem;
        private ToolStripMenuItem ��ʴToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ������ToolStripMenuItem;
        private ToolStripMenuItem ������ToolStripMenuItem;
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
        private ToolStripMenuItem ���ToolStripMenuItem;
        private ToolStripMenuItem ��λ��ToolStripMenuItem;
        private ToolStripMenuItem ٤��У��ToolStripMenuItem;
        private ToolStripMenuItem ����Ҷ�任ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ��¡ToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ��ֱ��תToolStripMenuItem;
        private ToolStripMenuItem ˮƽ��תToolStripMenuItem;
        private ToolStripMenuItem ��ת90ToolStripMenuItem;
        private ToolStripMenuItem �ü�ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem �Ŵ���ʾToolStripMenuItem;
        private ToolStripMenuItem ��С��ʾToolStripMenuItem;
        private ToolStripMenuItem ��Ӧ��ĻToolStripMenuItem;
        private ToolStripMenuItem photoShop����ToolStripMenuItem;
        private ToolStripMenuItem photoShop�̳�ToolStripMenuItem;
        private ToolStripMenuItem ϵͳ��ϢToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem ֱ��ͼToolStripMenuItem;
        private ToolStripMenuItem ͳ��ToolStripMenuItem;
        private ToolStripMenuItem rToolStripMenuItem;
        private ToolStripMenuItem gToolStripMenuItem;
        private ToolStripMenuItem bToolStripMenuItem;
        private ToolStripMenuItem ����ToolStripMenuItem;
        private ToolStripMenuItem ���¸����ĵ��д�ToolStripMenuItem;
        private ToolStripMenuItem ��ס�仯ToolStripMenuItem;
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
        private ToolStripMenuItem ��������ϵToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripMenuItem ����ToolStripMenuItem;

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
            this.�ļ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�½�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��Bridge�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.���¼���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ճ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.�رյ�ǰToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�ر�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ҳ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ӡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ӡԤ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.�˳�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�༭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��¡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.�Ŵ���ʾToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��С��ʾToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��Ӧ��ĻToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.��ֱ��תToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ˮƽ��תToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ת90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.�ü�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ѡ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���¸����ĵ��д�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ס�仯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�˾�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Ҷ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Ҷȵ�RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.�غ�ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.��ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.��ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ŷ�������ɫ�˲�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͨ���˲�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.��ȡ��ɫͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȡ��ɫͨ��ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȡ��ɫͨ��ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.������ɫͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ɫͨ��ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.������ɫͨ��ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ɫToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSL��ɫ�ռ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�Աȶ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���Ͷ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.HSL����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSL�˲�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ɫ������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr��ɫ�ռ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCr�˲�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.��ȡYͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȡCbͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ȡCrͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.����Yͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Cbͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����Crͨ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ֵ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͼ����ֵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.�������λ����ֵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.���򶶶�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bayer���򶶶�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.��������˹̹���񶶶�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����˹����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stucki����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisJudiceNinke����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sierra����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stevensonAndArce����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.sIS��ֵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��̬ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ʴToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hitAndMissTHickeningThinningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenExToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.˫Դ�˲���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intersectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTowardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��Ե�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.��СToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��תToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.���ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��λ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.٤��У��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.����Ҷ�任ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��ͼToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ֱ��ͼToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ͳ��ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoShop����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoShop�̳�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ϵͳ��ϢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ϵToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label9.Font = new System.Drawing.Font("��������", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "������";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("��������", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(279, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "��䣺";
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
            this.label8.Font = new System.Drawing.Font("��������", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(226, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "��͸���ȣ�";
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
            this.button15.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(162, 0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(83, 44);
            this.button15.TabIndex = 8;
            this.button15.Text = "·��";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.button12.Dock = System.Windows.Forms.DockStyle.Left;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(79, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(83, 44);
            this.button12.TabIndex = 0;
            this.button12.Text = "ͨ��";
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
            this.button14.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.Location = new System.Drawing.Point(0, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(79, 44);
            this.button14.TabIndex = 0;
            this.button14.Text = "ͼ��";
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
            this.label7.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.label6.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.label4.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.label3.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.label5.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(116, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "�ֱ��ʣ�";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "����";
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
            this.label1.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "�ĵ�";
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
            this.button5.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(79, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 44);
            this.button5.TabIndex = 0;
            this.button5.Text = "����";
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
            this.button7.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 44);
            this.button7.TabIndex = 0;
            this.button7.Text = "����";
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
            this.btnBoard.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBoard.ForeColor = System.Drawing.Color.White;
            this.btnBoard.Location = new System.Drawing.Point(79, 0);
            this.btnBoard.Name = "btnBoard";
            this.btnBoard.Size = new System.Drawing.Size(83, 44);
            this.btnBoard.TabIndex = 0;
            this.btnBoard.Text = "ɫ��";
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
            this.btnColor.Font = new System.Drawing.Font("΢���ź�", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(0, 0);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(79, 44);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "��ɫ";
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
            this.toolStripButton12.Text = "������ʷ��¼";
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
            this.toolStripButton13.Text = "����";
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
            this.toolStripButton26.Text = "�ַ�";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.AutoSize = false;
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(50, 36);
            this.toolStripButton11.Text = "����";
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
            this.toolStripButton1.ToolTipText = "�ƶ�����";
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
            this.toolStripButton2.ToolTipText = "����ѡ�򹤾�";
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
            this.toolStripButton3.Text = "�����ļ�";
            this.toolStripButton3.ToolTipText = "��������";
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
            this.toolStripButton4.ToolTipText = "����ѡ�񹤾�";
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
            this.toolStripButton5.ToolTipText = "�ü�����";
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
            this.toolStripButton6.Text = "���ܹ���";
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
            this.toolStripButton7.Text = "�۵��޸����ʹ���";
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
            this.toolStripButton8.Text = "���ʹ���";
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
            this.toolStripButton10.Text = "����ͼ�¹���";
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
            this.toolStripButton14.Text = "��ʷ��¼���ʹ���";
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
            this.toolStripButton15.Text = "��Ƥ������";
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
            this.toolStripButton16.Text = "���乤��";
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
            this.toolStripButton17.Text = "ģ������";
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
            this.toolStripButton18.Text = "�����";
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
            this.toolStripButton19.Text = "�ֱʹ���";
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
            this.toolStripButton20.Text = "���ֹ���";
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
            this.toolStripButton21.Text = "·��ѡ�񹤾�";
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
            this.toolStripButton22.Text = "ץ�ֹ���";
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
            this.toolStripButton23.Text = "�Ŵ󹤾�";
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
            this.toolStripButton24.Text = "�༭������";
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
            this.toolStripButton25.Text = "�ɰ�";
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
            this.�ļ�ToolStripMenuItem,
            this.�༭ToolStripMenuItem,
            this.ͼ��ToolStripMenuItem,
            this.ͼ��ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.ѡ��ToolStripMenuItem,
            this.�˾�ToolStripMenuItem,
            this.dToolStripMenuItem,
            this.��ͼToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(38, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 1, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1116, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // �ļ�ToolStripMenuItem
            // 
            this.�ļ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�½�ToolStripMenuItem,
            this.��ToolStripMenuItem,
            this.��Bridge�����ToolStripMenuItem,
            this.toolStripSeparator1,
            this.���¼���ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.ճ��ToolStripMenuItem,
            this.toolStripSeparator2,
            this.�رյ�ǰToolStripMenuItem,
            this.�ر�����ToolStripMenuItem,
            this.toolStripSeparator5,
            this.ҳ������ToolStripMenuItem,
            this.��ӡToolStripMenuItem,
            this.��ӡԤ��ToolStripMenuItem,
            this.toolStripSeparator6,
            this.�˳�ToolStripMenuItem});
            this.�ļ�ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.�ļ�ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.�ļ�ToolStripMenuItem.Name = "�ļ�ToolStripMenuItem";
            this.�ļ�ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.�ļ�ToolStripMenuItem.Text = "�ļ�[&F]";
            // 
            // �½�ToolStripMenuItem
            // 
            this.�½�ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.�½�ToolStripMenuItem.Enabled = false;
            this.�½�ToolStripMenuItem.Name = "�½�ToolStripMenuItem";
            this.�½�ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.�½�ToolStripMenuItem.Text = "�½�";
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.��ToolStripMenuItem.Text = "��";
            this.��ToolStripMenuItem.Click += new System.EventHandler(this.��ToolStripMenuItem_Click);
            // 
            // ��Bridge�����ToolStripMenuItem
            // 
            this.��Bridge�����ToolStripMenuItem.Name = "��Bridge�����ToolStripMenuItem";
            this.��Bridge�����ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.��Bridge�����ToolStripMenuItem.Text = "��Bridge�����";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // ���¼���ToolStripMenuItem
            // 
            this.���¼���ToolStripMenuItem.Name = "���¼���ToolStripMenuItem";
            this.���¼���ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.���¼���ToolStripMenuItem.Text = "���¼���";
            this.���¼���ToolStripMenuItem.Click += new System.EventHandler(this.���¼���ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ճ��ToolStripMenuItem
            // 
            this.ճ��ToolStripMenuItem.Name = "ճ��ToolStripMenuItem";
            this.ճ��ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.ճ��ToolStripMenuItem.Text = "ճ��";
            this.ճ��ToolStripMenuItem.Click += new System.EventHandler(this.ճ��ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // �رյ�ǰToolStripMenuItem
            // 
            this.�رյ�ǰToolStripMenuItem.Name = "�رյ�ǰToolStripMenuItem";
            this.�رյ�ǰToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.�رյ�ǰToolStripMenuItem.Text = "�رյ�ǰ";
            this.�رյ�ǰToolStripMenuItem.Click += new System.EventHandler(this.�رյ�ǰToolStripMenuItem_Click);
            // 
            // �ر�����ToolStripMenuItem
            // 
            this.�ر�����ToolStripMenuItem.Name = "�ر�����ToolStripMenuItem";
            this.�ر�����ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.�ر�����ToolStripMenuItem.Text = "�ر�����";
            this.�ر�����ToolStripMenuItem.Click += new System.EventHandler(this.�ر�����ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(236, 6);
            // 
            // ҳ������ToolStripMenuItem
            // 
            this.ҳ������ToolStripMenuItem.Name = "ҳ������ToolStripMenuItem";
            this.ҳ������ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.ҳ������ToolStripMenuItem.Text = "ҳ������";
            this.ҳ������ToolStripMenuItem.Click += new System.EventHandler(this.ҳ������ToolStripMenuItem_Click);
            // 
            // ��ӡToolStripMenuItem
            // 
            this.��ӡToolStripMenuItem.Name = "��ӡToolStripMenuItem";
            this.��ӡToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.��ӡToolStripMenuItem.Text = "��ӡ";
            this.��ӡToolStripMenuItem.Click += new System.EventHandler(this.��ӡToolStripMenuItem_Click);
            // 
            // ��ӡԤ��ToolStripMenuItem
            // 
            this.��ӡԤ��ToolStripMenuItem.Name = "��ӡԤ��ToolStripMenuItem";
            this.��ӡԤ��ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.��ӡԤ��ToolStripMenuItem.Text = "��ӡԤ�� ";
            this.��ӡԤ��ToolStripMenuItem.Click += new System.EventHandler(this.��ӡԤ��ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(236, 6);
            // 
            // �˳�ToolStripMenuItem
            // 
            this.�˳�ToolStripMenuItem.Name = "�˳�ToolStripMenuItem";
            this.�˳�ToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.�˳�ToolStripMenuItem.Text = "�˳�";
            this.�˳�ToolStripMenuItem.Click += new System.EventHandler(this.�˳�ToolStripMenuItem_Click);
            // 
            // �༭ToolStripMenuItem
            // 
            this.�༭ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.�༭ToolStripMenuItem.Name = "�༭ToolStripMenuItem";
            this.�༭ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.�༭ToolStripMenuItem.Text = "�༭[&E]";
            // 
            // ͼ��ToolStripMenuItem
            // 
            this.ͼ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem,
            this.��¡ToolStripMenuItem,
            this.toolStripSeparator8,
            this.����ToolStripMenuItem,
            this.toolStripSeparator9,
            this.��ֱ��תToolStripMenuItem,
            this.ˮƽ��תToolStripMenuItem,
            this.��ת90ToolStripMenuItem,
            this.toolStripSeparator10,
            this.�ü�ToolStripMenuItem});
            this.ͼ��ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ͼ��ToolStripMenuItem.Name = "ͼ��ToolStripMenuItem";
            this.ͼ��ToolStripMenuItem.Size = new System.Drawing.Size(79, 28);
            this.ͼ��ToolStripMenuItem.Text = "ͼ��[&I]";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ��¡ToolStripMenuItem
            // 
            this.��¡ToolStripMenuItem.Name = "��¡ToolStripMenuItem";
            this.��¡ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.��¡ToolStripMenuItem.Text = "��¡";
            this.��¡ToolStripMenuItem.Click += new System.EventHandler(this.��¡ToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(303, 6);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.�Ŵ���ʾToolStripMenuItem,
            this.��С��ʾToolStripMenuItem,
            this.��Ӧ��ĻToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.����ToolStripMenuItem.Text = "����";
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
            // �Ŵ���ʾToolStripMenuItem
            // 
            this.�Ŵ���ʾToolStripMenuItem.Name = "�Ŵ���ʾToolStripMenuItem";
            this.�Ŵ���ʾToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.�Ŵ���ʾToolStripMenuItem.Text = "�Ŵ���ʾ";
            this.�Ŵ���ʾToolStripMenuItem.Click += new System.EventHandler(this.�Ŵ���ʾToolStripMenuItem_Click);
            // 
            // ��С��ʾToolStripMenuItem
            // 
            this.��С��ʾToolStripMenuItem.Name = "��С��ʾToolStripMenuItem";
            this.��С��ʾToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.��С��ʾToolStripMenuItem.Text = "��С��ʾ";
            this.��С��ʾToolStripMenuItem.Click += new System.EventHandler(this.��С��ʾToolStripMenuItem_Click);
            // 
            // ��Ӧ��ĻToolStripMenuItem
            // 
            this.��Ӧ��ĻToolStripMenuItem.Name = "��Ӧ��ĻToolStripMenuItem";
            this.��Ӧ��ĻToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.��Ӧ��ĻToolStripMenuItem.Text = "��Ӧ��Ļ";
            this.��Ӧ��ĻToolStripMenuItem.Click += new System.EventHandler(this.��Ӧ��ĻToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(303, 6);
            // 
            // ��ֱ��תToolStripMenuItem
            // 
            this.��ֱ��תToolStripMenuItem.Name = "��ֱ��תToolStripMenuItem";
            this.��ֱ��תToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.��ֱ��תToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.��ֱ��תToolStripMenuItem.Text = "��ֱ��ת";
            this.��ֱ��תToolStripMenuItem.Click += new System.EventHandler(this.��ֱ��תToolStripMenuItem_Click);
            // 
            // ˮƽ��תToolStripMenuItem
            // 
            this.ˮƽ��תToolStripMenuItem.Name = "ˮƽ��תToolStripMenuItem";
            this.ˮƽ��תToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.ˮƽ��תToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.ˮƽ��תToolStripMenuItem.Text = "ˮƽ��ת";
            this.ˮƽ��תToolStripMenuItem.Click += new System.EventHandler(this.ˮƽ��תToolStripMenuItem_Click);
            // 
            // ��ת90ToolStripMenuItem
            // 
            this.��ת90ToolStripMenuItem.Name = "��ת90ToolStripMenuItem";
            this.��ת90ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.��ת90ToolStripMenuItem.Text = "��ת90��";
            this.��ת90ToolStripMenuItem.Click += new System.EventHandler(this.��ת90ToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(303, 6);
            // 
            // �ü�ToolStripMenuItem
            // 
            this.�ü�ToolStripMenuItem.Name = "�ü�ToolStripMenuItem";
            this.�ü�ToolStripMenuItem.Size = new System.Drawing.Size(306, 34);
            this.�ü�ToolStripMenuItem.Text = "�ü�";
            this.�ü�ToolStripMenuItem.Click += new System.EventHandler(this.�ü�ToolStripMenuItem_Click);
            // 
            // ͼ��ToolStripMenuItem
            // 
            this.ͼ��ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ͼ��ToolStripMenuItem.Name = "ͼ��ToolStripMenuItem";
            this.ͼ��ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.ͼ��ToolStripMenuItem.Text = "ͼ��[&L]";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(85, 28);
            this.����ToolStripMenuItem.Text = "����[&Y]";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ѡ��ToolStripMenuItem
            // 
            this.ѡ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.���¸����ĵ��д�ToolStripMenuItem,
            this.��ס�仯ToolStripMenuItem});
            this.ѡ��ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ѡ��ToolStripMenuItem.Name = "ѡ��ToolStripMenuItem";
            this.ѡ��ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.ѡ��ToolStripMenuItem.Text = "ѡ��[&S]";
            // 
            // ���¸����ĵ��д�ToolStripMenuItem
            // 
            this.���¸����ĵ��д�ToolStripMenuItem.Name = "���¸����ĵ��д�ToolStripMenuItem";
            this.���¸����ĵ��д�ToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.���¸����ĵ��д�ToolStripMenuItem.Text = "���¸����ĵ��д�";
            this.���¸����ĵ��д�ToolStripMenuItem.Click += new System.EventHandler(this.���¸����ĵ��д�ToolStripMenuItem_Click);
            // 
            // ��ס�仯ToolStripMenuItem
            // 
            this.��ס�仯ToolStripMenuItem.Name = "��ס�仯ToolStripMenuItem";
            this.��ס�仯ToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.��ס�仯ToolStripMenuItem.Text = "��ס�仯";
            this.��ס�仯ToolStripMenuItem.Click += new System.EventHandler(this.��ס�仯ToolStripMenuItem_Click);
            // 
            // �˾�ToolStripMenuItem
            // 
            this.�˾�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ɫToolStripMenuItem,
            this.hSL��ɫ�ռ�ToolStripMenuItem,
            this.yCbCr��ɫ�ռ�ToolStripMenuItem,
            this.��ֵ��ToolStripMenuItem,
            this.��̬ToolStripMenuItem,
            this.������ToolStripMenuItem,
            this.˫Դ�˲���ToolStripMenuItem,
            this.��Ե�����ToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.toolStripSeparator14,
            this.��СToolStripMenuItem,
            this.��תToolStripMenuItem,
            this.toolStripSeparator15,
            this.���ToolStripMenuItem,
            this.��λ��ToolStripMenuItem,
            this.٤��У��ToolStripMenuItem,
            this.toolStripSeparator16,
            this.����Ҷ�任ToolStripMenuItem});
            this.�˾�ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.�˾�ToolStripMenuItem.Name = "�˾�ToolStripMenuItem";
            this.�˾�ToolStripMenuItem.Size = new System.Drawing.Size(84, 28);
            this.�˾�ToolStripMenuItem.Text = "�˾�[&T]";
            // 
            // ��ɫToolStripMenuItem
            // 
            this.��ɫToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�Ҷ�ToolStripMenuItem,
            this.�Ҷȵ�RGBToolStripMenuItem,
            this.toolStripSeparator17,
            this.�غ�ɫToolStripMenuItem,
            this.toolStripSeparator18,
            this.��ɫToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.toolStripSeparator19,
            this.��ɫToolStripMenuItem,
            this.ŷ�������ɫ�˲�ToolStripMenuItem,
            this.ͨ���˲�ToolStripMenuItem,
            this.toolStripSeparator20,
            this.��ȡ��ɫͨ��ToolStripMenuItem,
            this.��ȡ��ɫͨ��ToolStripMenuItem1,
            this.��ȡ��ɫͨ��ToolStripMenuItem2,
            this.toolStripSeparator21,
            this.������ɫͨ��ToolStripMenuItem,
            this.������ɫͨ��ToolStripMenuItem1,
            this.������ɫͨ��ToolStripMenuItem2,
            this.toolStripSeparator22,
            this.��ToolStripMenuItem,
            this.��ToolStripMenuItem,
            this.��ToolStripMenuItem,
            this.��ɫToolStripMenuItem,
            this.���ɫToolStripMenuItem,
            this.��ɫToolStripMenuItem});
            this.��ɫToolStripMenuItem.Name = "��ɫToolStripMenuItem";
            this.��ɫToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��ɫToolStripMenuItem.Text = "��ɫ";
            // 
            // �Ҷ�ToolStripMenuItem
            // 
            this.�Ҷ�ToolStripMenuItem.Name = "�Ҷ�ToolStripMenuItem";
            this.�Ҷ�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.�Ҷ�ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.�Ҷ�ToolStripMenuItem.Text = "�Ҷ�";
            this.�Ҷ�ToolStripMenuItem.Click += new System.EventHandler(this.�Ҷ�ToolStripMenuItem_Click);
            // 
            // �Ҷȵ�RGBToolStripMenuItem
            // 
            this.�Ҷȵ�RGBToolStripMenuItem.Name = "�Ҷȵ�RGBToolStripMenuItem";
            this.�Ҷȵ�RGBToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.�Ҷȵ�RGBToolStripMenuItem.Text = "�Ҷȵ�RGB";
            this.�Ҷȵ�RGBToolStripMenuItem.Click += new System.EventHandler(this.�Ҷȵ�RGBToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(353, 6);
            // 
            // �غ�ɫToolStripMenuItem
            // 
            this.�غ�ɫToolStripMenuItem.Name = "�غ�ɫToolStripMenuItem";
            this.�غ�ɫToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.�غ�ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.�غ�ɫToolStripMenuItem.Text = "�غ�ɫ";
            this.�غ�ɫToolStripMenuItem.Click += new System.EventHandler(this.�غ�ɫToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(353, 6);
            // 
            // ��ɫToolStripMenuItem
            // 
            this.��ɫToolStripMenuItem.Name = "��ɫToolStripMenuItem";
            this.��ɫToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.I)));
            this.��ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ɫToolStripMenuItem.Text = "��ɫ";
            this.��ɫToolStripMenuItem.Click += new System.EventHandler(this.��ɫToolStripMenuItem_Click_1);
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
            // ��ɫToolStripMenuItem
            // 
            this.��ɫToolStripMenuItem.Name = "��ɫToolStripMenuItem";
            this.��ɫToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.��ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ɫToolStripMenuItem.Text = "��ɫ";
            this.��ɫToolStripMenuItem.Click += new System.EventHandler(this.��ɫToolStripMenuItem_Click);
            // 
            // ŷ�������ɫ�˲�ToolStripMenuItem
            // 
            this.ŷ�������ɫ�˲�ToolStripMenuItem.Name = "ŷ�������ɫ�˲�ToolStripMenuItem";
            this.ŷ�������ɫ�˲�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.ŷ�������ɫ�˲�ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.ŷ�������ɫ�˲�ToolStripMenuItem.Text = "ŷ�������ɫ�˲�";
            this.ŷ�������ɫ�˲�ToolStripMenuItem.Click += new System.EventHandler(this.ŷ�������ɫ�˲�ToolStripMenuItem_Click);
            // 
            // ͨ���˲�ToolStripMenuItem
            // 
            this.ͨ���˲�ToolStripMenuItem.Name = "ͨ���˲�ToolStripMenuItem";
            this.ͨ���˲�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.ͨ���˲�ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.ͨ���˲�ToolStripMenuItem.Text = "ͨ���˲�";
            this.ͨ���˲�ToolStripMenuItem.Click += new System.EventHandler(this.ͨ���˲�ToolStripMenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(353, 6);
            // 
            // ��ȡ��ɫͨ��ToolStripMenuItem
            // 
            this.��ȡ��ɫͨ��ToolStripMenuItem.Name = "��ȡ��ɫͨ��ToolStripMenuItem";
            this.��ȡ��ɫͨ��ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ȡ��ɫͨ��ToolStripMenuItem.Text = "��ȡ��ɫͨ��";
            this.��ȡ��ɫͨ��ToolStripMenuItem.Click += new System.EventHandler(this.��ȡ��ɫͨ��ToolStripMenuItem_Click);
            // 
            // ��ȡ��ɫͨ��ToolStripMenuItem1
            // 
            this.��ȡ��ɫͨ��ToolStripMenuItem1.Name = "��ȡ��ɫͨ��ToolStripMenuItem1";
            this.��ȡ��ɫͨ��ToolStripMenuItem1.Size = new System.Drawing.Size(356, 34);
            this.��ȡ��ɫͨ��ToolStripMenuItem1.Text = "��ȡ��ɫͨ��";
            this.��ȡ��ɫͨ��ToolStripMenuItem1.Click += new System.EventHandler(this.��ȡ��ɫͨ��ToolStripMenuItem1_Click);
            // 
            // ��ȡ��ɫͨ��ToolStripMenuItem2
            // 
            this.��ȡ��ɫͨ��ToolStripMenuItem2.Name = "��ȡ��ɫͨ��ToolStripMenuItem2";
            this.��ȡ��ɫͨ��ToolStripMenuItem2.Size = new System.Drawing.Size(356, 34);
            this.��ȡ��ɫͨ��ToolStripMenuItem2.Text = "��ȡ��ɫͨ��";
            this.��ȡ��ɫͨ��ToolStripMenuItem2.Click += new System.EventHandler(this.��ȡ��ɫͨ��ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(353, 6);
            // 
            // ������ɫͨ��ToolStripMenuItem
            // 
            this.������ɫͨ��ToolStripMenuItem.Name = "������ɫͨ��ToolStripMenuItem";
            this.������ɫͨ��ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.������ɫͨ��ToolStripMenuItem.Text = "������ɫͨ��";
            this.������ɫͨ��ToolStripMenuItem.Click += new System.EventHandler(this.������ɫͨ��ToolStripMenuItem_Click);
            // 
            // ������ɫͨ��ToolStripMenuItem1
            // 
            this.������ɫͨ��ToolStripMenuItem1.Name = "������ɫͨ��ToolStripMenuItem1";
            this.������ɫͨ��ToolStripMenuItem1.Size = new System.Drawing.Size(356, 34);
            this.������ɫͨ��ToolStripMenuItem1.Text = "������ɫͨ��";
            this.������ɫͨ��ToolStripMenuItem1.Click += new System.EventHandler(this.������ɫͨ��ToolStripMenuItem1_Click);
            // 
            // ������ɫͨ��ToolStripMenuItem2
            // 
            this.������ɫͨ��ToolStripMenuItem2.Name = "������ɫͨ��ToolStripMenuItem2";
            this.������ɫͨ��ToolStripMenuItem2.Size = new System.Drawing.Size(356, 34);
            this.������ɫͨ��ToolStripMenuItem2.Text = "������ɫͨ��";
            this.������ɫͨ��ToolStripMenuItem2.Click += new System.EventHandler(this.������ɫͨ��ToolStripMenuItem2_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(353, 6);
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ToolStripMenuItem.Text = "��ɫ";
            this.��ToolStripMenuItem.Click += new System.EventHandler(this.��ToolStripMenuItem_Click);
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ToolStripMenuItem.Text = "��ɫ";
            this.��ToolStripMenuItem.Click += new System.EventHandler(this.��ToolStripMenuItem_Click);
            // 
            // ��ToolStripMenuItem
            // 
            this.��ToolStripMenuItem.Name = "��ToolStripMenuItem";
            this.��ToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ToolStripMenuItem.Text = "��ɫ";
            this.��ToolStripMenuItem.Click += new System.EventHandler(this.��ToolStripMenuItem_Click);
            // 
            // ��ɫToolStripMenuItem
            // 
            this.��ɫToolStripMenuItem.Name = "��ɫToolStripMenuItem";
            this.��ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ɫToolStripMenuItem.Text = "��ɫ";
            this.��ɫToolStripMenuItem.Click += new System.EventHandler(this.��ɫToolStripMenuItem_Click);
            // 
            // ���ɫToolStripMenuItem
            // 
            this.���ɫToolStripMenuItem.Name = "���ɫToolStripMenuItem";
            this.���ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.���ɫToolStripMenuItem.Text = "���ɫ";
            this.���ɫToolStripMenuItem.Click += new System.EventHandler(this.���ɫToolStripMenuItem_Click);
            // 
            // ��ɫToolStripMenuItem
            // 
            this.��ɫToolStripMenuItem.Name = "��ɫToolStripMenuItem";
            this.��ɫToolStripMenuItem.Size = new System.Drawing.Size(356, 34);
            this.��ɫToolStripMenuItem.Text = "��ɫ";
            this.��ɫToolStripMenuItem.Click += new System.EventHandler(this.��ɫToolStripMenuItem_Click);
            // 
            // hSL��ɫ�ռ�ToolStripMenuItem
            // 
            this.hSL��ɫ�ռ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem,
            this.�Աȶ�ToolStripMenuItem,
            this.���Ͷ�ToolStripMenuItem,
            this.toolStripSeparator23,
            this.HSL����ToolStripMenuItem,
            this.hSL�˲�ToolStripMenuItem,
            this.ɫ������ToolStripMenuItem});
            this.hSL��ɫ�ռ�ToolStripMenuItem.Name = "hSL��ɫ�ռ�ToolStripMenuItem";
            this.hSL��ɫ�ռ�ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.hSL��ɫ�ռ�ToolStripMenuItem.Text = "HSL��ɫ�ռ�";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // �Աȶ�ToolStripMenuItem
            // 
            this.�Աȶ�ToolStripMenuItem.Name = "�Աȶ�ToolStripMenuItem";
            this.�Աȶ�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.�Աȶ�ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.�Աȶ�ToolStripMenuItem.Text = "�Աȶ�";
            this.�Աȶ�ToolStripMenuItem.Click += new System.EventHandler(this.�Աȶ�ToolStripMenuItem_Click);
            // 
            // ���Ͷ�ToolStripMenuItem
            // 
            this.���Ͷ�ToolStripMenuItem.Name = "���Ͷ�ToolStripMenuItem";
            this.���Ͷ�ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.���Ͷ�ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.���Ͷ�ToolStripMenuItem.Text = "���Ͷ�";
            this.���Ͷ�ToolStripMenuItem.Click += new System.EventHandler(this.���Ͷ�ToolStripMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(317, 6);
            // 
            // HSL����ToolStripMenuItem
            // 
            this.HSL����ToolStripMenuItem.Name = "HSL����ToolStripMenuItem";
            this.HSL����ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.HSL����ToolStripMenuItem.Text = "HSL����";
            this.HSL����ToolStripMenuItem.Click += new System.EventHandler(this.HSL����ToolStripMenuItem_Click);
            // 
            // hSL�˲�ToolStripMenuItem
            // 
            this.hSL�˲�ToolStripMenuItem.Name = "hSL�˲�ToolStripMenuItem";
            this.hSL�˲�ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.hSL�˲�ToolStripMenuItem.Text = "HSL�˲�";
            this.hSL�˲�ToolStripMenuItem.Click += new System.EventHandler(this.hSL�˲�ToolStripMenuItem_Click);
            // 
            // ɫ������ToolStripMenuItem
            // 
            this.ɫ������ToolStripMenuItem.Name = "ɫ������ToolStripMenuItem";
            this.ɫ������ToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.ɫ������ToolStripMenuItem.Text = "ɫ������";
            this.ɫ������ToolStripMenuItem.Click += new System.EventHandler(this.ɫ������ToolStripMenuItem_Click);
            // 
            // yCbCr��ɫ�ռ�ToolStripMenuItem
            // 
            this.yCbCr��ɫ�ռ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yCbCr����ToolStripMenuItem,
            this.yCbCr�˲�ToolStripMenuItem,
            this.toolStripSeparator24,
            this.��ȡYͨ��ToolStripMenuItem,
            this.��ȡCbͨ��ToolStripMenuItem,
            this.��ȡCrͨ��ToolStripMenuItem,
            this.toolStripSeparator25,
            this.����Yͨ��ToolStripMenuItem,
            this.����Cbͨ��ToolStripMenuItem,
            this.����Crͨ��ToolStripMenuItem});
            this.yCbCr��ɫ�ռ�ToolStripMenuItem.Name = "yCbCr��ɫ�ռ�ToolStripMenuItem";
            this.yCbCr��ɫ�ռ�ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.yCbCr��ɫ�ռ�ToolStripMenuItem.Text = "YCbCr��ɫ�ռ�";
            // 
            // yCbCr����ToolStripMenuItem
            // 
            this.yCbCr����ToolStripMenuItem.Name = "yCbCr����ToolStripMenuItem";
            this.yCbCr����ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.yCbCr����ToolStripMenuItem.Text = "YCbCr����";
            this.yCbCr����ToolStripMenuItem.Click += new System.EventHandler(this.yCbCr����ToolStripMenuItem_Click);
            // 
            // yCbCr�˲�ToolStripMenuItem
            // 
            this.yCbCr�˲�ToolStripMenuItem.Name = "yCbCr�˲�ToolStripMenuItem";
            this.yCbCr�˲�ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.yCbCr�˲�ToolStripMenuItem.Text = "YCbCr�˲�";
            this.yCbCr�˲�ToolStripMenuItem.Click += new System.EventHandler(this.yCbCr�˲�ToolStripMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(203, 6);
            // 
            // ��ȡYͨ��ToolStripMenuItem
            // 
            this.��ȡYͨ��ToolStripMenuItem.Name = "��ȡYͨ��ToolStripMenuItem";
            this.��ȡYͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.��ȡYͨ��ToolStripMenuItem.Text = "��ȡYͨ��";
            this.��ȡYͨ��ToolStripMenuItem.Click += new System.EventHandler(this.��ȡYͨ��ToolStripMenuItem_Click);
            // 
            // ��ȡCbͨ��ToolStripMenuItem
            // 
            this.��ȡCbͨ��ToolStripMenuItem.Name = "��ȡCbͨ��ToolStripMenuItem";
            this.��ȡCbͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.��ȡCbͨ��ToolStripMenuItem.Text = "��ȡCbͨ��";
            this.��ȡCbͨ��ToolStripMenuItem.Click += new System.EventHandler(this.��ȡCbͨ��ToolStripMenuItem_Click);
            // 
            // ��ȡCrͨ��ToolStripMenuItem
            // 
            this.��ȡCrͨ��ToolStripMenuItem.Name = "��ȡCrͨ��ToolStripMenuItem";
            this.��ȡCrͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.��ȡCrͨ��ToolStripMenuItem.Text = "��ȡCrͨ��";
            this.��ȡCrͨ��ToolStripMenuItem.Click += new System.EventHandler(this.��ȡCrͨ��ToolStripMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(203, 6);
            // 
            // ����Yͨ��ToolStripMenuItem
            // 
            this.����Yͨ��ToolStripMenuItem.Name = "����Yͨ��ToolStripMenuItem";
            this.����Yͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.����Yͨ��ToolStripMenuItem.Text = "����Yͨ��";
            this.����Yͨ��ToolStripMenuItem.Click += new System.EventHandler(this.����Yͨ��ToolStripMenuItem_Click);
            // 
            // ����Cbͨ��ToolStripMenuItem
            // 
            this.����Cbͨ��ToolStripMenuItem.Name = "����Cbͨ��ToolStripMenuItem";
            this.����Cbͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.����Cbͨ��ToolStripMenuItem.Text = "����Cbͨ��";
            this.����Cbͨ��ToolStripMenuItem.Click += new System.EventHandler(this.����Cbͨ��ToolStripMenuItem_Click);
            // 
            // ����Crͨ��ToolStripMenuItem
            // 
            this.����Crͨ��ToolStripMenuItem.Name = "����Crͨ��ToolStripMenuItem";
            this.����Crͨ��ToolStripMenuItem.Size = new System.Drawing.Size(206, 34);
            this.����Crͨ��ToolStripMenuItem.Text = "����Crͨ��";
            this.����Crͨ��ToolStripMenuItem.Click += new System.EventHandler(this.����Crͨ��ToolStripMenuItem_Click);
            // 
            // ��ֵ��ToolStripMenuItem
            // 
            this.��ֵ��ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ͼ����ֵToolStripMenuItem,
            this.toolStripSeparator26,
            this.�������λ����ֵToolStripMenuItem,
            this.���򶶶�ToolStripMenuItem,
            this.bayer���򶶶�ToolStripMenuItem,
            this.toolStripSeparator27,
            this.��������˹̹���񶶶�ToolStripMenuItem,
            this.����˹����ToolStripMenuItem,
            this.stucki����ToolStripMenuItem,
            this.jarvisJudiceNinke����ToolStripMenuItem,
            this.sierra����ToolStripMenuItem,
            this.stevensonAndArce����ToolStripMenuItem,
            this.toolStripSeparator28,
            this.sIS��ֵToolStripMenuItem});
            this.��ֵ��ToolStripMenuItem.Name = "��ֵ��ToolStripMenuItem";
            this.��ֵ��ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��ֵ��ToolStripMenuItem.Text = "��ֵ��";
            // 
            // ͼ����ֵToolStripMenuItem
            // 
            this.ͼ����ֵToolStripMenuItem.Name = "ͼ����ֵToolStripMenuItem";
            this.ͼ����ֵToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.ͼ����ֵToolStripMenuItem.Text = "ͼ����ֵ";
            this.ͼ����ֵToolStripMenuItem.Click += new System.EventHandler(this.ͼ����ֵToolStripMenuItem_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(312, 6);
            // 
            // �������λ����ֵToolStripMenuItem
            // 
            this.�������λ����ֵToolStripMenuItem.Name = "�������λ����ֵToolStripMenuItem";
            this.�������λ����ֵToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.�������λ����ֵToolStripMenuItem.Text = "�������λ����ֵ";
            this.�������λ����ֵToolStripMenuItem.Click += new System.EventHandler(this.�������λ����ֵToolStripMenuItem_Click);
            // 
            // ���򶶶�ToolStripMenuItem
            // 
            this.���򶶶�ToolStripMenuItem.Name = "���򶶶�ToolStripMenuItem";
            this.���򶶶�ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.���򶶶�ToolStripMenuItem.Text = "���򶶶�";
            this.���򶶶�ToolStripMenuItem.Click += new System.EventHandler(this.���򶶶�ToolStripMenuItem_Click);
            // 
            // bayer���򶶶�ToolStripMenuItem
            // 
            this.bayer���򶶶�ToolStripMenuItem.Name = "bayer���򶶶�ToolStripMenuItem";
            this.bayer���򶶶�ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.bayer���򶶶�ToolStripMenuItem.Text = "Bayer���򶶶�";
            this.bayer���򶶶�ToolStripMenuItem.Click += new System.EventHandler(this.bayer���򶶶�ToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(312, 6);
            // 
            // ��������˹̹���񶶶�ToolStripMenuItem
            // 
            this.��������˹̹���񶶶�ToolStripMenuItem.Name = "��������˹̹���񶶶�ToolStripMenuItem";
            this.��������˹̹���񶶶�ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.��������˹̹���񶶶�ToolStripMenuItem.Text = "��������-˹̹���񶶶�";
            this.��������˹̹���񶶶�ToolStripMenuItem.Click += new System.EventHandler(this.��������˹̹���񶶶�ToolStripMenuItem_Click);
            // 
            // ����˹����ToolStripMenuItem
            // 
            this.����˹����ToolStripMenuItem.Name = "����˹����ToolStripMenuItem";
            this.����˹����ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.����˹����ToolStripMenuItem.Text = "����˹����";
            this.����˹����ToolStripMenuItem.Click += new System.EventHandler(this.����˹����ToolStripMenuItem_Click);
            // 
            // stucki����ToolStripMenuItem
            // 
            this.stucki����ToolStripMenuItem.Name = "stucki����ToolStripMenuItem";
            this.stucki����ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.stucki����ToolStripMenuItem.Text = "Stucki����";
            this.stucki����ToolStripMenuItem.Click += new System.EventHandler(this.stucki����ToolStripMenuItem_Click);
            // 
            // jarvisJudiceNinke����ToolStripMenuItem
            // 
            this.jarvisJudiceNinke����ToolStripMenuItem.Name = "jarvisJudiceNinke����ToolStripMenuItem";
            this.jarvisJudiceNinke����ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.jarvisJudiceNinke����ToolStripMenuItem.Text = "Jarvis-Judice-Ninke����";
            this.jarvisJudiceNinke����ToolStripMenuItem.Click += new System.EventHandler(this.jarvisJudiceNinke����ToolStripMenuItem_Click);
            // 
            // sierra����ToolStripMenuItem
            // 
            this.sierra����ToolStripMenuItem.Name = "sierra����ToolStripMenuItem";
            this.sierra����ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.sierra����ToolStripMenuItem.Text = "Sierra����";
            this.sierra����ToolStripMenuItem.Click += new System.EventHandler(this.sierra����ToolStripMenuItem_Click);
            // 
            // stevensonAndArce����ToolStripMenuItem
            // 
            this.stevensonAndArce����ToolStripMenuItem.Name = "stevensonAndArce����ToolStripMenuItem";
            this.stevensonAndArce����ToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.stevensonAndArce����ToolStripMenuItem.Text = "Stevenson and Arce����";
            this.stevensonAndArce����ToolStripMenuItem.Click += new System.EventHandler(this.stevensonAndArce����ToolStripMenuItem_Click);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(312, 6);
            // 
            // sIS��ֵToolStripMenuItem
            // 
            this.sIS��ֵToolStripMenuItem.Name = "sIS��ֵToolStripMenuItem";
            this.sIS��ֵToolStripMenuItem.Size = new System.Drawing.Size(315, 34);
            this.sIS��ֵToolStripMenuItem.Text = "SIS��ֵ";
            this.sIS��ֵToolStripMenuItem.Click += new System.EventHandler(this.sIS��ֵToolStripMenuItem_Click);
            // 
            // ��̬ToolStripMenuItem
            // 
            this.��̬ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��ʴToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.������ToolStripMenuItem,
            this.������ToolStripMenuItem,
            this.customToolStripMenuItem,
            this.hitAndMissTHickeningThinningToolStripMenuItem});
            this.��̬ToolStripMenuItem.Name = "��̬ToolStripMenuItem";
            this.��̬ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��̬ToolStripMenuItem.Text = "��̬";
            // 
            // ��ʴToolStripMenuItem
            // 
            this.��ʴToolStripMenuItem.Name = "��ʴToolStripMenuItem";
            this.��ʴToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.��ʴToolStripMenuItem.Text = "��ʴ";
            this.��ʴToolStripMenuItem.Click += new System.EventHandler(this.��ʴToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ������ToolStripMenuItem
            // 
            this.������ToolStripMenuItem.Name = "������ToolStripMenuItem";
            this.������ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.������ToolStripMenuItem.Text = "������";
            this.������ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
            // 
            // ������ToolStripMenuItem
            // 
            this.������ToolStripMenuItem.Name = "������ToolStripMenuItem";
            this.������ToolStripMenuItem.Size = new System.Drawing.Size(412, 34);
            this.������ToolStripMenuItem.Text = "������";
            this.������ToolStripMenuItem.Click += new System.EventHandler(this.������ToolStripMenuItem_Click);
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
            // ������ToolStripMenuItem
            // 
            this.������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.edgesToolStripMenuItem,
            this.customToolStripMenuItem1,
            this.gaussianToolStripMenuItem,
            this.sharpenExToolStripMenuItem});
            this.������ToolStripMenuItem.Name = "������ToolStripMenuItem";
            this.������ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.������ToolStripMenuItem.Text = "���&&���";
            // 
            // meanToolStripMenuItem
            // 
            this.meanToolStripMenuItem.Name = "meanToolStripMenuItem";
            this.meanToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.meanToolStripMenuItem.Text = "��ֵ";
            this.meanToolStripMenuItem.Click += new System.EventHandler(this.meanToolStripMenuItem_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.blurToolStripMenuItem.Text = "ģ��";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.sharpenToolStripMenuItem.Text = "��";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // edgesToolStripMenuItem
            // 
            this.edgesToolStripMenuItem.Name = "edgesToolStripMenuItem";
            this.edgesToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.edgesToolStripMenuItem.Text = "��Ե";
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
            this.gaussianToolStripMenuItem.Text = "��˹ģ��";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // sharpenExToolStripMenuItem
            // 
            this.sharpenExToolStripMenuItem.Name = "sharpenExToolStripMenuItem";
            this.sharpenExToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.sharpenExToolStripMenuItem.Text = "��ǰ";
            this.sharpenExToolStripMenuItem.Click += new System.EventHandler(this.sharpenExToolStripMenuItem_Click);
            // 
            // ˫Դ�˲���ToolStripMenuItem
            // 
            this.˫Դ�˲���ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeToolStripMenuItem,
            this.intersectToolStripMenuItem,
            this.addToolStripMenuItem,
            this.subtractToolStripMenuItem,
            this.differenceToolStripMenuItem,
            this.moveTowardsToolStripMenuItem,
            this.morphToolStripMenuItem});
            this.˫Դ�˲���ToolStripMenuItem.Name = "˫Դ�˲���ToolStripMenuItem";
            this.˫Դ�˲���ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.˫Դ�˲���ToolStripMenuItem.Text = "˫Դ�˲���";
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.mergeToolStripMenuItem.Text = "�ϲ�";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
            // 
            // intersectToolStripMenuItem
            // 
            this.intersectToolStripMenuItem.Name = "intersectToolStripMenuItem";
            this.intersectToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.intersectToolStripMenuItem.Text = "�ཻ";
            this.intersectToolStripMenuItem.Click += new System.EventHandler(this.intersectToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.addToolStripMenuItem.Text = "���";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // subtractToolStripMenuItem
            // 
            this.subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            this.subtractToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.subtractToolStripMenuItem.Text = "���";
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
            // ��Ե�����ToolStripMenuItem
            // 
            this.��Ե�����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homogenityToolStripMenuItem,
            this.differenceToolStripMenuItem1,
            this.sobelToolStripMenuItem,
            this.cannyToolStripMenuItem});
            this.��Ե�����ToolStripMenuItem.Name = "��Ե�����ToolStripMenuItem";
            this.��Ե�����ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��Ե�����ToolStripMenuItem.Text = "��Ե�����";
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
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem2.Text = "����Ӧƽ��";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem3.Text = "����ƽ��";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem4.Text = "��������";
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
            this.toolStripMenuItem5.Text = "�ͻ�";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem6.Text = "����";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem7.Text = "���ػ�";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem8.Text = "�򵥹��ʻ�";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem9.Text = "����";
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
            this.toolStripMenuItem10.Text = "��ͨ������";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(218, 34);
            this.toolStripMenuItem11.Text = "�ߵ���ȡ";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(272, 6);
            // 
            // ��СToolStripMenuItem
            // 
            this.��СToolStripMenuItem.Name = "��СToolStripMenuItem";
            this.��СToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.��СToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��СToolStripMenuItem.Text = "��С";
            this.��СToolStripMenuItem.Click += new System.EventHandler(this.��СToolStripMenuItem_Click);
            // 
            // ��תToolStripMenuItem
            // 
            this.��תToolStripMenuItem.Name = "��תToolStripMenuItem";
            this.��תToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.��תToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��תToolStripMenuItem.Text = "��ת";
            this.��תToolStripMenuItem.Click += new System.EventHandler(this.��תToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(272, 6);
            // 
            // ���ToolStripMenuItem
            // 
            this.���ToolStripMenuItem.Name = "���ToolStripMenuItem";
            this.���ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.���ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.���ToolStripMenuItem.Text = "ɫ��";
            this.���ToolStripMenuItem.Click += new System.EventHandler(this.���ToolStripMenuItem_Click);
            // 
            // ��λ��ToolStripMenuItem
            // 
            this.��λ��ToolStripMenuItem.Name = "��λ��ToolStripMenuItem";
            this.��λ��ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.��λ��ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.��λ��ToolStripMenuItem.Text = "��λ��";
            this.��λ��ToolStripMenuItem.Click += new System.EventHandler(this.��λ��ToolStripMenuItem_Click);
            // 
            // ٤��У��ToolStripMenuItem
            // 
            this.٤��У��ToolStripMenuItem.Name = "٤��У��ToolStripMenuItem";
            this.٤��У��ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.٤��У��ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.٤��У��ToolStripMenuItem.Text = "٤��У��";
            this.٤��У��ToolStripMenuItem.Click += new System.EventHandler(this.٤��У��ToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(272, 6);
            // 
            // ����Ҷ�任ToolStripMenuItem
            // 
            this.����Ҷ�任ToolStripMenuItem.Name = "����Ҷ�任ToolStripMenuItem";
            this.����Ҷ�任ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.����Ҷ�任ToolStripMenuItem.Size = new System.Drawing.Size(275, 34);
            this.����Ҷ�任ToolStripMenuItem.Text = "����Ҷ�任";
            this.����Ҷ�任ToolStripMenuItem.Click += new System.EventHandler(this.����Ҷ�任ToolStripMenuItem_Click);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(77, 28);
            this.dToolStripMenuItem.Text = "3D[&D]";
            // 
            // ��ͼToolStripMenuItem
            // 
            this.��ͼToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ֱ��ͼToolStripMenuItem,
            this.ͳ��ToolStripMenuItem,
            this.rToolStripMenuItem,
            this.gToolStripMenuItem,
            this.bToolStripMenuItem,
            this.����ToolStripMenuItem,
            this.toolStripSeparator31,
            this.����ToolStripMenuItem});
            this.��ͼToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.��ͼToolStripMenuItem.Name = "��ͼToolStripMenuItem";
            this.��ͼToolStripMenuItem.Size = new System.Drawing.Size(86, 28);
            this.��ͼToolStripMenuItem.Text = "��ͼ[&V]";
            // 
            // ֱ��ͼToolStripMenuItem
            // 
            this.ֱ��ͼToolStripMenuItem.Name = "ֱ��ͼToolStripMenuItem";
            this.ֱ��ͼToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.ֱ��ͼToolStripMenuItem.Text = "ֱ��ͼ";
            this.ֱ��ͼToolStripMenuItem.Click += new System.EventHandler(this.ֱ��ͼToolStripMenuItem_Click);
            // 
            // ͳ��ToolStripMenuItem
            // 
            this.ͳ��ToolStripMenuItem.Name = "ͳ��ToolStripMenuItem";
            this.ͳ��ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.ͳ��ToolStripMenuItem.Text = "ͳ��";
            this.ͳ��ToolStripMenuItem.Click += new System.EventHandler(this.ͳ��ToolStripMenuItem_Click);
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
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(161, 6);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.����ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(92, 28);
            this.����ToolStripMenuItem.Text = "����[&W]";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.photoShop����ToolStripMenuItem,
            this.photoShop�̳�ToolStripMenuItem,
            this.toolStripSeparator7,
            this.ϵͳ��ϢToolStripMenuItem,
            this.��������ϵToolStripMenuItem});
            this.����ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(88, 28);
            this.����ToolStripMenuItem.Text = "����[&H]";
            // 
            // photoShop����ToolStripMenuItem
            // 
            this.photoShop����ToolStripMenuItem.Name = "photoShop����ToolStripMenuItem";
            this.photoShop����ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.photoShop����ToolStripMenuItem.Text = "PhotoShop����";
            this.photoShop����ToolStripMenuItem.Click += new System.EventHandler(this.photoShop����ToolStripMenuItem_Click);
            // 
            // photoShop�̳�ToolStripMenuItem
            // 
            this.photoShop�̳�ToolStripMenuItem.Name = "photoShop�̳�ToolStripMenuItem";
            this.photoShop�̳�ToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.photoShop�̳�ToolStripMenuItem.Text = "PhotoShop�̳�";
            this.photoShop�̳�ToolStripMenuItem.Click += new System.EventHandler(this.photoShop�̳�ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(238, 6);
            // 
            // ϵͳ��ϢToolStripMenuItem
            // 
            this.ϵͳ��ϢToolStripMenuItem.Name = "ϵͳ��ϢToolStripMenuItem";
            this.ϵͳ��ϢToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.ϵͳ��ϢToolStripMenuItem.Text = "ϵͳ��Ϣ";
            this.ϵͳ��ϢToolStripMenuItem.Click += new System.EventHandler(this.ϵͳ��ϢToolStripMenuItem_Click);
            // 
            // ��������ϵToolStripMenuItem
            // 
            this.��������ϵToolStripMenuItem.Name = "��������ϵToolStripMenuItem";
            this.��������ϵToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.��������ϵToolStripMenuItem.Text = "��������ϵ...";
            this.��������ϵToolStripMenuItem.Click += new System.EventHandler(this.��������ϵToolStripMenuItem_Click);
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
			this.���¸����ĵ��д�ToolStripMenuItem.Checked = config.openInNewDoc;
			this.��ס�仯ToolStripMenuItem.Checked = config.rememberOnChange;
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


        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void �Ҷ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�Ҷ�");
            }
        }
        

        private void ���¼���ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void ճ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteFromClipboard();
        }

        private void �رյ�ǰToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockManager.ActiveDocument != null)
                dockManager.ActiveDocument.Close();
        }

        private void �ر�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Content c in dockManager.Documents)
                c.Close();
        }

        private void ҳ������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ��ӡԤ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void �Ҷȵ�RGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�Ҷȵ�RGB");
            }
        }

        private void �غ�ɫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�غ�ɫ");
            }
        }



        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("Rotate");
            }
        }

        private void ��ɫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ŷ�������ɫ�˲�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ŷ�������ɫ�˲�");
            }
        }

        private void ͨ���˲�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ͨ���˲�");
            }
        }

        private void ��ȡ��ɫͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡ��ɫͨ��");
            }
        }

        private void ��ȡ��ɫͨ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡ��ɫͨ��");
            }
        }

        private void ��ȡ��ɫͨ��ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡ��ɫͨ��");
            }
        }

        private void ������ɫͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("������ɫͨ��");
            }
        }

        private void ������ɫͨ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("������ɫͨ��");
            }
        }

        private void ������ɫͨ��ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("������ɫͨ��");
            }
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ��ɫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ���ɫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("���ɫ");
            }
        }

        private void ��ɫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����");
            }
        }

        private void ��ɫToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ɫ");
            }
        }

        private void �Աȶ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�Աȶ�");
            }
        }

        private void ���Ͷ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("���Ͷ�");
            }
        }

        private void HSL����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("HSL����");
            }
        }

        private void hSL�˲�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("HSL�˲�");
            }
        }

        private void ɫ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ɫ������");
            }
        }

        private void yCbCr����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("YCbCr����");
            }
        }

        private void yCbCr�˲�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("YCbCr�˲�");
            }
        }

        private void ��ȡYͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡYͨ��");
            }
        }

        private void ��ȡCbͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡCbͨ��");
            }
        }

        private void ��ȡCrͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ȡCrͨ��");
            }
        }

        private void ����Yͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����Yͨ��");
            }
        }

        private void ����Cbͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����Cbͨ��");
            }
        }

        private void ����Crͨ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����Crͨ��");
            }
        }

        private void ͼ����ֵToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ͼ����ֵ");
            }
        }

        private void �������λ����ֵToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�������λ����ֵ");
            }
        }

        private void ���򶶶�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("���򶶶�");
            }
        }

        private void bayer���򶶶�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("bayer���򶶶�");
            }
        }

        private void ��������˹̹���񶶶�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��������˹̹���񶶶�");
            }
        }

        private void ����˹����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����˹����");
            }
        }

        private void stucki����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("stucki����");
            }
        }

        private void jarvisJudiceNinke����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("jarvisJudiceNinke����");
            }
        }

        private void sierra����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("sierra����");
            }
        }

        private void stevensonAndArce����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("stevensonAndArce����");
            }
        }

        private void sIS��ֵToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("SIS��ֵ");
            }
        }

        private void ��ʴToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ʴ");
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����");
            }
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("������");
            }
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("������");
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

        private void ��СToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��С");
            }
        }

        private void ��תToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ת");
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

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("���");
            }
        }

        private void ��λ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��λ��");
            }
        }

        private void ٤��У��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("٤��У��");
            }
        }

        private void ����Ҷ�任ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����Ҷ�任");
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("����");
            }
        }

        private void ��¡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��¡");
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

        private void �Ŵ���ʾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�Ŵ���ʾ");
            }
        }

        private void ��С��ʾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��С��ʾ");
            }
        }

        private void ��Ӧ��ĻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��Ӧ��Ļ");
            }
        }
        private void ��ֱ��תToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ֱ��ת");
            }
        }

        private void ˮƽ��תToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ˮƽ��ת");
            }
        }

        private void ��ת90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("��ת90");
            }
        }

        private void �ü�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�ü�");
            }
        }

        private void photoShop����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://helpx.adobe.com/cn/support/photoshop-china.html?mv=product&mv2=ps");
        }

        private void photoShop�̳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://helpx.adobe.com/cn/photoshop/tutorials.html?mv=product&mv2=ps");
        }

        private void ϵͳ��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PhotoShop2022�ڲ��2.2","�汾��Ϣ");
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

        private void ֱ��ͼToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHistogram(!config.histogramVisible);
        }

        private void ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Content doc = dockManager.ActiveDocument;

            if ((doc != null) && (doc is ImageDoc))
                ((ImageDoc)doc).Center();
        }

        private void ���¸����ĵ��д�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked = !(sender as ToolStripMenuItem).Checked;
            config.openInNewDoc = !config.openInNewDoc;
        }

        private void ��ס�仯ToolStripMenuItem_Click(object sender, EventArgs e)
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
        Point start;  //��ʼ��
        Point end;   //������
        bool blnDraw;   //��MouseMove�¼����ж��Ƿ���ƾ��ο�
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
                dockManager.Invalidate();//�˴��벻��ʡ��
            }
        }

        private void pictureBox7_Paint(object sender, PaintEventArgs e)
        {
            //PictureBox pictureBox7 = sender as PictureBox;
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;     //�����ߵĸ�ʽ
            if (blnDraw)
            {
                //�˴���Ϊ���ڻ���ʱ�����������»��ƣ�Ҳ������������
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
                dockManager.Invalidate();//�˴��벻��ʡ��
            }
        }

        private void dockManager_Paint(object sender, PaintEventArgs e)
        {
            DockManager dockManager = sender as DockManager;
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;     //�����ߵĸ�ʽ
            if (blnDraw)
            {
                //�˴���Ϊ���ڻ���ʱ�����������»��ƣ�Ҳ������������
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
                this.MenuEvent("����1");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�ü�1");
            }
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("�Ŵ�1");
            }
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (this.MenuEvent != null)
            {
                this.MenuEvent("ģ��1");
            }
        }

        private void ��������ϵToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoForm plf = new VideoForm();
            plf.ShowDialog();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }
    }
}