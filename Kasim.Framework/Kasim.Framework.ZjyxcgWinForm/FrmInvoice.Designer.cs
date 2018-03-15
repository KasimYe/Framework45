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
            this.txtInvoiceCode = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.txtInvoiceID = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel3 = new C1.Win.C1InputPanel.InputLabel();
            this.dpInvoiceDate = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputLabel4 = new C1.Win.C1InputPanel.InputLabel();
            this.txtSaleID = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel5 = new C1.Win.C1InputPanel.InputLabel();
            this.txtSaleRemark = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel7 = new C1.Win.C1InputPanel.InputLabel();
            this.txtBuyID = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel6 = new C1.Win.C1InputPanel.InputLabel();
            this.txtBuyRemarks = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel8 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox7 = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel9 = new C1.Win.C1InputPanel.InputLabel();
            this.inputTextBox8 = new C1.Win.C1InputPanel.InputTextBox();
            this.btnRequestImage = new C1.Win.C1InputPanel.InputButton();
            this.btnInsertData = new C1.Win.C1InputPanel.InputButton();
            this.btnSubmit = new C1.Win.C1InputPanel.InputButton();
            this.inputGroupHeader2 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.inputLabel10 = new C1.Win.C1InputPanel.InputLabel();
            this.inputDatePicker1 = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputLabel11 = new C1.Win.C1InputPanel.InputLabel();
            this.inputDatePicker2 = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputButton1 = new C1.Win.C1InputPanel.InputButton();
            this.dgd = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.ctxtJson = new C1.Win.C1Input.C1TextBox();
            this.cboInvoiceType = new C1.Win.C1InputPanel.InputComboBox();
            this.inputLabel12 = new C1.Win.C1InputPanel.InputLabel();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctxtJson)).BeginInit();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputGroupHeader1);
            this.c1InputPanel1.Items.Add(this.inputLabel1);
            this.c1InputPanel1.Items.Add(this.txtInvoiceCode);
            this.c1InputPanel1.Items.Add(this.inputLabel2);
            this.c1InputPanel1.Items.Add(this.txtInvoiceID);
            this.c1InputPanel1.Items.Add(this.inputLabel3);
            this.c1InputPanel1.Items.Add(this.dpInvoiceDate);
            this.c1InputPanel1.Items.Add(this.inputLabel12);
            this.c1InputPanel1.Items.Add(this.cboInvoiceType);
            this.c1InputPanel1.Items.Add(this.inputLabel4);
            this.c1InputPanel1.Items.Add(this.txtSaleID);
            this.c1InputPanel1.Items.Add(this.inputLabel5);
            this.c1InputPanel1.Items.Add(this.txtSaleRemark);
            this.c1InputPanel1.Items.Add(this.inputLabel7);
            this.c1InputPanel1.Items.Add(this.txtBuyID);
            this.c1InputPanel1.Items.Add(this.inputLabel6);
            this.c1InputPanel1.Items.Add(this.txtBuyRemarks);
            this.c1InputPanel1.Items.Add(this.inputLabel8);
            this.c1InputPanel1.Items.Add(this.inputTextBox7);
            this.c1InputPanel1.Items.Add(this.inputLabel9);
            this.c1InputPanel1.Items.Add(this.inputTextBox8);
            this.c1InputPanel1.Items.Add(this.btnRequestImage);
            this.c1InputPanel1.Items.Add(this.btnInsertData);
            this.c1InputPanel1.Items.Add(this.btnSubmit);
            this.c1InputPanel1.Items.Add(this.inputGroupHeader2);
            this.c1InputPanel1.Items.Add(this.inputLabel10);
            this.c1InputPanel1.Items.Add(this.inputDatePicker1);
            this.c1InputPanel1.Items.Add(this.inputLabel11);
            this.c1InputPanel1.Items.Add(this.inputDatePicker2);
            this.c1InputPanel1.Items.Add(this.inputButton1);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(846, 197);
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
            // txtInvoiceCode
            // 
            this.txtInvoiceCode.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtInvoiceCode.Name = "txtInvoiceCode";
            // 
            // inputLabel2
            // 
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "发票号码:";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtInvoiceID.Name = "txtInvoiceID";
            // 
            // inputLabel3
            // 
            this.inputLabel3.Name = "inputLabel3";
            this.inputLabel3.Text = "开票日期:";
            // 
            // dpInvoiceDate
            // 
            this.dpInvoiceDate.Break = C1.Win.C1InputPanel.BreakType.None;
            this.dpInvoiceDate.Name = "dpInvoiceDate";
            // 
            // inputLabel4
            // 
            this.inputLabel4.Name = "inputLabel4";
            this.inputLabel4.Text = "销售方ID:";
            // 
            // txtSaleID
            // 
            this.txtSaleID.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSaleID_KeyDown);
            // 
            // inputLabel5
            // 
            this.inputLabel5.Name = "inputLabel5";
            this.inputLabel5.Text = "销售备注:";
            // 
            // txtSaleRemark
            // 
            this.txtSaleRemark.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtSaleRemark.Name = "txtSaleRemark";
            // 
            // inputLabel7
            // 
            this.inputLabel7.Name = "inputLabel7";
            this.inputLabel7.Text = "购买方ID:";
            // 
            // txtBuyID
            // 
            this.txtBuyID.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtBuyID.Name = "txtBuyID";
            this.txtBuyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuyID_KeyDown);
            // 
            // inputLabel6
            // 
            this.inputLabel6.Name = "inputLabel6";
            this.inputLabel6.Text = "购买备注:";
            // 
            // txtBuyRemarks
            // 
            this.txtBuyRemarks.Name = "txtBuyRemarks";
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
            // btnRequestImage
            // 
            this.btnRequestImage.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnRequestImage.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.image_link;
            this.btnRequestImage.Name = "btnRequestImage";
            this.btnRequestImage.Text = "RequestImage";
            this.btnRequestImage.Width = 130;
            this.btnRequestImage.Click += new System.EventHandler(this.BtnRequestImage_Click);
            // 
            // btnInsertData
            // 
            this.btnInsertData.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnInsertData.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.save_data;
            this.btnInsertData.Name = "btnInsertData";
            this.btnInsertData.Text = "InsertData";
            this.btnInsertData.Width = 100;
            this.btnInsertData.Click += new System.EventHandler(this.BtnInsertData_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.upload_for_mac;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Width = 80;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // inputGroupHeader2
            // 
            this.inputGroupHeader2.Name = "inputGroupHeader2";
            this.inputGroupHeader2.Text = "搜索";
            // 
            // inputLabel10
            // 
            this.inputLabel10.Name = "inputLabel10";
            this.inputLabel10.Text = "起始日期:";
            // 
            // inputDatePicker1
            // 
            this.inputDatePicker1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputDatePicker1.Name = "inputDatePicker1";
            // 
            // inputLabel11
            // 
            this.inputLabel11.Name = "inputLabel11";
            this.inputLabel11.Text = "截至日期:";
            // 
            // inputDatePicker2
            // 
            this.inputDatePicker2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputDatePicker2.Name = "inputDatePicker2";
            // 
            // inputButton1
            // 
            this.inputButton1.Image = global::Kasim.Framework.ZjyxcgWinForm.Properties.Resources.table_tab_search;
            this.inputButton1.Name = "inputButton1";
            this.inputButton1.Text = "Search";
            this.inputButton1.Width = 80;
            // 
            // dgd
            // 
            this.dgd.CaptionHeight = 18;
            this.dgd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgd.Location = new System.Drawing.Point(0, 197);
            this.dgd.Name = "dgd";
            this.dgd.PreviewInfo.Caption = "PrintPreview窗口";
            this.dgd.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.dgd.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.dgd.PreviewInfo.ZoomFactor = 75D;
            this.dgd.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("dgd.PrintInfo.PageSettings")));
            this.dgd.PropBag = resources.GetString("dgd.PropBag");
            this.dgd.RowHeight = 16;
            this.dgd.Size = new System.Drawing.Size(846, 203);
            this.dgd.TabIndex = 1;
            this.dgd.Text = "c1TrueDBGrid1";
            // 
            // ctxtJson
            // 
            this.ctxtJson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctxtJson.Location = new System.Drawing.Point(0, 400);
            this.ctxtJson.Multiline = true;
            this.ctxtJson.Name = "ctxtJson";
            this.ctxtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ctxtJson.Size = new System.Drawing.Size(846, 152);
            this.ctxtJson.TabIndex = 2;
            this.ctxtJson.Tag = null;
            // 
            // cboInvoiceType
            // 
            this.cboInvoiceType.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.cboInvoiceType.Name = "cboInvoiceType";
            // 
            // inputLabel12
            // 
            this.inputLabel12.Name = "inputLabel12";
            this.inputLabel12.Text = "发票类型:";
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 552);
            this.Controls.Add(this.dgd);
            this.Controls.Add(this.ctxtJson);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FrmInvoice";
            this.Text = "C018票据上传";
            this.Load += new System.EventHandler(this.FrmInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctxtJson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader1;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputTextBox txtInvoiceCode;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputTextBox txtInvoiceID;
        private C1.Win.C1InputPanel.InputLabel inputLabel3;
        private C1.Win.C1InputPanel.InputDatePicker dpInvoiceDate;
        private C1.Win.C1InputPanel.InputLabel inputLabel4;
        private C1.Win.C1InputPanel.InputTextBox txtSaleID;
        private C1.Win.C1InputPanel.InputLabel inputLabel5;
        private C1.Win.C1InputPanel.InputTextBox txtSaleRemark;
        private C1.Win.C1InputPanel.InputLabel inputLabel7;
        private C1.Win.C1InputPanel.InputTextBox txtBuyID;
        private C1.Win.C1InputPanel.InputLabel inputLabel6;
        private C1.Win.C1InputPanel.InputTextBox txtBuyRemarks;
        private C1.Win.C1InputPanel.InputLabel inputLabel8;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox7;
        private C1.Win.C1InputPanel.InputLabel inputLabel9;
        private C1.Win.C1InputPanel.InputTextBox inputTextBox8;
        private C1.Win.C1InputPanel.InputButton btnRequestImage;
        private C1.Win.C1InputPanel.InputButton btnInsertData;
        private C1.Win.C1InputPanel.InputButton btnSubmit;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid dgd;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader2;
        private C1.Win.C1InputPanel.InputLabel inputLabel10;
        private C1.Win.C1InputPanel.InputDatePicker inputDatePicker1;
        private C1.Win.C1InputPanel.InputLabel inputLabel11;
        private C1.Win.C1InputPanel.InputDatePicker inputDatePicker2;
        private C1.Win.C1InputPanel.InputButton inputButton1;
        private C1.Win.C1Input.C1TextBox ctxtJson;
        private C1.Win.C1InputPanel.InputLabel inputLabel12;
        private C1.Win.C1InputPanel.InputComboBox cboInvoiceType;
    }
}