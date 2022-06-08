using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
namespace IPLab
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            QRCodeEncoder qed = new QRCodeEncoder();
            var qrcode = qed.Encode("验证码：0113", Encoding.UTF8);
            pictureBox1.Image = qrcode;
        }

        private void shapeButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0113")
            {
                this.Close();
                Form3 frm3 = new Form3();
                frm3.ShowDialog();
            }
            else
                MessageBox.Show("验证码错误！", "提示");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int t=int.Parse(label6.Text);
            t--;
            label6.Text = t.ToString();
            if (label6.Text == "0")
                this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }
    }
}
