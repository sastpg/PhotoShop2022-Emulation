using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = 0;
            if (this.label1.Text == "正在扫描增效工具..." && count == 0)
            {
                this.label1.Text = "正在扫描预置...";
                count = 1;
            }
            if (this.label1.Text == "正在扫描预置..." && count == 0)
            {
                this.label1.Text = "正在初始化...";
                count = 1;
            }
            if (this.label1.Text == "正在初始化..." && count == 0)
            {
                this.label1.Text = "正在初始化AXE...";
                count = 1;
            }
            if (this.label1.Text == "正在初始化AXE..." && count == 0)
            {
                this.label1.Text = "正在读取首选项...";
                count = 1;
            }
            if (this.label1.Text == "正在读取首选项..." && count == 0)
            {
                this.label1.Text = "正在读取画笔...";
                count = 1;
            }
            if (this.label1.Text == "正在读取画笔..." && count == 0)
            {
                this.label1.Text = "正在启动增效工具...脚本支持";
                count = 1;
            }
            if (this.label1.Text == "正在启动增效工具...脚本支持" && count == 0)
            {
                this.label1.Text = "正在初始化面板...";
                count = 1;
            }

            if (this.label1.Text == "正在初始化面板..." && count == 0)
            {
                timer1.Stop();
                using (Form2 ps = new Form2())
                {
                    this.Hide();
                    ps.ShowDialog();
                    
                }
            }
        }
    }
    
}
