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

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmInvoice : DevExpress.XtraEditors.XtraForm
    {
        IInvoiceBLL invoiceBLL = new InvoiceBLL();
        public FrmInvoice()
        {
            InitializeComponent();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            txtInvoiceCode.Text = "3302172320";
            txtInvoiceID.Text = "07544957";
            dpInvoiceDate.Value = DateTime.Parse("2018-03-13");
        }

        private void BtnRequestImage_Click(object sender, EventArgs e)
        {
            var fileModel = new FileModel
            {
                TypeId = 3,
                Table = "Invoices",
                Keys = new string[] { "invoiceCode", "invoiceID", "invoiceDate" },
                Vals = new string[] { txtInvoiceCode.Text, txtInvoiceID.Text, dpInvoiceDate.Value.ToShortDateString() },
                Message = string.Format("发票号码:{0} 发票代码:{1} 开票日期:{2}", txtInvoiceID.Text, txtInvoiceCode.Text, dpInvoiceDate.Value.ToShortDateString())
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
                TypeId = 3,
                Table = "Invoices",
                Keys = new string[] { "invoiceCode", "invoiceID", "invoiceDate" },
                Vals = new string[] { txtInvoiceCode.Text, txtInvoiceID.Text, dpInvoiceDate.Value.ToShortDateString() },
                Message = string.Format("发票号码:{0} 发票代码:{1} 开票日期:{2}", txtInvoiceID.Text, txtInvoiceCode.Text, dpInvoiceDate.Value.ToShortDateString())
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
                foreach (var item in entity.FileList)
                {
                    objList.Add(new
                    {
                        companyPrimaryKey = "123",
                        invoiceCode = txtInvoiceCode.Text,
                        invoiceID = txtInvoiceID.Text,
                        invoiceDate = dpInvoiceDate.Value.ToString("yyyyMMdd"),                     
                        invoceType = 1,
                        saleID = "123",
                        saleRemark = "",
                        buyID = "456",
                        buyRemarks = "123",
                        picUrl = ModelFactory.ImgPUrl + item.Url,
                        picMD5 = item.Md5,
                    });
                }
                ctxtJson.Text = JsonConvert.SerializeObject(new { list = objList });
            }
            catch (Exception ex)
            {
                MBox.ShowErr(ex.Message);
            }                    
        }

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
            //    string url = "http://trade.zgyxcgw.cn:9092/tradeInterface/v1/companyInterface/drug/distribution/distribute";
            //    var postVars = new System.Collections.Specialized.NameValueCollection
            //    {
            //        { "accessToken", BLL.QuartzLog.CompanyInterface.AccessTokeBLL.AccessToken.AccessToken },
            //        { "distributeInfo", rtxtJson.Text }
            //    };
            //    string result = WebClientHttp.Post(url, postVars);
            //    FlashLogger.Info(result);                 
            //}
            //catch (Exception ex)
            //{
            //    FlashLogger.Error(ex.Message);                
            //}
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
    }
}