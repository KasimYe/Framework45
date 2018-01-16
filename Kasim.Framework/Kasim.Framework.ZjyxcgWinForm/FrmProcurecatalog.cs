using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
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
    public partial class FrmProcurecatalog : Form
    {
        public FrmProcurecatalog()
        {
            InitializeComponent();
        }
        IProcurecatalogBLL procurecatalogBLL = new ProcurecatalogBLL();
        List<PurchaseType> purchaseTypeList;
        private void FrmProcurecatalog_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            purchaseTypeList = procurecatalogBLL.GetPurchaseTypes();
            BindDgv();
        }

        private void BindDgv()
        {
            var list = procurecatalogBLL.GetProcurecatalogList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value), txtName.Text.Trim());
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("procurecatalogId", "商品编号", 65, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("goodsId", "产品ID", 65, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("productName", "通用名", 230, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("goodsName", "商品名", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("medicinemodel", "剂型", 80, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("outlook", "规格", 90, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("factor", "转换比", 50, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("materialName", "包装材质", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("unit", "单位", 35, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("companyIdSc", "生产企业编号", 120, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("companyNameSc", "生产企业名称", 180, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvComboBox(purchaseTypeList, "TypeID", "TypeName", "purchaseType", "采购类别", 75, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("sourceName", "来源名称", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("middlePack", "中包装", 50, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("maxPack", "大包装", 50, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("bidPrice", "中标价格", 70,_Format:"0.00#", _Alignment: Dgv.DgvAlign.MR));
            dgv.Columns.Add(Dgv.AddDgvCheckBox("isUsing", "启用", 35, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("addTime", "添加时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("lastUpdateTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
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
            var startMonth = dtpStartDate.Value;
            var endMonth = dtpEndDate.Value.AddMonths(1);
            if (MBox.ShowAsk(string.Format("即将下载从[{0}]到[{1}]的商品信息,是否继续?",
                startMonth.ToString("yyyy-MM"), dtpEndDate.Value.ToString("yyyy-MM"))))
            {
                List<Procurecatalog> procurecatalogList = null;
                while (true)
                {
                    if (startMonth.Year == endMonth.Year && startMonth.Month == endMonth.Month)
                    {
                        break;
                    }
                    var listEntity = procurecatalogBLL.GetProcurecatalogs("", startMonth.ToString("yyyy-MM"), "1");
                    if (listEntity == null)
                    {
                        break;
                    }
                    procurecatalogList = listEntity.DataList;
                    if (procurecatalogList != null && procurecatalogList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            procurecatalogBLL.AddProcurecatalogs(procurecatalogList);
                            var log = string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条商品信息.【{4}】", startMonth.ToString("yyyy-MM"),
                            i, listEntity.TotalPageCount, procurecatalogList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                            FlashLogger.Warn(log);
                            ModelFactory.FMsg.Show2(log);
                            procurecatalogList = procurecatalogBLL.GetProcurecatalogs("", startMonth.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                        }
                    }
                    startMonth = startMonth.AddMonths(1);
                }
                ModelFactory.FMsg.Close2();
                MBox.ShowMsg("商品信息下载结束");
                BindDgv();
            }
        }
    }
}
