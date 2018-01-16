using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
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
    public partial class FrmWareHouse : Form
    {
        public FrmWareHouse()
        {
            InitializeComponent();
        }
        //IDistributionBLL distributionBLL = new DistributionBLL();
        IHospitalBLL hospitalBLL = new HospitalBLL();
        IWareHouseBLL wareHouseBLL = new WareHouseBLL();
        private void FrmWareHouse_Load(object sender, EventArgs e)
        {

        }

        private void BindDgv()
        {
            //var list = wareHouseBLL.GetWareHouseList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value), 
            //    Convert.ToString(txtName.Tag));
            var list = wareHouseBLL.GetWareHouseList(Convert.ToString(txtName.Tag));
            var bList = new BindingList<WareHouse>(list);
            var bs = new BindingSource { DataSource = bList };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.DistributeId", "中心配送明细编号", 150, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("warehouseCount", "收货数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("warehouseTime", "收货时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("warehouseCustomInfo", "收货信息", 200, _Alignment: Dgv.DgvAlign.ML));

            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.CompanyDistributeId", "企业配送明细编号", 120, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.DistributeCount", "配送数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.InvoiceId", "发票号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.BatchCode", "批号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.PeriodDate", "有效期", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.DistributeCustomInfo", "配送信息", 85, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.FirstInviceID", "第一票编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.MiddleInviceID", "中间票编号", 85, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.SecondInviceCode", "第二票发票代码", 100, _Alignment: Dgv.DgvAlign.MC));

            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.OrderDetailId", "订单明细编号", 150, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.OrderId", "订单编号", 150, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.OrderName", "订单名称", 320, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.OrderType", "是否急救", 60, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.OrderRemarks", "订单备注", 230, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.TotalDetailCount", "总单行数", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.ProcurecatalogId", "商品编号", 65, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.HospitalId", "医疗机构编号", 225, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.PurchaseCount", "采购数量", 70, _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.PurchasePrice", "采购价格", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.PurchaseAmount", "采购金额", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
            //dgv.Columns.Add(Dgv.AddDgvComboBox(orderDetailStateList, "StateID", "StateName", "Order.OrderDetailState", "订单明细状态", 105, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.DetailDistributeAddress", "送货地址", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.SubmitTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("Distribute.Order.OrderCustomInfo", "订单信息", 200, _Alignment: Dgv.DgvAlign.ML));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDgv();
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
                    distributeId = item.Cells[0].EditedFormattedValue.ToString(),
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
            StringBuilder stringBuilder = new StringBuilder();

            List<WareHouse> wareHouseList = null;
            var listEntity = wareHouseBLL.GetWareHouses(rtxtJson.Text, "1");
            if (listEntity != null)
            {
                wareHouseList = listEntity.DataList;
                if (wareHouseList != null && wareHouseList.Count > 0)
                {
                    for (int i = 1; i <= listEntity.TotalPageCount; i++)
                    {                        
                        wareHouseBLL.AddWareHouses(wareHouseList);
                        var log=string.Format("第{0}页/共{1}页 成功下载 {2} 条收货信息.【{3}】", 
                            i, listEntity.TotalPageCount, wareHouseList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                        FlashLogger.Warn(log);
                        ModelFactory.FMsg.Show2(log);
                        wareHouseList = wareHouseBLL.GetWareHouses(rtxtJson.Text, (i + 1).ToString()).DataList;
                    }
                }
            }
            ModelFactory.FMsg.Close2();
            MBox.ShowMsg("收货信息下载结束");
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
    }
}
