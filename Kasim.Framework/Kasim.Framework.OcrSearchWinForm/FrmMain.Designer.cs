﻿namespace Kasim.Framework.OcrSearchWinForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.gbQuestion = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAnswer3 = new System.Windows.Forms.Label();
            this.rtxtAnswer3 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.rtxtAnswer2 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.rtxtAnswer1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtQuestion = new System.Windows.Forms.RichTextBox();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.btnSubmit3 = new System.Windows.Forms.Button();
            this.cboGames = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboGames);
            this.groupBox1.Controls.Add(this.btnSubmit3);
            this.groupBox1.Controls.Add(this.btnSubmit2);
            this.groupBox1.Controls.Add(this.btnSubmit1);
            this.groupBox1.Controls.Add(this.btnCut);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmit1.Location = new System.Drawing.Point(171, 11);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(124, 32);
            this.btnSubmit1.TabIndex = 3;
            this.btnSubmit1.Text = "答题一行";
            this.btnSubmit1.UseVisualStyleBackColor = false;
            this.btnSubmit1.Click += new System.EventHandler(this.BtnSubmit1_Click);
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(23, 61);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(124, 39);
            this.btnCut.TabIndex = 2;
            this.btnCut.Text = "截取题目区域";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // gbQuestion
            // 
            this.gbQuestion.Location = new System.Drawing.Point(12, 136);
            this.gbQuestion.Name = "gbQuestion";
            this.gbQuestion.Size = new System.Drawing.Size(316, 156);
            this.gbQuestion.TabIndex = 3;
            this.gbQuestion.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Controls.Add(this.lblAnswer3);
            this.groupBox3.Controls.Add(this.rtxtAnswer3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblAnswer2);
            this.groupBox3.Controls.Add(this.rtxtAnswer2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblAnswer1);
            this.groupBox3.Controls.Add(this.rtxtAnswer1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.rtxtQuestion);
            this.groupBox3.Location = new System.Drawing.Point(12, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 251);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "问题&答案";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(21, 217);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(50, 26);
            this.lblResult.TabIndex = 11;
            this.lblResult.Text = "结果";
            // 
            // lblAnswer3
            // 
            this.lblAnswer3.AutoSize = true;
            this.lblAnswer3.Location = new System.Drawing.Point(225, 186);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(29, 12);
            this.lblAnswer3.TabIndex = 10;
            this.lblAnswer3.Text = "结果";
            // 
            // rtxtAnswer3
            // 
            this.rtxtAnswer3.Location = new System.Drawing.Point(43, 173);
            this.rtxtAnswer3.Name = "rtxtAnswer3";
            this.rtxtAnswer3.Size = new System.Drawing.Size(176, 37);
            this.rtxtAnswer3.TabIndex = 9;
            this.rtxtAnswer3.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "答案三";
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Location = new System.Drawing.Point(225, 143);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(29, 12);
            this.lblAnswer2.TabIndex = 7;
            this.lblAnswer2.Text = "结果";
            // 
            // rtxtAnswer2
            // 
            this.rtxtAnswer2.Location = new System.Drawing.Point(43, 130);
            this.rtxtAnswer2.Name = "rtxtAnswer2";
            this.rtxtAnswer2.Size = new System.Drawing.Size(176, 37);
            this.rtxtAnswer2.TabIndex = 6;
            this.rtxtAnswer2.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "答案二";
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Location = new System.Drawing.Point(225, 100);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(29, 12);
            this.lblAnswer1.TabIndex = 4;
            this.lblAnswer1.Text = "结果";
            // 
            // rtxtAnswer1
            // 
            this.rtxtAnswer1.Location = new System.Drawing.Point(43, 87);
            this.rtxtAnswer1.Name = "rtxtAnswer1";
            this.rtxtAnswer1.Size = new System.Drawing.Size(176, 37);
            this.rtxtAnswer1.TabIndex = 3;
            this.rtxtAnswer1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "答案一";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "问题";
            // 
            // rtxtQuestion
            // 
            this.rtxtQuestion.Location = new System.Drawing.Point(43, 20);
            this.rtxtQuestion.Name = "rtxtQuestion";
            this.rtxtQuestion.Size = new System.Drawing.Size(267, 64);
            this.rtxtQuestion.TabIndex = 0;
            this.rtxtQuestion.Text = "";
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmit2.Location = new System.Drawing.Point(171, 46);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(124, 32);
            this.btnSubmit2.TabIndex = 4;
            this.btnSubmit2.Text = "答题两行";
            this.btnSubmit2.UseVisualStyleBackColor = false;
            this.btnSubmit2.Click += new System.EventHandler(this.BtnSubmit2_Click);
            // 
            // btnSubmit3
            // 
            this.btnSubmit3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSubmit3.Location = new System.Drawing.Point(171, 80);
            this.btnSubmit3.Name = "btnSubmit3";
            this.btnSubmit3.Size = new System.Drawing.Size(124, 32);
            this.btnSubmit3.TabIndex = 5;
            this.btnSubmit3.Text = "答题三行";
            this.btnSubmit3.UseVisualStyleBackColor = false;
            this.btnSubmit3.Click += new System.EventHandler(this.BtnSubmit3_Click);
            // 
            // cboGames
            // 
            this.cboGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGames.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboGames.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cboGames.FormattingEnabled = true;
            this.cboGames.Items.AddRange(new object[] {
            "冲顶大会",
            "芝士超人",
            "百万英雄"});
            this.cboGames.Location = new System.Drawing.Point(26, 21);
            this.cboGames.Name = "cboGames";
            this.cboGames.Size = new System.Drawing.Size(121, 29);
            this.cboGames.TabIndex = 6;
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.GroupBox gbQuestion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtxtQuestion;
        private System.Windows.Forms.Label lblAnswer3;
        private System.Windows.Forms.RichTextBox rtxtAnswer3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.RichTextBox rtxtAnswer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.RichTextBox rtxtAnswer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cboGames;
        private System.Windows.Forms.Button btnSubmit3;
        private System.Windows.Forms.Button btnSubmit2;
    }
}

