namespace ScienceAttendance.form
{
    partial class WriteWeekly
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
            this.txtWeekly = new System.Windows.Forms.TextBox();
            this.lblsbsj = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxPro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtWeekly
            // 
            this.txtWeekly.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWeekly.Location = new System.Drawing.Point(46, 70);
            this.txtWeekly.Multiline = true;
            this.txtWeekly.Name = "txtWeekly";
            this.txtWeekly.Size = new System.Drawing.Size(480, 96);
            this.txtWeekly.TabIndex = 0;
            // 
            // lblsbsj
            // 
            this.lblsbsj.AutoSize = true;
            this.lblsbsj.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblsbsj.Location = new System.Drawing.Point(44, 19);
            this.lblsbsj.Name = "lblsbsj";
            this.lblsbsj.Size = new System.Drawing.Size(77, 12);
            this.lblsbsj.TabIndex = 2;
            this.lblsbsj.Text = "选择默认项目";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "确 定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxPro
            // 
            this.cbxPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPro.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxPro.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cbxPro.FormattingEnabled = true;
            this.cbxPro.Location = new System.Drawing.Point(46, 42);
            this.cbxPro.Name = "cbxPro";
            this.cbxPro.Size = new System.Drawing.Size(480, 22);
            this.cbxPro.TabIndex = 6;
            // 
            // WriteWeekly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxPro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblsbsj);
            this.Controls.Add(this.txtWeekly);
            this.Name = "WriteWeekly";
            this.Size = new System.Drawing.Size(580, 200);
            this.Load += new System.EventHandler(this.WriteWeekly_Load);
            this.VisibleChanged += new System.EventHandler(this.WriteWeekly_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWeekly;
        private System.Windows.Forms.Label lblsbsj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxPro;
    }
}
