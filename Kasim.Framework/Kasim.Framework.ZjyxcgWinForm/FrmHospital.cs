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
    public partial class FrmHospital : Form
    {
        public FrmHospital()
        {
            InitializeComponent();
        }
        IHospitalBLL hospitalBLL = new HospitalBLL();

        private void FrmHospital_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            BindDgv();
        }

        private void BindDgv()
        {
            var list = hospitalBLL.GetHospitalList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value), txtName.Text.Trim());
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("hospitalId", "医疗机构编号", 225, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("hospitalName", "医疗机构名称", 220, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("hospitalAddress", "地址", 250, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("departmentId", "部门编号", 70, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("groupName", "部门名称", 120, _Alignment: Dgv.DgvAlign.MC));
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
            if (dtpStartDate.Value> dtpEndDate.Value)
            {
                MBox.ShowErr("起始时间大于终止时间,请重新选择!");
                return;
            }
            var startMonth = dtpStartDate.Value;
            var endMonth = dtpEndDate.Value.AddMonths(1);
            if (MBox.ShowAsk(string.Format("即将下载从[{0}]到[{1}]的医疗机构信息,是否继续?",
                startMonth.ToString("yyyy-MM"), dtpEndDate.Value.ToString("yyyy-MM"))))
            {
                List<Hospital> hospitalList = null;
                while (true)
                {
                    if (startMonth.Year == endMonth.Year && startMonth.Month == endMonth.Month)
                    {
                        break;
                    }
                    var listEntity = hospitalBLL.GetHospitals("", startMonth.ToString("yyyy-MM"), "1");
                    if (listEntity == null)
                    {
                        break;
                    }
                    hospitalList = listEntity.DataList;
                    if (hospitalList != null && hospitalList.Count > 0)
                    {
                        for (int i = 1; i <= listEntity.TotalPageCount; i++)
                        {
                            hospitalBLL.AddHospitals(hospitalList);
                            var log = string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条医疗机构信息.【{4}】", startMonth.ToString("yyyy-MM"),
                            i, listEntity.TotalPageCount, hospitalList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId);
                            FlashLogger.Warn(log);
                            ModelFactory.FMsg.Show2(log);
                            hospitalList = hospitalBLL.GetHospitals("", startMonth.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                        }
                    }
                    startMonth = startMonth.AddMonths(1);
                }
                ModelFactory.FMsg.Close2();
                MBox.ShowMsg("医疗机构信息下载结束");
                BindDgv();
            }
        }
    }
}
