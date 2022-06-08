using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Palette
{
    //用于调节颜色亮度的控件，通过滑竿调节选定颜色的亮度
    class ColorBar : Control
    {
        //控件事件
        public event EventHandler SelectedValueChanged;//亮度变化事件


        #region   控件属性

        private int lightnessWidth = 15;//亮度环宽度
        [Description("亮度选择环的宽度"), Category("控件布局属性"), Browsable(true)]
        public int LightnessWidth
        {
            get { return lightnessWidth; }
            set
            {
                lightnessWidth = value;
                this.colorSelectorSize = new Size(value * 20 / 15, value);
            }
        }

        private Size colorSelectorSize = new Size(20, 15);//颜色选择块的size
        [Description("颜色选择块的Size"), Category("控件布局属性"), Browsable(true)]
        public Size ColorSelectorSize
        {
            get { return colorSelectorSize; }
            set { colorSelectorSize = value; }
        }

        public enum eNumberOfColors//多个颜色渐变
        {
            Use2Colors,
            Use3Colors,
        }
        eNumberOfColors m_numberOfColors = eNumberOfColors.Use3Colors;
        public eNumberOfColors NumberOfColors
        {
            get { return m_numberOfColors; }
            set { m_numberOfColors = value; }
        }

        double m_percent = 0;//亮度变化值  0 - 1.
        public double Percent
        {
            get { return m_percent; }
            set
            {
                // ok so it is not really percent, but a value between 0 - 1.
                if (value < 0) value = 0;
                if (value > 1) value = 1;
                if (value != m_percent)
                {
                    m_percent = value;
                    if (SelectedValueChanged != null)
                        SelectedValueChanged(this, null);
                    Refresh();
                    //Invalidate();
                }

            }
        }

        Color m_color1 = Color.Black;//默认黑
        Color m_color2 = Color.FromArgb(255, 127, 127, 127);//灰色//HSL灰度
        Color m_color3 = Color.White;//默认白
        public Color Color1
        {
            get { return m_color1; }
            set { m_color1 = value; }
        }
        public Color Color2
        {
            get { return m_color2; }
            set
            {
                m_color2 = value;
                Refresh();
            }
        }
        public Color Color3
        {
            get { return m_color3; }
            set { m_color3 = value; }
        }

        double lightWidthRatio;//环比例
        private bool executeOnce = true;//初始化界面比例参数只执行一次
        #endregion


        public ColorBar()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

        }
        protected override void OnCreateControl()//控件重绘为环形
        {
            this.Region = GetRegion();

            base.OnCreateControl();
        }
        private Region GetRegion()
        {

            GraphicsPath gpOut = new GraphicsPath();      //亮度环外圈
            GraphicsPath gpInner = new GraphicsPath();      //亮度环内圈

            gpOut.AddEllipse(ClientRectangleF);
            Region regionOut = new Region(gpOut);

            RectangleF RectangleInner = new RectangleF(ClientRectangleF.Location.X + lightnessWidth, ClientRectangleF.Location.Y + lightnessWidth, ClientRectangleF.Width - lightnessWidth * 2, ClientRectangleF.Height - lightnessWidth * 2);
            gpInner.AddEllipse(RectangleInner);

            regionOut.Xor(gpInner);//并集减去交集

            gpOut.Dispose();
            gpInner.Dispose();
            return regionOut;

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (executeOnce)
            {
                lightWidthRatio = lightnessWidth / this.ClientRectangleF.Width;
                executeOnce = false;
            }
            this.LightnessWidth = (int)(lightWidthRatio * this.ClientRectangleF.Width);
            this.Region = GetRegion();
            Refresh();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿
            base.OnPaint(e);
            DrawColorBar(e.Graphics);
        }
        /// <summary>
        /// 使用GDI渐变色画控件过渡色
        /// </summary>
        /// <param name="dc"></param>
        protected void DrawColorBar(Graphics dc)
        {
            RectangleF lr = ClientRectangleF;
            if (m_numberOfColors == eNumberOfColors.Use2Colors)
                Util.Draw2ColorBar(dc, lr, lightnessWidth, m_color1, m_color3, 0, 360);
            else
                Util.Draw3ColorBar(dc, lr, lightnessWidth, m_color1, m_color2, m_color3);

            DrawSelector(dc, ClientRectangleF, (float)Percent);
        }
        /// <summary>
        /// 画控件亮度拉杆
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="r">拉杆所在圆弧的Rectangle</param>
        /// <param name="percentSet">亮度百分比</param>
        protected void DrawSelector(Graphics graphics, RectangleF r, float percentSet)
        {
            Pen pen = new Pen(Color.CadetBlue);
            percentSet = Math.Max(0, percentSet);
            percentSet = Math.Min(1, percentSet);

            Image image = SelectorImages.GetColorPoint();

            PointF Center = Util.Center(r);
            graphics.TranslateTransform(Center.X, Center.Y);

            float xpos = r.Top - colorSelectorSize.Width / 2;
            float ypos = r.Top + r.Height / 2 - colorSelectorSize.Height;

            float Angle = percentSet * 360;
            graphics.RotateTransform(Angle);
            Rectangle imageRect = new Rectangle(new Point((int)xpos, (int)ypos), colorSelectorSize);
            graphics.DrawImage(image, imageRect);
            //graphics.DrawImageUnscaled(image, (int)xpos, (int)ypos);//按原始大小

            graphics.ResetTransform();

        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            PointF mousepoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetPercent(mousepoint);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            PointF mousepoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetPercent(mousepoint);
        }
        /// <summary>
        /// 设置亮度百分比
        /// </summary>
        /// <param name="mousepoint"></param>
        protected virtual void SetPercent(PointF mousepoint)
        {
            RectangleF cr = ClientRectangleF;


            this.Percent = Util.GetPercentFromTwoPoint(mousepoint, cr);

            if (this.SelectedValueChanged != null)
                SelectedValueChanged(this, null);

            Refresh();

        }
        protected virtual void SetPercent(double percent)
        {
            Percent = percent;
        }

        protected RectangleF ClientRectangleF
        {
            get
            {
                RectangleF r = ClientRectangle;
                return r;
            }
        }
        //protected RectangleF DrawRingRectangleF
        //{
        //    get
        //    {
        //        RectangleF r = ClientRectangleF;
        //        r.Inflate(-colorSelectorSize.Width, -colorSelectorSize.Height);
        //        return r;
        //    }
        //}
    }
    //ColorBar的子类，处理HSL颜色
    class HSLColorBar : ColorBar
    {

        HSLColor m_selectedColor = new HSLColor();
        public HSLColor SelectedHSLColor
        {
            get { return m_selectedColor; }
            set
            {
                if (m_selectedColor == value)
                    return;
                m_selectedColor = value;
                //-----------------------------------------------------
                HSLColor cl = new HSLColor(value.Color);
                cl.Lightness = 0.5;
                Color2 = cl.Color;
                //Color2 = Color.FromArgb(255, value.Color);
                Percent = (float)m_selectedColor.Lightness;
                Refresh();//Invalidate(Util.Rect(BarRectangle));
            }
        }

        protected override void SetPercent(PointF mousepoint)
        {
            base.SetPercent(mousepoint);
            m_selectedColor.Lightness = Percent;
            //---------------------------------------------
            RectangleF cr = ClientRectangleF;
            PointF center = Util.Center(cr);
            PointF newp = new PointF(mousepoint.X, mousepoint.Y);
            if (cr.Contains(mousepoint))
            {
                newp.X -= center.X;
                newp.Y -= center.Y;
                newp.Y = -newp.Y;
                //mousepoint.X -= center.X;
                //mousepoint.Y -= center.Y;
            }
            double angleOfLine = Math.Atan2((-mousepoint.Y + center.X), (mousepoint.X - center.Y)) * 180 / Math.PI;


            //----------------------------------------------
            Refresh();
        }
        //protected override void SetPercent(double percent)
        //{
        //    base.SetPercent(percent);
        //    m_selectedColor.Lightness = percent;
        //    SelectedHSLColor = m_selectedColor;
        //}
    }
}
