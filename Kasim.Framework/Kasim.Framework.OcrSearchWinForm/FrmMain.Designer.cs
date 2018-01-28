namespace Kasim.Framework.OcrSearchWinForm
{
    partial class FrmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboGames = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCut = new System.Windows.Forms.Button();
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏选择：";
            // 
            // cboGames
            // 
            this.cboGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGames.FormattingEnabled = true;
            this.cboGames.Items.AddRange(new object[] {
            "冲顶大会",
            "芝士超人",
            "百万英雄"});
            this.cboGames.Location = new System.Drawing.Point(79, 20);
            this.cboGames.Name = "cboGames";
            this.cboGames.Size = new System.Drawing.Size(121, 20);
            this.cboGames.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCut);
            this.groupBox1.Controls.Add(this.cboGames);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(79, 46);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(99, 35);
            this.btnCut.TabIndex = 2;
            this.btnCut.Text = "截取题目区域";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // gbQuestion
            // 
            this.gbQuestion.Location = new System.Drawing.Point(12, 107);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Size = new System.Drawing.Size(316, 263);
            this.gbQuestion.TabIndex = 3;
            this.gbQuestion.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "答案";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbQuestion);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kasim\'s OCR Search";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

