using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Kasim.Framework.BLL.QuartzLog.CompanyInterface.Drug;
using C1.Win.C1TrueDBGrid;
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Newtonsoft.Json;

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmSale : DevExpress.XtraEditors.XtraForm
    {
        IInvoiceBLL invoiceBLL = new InvoiceBLL();
        ISaleBLL saleBLL = new SaleBLL();
        IProcurecatalogBLL procurecatalogBLL = new ProcurecatalogBLL();
        private Invoice invoice = null;
        public FrmSale()
        {
            InitializeComponent();
        }

        private void FrmSale_Load(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            BindDgd();
        }

        private void BindDgd()
        {
            var dt = invoiceBLL.GetInvoices(dpStartDate.Value.Date, dpEndDate.Value.Date);
            var binding = new BindingSource { DataSource = dt };
            bnDetail.BindingSource = binding;
            Cgd.SetDefaultStyle(dgd, binding, false, false, false, _ClearColumns: true);

            Cgd.SetColumn(dgd, "companyPrimaryKey", "主键", 270, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "invoiceCode", "发票代码", 100, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "invoiceID", "发票号码", 80, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "invoiceDate", "发票日期", 80, -1, "yyyy-MM-dd", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "saleName", "销售方", 170, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "saleRemark", "销售方备注", 120, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "buyName", "购买方", 170, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "buyRemarks", "购买方备注", 120, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "id", "中心返回ID", 200, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "buyID", "buyID", 100);
            Cgd.SetColumn(dgd, "saleID", "saleID", 100);
            Cgd.SetColumn(dgd, "picMD5", "picMD5", 100);
            Cgd.SetColumn(dgd, "picUrl", "picUrl", 100);
            Cgd.SetColumn(dgd, "invoiceType", "invoiceType", 0, _Visible: false);
            Cgd.AddEndingStyle(dgd);
        }

        private void dgd_RowColChange(object sender, RowColChangeEventArgs e)
        {
            BindDetail(dgd.Row);
        }

        private void BindDetail(int row)
        {
            invoice = new Invoice
            {
                CompanyPrimaryKey = Convert.ToString(dgd[row, "companyPrimaryKey"]),
                BuyID = Convert.ToString(dgd[row, "buyID"]),
                BuyRemarks = Convert.ToString(dgd[row, "buyRemarks"]),
                Id = Convert.ToString(dgd[row, "id"]),
                InvoiceCode = Convert.ToString(dgd[row, "invoiceCode"]),
                InvoiceDate = Convert.ToString(dgd[row, "invoiceDate"]),
                InvoiceID = Convert.ToString(dgd[row, "invoiceID"]),
                InvoiceType = Convert.ToInt32(dgd[row, "invoiceType"]),
                PicMD5 = Convert.ToString(dgd[row, "picMD5"]),
                PicUrl = Convert.ToString(dgd[row, "picUrl"]),
                SaleID = Convert.ToString(dgd[row, "saleID"]),
                SaleRemark = Convert.ToString(dgd[row, "saleRemark"]),
            };
            plInfo.Text = string.Format("&nbsp;&nbsp;&nbsp;<i>发票代码:</i>&nbsp;&nbsp;<b><u>{0}</u></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>发票号码:</i>&nbsp;&nbsp;<b><u>{1}</u></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>发票日期:</i>&nbsp;&nbsp;<b><u>{2}</u></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>销售方:</i>&nbsp;&nbsp;<b><u>{3}</u></b>&nbsp;&nbsp;&nbsp;&nbsp;<i>购买方:</i>&nbsp;&nbsp;<b><u>{4}</u></b>",
                dgd[row, "invoiceCode"], dgd[row, "invoiceID"], dgd[row, "invoiceDate"], dgd[row, "saleName"], dgd[row, "buyName"]);

            var dt = saleBLL.GetEmptySale(invoice);
            Cgd.SetDefaultStyle(dgdDetail, dt);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                switch (dt.Columns[i].ColumnName)
                {
                    case "procurecatalogId":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "商品编号", 100, i, _Locked: true);
                        break;
                    case "productName":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "通用名", 150, i);
                        break;
                    case "goodsName":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "商品名", 100, i, _Locked: true);
                        break;
                    case "outlook":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "规格", 100, i, _Locked: true);
                        break;
                    case "companyNameSc":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "生产企业", 190, i, _Locked: true);
                        break;
                    case "batchCode":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "批号", 100, i);
                        break;
                    case "periodDate":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "有效期", 90, i, _HorizontalAlignment: AlignHorzEnum.Center);
                        break;
                    case "saleNumber":
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, "销售数量", 100, i, _HorizontalAlignment: AlignHorzEnum.Far);
                        break;
                    default:
                        Cgd.SetColumn(dgdDetail, dt.Columns[i].ColumnName, dt.Columns[i].ColumnName, 0, i, "", AlignHorzEnum.Near, false);
                        break;
                }
            }
        }

        private void dgdDetail_AfterColEdit(object sender, ColEventArgs e)
        {
            switch (e.Column.DataColumn.DataField)
            {
                case "productName":
                    var search = Convert.ToString(dgdDetail.Columns["productName"].Value).Trim();
                    if (!string.IsNullOrEmpty(search))
                    {
                        DataTable dataTable = null;
                        var list = procurecatalogBLL.GetProcurecatalogList(DateTime.Now, DateTime.Now, search);
                        if (list != null && list.Count > 0)
                            dataTable = new DataTableExtensions<Procurecatalog>(list).DtReturn;

                        if (dataTable != null)
                        {
                            var frm = new FrmPopList
                            {
                                dataTable = dataTable,
                                StartPosition = FormStartPosition.CenterParent
                            };
                            frm.ShowDialog();
                            if (frm.dataRow != null)
                            {
                                dgdDetail.Columns["goodsID"].Value = frm.dataRow["goodsID"];
                                dgdDetail.Columns["procurecatalogId"].Value = frm.dataRow["procurecatalogId"];
                                dgdDetail.Columns["productName"].Value = frm.dataRow["productName"];
                                dgdDetail.Columns["goodsName"].Value = frm.dataRow["goodsName"];
                                dgdDetail.Columns["outlook"].Value = frm.dataRow["outlook"];
                                dgdDetail.Columns["companyNameSc"].Value = frm.dataRow["companyNameSc"];
                            }
                        }
                        else
                            MBox.ShowMsg("数据不存在");
                    }
                    break;
                default:
                    break;
            }
        }

        private void tlSubmit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgdDetail.RowCount; i++)
            {
                if (dgdDetail[i, "goodsID"]!=null&&dgdDetail[i, "saleNumber"] !=null)
                {
                    var sale = new Sale {
                        CompanyPrimaryKey=Guid.NewGuid().ToString(),
                        BatchCode=Convert.ToString(dgdDetail[i, "batchCode"]),
                        GoodsID = Convert.ToInt32(dgdDetail[i, "goodsID"]),
                        InvoiceCode = invoice.InvoiceCode,
                        InvoiceID = invoice.InvoiceID,
                        PeriodDate = Convert.ToString(dgdDetail[i, "periodDate"]),
                        SaleNumber = Convert.ToInt32(dgdDetail[i, "saleNumber"])
                    };
                    saleBLL.AddSale(sale);
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var objList = new List<object>();
            for (int i = 0; i < dgdDetail.RowCount; i++)
            {
                if (dgdDetail[i, "goodsID"] != null && dgdDetail[i, "saleNumber"] != null)
                {
                    var obj = new
                    {
                        companyPrimaryKey = Convert.ToString(dgdDetail[i, "companyPrimaryKey"]),
                        invoiceCode = Convert.ToString(dgdDetail[i, "invoiceCode"]),
                        invoiceID = Convert.ToString(dgdDetail[i, "invoiceID"]),
                        goodsID = Convert.ToInt32(dgdDetail[i, "goodsID"]),
                        batchCode = Convert.ToString(dgdDetail[i, "batchCode"]),
                        periodDate = Convert.ToString(dgdDetail[i, "periodDate"]),
                        saleNumber = Convert.ToInt32(dgdDetail[i, "saleNumber"])
                    };
                    objList.Add(obj);
                }
            }          
            txtJson.Text = JsonConvert.SerializeObject(new { list = objList });
            if (MBox.ShowAsk("是否开始传输？"))
            {
                StringBuilder stringBuilder = new StringBuilder();
                var checkList = saleBLL.AddSale(txtJson.Text);
                if (checkList != null)
                {
                    stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                    if (checkList.SuccessList != null && checkList.SuccessList.Count > 0)
                    {
                        foreach (var itemS in checkList.SuccessList)
                        {
                            stringBuilder.AppendFormat("企业发票主键编号:{0}   中心发票ID:{1}\r\n", itemS.CompanyPrimaryKey, itemS.Id);
                            saleBLL.WriteBackSaleId(itemS.CompanyPrimaryKey, itemS.Id);
                        }
                    }
                    if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                    {
                        foreach (var itemP in checkList.ErrorList)
                        {
                            stringBuilder.AppendFormat("企业发票主键编号:{0}   错误原因如下:\r\n", itemP.CompanyPrimaryKey);
                            foreach (var itemC in itemP.ErrorReasonList)
                            {
                                stringBuilder.AppendFormat("      错误码:{0}   错误原因:{1}\r\n", itemC.ErrorCode.ToString(), itemC.ErrorMsg);
                            }
                        }
                    }
                }

                txtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
            }
        }
    }
}