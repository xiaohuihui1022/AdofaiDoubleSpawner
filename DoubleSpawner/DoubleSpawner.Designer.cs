namespace DoubleSpawner
{
    partial class DoubleSpawner
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.select = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(18, 154);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(838, 110);
            this.select.TabIndex = 0;
            this.select.Text = "选择谱面";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.button1_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 9);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(158, 31);
            this.status.TabIndex = 1;
            this.status.Text = "状态：未启动";
            // 
            // DoubleSpawner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 276);
            this.Controls.Add(this.status);
            this.Controls.Add(this.select);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DoubleSpawner";
            this.Text = "Adofai双押生成器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoubleSpawner_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select;
        private System.Windows.Forms.Label status;
    }
}

