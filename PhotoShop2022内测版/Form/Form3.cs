using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ThoughtWorks.QRCode.Codec;
using System.Speech.Synthesis;
namespace IPLab
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void DrawBlockText()
        {
            SizeF textSize;
            Graphics g;
            Brush myBackBrush = Brushes.Black;
            Brush myForeBrush = Brushes.Aquamarine;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);
            float xLocation, yLocation;
            int i;

            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);

            textSize = g.MeasureString(this.txtShortText.Text, myFont);
            xLocation = (picDemoArea.Width - textSize.Width) / 2;
            yLocation = (picDemoArea.Height - textSize.Height) / 2;

            for (i = (int)effectDepth.Value; i >= 0; i--)
                g.DrawString(txtShortText.Text, myFont, myBackBrush, xLocation - i, yLocation + i);
            g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
        }
        private void DrawBrushText()
        {
            SizeF textSize;
            Graphics g;
            Brush myBrush;
            RectangleF gradientRectangle;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);

            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);

            textSize = g.MeasureString(this.txtShortText.Text, myFont);
            if (this.optHatch.Checked)
                myBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.Blue, Color.Yellow);
            else
            {
                gradientRectangle = new RectangleF(new PointF(0, 0), textSize);
                myBrush = new LinearGradientBrush(gradientRectangle, Color.Blue, Color.Yellow, LinearGradientMode.ForwardDiagonal);
            }

            g.DrawString(txtShortText.Text, myFont, myBrush, (picDemoArea.Width - textSize.Width) / 2, (picDemoArea.Height - textSize.Height) / 2);
        }
        private void DrawEmbossedText()
        {
            SizeF textSize;
            Graphics g;
            Brush myBackBrush = Brushes.Black;
            Brush myForeBrush = Brushes.White;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);
            float xLocation, yLocation;
            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);
            textSize = g.MeasureString(this.txtShortText.Text, myFont);

            xLocation = (picDemoArea.Width - textSize.Width) / 2;
            yLocation = (picDemoArea.Height - textSize.Height) / 2;

            g.DrawString(txtShortText.Text, myFont, myBackBrush, xLocation + (float)this.effectDepth.Value, yLocation + (float)this.effectDepth.Value);

            g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
        }
        private void DrawReflectText()
        {
            SizeF textSize;
            Graphics g;
            Brush myBackBrush = Brushes.Gray;
            Brush myForeBrush = Brushes.Black;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);
            float xLocation, yLocation;
            float textHeight;
            GraphicsState myState;

            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);
            textSize = g.MeasureString(this.txtShortText.Text, myFont);
            xLocation = (picDemoArea.Width - textSize.Width) / 2;
            yLocation = (picDemoArea.Height - textSize.Height) / 2;
            g.TranslateTransform(xLocation, yLocation);

            int lineAscent;
            int lineSpacing;
            float lineHeight;

            lineAscent = myFont.FontFamily.GetCellAscent(myFont.Style);
            lineSpacing = myFont.FontFamily.GetLineSpacing(myFont.Style);
            lineHeight = myFont.GetHeight(g);
            textHeight = lineHeight * lineAscent / lineSpacing;
            myState = g.Save();
            g.ScaleTransform(1, -1.0F);
            g.DrawString(txtShortText.Text, myFont, myBackBrush, 0, -textHeight);
            g.Restore(myState);
            g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, -textHeight);
        }
        private void DrawShadowText()
        {
            SizeF textSize;
            Graphics g;
            Brush myShadowBrush = Brushes.Gray;
            Brush myForeBrush = Brushes.Black;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);
            float xLocation, yLocation;
            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);
            textSize = g.MeasureString(this.txtShortText.Text, myFont);
            xLocation = (picDemoArea.Width - textSize.Width) / 2;
            yLocation = (picDemoArea.Height - textSize.Height) / 2;

            g.DrawString(txtShortText.Text, myFont, myShadowBrush, xLocation + (float)this.effectDepth.Value, yLocation + (float)this.effectDepth.Value);


            g.DrawString(txtShortText.Text, myFont, myForeBrush, xLocation, yLocation);
        }
        private void DrawShearText()
        {
            SizeF textSize;
            Graphics g;
            Brush myForeBrush = Brushes.Black;
            Font myFont = new Font("宋体", (float)this.nudFontSize.Value, FontStyle.Regular);
            Matrix myTransform;
            float xLocation, yLocation;

            g = picDemoArea.CreateGraphics();
            g.Clear(Color.White);
            textSize = g.MeasureString(this.txtShortText.Text, myFont);

            xLocation = (picDemoArea.Width - textSize.Width) / 2;
            yLocation = (picDemoArea.Height - textSize.Height) / 2;

            g.TranslateTransform(xLocation, yLocation);

            myTransform = g.Transform;
            myTransform.Shear((float)nudSkew.Value, 0);
            g.Transform = myTransform;

            g.DrawString(txtShortText.Text, myFont, myForeBrush, 0, 0);
        }
        private void DrawText()
        {
            if (lstEffects.SelectedItem == null)
                lstEffects.SelectedIndex = 0;

            string str = lstEffects.SelectedItem.ToString();
            switch (str)
            {
                case "Brush":
                    DrawBrushText();
                    break;
                case "阴影":
                    DrawShadowText();
                    break;
                case "浮雕":
                    DrawEmbossedText();
                    break;
                case "Block":
                    DrawBlockText();
                    break;
                case "切变":
                    DrawShearText();
                    break;
                case "倒影":
                    DrawReflectText();
                    break;
            }
        }

        private void lstEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.optHatch.Enabled = false;
            this.optGradient.Enabled = false;
            this.effectDepth.Enabled = false;
            this.nudSkew.Enabled = false;
            string str = lstEffects.SelectedItem.ToString();
            switch (str)
            {
                case "Brush":
                    this.optHatch.Enabled = true;
                    this.optGradient.Enabled = true;
                    break;
                case "阴影":
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    break;
                case "浮雕":
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    break;
                case "Block":
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    this.effectDepth.Enabled = true;
                    break;
                case "切变":
                    this.nudSkew.Enabled = true;
                    break;
                case "倒影":
                    break;
            }

            DrawText();
        }

        private void optHatch_CheckedChanged(object sender, EventArgs e)
        {
            if (nudFontSize.Value == 0)
                this.nudFontSize.Value = 50;
            DrawText();
        }

        private void optGradient_CheckedChanged(object sender, EventArgs e)
        {
            if (nudFontSize.Value == 0)
                this.nudFontSize.Value = 50;
            DrawText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void shapeButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SpeechSynthesizer speech = new SpeechSynthesizer();
        private void shapeButton2_Click(object sender, EventArgs e)
        {
            speech.SpeakAsync("这是付费项目，请您扫码支付");
            QRCodeEncoder qed = new QRCodeEncoder();
            var qrcode = qed.Encode("支付宝收款20元", Encoding.UTF8);
            picDemoArea.Image = qrcode;
        }
    }
}