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
using Kasim.Framework.Entity.QuartzLog;
using Newtonsoft.Json;
using Kasim.Framework.Factory;
using Kasim.Framework.Common;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Kasim.Framework.BLL.QuartzLog.CompanyInterface.Drug;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using C1.Win.C1TrueDBGrid;

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmInvoice : DevExpress.XtraEditors.XtraForm
    {
        IInvoiceBLL invoiceBLL = new InvoiceBLL();
        ICompanySCBLL companySCBLL = new CompanySCBLL();
        public FrmInvoice()
        {
            InitializeComponent();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            txtInvoiceCode.Text = "3302172320";
            txtInvoiceID.Text = "07544959";
            dpInvoiceDate.Value = DateTime.Parse("2018-03-13");
            txtBuyRemarks.Text = "购买方是医药公司";
            txtSaleRemark.Text = "销售方是厂家";
            txtSaleID.Text = "湖南科伦";
            txtBuyID.Text = "万隆";
            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                { "第一票", 1 },
                { "中间票", 3 }
            };
            BindingSource bs = new BindingSource
            {
                DataSource = dic
            };
            cboInvoiceType.DataSource = bs;
            cboInvoiceType.DisplayMember = "Key";
            cboInvoiceType.ValueMember = "Value";
        }

        private void BtnRequestImage_Click(object sender, EventArgs e)
        {
            var fileModel = new FileModel
            {
                TypeId = 1,
                Table = "Invoices",
                Keys = new string[] { "invoiceCode", "invoiceID", "invoiceDate" },
                Vals = new string[] { txtInvoiceCode.Text, txtInvoiceID.Text, dpInvoiceDate.Value.ToShortDateString() },
                Message = string.Format("发票号码:{0} 发票代码:{1} 开票日期:{2} 销售方:{3} 购买方:{4}",
                txtInvoiceID.Text, txtInvoiceCode.Text, dpInvoiceDate.Value.ToShortDateString(), txtSaleID.Text, txtBuyID.Text)
            };
            var json = JsonConvert.SerializeObject(fileModel);
            var queryString = MySecurity.SEncryptString(json, "yss.yh"); ;
            var url = string.Format("{0}?{1}", ModelFactory.ImgPUrl, queryString);
            System.Diagnostics.Process.Start("chrome.exe", url);
        }

        private void BtnInsertData_Click(object sender, EventArgs e)
        {
            var fileModel = new FileModel
            {
                TypeId = 1,
                Table = "Invoices",
                Keys = new string[] { "invoiceCode", "invoiceID", "invoiceDate" },
                Vals = new string[] { txtInvoiceCode.Text, txtInvoiceID.Text, dpInvoiceDate.Value.ToShortDateString() },
                Message = string.Format("发票号码:{0} 发票代码:{1} 开票日期:{2} 销售方:{3} 购买方:{4}",
                txtInvoiceID.Text, txtInvoiceCode.Text, dpInvoiceDate.Value.ToShortDateString(), txtSaleID.Text, txtBuyID.Text)
            };

            try
            {
                var json = JsonConvert.SerializeObject(fileModel);
                var queryString = MySecurity.SEncryptString(json, "yss.yh"); ;
                var url = string.Format("{0}Home/GetData", ModelFactory.ImgPUrl);
                var postVars = new NameValueCollection { { "uid", queryString } };
                var result = WebClientHttp.Post(url, postVars);
                FileModel entity = JsonConvert.DeserializeObject<JObject>(result)["fileModel"].ToObject<FileModel>();
                var objList = new List<object>();
                var list = new List<Invoice>();
                foreach (var item in entity.FileList)
                {
                    var obj = new
                    {
                        companyPrimaryKey = Guid.NewGuid().ToString(),
                        invoiceCode = txtInvoiceCode.Text,
                        invoiceID = txtInvoiceID.Text,
                        invoiceDate = dpInvoiceDate.Value.ToString("yyyyMMdd"),
                        invoiceType = (int)cboInvoiceType.SelectedValue,
                        saleID = txtSaleID.Tag.ToString(),
                        saleRemark = txtSaleRemark.Text,
                        buyID = txtBuyID.Tag.ToString(),
                        buyRemarks = txtBuyRemarks.Text,
                        picUrl = ModelFactory.ImgPUrl + item.Url,
                        picMD5 = item.Md5,
                    };
                    objList.Add(obj);
                    list.Add(new Invoice
                    {
                        CompanyPrimaryKey = obj.companyPrimaryKey,
                        InvoiceCode = obj.invoiceCode,
                        InvoiceID = obj.invoiceID,
                        InvoiceDate = obj.invoiceDate,
                        InvoiceType = obj.invoiceType,
                        SaleID = obj.saleID,
                        SaleRemark = obj.saleRemark,
                        BuyID = obj.buyID,
                        BuyRemarks = obj.buyRemarks,
                        PicUrl = obj.picUrl,
                        PicMD5 = obj.picMD5,
                    });
                }
                ctxtJson.Text = JsonConvert.SerializeObject(new { list = objList });
                if (MBox.ShowAsk("是否写入数据库？"))
                {
                    list.ForEach(x => invoiceBLL.AddInvoice(x));
                }
            }
            catch (Exception ex)
            {
                MBox.ShowErr(ex.Message);
            }
        }

        //第一票销售方是厂家，购买方是医药公司
        //第二票销售方是医药公司，购买方是医院
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctxtJson.Text.Trim()))
            {
                MBox.ShowErr("请先点击【生成】获取Json传输参数");
                return;
            }

            #region "Test"
            //try
            //{
            //    string url = "http://trade.zgyxcgw.cn:9092/tradeInterface/v1/companyInterface/drug/invoice/addInvoice";
            //    var postVars = new NameValueCollection
            //    {
            //        { "accessToken", BLL.QuartzLog.CompanyInterface.AccessTokeBLL.AccessToken.AccessToken },
            //        { "invoiceInfo", ctxtJson.Text },
            //    };
            //    string result = WebClientHttp.Post(url, postVars);
            //    FlashLogger.Info(result); 
            //}
            //catch (Exception ex)
            //{
            //    FlashLogger.Error(ex.Message);                
            //}
            //return;
            #endregion

            StringBuilder stringBuilder = new StringBuilder();

            var checkList = invoiceBLL.SubmitInvoice(ctxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.SuccessList != null && checkList.SuccessList.Count > 0)
                {
                    foreach (var itemS in checkList.SuccessList)
                    {
                        stringBuilder.AppendFormat("企业发票主键编号:{0}   中心发票ID:{1}\r\n", itemS.CompanyPrimaryKey, itemS.Id);
                        invoiceBLL.WriteBackInvoiceId(itemS.CompanyPrimaryKey, itemS.Id);
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

            ctxtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
        }

        private void TxtSaleID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtSaleID.Text.Trim()))
            {
                var list = companySCBLL.GetCompanyList(DateTime.Now, DateTime.Now, txtSaleID.Text.Trim());
                DataTable dataTable = null;
                if (list != null && list.Count > 0)
                    dataTable = new DataTableExtensions<Company>(list).DtReturn;
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
                        txtSaleID.Text = frm.dataRow["companyName"].ToString();
                        txtSaleID.Tag = frm.dataRow["companyId"];
                    }
                }
                else
                    MBox.ShowMsg("数据不存在");
            }
        }

        private void TxtBuyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtBuyID.Text.Trim()))
            {
                var list = companySCBLL.GetCompanyList(DateTime.Now, DateTime.Now, txtBuyID.Text.Trim());
                DataTable dataTable = null;
                if (list != null && list.Count > 0)
                    dataTable = new DataTableExtensions<Company>(list).DtReturn;
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
                        txtBuyID.Text = frm.dataRow["companyName"].ToString();
                        txtBuyID.Tag = frm.dataRow["companyId"];
                    }
                }
                else
                    MBox.ShowMsg("数据不存在");
            }
        }

        private void BindDgd()
        {
            var dt = invoiceBLL.GetInvoices(dpStartDate.Value.Date, dpEndDate.Value.Date);
            Cgd.SetDefaultStyle(dgd, dt, false, false, false, _ClearColumns: true);

            Cgd.SetColumn(dgd, "companyPrimaryKey", "主键", 270, -1, "", AlignHorzEnum.Center);            
            Cgd.SetColumn(dgd, "invoiceCode", "发票代码", 100, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "invoiceID", "发票号码", 80, -1, "", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "invoiceDate", "发票日期", 80, -1, "yyyy-MM-dd", AlignHorzEnum.Center);
            Cgd.SetColumn(dgd, "saleName", "销售方", 170, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "saleRemark", "销售方备注", 120, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "buyName", "购买方", 170, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "buyRemarks", "购买方备注", 120, -1, "", AlignHorzEnum.Near);
            Cgd.SetColumn(dgd, "id", "中心返回ID", 200, -1, "", AlignHorzEnum.Center);
            Cgd.AddEndingStyle(dgd);
        }     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgd();
        }
    }
}