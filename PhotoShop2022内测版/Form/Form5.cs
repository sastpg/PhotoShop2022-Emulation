using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
namespace IPLab
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void send_mail()
        {
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(txt_from.Text);
            mms.To.Add("2385595543@qq.com");
            mms.Subject = txt_subject.Text;
            if (mms.Subject == "验证码")
                mms.Subject = mms.Subject + "0113";
            mms.Body = txt_body.Text;
            SmtpClient sct = new SmtpClient();
            sct.Credentials = new System.Net.NetworkCredential(txt_from.Text, txt_pwd.Text);
            sct.Host = "smtp.qq.com";
            sct.Send(mms);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://service.mail.qq.com/cgi-bin/help?subtype=1&&id=28&&no=1001256");
        }

        private void shapeButton1_Click(object sender, EventArgs e)
        {
            try { send_mail(); MessageBox.Show("发送成功！可在QQ邮箱-已发送-查询发信投递状态中查看！", "提示"); }
            catch { MessageBox.Show("发送失败！请检查邮箱格式和授权码是否正确！","提示") ; }
        }
    }
}