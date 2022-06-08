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
    //根据HSL颜色坐标系，选择颜色的控件
    class ColorSetWheel : Control
    {
        public event EventHandler SelectedColorChanged;//定义颜色选择事件

        //Color m_frameColor = Color.CadetBlue;//CadetBlue军校蓝
        HSLColor m_selectedColor = new HSLColor(Color.BlanchedAlmond);//定义一个HSLColor类实例//BlanchedAlmond白杏色
        PathGradientBrush m_brush = null;//渐变画刷
        List<PointF> m_path = new List<PointF>();//渐变圆环上节点
        List<Color> m_colors = new List<Color>();//渐变圆对应的颜色
        double m_wheelLightness = 0.5;//默认亮度0.5

        public ColorSetWheel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnCreateControl()//控件重绘为圆形
        {
            this.Region = GetRegion();

            base.OnCreateControl();
        }

        private Region GetRegion()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(WheelRectangle);
            Region region = new Region(gp);
            gp.Dispose();
            return region;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            RectangleF wheelrect = ColorWheelRectangle;

            PointF center = Util.Center(wheelrect);
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;//不抗锯齿

            if (m_brush == null)
            {
                m_brush = new PathGradientBrush(m_path.ToArray(), WrapMode.Clamp);
                m_brush.CenterPoint = center;
                m_brush.CenterColor = Color.FromArgb(127, 127, 127);//圆心颜色为灰色
                m_brush.SurroundColors = m_colors.ToArray();
            }
            e.Graphics.FillPie(m_brush, Util.Rect(wheelrect), 0, 360);
            DrawColorSelector(e.Graphics);//画颜色选择点

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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = GetRegion();
            if (m_brush != null)
                m_brush.Dispose();
            m_brush = null;
            RecalcWheelPoints();
            Refresh();
        }
        void RecalcWheelPoints()//生成构成圆上点和颜色
        {
            m_path.Clear();
            m_colors.Clear();

            PointF center = Util.Center(ColorWheelRectangle);
            float radius = Radius(ColorWheelRectangle);
            double angle = 0;
            double fullcircle = 360;
            double step = 5;
            while (angle < fullcircle)
            {
                double angleR = angle * (Math.PI / 180);
                double x = center.X + Math.Cos(angleR) * radius;
                double y = center.Y - Math.Sin(angleR) * radius;
                m_path.Add(new PointF((float)x, (float)y));
                m_colors.Add(new HSLColor(angle, 1, m_wheelLightness).Color);
                angle += step;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            PointF mousepoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetColor(mousepoint);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            PointF mousepoint = new PointF(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                SetColor(mousepoint);
        }
        public HSLColor SelectedHSLColor
        {
            get { return m_selectedColor; }
            set
            {
                if (m_selectedColor == value)
                    return;
                //Invalidate(Util.Rect(ColorSelectorRectangle));
                m_selectedColor = value;
                Refresh();//Invalidate(Util.Rect(ColorSelectorRectangle));
                if (SelectedColorChanged != null)
                    SelectedColorChanged(this, null);

            }
        }
        public HSLColor SelectedHSLColorNoEvent
        {
            get { return m_selectedColor; }
            set
            {
                if (m_selectedColor == value)
                    return;
                //Invalidate(Util.Rect(ColorSelectorRectangle));
                m_selectedColor = value;
                Refresh();//Invalidate(Util.Rect(ColorSelectorRectangle));
            }
        }

        RectangleF ColorSelectorRectangle
        {
            get
            {
                HSLColor color = m_selectedColor;
                double angleR = color.Hue * Math.PI / 180;
                PointF center = Util.Center(ColorWheelRectangle);
                double radius = Radius(ColorWheelRectangle);
                radius *= color.Saturation;//半径
                double x = center.X + Math.Cos(angleR) * radius;
                double y = center.Y - Math.Sin(angleR) * radius;
                Rectangle colrect = new Rectangle(new Point((int)x, (int)y), new Size(0, 0));
                colrect.Inflate(5, 5);//取色小环的大小
                return colrect;
            }
        }
        float Radius(RectangleF r)
        {
            //PointF center = Util.Center(r);
            float radius = Math.Min((r.Width / 2), (r.Height / 2));
            return radius;
        }
        /// <summary>
        /// 根据鼠标点在控件的位置，设置HSL颜色值
        /// </summary>
        /// <param name="mousepoint"></param>
        void SetColor(PointF mousepoint)
        {
            if (WheelRectangle.Contains(mousepoint) == false)
                return;

            PointF center = Util.Center(ColorWheelRectangle);
            double radius = Radius(ColorWheelRectangle);
            double dx = Math.Abs(mousepoint.X - center.X);
            double dy = Math.Abs(mousepoint.Y - center.Y);
            double angle = Math.Atan(dy / dx) / Math.PI * 180;
            double dist = Math.Pow((Math.Pow(dx, 2) + (Math.Pow(dy, 2))), 0.5);
            double saturation = dist / radius;
            //if (dist > radius + 5) // give 5 pixels slack
            //	return;
            if (dist < 6)
                saturation = 0; // snap to center

            if (mousepoint.X < center.X)
                angle = 180 - angle;
            if (mousepoint.Y > center.Y)
                angle = 360 - angle;

            SelectedHSLColor = new HSLColor(angle, saturation, SelectedHSLColor.Lightness);
        }
        void DrawColorSelector(Graphics dc)
        {
            Rectangle r = Util.Rect(ColorSelectorRectangle);
            PointF center = Util.Center(r);

            Image image = SelectorImages.Image(SelectorImages.eIndexes.Donut);//实心块
            dc.DrawImageUnscaled(image, (int)(center.X - image.Width / 2), (int)(center.Y - image.Height / 2));

            //Pen penOut = new Pen(Color.Black);  //圆圈
            //dc.DrawEllipse(penOut, r);
        }
        RectangleF WheelRectangle//组件所在矩形
        {
            get
            {
                Rectangle r = ClientRectangle;
                return r;
            }
        }
        RectangleF ColorWheelRectangle//组件高宽减5
        {
            get
            {
                RectangleF r = WheelRectangle;
                r.Inflate(-5, -5);
                return r;
            }
        }
    }
}
