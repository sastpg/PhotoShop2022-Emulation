using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

using WeifenLuo.WinFormsUI;
using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;


namespace IPLab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelDock3.Controls.Add(childForm);
            panelDock3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.adobe.com/cn/products/photoshop.html");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(42, 42, 42);
            panel8.Visible = false;
        }
        SpeechSynthesizer speech = new SpeechSynthesizer();
        private void btnLearn_Click(object sender, EventArgs e)
        {
            btnLearn.BackColor = Color.FromArgb(42, 42, 42);
            panel8.Visible = true;
            speech.SpeakAsync("真是好学呀！让我们一起开启Photo Shop2022之旅！");
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(27, 27, 27);
        }

        private void btnLearn_Leave(object sender, EventArgs e)
        {
            btnLearn.BackColor = Color.FromArgb(27, 27, 27);
        }


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            System.Windows.Forms.OpenFileDialog openFileDlg = new System.Windows.Forms.OpenFileDialog();
            openFileDlg.Title = "请选择图片";
            openFileDlg.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                mainform.fileName = openFileDlg.FileName;
                OpenChildForm(mainform);
                mainform.OpenFile();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void shapeButton2_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            System.Windows.Forms.OpenFileDialog openFileDlg = new System.Windows.Forms.OpenFileDialog();
            openFileDlg.Title = "请选择图片";
            openFileDlg.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                mainform.fileName = openFileDlg.FileName;
                OpenChildForm(mainform);
                mainform.OpenFile();
            }
        }

        private void shapeButton1_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            OpenChildForm(mainform);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainform = new MainForm();
            System.Windows.Forms.OpenFileDialog openFileDlg = new System.Windows.Forms.OpenFileDialog();
            openFileDlg.Title = "请选择图片";
            openFileDlg.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                mainform.fileName = openFileDlg.FileName;
                OpenChildForm(mainform);
                mainform.OpenFile();
            }
        }


        private void 摄影_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Resources\\简介.3gp";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = "Resources\\裁剪.3gp";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.URL = "Resources\\滤镜.3gp";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.URL = "Resources\\锐化.3gp";
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            OpenChildForm(mainform);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            btnLearn.BackColor = Color.FromArgb(42, 42, 42);
            panel8.Visible = true;
            speech.SpeakAsync("真是好学呀！让我们一起开启Photo Shop2022之旅！");
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
            MessageBox.Show("PhotoShop2022内测版2.2", "版本信息");
        }

        private void 与作者联系ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }
    }
}
