/*******************************************************************************
 * ColorPalette.cs
 * A simple Dreamweaver-styled color palette control.
 * -----------------------------------------------------------------------------
 * Project: Conmajia's ColorPicker
 * Author: Conmajia
 * Url: conmajia@gmail.com
 * Initiate: 18th July, 2012
 * Version: 1.0.0.0
 * History:
 *      18th July, 2012
 *      Initiated.
 * ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ConmajiaColorPicker
{
    [DefaultEvent("ColorChanged")]
    public class ColorPalette : Control
    {
        // -- variables
        int blockWidth = 10;
        int rows = 6;
        int cols = 36;
        Color current;
        Rectangle cursor;
        Rectangle lastCursor;
        Brush brush;

        // -- properties
        public int BlockWidth
        {
            get { return blockWidth; }
            set
            {
                if (value < 3 || value > 20)
                {
                    MessageBox.Show("Block size is between 3 and 20.");
                    return;
                }
                blockWidth = value;
                cursor.Width = cursor.Height = blockWidth;
                lastCursor.Width = lastCursor.Height = blockWidth;
                OnResize(null);
                Refresh();
            }
        }

        public bool ShowCursor
        {
            get;
            set;
        }

        // -- initializers
        public ColorPalette()
        {
            this.DoubleBuffered = true;

            this.BackColor = Color.Black;
            this.brush = new SolidBrush(Color.Black);
            this.current = Color.Black;
            this.lastCursor = this.cursor = new Rectangle(0, 0, blockWidth, blockWidth);
            this.Size = getSize(rows, cols);
        }
        public ColorPalette(int blockWidth)
        {
            this.SetStyle(
                ControlStyles.FixedWidth |
                ControlStyles.FixedHeight |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;

            this.BackColor = Color.Black;
            this.brush = new SolidBrush(Color.Black);
            this.blockWidth = blockWidth;
            this.current = Color.Black;
            this.lastCursor = this.cursor = new Rectangle(0, 0, blockWidth, blockWidth);
            this.Size = getSize(rows, cols);
        }

        // -- helpers
        Size getSize(int rows, int cols)
        {
            return new Size(blockWidth * cols + 1, blockWidth * rows + 1);
        }

        Color getColor(int row, int col)
        {
            byte r = 0, g = 0, b = 0;

            int step = 0xff / (rows - 1);

            r = (byte)(row * step);
            g = (byte)(step * (col / rows));
            b = (byte)(step * (col % rows));

            return Color.FromArgb(r, g, b);
        }

        void updateCursor(Point pt)
        {
            lastCursor.X = cursor.X;
            lastCursor.Y = cursor.Y;

            cursor.X = pt.X - pt.X % blockWidth;
            cursor.Y = pt.Y - pt.Y % blockWidth;

            current = getColor(pt.Y / blockWidth, pt.X / blockWidth);
        }

        // -- painters
        void drawCursor(Graphics g)
        {
            g.DrawRectangle(
                Pens.White,
                cursor
                );
        }

        void drawBorder(Graphics g)
        {
            g.DrawRectangle(
                Pens.Black,
                0, 0,
                blockWidth * cols,
                blockWidth * rows
                );
        }

        void drawGrid(Graphics g)
        {
            for (int i = 0; i < rows; i++)
            {
                g.DrawLine(
                    Pens.Black,
                    0,
                    blockWidth * (i + 1),
                    blockWidth * cols,
                    blockWidth * (i + 1)
                    );
            }

            for (int i = 0; i < cols; i++)
            {
                g.DrawLine(
                    Pens.Black,
                    blockWidth * (i + 1),
                    0,
                    blockWidth * (i + 1),
                    blockWidth * rows
                    );
            }
        }

        void drawPalette(Graphics g)
        {
            SolidBrush b = (SolidBrush)brush;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    b.Color = getColor(row, col);
                    g.FillRectangle(
                        b,
                        blockWidth * col,
                        blockWidth * row,
                        blockWidth,
                        blockWidth
                        );
                }
            }
        }

        // -- events
        protected override void OnResize(EventArgs e)
        {
            this.Size = getSize(rows, cols);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawPalette(g);
            drawGrid(g);
            drawBorder(g);
            if (ShowCursor)
                drawCursor(g);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Location.X > this.Width - 2 || e.Location.Y > this.Height - 2)
                return;

            updateCursor(e.Location);

            // redraw larger spaces
            Invalidate(
                new Rectangle(
                    lastCursor.X - 1,
                    lastCursor.Y - 1,
                    lastCursor.Width + 2,
                    lastCursor.Height + 2
                    )
                );
            Invalidate(
                new Rectangle(
                    cursor.X - 1,
                    cursor.Y - 1,
                    cursor.Width + 2,
                    cursor.Height + 2
                    )
                );

            // fire event
            OnColorChanged();
        }

        // -- custom events
        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);
        [Description("Fires every time when color changed.")]
        public event ColorChangedEventHandler ColorChanged;
        protected virtual void OnColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, new ColorChangedEventArgs(current));
        }
    }

    // custom event args
    public class ColorChangedEventArgs : EventArgs
    {
        Color color = Color.Black;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public ColorChangedEventArgs(Color color)
            : base()
        {
            this.color = color;
        }
    }
}
