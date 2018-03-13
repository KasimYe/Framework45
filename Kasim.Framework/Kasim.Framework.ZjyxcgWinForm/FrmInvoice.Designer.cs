namespace Kasim.Framework.ZjyxcgWinForm
{
    partial class FrmInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoice));
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputGroupHeader1 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox1 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox2 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel3 = new C1.Win.C1InputPanel.InputLabel();
            this.inputDatePicker1 = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputLabel4 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox3 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel5 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox4 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel6 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox5 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel7 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox6 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel8 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox7 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel9 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox8 = new C1.Win.C1InputPanel.InputTextBox();
            this.dgd = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton2 = new C1.Win.C1InputPanel.InputButton();
            this.inputButton3 = new C1.Win.C1InputPanel.InputButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputGroupHeader1);
            this.c1InputPanel1.Items.Add(this.inputLabel1);
            this.c1InputPanel1.Items.Add(this.inputTextBox1);
            this.c1InputPanel1.Items.Add(this.inputLabel2);
            this.c1InputPanel1.Items.Add(this.inputTextBox2);
            this.c1InputPanel1.Items.Add(this.inputLabel3);
            this.c1InputPanel1.Items.Add(this.inputDatePicker1);
            this.c1InputPanel1.Items.Add(this.inputLabel4);
            this.c1InputPanel1.Items.Add(this.inputTextBox3);
            this.c1InputPanel1.Items.Add(this.inputLabel5);
            this.c1InputPanel1.Items.Add(this.inputTextBox4);
            this.c1InputPanel1.Items.Add(this.inputLabel7);
            this.c1InputPanel1.Items.Add(this.inputTextBox6);
            this.c1InputPanel1.Items.Add(this.inputLabel6);
            this.c1InputPanel1.Items.Add(this.inputTextBox5);
            this.c1InputPanel1.Items.Add(this.inputLabel8);
            this.c1InputPanel1.Items.Add(this.inputTextBox7);
            this.c1InputPanel1.Items.Add(this.inputLabel9);
            this.c1InputPanel1.Items.Add(this.inputTextBox8);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Items.Add(this.inputButton2);
            this.c1InputPanel1.Items.Add(this.inputButton3);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(846, 150);
            this.c1InputPanel1.TabIndex = 0;
            // 
            // inputGroupHeader1
            // 
            this.inputGroupHeader1.Name = "inputGroupHeader1";
            this.inputGroupHeader1.Text = "生成";
            // 
            // inputLabel1
            // 
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "发票代码:";
            // 
            // inputTextBox1
            // 
            this.inputTextBox1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox1.Name = "inputTextBox1";
            // 
            // inputLabel2
            // 
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "发票号码:";
            // 
            // inputTextBox2
            // 
            this.inputTextBox2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox2.Name = "inputTextBox2";
            // 
            // inputLabel3
            // 
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Text = "开票日期:";
            // 
            // inputDatePicker1
            // 
            this.inputDatePicker1.Name = "inputDatePicker1";
            // 
            // inputLabel4
            // 
            this.inputLabel4.Name = "inputLabel4";
            this.inputLabel4.Text = "销售方ID:";
            // 
            // inputTextBox3
            // 
            this.inputTextBox3.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox3.Name = "inputTextBox3";
            // 
            // inputLabel5
            // 
            this.inputLabel5.Name = "inputLabel5";
            this.inputLabel5.Text = "销售备注:";
            // 
            // inputTextBox4
            // 
            this.inputTextBox4.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox4.Name = "inputTextBox4";
            // 
            // inputLabel6
            // 
            this.inputLabel6.Name = "inputLabel6";
            this.inputLabel6.Text = "购买备注:";
            // 
            // inputTextBox5
            // 
            this.inputTextBox5.Name = "inputTextBox5";
            // 
            // inputLabel7
            // 
            this.inputLabel7.Name = "inputLabel7";
            this.inputLabel7.Text = "购买方ID:";
            // 
            // inputTextBox6
            // 
            this.inputTextBox6.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox6.Name = "inputTextBox6";
            // 
            // inputLabel8
            // 
            this.inputLabel8.Name = "inputLabel8";
            this.inputLabel8.Text = "Url:";
            // 
            // inputTextBox7
            // 
            this.inputTextBox7.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputTextBox7.Name = "inputTextBox7";
            this.inputTextBox7.Width = 500;
            // 
            // inputLabel9
            // 
            this.inputLabel9.Name = "inputLabel9";
            this.inputLabel9.Text = "MD5:";
            // 
            // inputTextBox8
            // 
            this.inputTextBox8.Name = "inputTextBox8";
            this.inputTextBox8.Width = 200;
            // 
            // dgd
            // 
            this.dgd.CaptionHeight = 18;
            this.dgd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgd.Location = new System.Drawing.Point(0, 150);
            this.dgd.Name = "dgd";
            this.dgd.PreviewInfo.Caption = "PrintPreview窗口";
            this.dgd.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.dgd.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.dgd.PreviewInfo.ZoomFactor = 75D;
            this.dgd.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("dgd.PrintInfo.PageSettings")));
            this.dgd.PropBag = resources.GetString("dgd.PropBag");
            this.dgd.RowHeight = 16;
            this.dgd.Size = new System.Drawing.Size(846, 402);
            this.dgd.TabIndex = 1;
            this.dgd.Text = "c1TrueDBGrid1";
            // 
            // inputButton1
            // 
            this.inputButton1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton1.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.image_link;
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Text = "RequestImage";
            this.inputButton1.Width = 130;
            // 
            // inputButton2
            // 
            this.inputButton2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputButton2.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.save_data;
            this.inputButton2.Name = "inputButton2";
            this.inputButton2.Text = "InsertData";
            this.inputButton2.Width = 100;
            // 
            // inputButton3
            // 
            this.inputButton3.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.upload_for_mac;
            this.inputButton3.Name = "inputButton3";
            this.inputButton3.Text = "Submit";
            this.inputButton3.Width = 80;
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 552);
            this.Controls.Add(this.dgd);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FrmInvoice";
            this.Text = "C018票据上传";
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader1;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox1;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox2;
        private C1.Win.C1InputPanel.InputLabel inputLabel3;
        private C1.Win.C1InputPanel.InputDatePicker inputDatePicker1;
        private C1.Win.C1InputPanel.InputLabel inputLabel4;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox3;
        private C1.Win.C1InputPanel.InputLabel inputLabel5;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox4;
        private C1.Win.C1InputPanel.InputLabel inputLabel7;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox6;
        private C1.Win.C1InputPanel.InputLabel inputLabel6;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox5;
        private C1.Win.C1InputPanel.InputLabel inputLabel8;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox7;
        private C1.Win.C1InputPanel.InputLabel inputLabel9;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox8;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private C1.Win.C1InputPanel.InputButton inputButton2;
        private C1.Win.C1InputPanel.InputButton inputButton3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid dgd;
    }
}