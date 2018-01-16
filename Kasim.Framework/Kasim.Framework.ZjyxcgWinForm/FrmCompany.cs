using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
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
    public partial class FrmCompany : Form
    {
        public FrmCompany()
        {
            InitializeComponent();
        }

        ICompanySCBLL companySCBLL = new CompanySCBLL();
        private void FrmCompany_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            BindDgv();
        }

        private void BindDgv()
        {
            var list = companySCBLL.GetCompanyList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value), txtName.Text.Trim());
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("companyId", "企业编号", 225, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("companyName", "企业名称", 200, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("address", "地址", 250, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("companyContactTel", "企业联系电话", 100, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("companyContactFax", "企业传真号码", 100, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("zipCode", "邮编", 80, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("email", "邮箱", 150, _Alignment: Dgv.DgvAlign.ML));
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
            if (MBox.ShowAsk(string.Format("即将下载从[{0}]到[{1}]的生产企业信息,是否继续?",
                startMonth.ToString("yyyy-MM"), dtpEndDate.Value.ToString("yyyy-MM"))))
            {
                List<Company> companyList = null;
                while (true)
                {
                    if (startMonth.Year == endMonth.Year && startMonth.Month == endMonth.Month)
                    {
                        break;
                    }
                    var listEntity = companySCBLL.GetCompanys("", startMonth.ToString("yyyy-MM"), "1");
                    if (listEntity == null)
                    {
                        break;
                    }
                    companyList = listEntity.DataList;
                    if (companyList != null && companyList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            companySCBLL.AddCompanys(companyList);
                            var log = string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条生产企业信息.【{4}】", startMonth.ToString("yyyy-MM"),
                            i, listEntity.TotalPageCount, companyList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                            FlashLogger.Warn(log);
                            ModelFactory.FMsg.Show2(log);
                            companyList = companySCBLL.GetCompanys("", startMonth.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                        }
                    }
                    startMonth = startMonth.AddMonths(1);
                }
                ModelFactory.FMsg.Close2();
                MBox.ShowMsg("生产企业信息下载结束");
                BindDgv();
            }
        }
    }
}
