using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConmajiaColorPicker;

namespace IPLab
{
    public partial class UC_Palette : UserControl
    {
        public UC_Palette()
        {
            InitializeComponent();
        }
        private void colorPalette1_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            Color current = e.Color;
            textBox1.Text = string.Format("#{0:X2}{1:X2}{2:X2}", current.R, current.G, current.B);
            label1.BackColor = current;
        }

        private void UC_Palette_Load(object sender, EventArgs e)
        {
            colorPalette1.ShowCursor = true;
        }
    }
}
