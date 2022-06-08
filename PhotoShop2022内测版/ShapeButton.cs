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
namespace PhotoShop2022_内测版
{
    public class ShapeButton : Control
    {
        private float exBorderSize=0f;
        [Category("EX属性")]
        [DefaultValue(typeof(float),"0")]
        public float ExBorderSize
        {
            get { return exBorderSize; }
            set { exBorderSize = value; Invalidate(); }
        }

        private float exBorderRadius = 10f;
        [Category("EX属性")]
        [DefaultValue(typeof(float), "10")]
        public float ExBorderRadius
        {
            get { return exBorderRadius; }
            set { exBorderRadius = value; Invalidate(); }
        }

        private Color exBorderColor = Color.Transparent;
        [Category("EX属性")]
        [DefaultValue(typeof(Color), "Transparent")]
        public Color ExBorderColor
        {
            get { return exBorderColor; }
            set { exBorderColor = value; Invalidate(); }
        }

        private Color exButtonColor = Color.Lime;
        [Category("EX属性")]
        [DefaultValue(typeof(Color), "Lime")]
        public Color ExButtonColor
        {
            get { return exButtonColor; }
            set { exButtonColor = value; Invalidate(); }
        }

        private string exText = "ShapeButton";
        [Category("EX属性")]
        [DefaultValue(typeof(string), "ShapeButton")]
        public string ExText
        {
            get { return exText; }
            set { exText = value; Invalidate(); }
        }

        private Color exTextColor = Color.Black;
        [Category("EX属性")]
        [DefaultValue(typeof(Color), "Black")]
        public Color ExTextColor
        {
            get { return exTextColor; }
            set { exTextColor = value; Invalidate(); }
        }
        
        private Font exTextFont = new Font("微软雅黑",12f,FontStyle.Regular);
        [Category("EX属性")]
        public Font ExTextFont
        {
            get { return exTextFont; }
            set { exTextFont = value; Invalidate(); }
        }
        public ShapeButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Size = new Size(210, 70);
        }
        private RectangleF GetRectangleF(RectangleF rectangleF,float borderSize)
        {
            float x = rectangleF.X + borderSize;
            float y = rectangleF.Y + borderSize;
            float w = rectangleF.Width - borderSize;
            float h = rectangleF.Height - borderSize;
            return new RectangleF(x,y,w,h);
        }

        GraphicsPath GetGraphicsPath(RectangleF rectangleF,float borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            borderRadius = (borderRadius + 1f) * 2f;
            RectangleF topLeft = new RectangleF(rectangleF.X,rectangleF.Y,borderRadius,borderRadius);
            RectangleF topRight = new RectangleF(rectangleF.Width - borderRadius - 1f, rectangleF.Y, borderRadius, borderRadius);
            RectangleF bottomRight = new RectangleF(rectangleF.Width - borderRadius - 1f, rectangleF.Height - borderRadius - 1f, borderRadius, borderRadius);
            RectangleF bottomLeft = new RectangleF(rectangleF.X, rectangleF.Height - borderRadius - 1f, borderRadius, borderRadius);

            path.AddArc(topLeft, 180f, 90f);
            path.AddArc(topRight, 270f, 90f);
            path.AddArc(bottomRight, 0, 90f);
            path.AddArc(bottomLeft, 90f, 90f);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Region
            RectangleF rectangleF_Region = GetRectangleF(ClientRectangle, 0f);
            GraphicsPath path_Region = GetGraphicsPath(rectangleF_Region, exBorderRadius);
            Region = new Region(path_Region);

            //Border
            RectangleF rectangleF_Border = GetRectangleF(rectangleF_Region, 1f);
            GraphicsPath path_Border = GetGraphicsPath(rectangleF_Border, exBorderRadius);
            SolidBrush solidBrush_Border = new SolidBrush(exBorderColor);
            e.Graphics.FillPath(solidBrush_Border, path_Border);
            //Main
            RectangleF rectangleF_Main = GetRectangleF(rectangleF_Border, exBorderSize);
            GraphicsPath path_Main = GetGraphicsPath(rectangleF_Main, exBorderRadius);
            SolidBrush solidBrush_Main = new SolidBrush(exButtonColor);
            e.Graphics.FillPath(solidBrush_Main, path_Main);

            //Text
            SolidBrush solidBrush_Text = new SolidBrush(exTextColor);
            StringFormat exTextFormat = new StringFormat();
            exTextFormat.Alignment = StringAlignment.Center;
            exTextFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(exText, exTextFont, solidBrush_Text, rectangleF_Main, exTextFormat);

        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button==MouseButtons.Left)
            {
                ExBorderSize += 2f;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                ExBorderSize -= 2f;
            }
        }
    }
}
