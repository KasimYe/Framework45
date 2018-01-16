using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmDistribute : Form
    {
        public FrmDistribute()
        {
            InitializeComponent();
        }

        IDistributionBLL distributionBLL = new DistributionBLL();
        IHospitalBLL hospitalBLL = new HospitalBLL();
        List<OrderDetailState> orderDetailStateList;
        private void FrmDistribute_Load(object sender, EventArgs e)
        {
            IPurchaseOrderBLL purchaseOrderBLL = new PurchaseOrderBLL();
            orderDetailStateList = purchaseOrderBLL.GetOrderDetailStates();
            //BindDgv();
        }

        private void BindDgv()
        {
            var list = distributionBLL.GetDistributeList(Convert.ToString(txtName.Tag));
            var bList = new BindingList<Distribute>(list);
            var bs = new BindingSource { DataSource = bList };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("companyDistributeId", "企业配送明细编号", 120, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("distributeCount", "配送数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("invoiceId", "发票号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("batchCode", "批号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("periodDate", "有效期", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("distributeCustomInfo", "配送信息", 85, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("firstInviceID", "第一票编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("middleInviceID", "中间票编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("secondInviceCode", "第二票发票代码", 100, _Alignment: Dgv.DgvAlign.MC));

            dgv.Columns.Add(Dgv.AddDgvTextBox("orderDetailId", "订单明细编号", 150, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.OrderId", "订单编号", 150, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.OrderName", "订单名称", 320, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.OrderType", "是否急救", 60, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.OrderRemarks", "订单备注", 230, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.TotalDetailCount", "总单行数", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.ProcurecatalogId", "商品编号", 65, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.HospitalId", "医疗机构编号", 225, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.PurchaseCount", "采购数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.PurchasePrice", "采购价格", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.PurchaseAmount", "采购金额", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            //dgv.Columns.Add(Dgv.AddDgvComboBox(orderDetailStateList, "StateID", "StateName", "Order.OrderDetailState", "订单明细状态", 105, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.DetailDistributeAddress", "送货地址", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.SubmitTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Order.OrderCustomInfo", "订单信息", 200, _Alignment: Dgv.DgvAlign.ML));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtName.Text.Trim()))
            {                
                var list = hospitalBLL.GetHospitalList(DateTime.Now, DateTime.Now, txtName.Text.Trim());
                DataTable dataTable = null;
                if (list != null && list.Count > 0)
                    dataTable = new DataTableExtensions<Hospital>(list).DtReturn;
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
                        txtName.Text = frm.dataRow["hospitalName"].ToString();
                        txtName.Tag = frm.dataRow["hospitalId"];
                    }
                }
                else
                    MBox.ShowMsg("数据不存在");
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //找到绑定字段中带下划线的列
            if ((dgv.Rows[e.RowIndex].DataBoundItem != null) &&
                (dgv.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                //用split方法将其分割成一个数组
                string[] names = dgv.Columns[e.ColumnIndex].DataPropertyName.Split('.');
                object obj = dgv.Rows[e.RowIndex].DataBoundItem;//获取到当前记录绑定的类型
                for (int i = 0; i < names.Count(); ++i)
                {
                    try
                    {
                        //通过反射的方式获取当前列的属性值，如StudentName
                        //第一次循环到Student，第二次拿到的是StudentName
                        var result = obj.GetType().GetProperty(names[i]).GetValue(obj, null);
                        obj = result;
                        e.Value = result.ToString();//拿到对应的值
                    }
                    catch (Exception)
                    {
                        return;
                        throw;
                    }
                }
            }
        }

        private void tsbJson_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MBox.ShowErr("请选择要操作的配送明细");
                return;
            }
            var objList = new List<object>();
            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                objList.Add(new
                {
                    companyDistributeId = item.Cells["companyDistributeId"].Value.ToString(),
                    orderDetailId = item.Cells["orderDetailId"].Value.ToString(),
                    distributeCount = item.Cells["distributeCount"].Value.ToString(),
                    invoiceId = Convert.ToString(item.Cells["invoiceId"].Value),
                    //invoiceCode = "3302154320",
                    batchCode = item.Cells["batchCode"].Value.ToString(),
                    periodDate = item.Cells["periodDate"].Value.ToString(),
                    distributeCustomInfo = Convert.ToString(item.Cells["distributeCustomInfo"].Value),
                    firstInviceID = Convert.ToString(item.Cells["firstInviceID"].Value),
                    middleInviceID = Convert.ToString(item.Cells["middleInviceID"].Value),
                    secondInviceCode = Convert.ToString(item.Cells["secondInviceCode"].Value),
                });
            }
            rtxtJson.Text = JsonConvert.SerializeObject(new { list = objList });
        }

        private void tsbSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtJson.Text.Trim()))
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

            var checkList = distributionBLL.SubmitDistribute(rtxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.SuccessList != null && checkList.SuccessList.Count > 0)
                {
                    foreach (var itemS in checkList.SuccessList)
                    {
                        stringBuilder.AppendFormat("企业配送明细编号:{0}   中心配送明细编号{1}:\r\n", itemS.CompanyDistributeId, itemS.DistributeId);
                        distributionBLL.WriteBackDistributeId(itemS.CompanyDistributeId, itemS.DistributeId);
                    }
                }
                if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                {
                    foreach (var itemP in checkList.ErrorList)
                    {
                        stringBuilder.AppendFormat("企业配送明细编号:{0}   错误原因如下:\r\n", itemP.CompanyDistributeId);
                        foreach (var itemC in itemP.ErrorReasonList)
                        {
                            stringBuilder.AppendFormat("      错误码:{0}   错误原因:{1}\r\n", itemC.ErrorCode.ToString(), itemC.ErrorMsg);
                        }
                    }
                }
            }

            rtxtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
        }
    }
}
