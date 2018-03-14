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

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmInvoice : DevExpress.XtraEditors.XtraForm
    {
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
                MBox.ShowMsg(result);
            }
            catch (Exception ex)
            {
                MBox.ShowErr(ex.Message);
            }                    
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}