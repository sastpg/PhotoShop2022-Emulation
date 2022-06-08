namespace Palette
{
    partial class PaletteControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hslColorBar1 = new Palette.HSLColorBar();
            this.m_colorBar = new Palette.HSLColorBar();
            this.m_colorWheel = new Palette.ColorSetWheel();
            this.SuspendLayout();
            // 
            // hslColorBar1
            // 
            this.hslColorBar1.Color1 = System.Drawing.Color.Black;
            this.hslColorBar1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.hslColorBar1.Color3 = System.Drawing.Color.White;
            this.hslColorBar1.ColorSelectorSize = new System.Drawing.Size(20, 15);
            this.hslColorBar1.LightnessWidth = 15;
            this.hslColorBar1.Location = new System.Drawing.Point(413, 48);
            this.hslColorBar1.Name = "hslColorBar1";
            this.hslColorBar1.NumberOfColors = Palette.ColorBar.eNumberOfColors.Use3Colors;
            this.hslColorBar1.Percent = 0D;
            this.hslColorBar1.Size = new System.Drawing.Size(25, 22);
            this.hslColorBar1.TabIndex = 2;
            this.hslColorBar1.Text = "hslColorBar1";
            // 
            // m_colorBar
            // 
            this.m_colorBar.Color1 = System.Drawing.Color.Black;
            this.m_colorBar.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.m_colorBar.Color3 = System.Drawing.Color.White;
            this.m_colorBar.ColorSelectorSize = new System.Drawing.Size(34, 26);
            this.m_colorBar.LightnessWidth = 26;
            this.m_colorBar.Location = new System.Drawing.Point(18, 4);
            this.m_colorBar.Margin = new System.Windows.Forms.Padding(4);
            this.m_colorBar.Name = "m_colorBar";
            this.m_colorBar.NumberOfColors = Palette.ColorBar.eNumberOfColors.Use3Colors;
            this.m_colorBar.Percent = 0D;
            this.m_colorBar.Size = new System.Drawing.Size(420, 420);
            this.m_colorBar.TabIndex = 1;
            this.m_colorBar.Text = "colorBar1";
            // 
            // m_colorWheel
            // 
            this.m_colorWheel.Location = new System.Drawing.Point(94, 81);
            this.m_colorWheel.Margin = new System.Windows.Forms.Padding(4);
            this.m_colorWheel.Name = "m_colorWheel";
            this.m_colorWheel.Size = new System.Drawing.Size(270, 270);
            this.m_colorWheel.TabIndex = 0;
            this.m_colorWheel.Text = "colorSetWheel1";
            // 
            // PaletteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hslColorBar1);
            this.Controls.Add(this.m_colorBar);
            this.Controls.Add(this.m_colorWheel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PaletteControl";
            this.Size = new System.Drawing.Size(450, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private ColorSetWheel m_colorWheel;
        private HSLColorBar m_colorBar;
        private HSLColorBar hslColorBar1;
    }
}
