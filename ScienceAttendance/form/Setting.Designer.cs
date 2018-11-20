namespace ScienceAttendance.form
{
    partial class Setting
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
            this.cbxPro = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSbsj = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXbsj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(125, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择默认项目";
            // 
            // cbxPro
            // 
            this.cbxPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPro.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxPro.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cbxPro.FormattingEnabled = true;
            this.cbxPro.Location = new System.Drawing.Point(127, 28);
            this.cbxPro.Name = "cbxPro";
            this.cbxPro.Size = new System.Drawing.Size(218, 22);
            this.cbxPro.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.checkBox1.Location = new System.Drawing.Point(127, 72);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "每天填写周报";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(228, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "（若不勾选，则每天不弹出程序，周报中没有具体工作内容）";
            // 
            // txtSbsj
            // 
            this.txtSbsj.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtSbsj.Location = new System.Drawing.Point(195, 103);
            this.txtSbsj.Name = "txtSbsj";
            this.txtSbsj.Size = new System.Drawing.Size(100, 21);
            this.txtSbsj.TabIndex = 4;
            this.txtSbsj.Text = "09:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(124, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "上班时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(124, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "下班时间：";
            // 
            // txtXbsj
            // 
            this.txtXbsj.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtXbsj.Location = new System.Drawing.Point(195, 139);
            this.txtXbsj.Name = "txtXbsj";
            this.txtXbsj.Size = new System.Drawing.Size(100, 21);
            this.txtXbsj.TabIndex = 7;
            this.txtXbsj.Text = "18:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(303, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "（不计算锁屏的时间段，一般为9:00到18:00）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(351, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "(每天默认填写周报的项目)";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(392, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "完 成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtXbsj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSbsj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbxPro);
            this.Controls.Add(this.label1);
            this.Name = "Setting";
            this.Size = new System.Drawing.Size(580, 200);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPro;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSbsj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXbsj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}
