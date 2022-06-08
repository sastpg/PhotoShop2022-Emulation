
namespace IPLab
{
    partial class UC_Palette
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorPalette1 = new ConmajiaColorPicker.ColorPalette();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(126, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 28);
            this.label1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(213, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 21);
            this.textBox1.TabIndex = 2;
            // 
            // colorPalette1
            // 
            this.colorPalette1.BackColor = System.Drawing.Color.Black;
            this.colorPalette1.BlockWidth = 10;
            this.colorPalette1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorPalette1.Location = new System.Drawing.Point(0, 0);
            this.colorPalette1.Name = "colorPalette1";
            this.colorPalette1.ShowCursor = false;
            this.colorPalette1.Size = new System.Drawing.Size(361, 61);
            this.colorPalette1.TabIndex = 0;
            this.colorPalette1.Text = "colorPalette1";
            this.colorPalette1.ColorChanged += new ConmajiaColorPicker.ColorPalette.ColorChangedEventHandler(this.colorPalette1_ColorChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.colorPalette1);
            this.panel1.Location = new System.Drawing.Point(3, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 191);
            this.panel1.TabIndex = 3;
            // 
            // UC_Palette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_Palette";
            this.Size = new System.Drawing.Size(483, 432);
            this.Load += new System.EventHandler(this.UC_Palette_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConmajiaColorPicker.ColorPalette colorPalette1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
