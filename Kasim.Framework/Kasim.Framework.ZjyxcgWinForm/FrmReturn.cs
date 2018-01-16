using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FrmReturn : Form
    {
        public FrmReturn()
        {
            InitializeComponent();
        }
        IReturnBLL returnBLL = new ReturnBLL();
        public int modeType = 0;
        private void FrmReturn_Load(object sender, EventArgs e)
        {
            if (modeType == 1)
            {
                tsbMaintenance.Visible = false;
                tsbResponse.Visible = true;
                btnInit.Visible = false;
                tsbJson.Visible = true;
                Text = "C009退货响应";
                tscResponseStatus.Visible = true;
                tstResponseNote.Visible = true;
                toolStripLabel1.Visible = true;
            }
            else if (modeType==2)
            {
                tsbMaintenance.Visible = true;
                tsbResponse.Visible = false;
                btnInit.Visible = false;
                tsbJson.Visible = true;
                Text = "C010维护退货发票";
                tscResponseStatus.Visible = false;
                tstResponseNote.Visible = false;
                toolStripLabel1.Visible = false;
            }
            else
            {
                tsbMaintenance.Visible = false;
                tsbResponse.Visible = false;
                btnInit.Visible = true;
                Text = "C008获取退货信息";
                panel2.Visible = false;
                tsbJson.Visible = false;
                tscResponseStatus.Visible = false;
                tstResponseNote.Visible = false;
                toolStripLabel1.Visible = false;
            }
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            BindDgv();
        }

        private void BindDgv()
        {
            var list = returnBLL.GetReturnList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value));
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("returnId", "退货明细编号", 150, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvCheckBox("returnType", "入库后退", 60, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("distributeId", "配送明细编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("returnCount", "退货数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("returnReason", "退货理由", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("returnCustomInfo", "自定义退货信息", 200, _Alignment: Dgv.DgvAlign.ML));
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
            if (MBox.ShowAsk(string.Format("即将下载从[{0}]到[{1}]的退货信息,是否继续?",
                startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))))
            {
                List<Return> returnList = null;
                var listEntity = returnBLL.GetReturns(TimeHelper.GetStartDateTime(startDate),
                    TimeHelper.GetEndDateTime(endDate), "1");
                if (listEntity != null)
                {
                    returnList = listEntity.DataList;
                    if (returnList != null && returnList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            returnBLL.AddReturns(returnList);
                            var log = string.Format("{0} - {1} : 第{2}页/共{3}页 成功下载 {4} 条退货信息.【{5}】", startDate.ToString("yyyy-MM-dd"),
                                endDate.ToString("yyyy-MM-dd"), i, listEntity.TotalPageCount, returnList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                            FlashLogger.Warn(log);
                            ModelFactory.FMsg.Show2(log);
                            returnList = returnBLL.GetReturns(TimeHelper.GetStartDateTime(startDate),
                                TimeHelper.GetEndDateTime(endDate), (i + 1).ToString()).DataList;
                        }
                    }
                }
                ModelFactory.FMsg.Close2();
                MBox.ShowMsg("退货信息下载结束");
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
            if (modeType == 1)
            {
                if (tscResponseStatus.Text == "已确认待维护退货发票")
                {
                    responseState = 1;
                }
                else if (tscResponseStatus.Text == "已确认且已维护退货发票")
                {
                    responseState = 2;
                    if (tstReturnInvoiceId.Text == "")
                    {
                        MBox.ShowErr("维护退货发票必须填写退货发票号");
                        return;
                    }
                }
                else if (tscResponseStatus.Text == "拒绝退货")
                {
                    responseState = 3;
                    if (tstResponseNote.Text == "")
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
            else if (modeType==2)
            {
                if (tstReturnInvoiceId.Text == "")
                {
                    MBox.ShowErr("维护退货发票必须填写退货发票号");
                    return;
                }
            }
            var objList = new List<object>();
            foreach (DataGridViewRow item in dgv.SelectedRows)
            {
                if (modeType == 1)
                {
                    objList.Add(new
                    {
                        returnId = item.Cells["returnId"].Value.ToString(),
                        isResponse = responseState,
                        refuseReason = tstResponseNote.Text,
                        returnInvoiceId = tstReturnInvoiceId.Text
                    });
                }
                else if (modeType == 2)
                {
                    objList.Add(new
                    {
                        returnId = item.Cells["returnId"].Value.ToString(),
                        returnInvoiceId = tstReturnInvoiceId.Text
                    });
                }
            }
            rtxtJson.Text = JsonConvert.SerializeObject(new { list = objList });
        }

        private void tsbMaintenance_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtJson.Text.Trim()))
            {
                MBox.ShowErr("请先点击【生成】获取Json传输参数");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();

            var checkList = returnBLL.Maintenance(rtxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                {
                    foreach (var itemP in checkList.ErrorList)
                    {
                        stringBuilder.AppendFormat("退货明细编号:{0}   错误原因如下:\r\n", itemP.ReturnId);
                        foreach (var itemC in itemP.ErrorReasonList)
                        {
                            stringBuilder.AppendFormat("      错误码:{0}   错误原因:{1}\r\n", itemC.ErrorCode.ToString(), itemC.ErrorMsg);
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

            var checkList = returnBLL.Response(rtxtJson.Text);
            if (checkList != null)
            {
                stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                if (checkList.ErrorList != null && checkList.ErrorList.Count > 0)
                {
                    foreach (var itemP in checkList.ErrorList)
                    {
                        stringBuilder.AppendFormat("退货明细编号:{0}   错误原因如下:\r\n", itemP.ReturnId);
                        foreach (var itemC in itemP.ErrorReasonList)
                        {
                            stringBuilder.AppendFormat("      错误码:{0}   错误原因:{1}\r\n", itemC.ErrorCode.ToString(), itemC.ErrorMsg);
                        }

                    }
                }
                else
                {
                    JObject list = (JObject)JsonConvert.DeserializeObject(rtxtJson.Text.Trim());
                    foreach (var item in list["list"])
                    {
                        var rtn = returnBLL.GetReturnById(item["returnId"].ToString());
                        rtn.IsResponse = Convert.ToInt32(item["isResponse"]);
                        rtn.RefuseReason = item["refuseReason"].ToString();
                        rtn.ReturnInvoiceId = item["returnInvoiceId"].ToString();
                        returnBLL.UpdateReturn(rtn);
                    }
                }
            }

            rtxtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
        }
    }
}
