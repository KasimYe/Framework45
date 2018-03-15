namespace Kasim.Framework.ZjyxcgWinForm
{
    partial class FrmSale
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSale));
            this.c1InputPanel1 = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputGroupHeader1 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.inputLabel1 = new C1.Win.C1InputPanel.InputLabel();
            this.dpStartDate = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputLabel2 = new C1.Win.C1InputPanel.InputLabel();
            this.dpEndDate = new C1.Win.C1InputPanel.InputDatePicker();
            this.inputLabel4 = new C1.Win.C1InputPanel.InputLabel();
            this.txtClientName = new C1.Win.C1InputPanel.InputTextBox();
            this.inputLabel5 = new C1.Win.C1InputPanel.InputLabel();
            this.txtPName = new C1.Win.C1InputPanel.InputTextBox();
            this.btnSearch = new C1.Win.C1InputPanel.InputButton();
            this.btnAddNew = new C1.Win.C1InputPanel.InputButton();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.tlSubmit = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.dgdDetail = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.bnDetail = new DevComponents.DotNetBar.Controls.BindingNavigatorEx(this.components);
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dgd = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.plInfo = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtJson = new C1.Win.C1InputPanel.InputTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDetail)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1InputPanel1
            // 
            this.c1InputPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1InputPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.c1InputPanel1.Items.Add(this.inputGroupHeader1);
            this.c1InputPanel1.Items.Add(this.inputLabel1);
            this.c1InputPanel1.Items.Add(this.dpStartDate);
            this.c1InputPanel1.Items.Add(this.inputLabel2);
            this.c1InputPanel1.Items.Add(this.dpEndDate);
            this.c1InputPanel1.Items.Add(this.inputLabel4);
            this.c1InputPanel1.Items.Add(this.txtClientName);
            this.c1InputPanel1.Items.Add(this.inputLabel5);
            this.c1InputPanel1.Items.Add(this.txtPName);
            this.c1InputPanel1.Items.Add(this.btnSearch);
            this.c1InputPanel1.Items.Add(this.btnAddNew);
            this.c1InputPanel1.Items.Add(this.txtJson);
            this.c1InputPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1InputPanel1.Name = "c1InputPanel1";
            this.c1InputPanel1.Size = new System.Drawing.Size(950, 149);
            this.c1InputPanel1.TabIndex = 26;
            this.c1InputPanel1.VisualStyle = C1.Win.C1InputPanel.VisualStyle.Office2010Blue;
            // 
            // inputGroupHeader1
            // 
            this.inputGroupHeader1.Name = "inputGroupHeader1";
            this.inputGroupHeader1.Text = "查询条件";
            // 
            // inputLabel1
            // 
            this.inputLabel1.Name = "inputLabel1";
            this.inputLabel1.Text = "日期:";
            // 
            // dpStartDate
            // 
            this.dpStartDate.Break = C1.Win.C1InputPanel.BreakType.None;
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Width = 114;
            // 
            // inputLabel2
            // 
            this.inputLabel2.Name = "inputLabel2";
            this.inputLabel2.Text = "至";
            // 
            // dpEndDate
            // 
            this.dpEndDate.Break = C1.Win.C1InputPanel.BreakType.None;
            this.dpEndDate.Name = "dpEndDate";
            this.dpEndDate.Width = 114;
            // 
            // inputLabel4
            // 
            this.inputLabel4.Name = "inputLabel4";
            this.inputLabel4.Text = "客户名称:";
            // 
            // txtClientName
            // 
            this.txtClientName.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Width = 141;
            // 
            // inputLabel5
            // 
            this.inputLabel5.Name = "inputLabel5";
            this.inputLabel5.Text = "商品名称:";
            // 
            // txtPName
            // 
            this.txtPName.Break = C1.Win.C1InputPanel.BreakType.None;
            this.txtPName.Name = "txtPName";
            this.txtPName.Width = 141;
            // 
            // btnSearch
            // 
            this.btnSearch.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "搜索";
            this.btnSearch.Width = 75;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Text = "传输";
            this.btnAddNew.Width = 75;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "Move last";
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "Move next";
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.AccessibleName = "Position";
            this.textBoxItem1.BeginGroup = true;
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.Text = "0";
            this.textBoxItem1.TextBoxWidth = 54;
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // buttonItem4
            // 
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "Move previous";
            // 
            // tlSubmit
            // 
            this.tlSubmit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.tlSubmit.Name = "tlSubmit";
            this.tlSubmit.Text = "确认提交";
            this.tlSubmit.Click += new System.EventHandler(this.tlSubmit_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Move first";
            // 
            // dgdDetail
            // 
            this.dgdDetail.BackColor = System.Drawing.SystemColors.Window;
            this.dgdDetail.Caption = "单据明细";
            this.dgdDetail.CaptionHeight = 18;
            this.dgdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgdDetail.Images.Add(((System.Drawing.Image)(resources.GetObject("dgdDetail.Images"))));
            this.dgdDetail.Location = new System.Drawing.Point(0, 30);
            this.dgdDetail.Name = "dgdDetail";
            this.dgdDetail.PreviewInfo.Caption = "PrintPreview窗口";
            this.dgdDetail.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.dgdDetail.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.dgdDetail.PreviewInfo.ZoomFactor = 75D;
            this.dgdDetail.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("dgdDetail.PrintInfo.PageSettings")));
            this.dgdDetail.PropBag = resources.GetString("dgdDetail.PropBag");
            this.dgdDetail.RowHeight = 16;
            this.dgdDetail.Size = new System.Drawing.Size(950, 409);
            this.dgdDetail.TabIndex = 6;
            this.dgdDetail.Text = "c1TrueDBGrid2";
            this.dgdDetail.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2010Blue;
            this.dgdDetail.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.dgdDetail_AfterColEdit);
            // 
            // bnDetail
            // 
            this.bnDetail.AntiAlias = true;
            this.bnDetail.CountLabel = this.labelItem1;
            this.bnDetail.CountLabelFormat = "of {0}";
            this.bnDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnDetail.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bnDetail.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bnDetail.IsMaximized = false;
            this.bnDetail.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem3,
            this.buttonItem4,
            this.textBoxItem1,
            this.labelItem1,
            this.buttonItem5,
            this.buttonItem6,
            this.tlSubmit});
            this.bnDetail.Location = new System.Drawing.Point(0, 137);
            this.bnDetail.MoveFirstButton = this.buttonItem3;
            this.bnDetail.MoveLastButton = this.buttonItem6;
            this.bnDetail.MoveNextButton = this.buttonItem5;
            this.bnDetail.MovePreviousButton = this.buttonItem4;
            this.bnDetail.Name = "bnDetail";
            this.bnDetail.PositionTextBox = this.textBoxItem1;
            this.bnDetail.Size = new System.Drawing.Size(950, 26);
            this.bnDetail.Stretch = true;
            this.bnDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bnDetail.TabIndex = 10;
            this.bnDetail.TabStop = false;
            this.bnDetail.Text = "bindingNavigatorEx2";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "of {0}";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dgd);
            this.panelEx2.Controls.Add(this.bnDetail);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(950, 163);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "panelEx2";
            // 
            // dgd
            // 
            this.dgd.BackColor = System.Drawing.SystemColors.Window;
            this.dgd.Caption = "单据列表";
            this.dgd.CaptionHeight = 18;
            this.dgd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgd.Images.Add(((System.Drawing.Image)(resources.GetObject("dgd.Images"))));
            this.dgd.Location = new System.Drawing.Point(0, 0);
            this.dgd.Name = "dgd";
            this.dgd.PreviewInfo.Caption = "PrintPreview窗口";
            this.dgd.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.dgd.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.dgd.PreviewInfo.ZoomFactor = 75D;
            this.dgd.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("dgd.PrintInfo.PageSettings")));
            this.dgd.PropBag = resources.GetString("dgd.PropBag");
            this.dgd.RowHeight = 16;
            this.dgd.Size = new System.Drawing.Size(950, 137);
            this.dgd.TabIndex = 10;
            this.dgd.Text = "c1TrueDBGrid2";
            this.dgd.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2010Blue;
            this.dgd.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.dgd_RowColChange);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 163);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(950, 5);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 8;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.dgdDetail);
            this.panelEx3.Controls.Add(this.plInfo);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 168);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(950, 439);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 4;
            this.panelEx3.Text = "panelEx3";
            // 
            // plInfo
            // 
            this.plInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.plInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.plInfo.DisabledBackColor = System.Drawing.Color.Empty;
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plInfo.Location = new System.Drawing.Point(0, 0);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(950, 30);
            this.plInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.plInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.plInfo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.plInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.plInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.plInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.plInfo.Style.GradientAngle = 90;
            this.plInfo.Style.MarginTop = 6;
            this.plInfo.TabIndex = 2;
            this.plInfo.Text = "panelEx1";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Controls.Add(this.expandableSplitter1);
            this.panelEx1.Controls.Add(this.panelEx3);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 149);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(950, 607);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 27;
            // 
            // txtJson
            // 
            this.txtJson.Height = 90;
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.VerticalAlign = C1.Win.C1InputPanel.InputContentAlignment.Spread;
            this.txtJson.Width = 833;
            // 
            // FrmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 756);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.c1InputPanel1);
            this.Name = "FrmSale";
            this.Text = "FrmSale";
            this.Load += new System.EventHandler(this.FrmSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1InputPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDetail)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgd)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel c1InputPanel1;
        private C1.Win.C1InputPanel.InputGroupHeader inputGroupHeader1;
        private C1.Win.C1InputPanel.InputLabel inputLabel1;
        private C1.Win.C1InputPanel.InputDatePicker dpStartDate;
        private C1.Win.C1InputPanel.InputLabel inputLabel2;
        private C1.Win.C1InputPanel.InputDatePicker dpEndDate;
        private C1.Win.C1InputPanel.InputLabel inputLabel4;
        private C1.Win.C1InputPanel.InputTextBox txtClientName;
        private C1.Win.C1InputPanel.InputLabel inputLabel5;
        private C1.Win.C1InputPanel.InputTextBox txtPName;
        private C1.Win.C1InputPanel.InputButton btnSearch;
        private C1.Win.C1InputPanel.InputButton btnAddNew;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem tlSubmit;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid dgdDetail;
        private DevComponents.DotNetBar.Controls.BindingNavigatorEx bnDetail;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid dgd;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.PanelEx plInfo;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private C1.Win.C1InputPanel.InputTextBox txtJson;
    }
}