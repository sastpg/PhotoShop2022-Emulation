using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Palette
{
    class Util
    {
        /// <summary>
        /// 根据RectangleF得到Rectangle
        /// </summary>
        /// <param name="rf"></param>
        /// <returns></returns>
        public static Rectangle Rect(RectangleF rf)
        {
            Rectangle r = new Rectangle();
            r.X = (int)rf.X;
            r.Y = (int)rf.Y;
            r.Width = (int)rf.Width;
            r.Height = (int)rf.Height;
            return r;
        }
        /// <summary>
        /// 根据Rectangle得到RectangleF
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static RectangleF Rect(Rectangle r)
        {
            RectangleF rf = new RectangleF();
            rf.X = (float)r.X;
            rf.Y = (float)r.Y;
            rf.Width = (float)r.Width;
            rf.Height = (float)r.Height;
            return rf;
        }
        /// <summary>
        /// 根据PointF得到Point
        /// </summary>
        /// <param name="rf"></param>
        /// <returns></returns>
        public static Point Point(PointF pf)
        {
            return new Point((int)pf.X, (int)pf.Y);
        }
        /// <summary>
        /// 得到RectangleF的中心点
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static PointF Center(RectangleF r)
        {
            PointF center = r.Location;
            center.X += r.Width / 2;
            center.Y += r.Height / 2;
            return center;
        }
        /// <summary>
        /// 得到半径
        /// </summary>
        /// <param name="r">RectangleF</param>
        /// <returns></returns>
        public static double Radius(RectangleF r)
        {
            return Math.Min(r.Width / 2, r.Height / 2);
        }
        /// <summary>
        /// 得到半径
        /// </summary>
        /// <param name="r">Rectangle</param>
        /// <returns></returns>
        public static int RadiusInt(Rectangle r)
        {
            return Math.Min(r.Width / 2, r.Height / 2);
        }
        /// <summary>
        /// 绘制外围颜色框
        /// </summary>
        public static void DrawFrame(Graphics dc, RectangleF r, float cornerRadius, Color color)
        {
            Pen pen = new Pen(color);
            if (cornerRadius <= 0)
            {
                dc.DrawRectangle(pen, Rect(r));
                return;
            }
            cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Width) - 2);
            cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Height) - 2);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(r.Right - cornerRadius, r.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(r.Right - cornerRadius, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(r.X, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            dc.DrawPath(pen, path);
        }
        /// <summary>
        /// 画2颜色过渡
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="r">RectangleF</param>
        /// <param name="lightnessWidth">过渡色控件宽度</param>
        /// <param name="Start">起始颜色</param>
        /// <param name="End">结束颜色</param>
        /// <param name="startAngle">起始角度</param>
        /// <param name="Angle">跨越角度</param>
        public static void Draw2ColorBar(Graphics graphics, RectangleF r, int lightnessWidth, Color Start, Color End, float startAngle, float Angle)
        {
            r.Inflate(-lightnessWidth / 2, -lightnessWidth / 2);
            //PointF pf= Util.Center(r);
            //graphics.TranslateTransform(pf.X,pf.Y);
            //graphics.RotateTransform(270f - startAngle * 2f);

            float trA, tgA, tbA;//R,G,B颜色
            float trB, tgB, tbB;//R,G,B颜色

            trA = Start.R; tgA = Start.G; tbA = Start.B;
            trB = End.R; tgB = End.G; tbB = End.B;
            for (int i = 0; i < Angle; i++)
            {
                float tr, tg, tb;//R,G,B颜色
                tr = trA + (trB - trA) / Angle * i;
                tg = tgA + (tgB - tgA) / Angle * i;
                tb = tbA + (tbB - tbA) / Angle * i;
                Color c = Color.FromArgb(255, (int)tr, (int)tg, (int)tb);
                Pen pen = new Pen(c, lightnessWidth);


                startAngle -= 1;
                graphics.DrawArc(pen, r, startAngle, 2);
            }
        }
        /// <summary>
        /// 画3颜色过渡
        /// </summary>
        /// <param name="lightnessWidth">过渡色控件宽度</param>
        /// <param name="Start">起始颜色</param>
        /// <param name="End">结束颜色</param>
        /// <param name="Middle">中间颜色</param>
        public static void Draw3ColorBar(Graphics graphics, RectangleF r, int lightnessWidth, Color End, Color Middle, Color Start)
        {
            Draw2ColorBar(graphics, r, lightnessWidth, Start, Middle, 90, 180);
            Draw2ColorBar(graphics, r, lightnessWidth, Middle, End, 270, 180);
        }
        /// <summary>
        /// 根据坐标点在RectangleF的位置得到百分比
        /// </summary>
        /// <param name="p"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static double GetPercentFromTwoPoint(PointF p, RectangleF rect)
        {
            double Percent = new double();
            PointF center = Util.Center(rect);
            double angleOfLine = Math.Atan2((p.Y - center.Y), (p.X - center.X)) * 180 / Math.PI;
            if (angleOfLine > 90 && angleOfLine <= 180)
            {
                Percent = (angleOfLine - 90) / 360;
            }
            else if (angleOfLine > -180 && angleOfLine <= 0)
            {
                Percent = (180 + angleOfLine + 90) / 360;
            }
            else if ((angleOfLine > 0 && angleOfLine <= 90))
            {
                Percent = (angleOfLine + 270) / 360;
            }
            return Percent;
        }

        public static double RadianFromDensity(int Density, int minHu, int maxHu)//根据密度得到弧度
        {
            return ((Density - minHu) * (340 * Math.PI / 180) / (maxHu - minHu)) + (10 * Math.PI / 180);
        }
        public static double AngleFromDensity(int Density, int minHu, int maxHu)//根据密度得到角度
        {
            return (Density - minHu) * 340 / (maxHu - minHu) + 10;
        }
        public static double DensityFromAngle(double Angle, int minHu, int maxHu)//根据角度得到密度
        {
            return ((Angle - 10) * (maxHu - minHu)) / 340 + minHu;
        }
        public static Point GetPointByAR(double Angle, double Radius, PointF Center)//根据角度和半径得到坐标
        {
            double Radian = Angle * Math.PI / 180;

            Point Result = new Point();
            if (Radian >= 0 && Radian < Math.PI / 2)//1区-----豁口处逆时针第一个象限,并且横坐标不可以为零纵坐标可以为零,即包括起点不包括终点,即分母不能为零)
            {
                Result = new Point((int)(Center.X - (Radius * Math.Sin(Radian))), (int)(Center.Y - (Radius * Math.Cos(Radian))));
            }
            else if (Radian >= Math.PI / 2 && Radian < Math.PI)//2区
            {
                Radian = Radian - Math.PI / 2;
                Result = new Point((int)(Center.X - Radius * Math.Cos(Radian)), (int)(Center.Y + (Radius * Math.Sin(Radian))));
            }
            else if (Radian >= Math.PI && Radian < Math.PI + Math.PI / 2)//3区
            {
                Radian = Radian - Math.PI;
                Result = new Point((int)(Center.X + (Radius * Math.Sin(Radian))), (int)(Center.Y + (Radius * Math.Cos(Radian))));
            }
            else if (Radian >= Math.PI + Math.PI / 2 && Radian < Math.PI * 2)//4区
            {
                Radian = Radian - (Math.PI + Math.PI / 2);

                Result = new Point((int)(Center.X + Radius * Math.Cos(Radian)), (int)(Center.Y - (Radius * Math.Sin(Radian))));
            }
            //------------------------------------------------
            return Result;
        }
        public static PointF GetPointFByAR(double Angle, double Radius, PointF Center)//根据角度和半径得到坐标
        {
            double Radian = Angle * Math.PI / 180;
            PointF Result = new PointF();
            if (Radian >= 0 && Radian < Math.PI / 2)//1区-----豁口处逆时针第一个象限,并且横坐标不可以为零纵坐标可以为零,即包括起点不包括终点,即分母不能为零)
            {
                Result = new PointF(Convert.ToSingle(Center.X - (Radius * Math.Sin(Radian))), Convert.ToSingle(Center.Y - (Radius * Math.Cos(Radian))));
            }
            else if (Radian >= Math.PI / 2 && Radian < Math.PI)//2区
            {
                Radian = Radian - Math.PI / 2;
                Result = new PointF(Convert.ToSingle(Center.X - Radius * Math.Cos(Radian)), Convert.ToSingle(Center.Y + (Radius * Math.Sin(Radian))));
            }
            else if (Radian >= Math.PI && Radian < Math.PI + Math.PI / 2)//3区
            {
                Radian = Radian - Math.PI;
                Result = new PointF(Convert.ToSingle(Center.X + (Radius * Math.Sin(Radian))), Convert.ToSingle(Center.Y + (Radius * Math.Cos(Radian))));
            }
            else if (Radian >= Math.PI + Math.PI / 2 && Radian < Math.PI * 2)//4区
            {
                Radian = Radian - (Math.PI + Math.PI / 2);

                Result = new PointF(Convert.ToSingle(Center.X + Radius * Math.Cos(Radian)), Convert.ToSingle(Center.Y - (Radius * Math.Sin(Radian))));
            }
            //------------------------------------------------
            return Result;
        }
        public static double PointToCenter(PointF Center, PointF point)//得到坐标距离中心的距离
        {
            return (Math.Sqrt(Math.Abs(point.X - Center.X) * Math.Abs(point.X - Center.X) + Math.Abs(point.Y - Center.Y) * Math.Abs(point.Y - Center.Y)));//鼠标点距离中心的距离
        }
        public static double GetAngle(PointF Center, PointF A)//根据坐标返回角度
        {
            double Y = -((double)A.Y) + Center.Y;
            double X = (double)A.X - Center.X;//页面坐标转换为平面坐标系
            double Radian = 0;
            double Angle = 0;

            if (X <= 0 & Y > 0)//1区-----豁口处逆时针第一个象限,并且横坐标不可以为零纵坐标可以为零,即包括起点不包括终点,即分母不能为零)
            {
                Radian = Math.Atan(-X / Y);
                Angle = Radian * 180 / Math.PI;
            }
            else if (X < 0 & Y <= 0)//2区
            {
                Radian = Math.Atan(Y / X);
                Radian = Radian + Math.PI / 2;
                Angle = Radian * 180 / Math.PI;
            }
            else if (X >= 0 & Y < 0)//3区
            {
                Radian = Math.Atan(X / -Y);
                Radian = Radian + Math.PI;
                Angle = Radian * 180 / Math.PI;
            }
            else if (X > 0 & Y >= 0)//4区
            {
                Radian = Math.Atan(Y / X);
                Radian = Radian + Math.PI + Math.PI / 2;
                Angle = Radian * 180 / Math.PI;
            }
            return Angle;
        }
        public static double ThreePointAngle(PointF cen, PointF first, PointF second)//求三点夹角
        {
            const double M_PI = 3.1415926535897;

            double v1 = ((first.X - cen.X) * (second.X - cen.X)) + ((first.Y - cen.Y) * (second.Y - cen.Y));
            double ma_val = Math.Sqrt((first.X - cen.X) * (first.X - cen.X) + (first.Y - cen.Y) * (first.Y - cen.Y));
            double mb_val = Math.Sqrt((second.X - cen.X) * (second.X - cen.X) + (second.Y - cen.Y) * (second.Y - cen.Y));
            double cosM = v1 / (ma_val * mb_val);
            double angleAMB = Math.Acos(cosM) * 180 / M_PI;
            return angleAMB;
        }
        public static double TwoPointRange(PointF p, PointF p2)//求两点距离
        {
            return Math.Sqrt(Math.Abs(p.X - p2.X) * Math.Abs(p.X - p2.X) + Math.Abs(p.Y - p2.Y) * Math.Abs(p.Y - p2.Y));
        }
        public static double GetDistance(PointF a, PointF b)//求两点距离
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        public static Point GetPointByTwoPointAndAngle(Point A, Point Center, double Angle)//根据A点、一个中心点以及旋转的角度，求A点旋转后的坐标
        {
            int realx1 = A.X - Center.X;
            int realy1 = A.Y - Center.Y;
            Angle = 360 - Angle;

            int realx2 = (int)(realx1 * Math.Cos(Math.PI / 180 * Angle) - realy1 * Math.Sin(Math.PI / 180 * Angle));
            int realy2 = (int)(realy1 * Math.Cos(Math.PI / 180 * Angle) + realx1 * Math.Sin(Math.PI / 180 * Angle));

            int x2 = realx2 + Center.X;
            int y2 = realy2 + Center.Y;
            return new Point(x2, y2);
        }

    }
}
