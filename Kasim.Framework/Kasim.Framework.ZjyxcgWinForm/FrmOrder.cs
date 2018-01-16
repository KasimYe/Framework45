using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
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
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
        }
        IPurchaseOrderBLL purchaseOrderBLL = new PurchaseOrderBLL();
        List<OrderDetailState> orderDetailStateList;
        public int modeType = 0;
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            if (modeType == 1)
            {
                tsbRead.Visible = true;
                tsbResponse.Visible = false;
                btnInit.Visible = false;
                tsbJson.Visible = true;
                Text = "C004阅读订单";
                tscResponseStatus.Visible = false;
                tstResponseNote.Visible = false;
                toolStripLabel1.Visible = false;
            }
            else if (modeType == 2)
            {
                tsbRead.Visible = false;
                tsbResponse.Visible = true;
                btnInit.Visible = false;
                tsbJson.Visible = true;
                Text = "C005响应订单";
                tscResponseStatus.Visible = true;
                tstResponseNote.Visible = true;
                toolStripLabel1.Visible = true;
            }
            else
            {
                tsbRead.Visible = false;
                tsbResponse.Visible = false;
                btnInit.Visible = true;
                Text = "C003获取采购订单";
                panel2.Visible = false;
                tsbJson.Visible = false;
                tscResponseStatus.Visible = false;
                tstResponseNote.Visible = false;
                toolStripLabel1.Visible = false;
            }
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            orderDetailStateList = purchaseOrderBLL.GetOrderDetailStates();
            BindDgv();
        }

        private void BindDgv()
        {
            var list = purchaseOrderBLL.GetOrderList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value),
                Convert.ToString(txtName.Tag), Convert.ToString(txtName2.Tag));
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("orderId", "订单编号", 150, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("orderName", "订单名称", 320, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvCheckBox("orderType", "急救订单", 60, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("orderRemarks", "订单备注", 230, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("totalDetailCount", "总单行数", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("orderDetailId", "订单明细编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("procurecatalogId", "商品编号", 65, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("hospitalId", "医疗机构编号", 225, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("purchaseCount", "采购数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("purchasePrice", "采购价格", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("purchaseAmount", "采购金额", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvComboBox(orderDetailStateList, "StateID", "StateName", "orderDetailState", "订单明细状态", 105, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("detailDistributeAddress", "送货地址", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("submitTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("orderCustomInfo", "送货地址", 200, _Alignment: Dgv.DgvAlign.ML));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MBox.ShowErr("起始时间大于终止时间,请重新选择!");
                return;
            }
            BindDgv();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MBox.ShowErr("起始时间大于终止时间,请重新选择!");
                return;
            }
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;
            if (MBox.ShowAsk(string.Format("即将下载从[{0}]到[{1}]的采购订单信息,是否继续?",
                startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))))
            {
                List<Order> orderList = null;
                var listEntity = purchaseOrderBLL.GetOrders(TimeHelper.GetStartDateTime(startDate),
                    TimeHelper.GetEndDateTime(endDate), "1");
                if (listEntity != null)
                {                    
                    orderList = listEntity.DataList;
                    if (orderList != null && orderList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            purchaseOrderBLL.AddOrders(orderList);
                            var log=string.Format("{0} - {1} : 第{2}页/共{3}页 成功下载 {4} 条采购订单信息.【{5}】", startDate.ToString("yyyy-MM-dd"),
                                endDate.ToString("yyyy-MM-dd"), i, listEntity.TotalPageCount, orderList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                            FlashLogger.Warn(log);
                            ModelFactory.FMsg.Show2(log);
                            orderList = purchaseOrderBLL.GetOrders(TimeHelper.GetStartDateTime(startDate),
                                TimeHelper.GetEndDateTime(endDate), (i + 1).ToString()).DataList;
                        }
                    }
                }
                ModelFactory.FMsg.Close2();
                MBox.ShowMsg("采购订单信息下载结束");
                BindDgv();
            }
        }

        private void tsbJson_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MBox.ShowErr("请选择要操作的订单明细");
                return;
            }
            int responseState = 0;
            if (modeType==2)
            {                
                if (tscResponseStatus.Text == "同意响应")
                {
                    responseState = 2;
                }
                else if (tscResponseStatus.Text == "拒绝响应")
                {
                    responseState = 3;
                    if (tstResponseNote.Text=="")
                    {
                        MBox.ShowErr("拒绝响应必须填写理由");
                        return;
                    }
                }
                else
                {
                    MBox.ShowErr("请选择响应方式");
                    return;
                }
            }
            var objList = new List<object>();
            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                if (modeType == 1)
                {
                    objList.Add(new { orderDetailId = item.Cells["orderDetailId"].Value.ToString() });
                }
                else if (modeType == 2)
                {

                    objList.Add(new {
                        orderDetailId = item.Cells["orderDetailId"].Value.ToString(),
                        responseState,
                        refuseReason = tstResponseNote.Text
                    });
                }
            }
            rtxtJson.Text = JsonConvert.SerializeObject(new { list = objList });
        }

        private void tsbRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtJson.Text.Trim()))
            {
                MBox.ShowErr("请先点击【生成】获取Json传输参数");
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();

            var checkList = purchaseOrderBLL.Read(rtxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                {
                    foreach (var itemP in checkList.ErrorList)
                    {
                        stringBuilder.AppendFormat("订单明细编号:{0}   错误原因如下:\r\n", itemP.OrderDetailId);
                        foreach (var itemC in itemP.ErrorReasonList)
                        {
                            stringBuilder.AppendFormat("      错误码:{0}   错误原因:{1}\r\n", itemC.ErrorCode.ToString(),itemC.ErrorMsg);
                        }
                        
                    }
                }
            }

            rtxtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
        }

        private void tsbResponse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtJson.Text.Trim()))
            {
                MBox.ShowErr("请先点击【生成】获取Json传输参数");
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();

            var checkList = purchaseOrderBLL.Response(rtxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                {
                    foreach (var itemP in checkList.ErrorList)
                    {
                        stringBuilder.AppendFormat("订单明细编号:{0}   错误原因如下:\r\n", itemP.OrderDetailId);
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
