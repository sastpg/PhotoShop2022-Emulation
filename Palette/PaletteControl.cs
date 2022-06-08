using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palette
{
    public delegate void ColorChangedHandle(object sender, Color e);
    public partial class PaletteControl : UserControl
    {
        public event ColorChangedHandle ColorChanged;
        //HSL颜色
        HSLColor m_selectedColor = new HSLColor(Color.FromArgb(100, 255, 0, 0));
        private HSLColor SelectedHSLColor
        {
            get { return m_selectedColor; }
            set
            {
                m_colorWheel.SelectedHSLColorNoEvent = value;
                m_colorBar.SelectedHSLColor = value;
                m_selectedColor = value;

                //if (this.SelectedColorChanged != null)
                //    this.SelectedColorChanged(this, null);
            }
        }
        public PaletteControl()
        {
            InitializeComponent();
            m_colorWheel.SelectedColorChanged += new EventHandler(OnWheelColorChanged);
            this.m_colorBar.SelectedValueChanged += m_colorBar_SelectedValueChanged;
        }
        void OnWheelColorChanged(object sender, EventArgs e)//内圆颜色改变回调函数
        {
            m_selectedColor.Hue = m_colorWheel.SelectedHSLColor.Hue;
            m_selectedColor.Saturation = m_colorWheel.SelectedHSLColor.Saturation;
            m_selectedColor.Lightness = 0.5;
            SelectedHSLColor = m_selectedColor;
            if (ColorChanged != null)
            {
                ColorChanged(this, m_selectedColor.Color);
            }

           
        }
        private void m_colorBar_SelectedValueChanged(object sender, EventArgs e)//亮度改变事件
        {
            HSLColorBar cb = (HSLColorBar)sender;
            if (ColorChanged != null)
            {
                ColorChanged(this, cb.SelectedHSLColor.Color);
            }
        }
    }
}
