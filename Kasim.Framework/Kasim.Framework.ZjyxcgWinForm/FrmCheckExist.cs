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
    public partial class FrmCheckExist : Form
    {
        public FrmCheckExist()
        {
            InitializeComponent();
        }

        public int CheckExistType;
        IProcurecatalogBLL procurecatalogBLL = new ProcurecatalogBLL();
        List<PurchaseType> purchaseTypeList;
        IHospitalBLL hospitalBLL = new HospitalBLL();
        private DataTable dt;
        private void FrmCheckExist_Load(object sender, EventArgs e)
        {
            if (CheckExistType == 1)
            {
                Text = "C014判断商品是否存在";
                purchaseTypeList = procurecatalogBLL.GetPurchaseTypes();
            }
            else if (CheckExistType == 2)
            {
                Text = "C015判断医疗机构是否存在";
            }
            BindDgv();
        }

        private void BindDgv()
        {
            if (CheckExistType == 1)
            {
                dt = new DataTableExtensions<Procurecatalog>(new List<Procurecatalog>()).DtReturn;
                var bs = new BindingSource { DataSource = dt };
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
                dgv.Columns.Add(Dgv.AddDgvTextBox("bidPrice", "中标价格", 70, _Format: "0.00#", _Alignment: Dgv.DgvAlign.MR));
                dgv.Columns.Add(Dgv.AddDgvCheckBox("isUsing", "启用", 35, _Alignment: Dgv.DgvAlign.MC));
                dgv.Columns.Add(Dgv.AddDgvTextBox("addTime", "添加时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
                dgv.Columns.Add(Dgv.AddDgvTextBox("lastUpdateTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            }
            else if (CheckExistType == 2)
            {
                dt = new DataTableExtensions<Hospital>(new List<Hospital>()).DtReturn;
                var bs = new BindingSource { DataSource = dt };
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
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                DataTable dataTable = null;
                if (CheckExistType == 1)
                {
                    var list = procurecatalogBLL.GetProcurecatalogList(DateTime.Now, DateTime.Now, txtName.Text.Trim());
                    if (list != null && list.Count > 0)
                        dataTable = new DataTableExtensions<Procurecatalog>(list).DtReturn;
                }
                else if (CheckExistType == 2)
                {
                    var list = hospitalBLL.GetHospitalList(DateTime.Now, DateTime.Now, txtName.Text.Trim());
                    if (list != null && list.Count > 0)
                        dataTable = new DataTableExtensions<Hospital>(list).DtReturn;
                }
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
                        dt.ImportRow(frm.dataRow);
                    }
                }
                else
                    MBox.ShowMsg("数据不存在");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MBox.ShowErr("请先加载需要判断的内容");
                return;
            }
            var objList = new List<object>();
            foreach (DataRow item in dt.Rows)
            {
                if (CheckExistType == 1)
                {
                    objList.Add(new { procurecatalogId = item["procurecatalogId"].ToString() });
                }
                else if (CheckExistType == 2)
                {
                    objList.Add(new { hospitalId = item["hospitalId"].ToString() });
                }
            }
            rtxtJson.Text = JsonConvert.SerializeObject(new { list = objList });

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtJson.Text.Trim()))
            {
                MBox.ShowErr("请先点击【生成】获取Json传输参数");
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            if (CheckExistType == 1)
            {
                var checkList = procurecatalogBLL.CheckExist(rtxtJson.Text);
                if (checkList != null)
                {
                    stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                    if (checkList.ResultList != null && checkList.ResultList.Count > 0)
                    {
                        foreach (var item in checkList.ResultList)
                        {
                            var entity = procurecatalogBLL.GetProcurecatalogById(item.ProcurecatalogId);
                            stringBuilder.AppendFormat("编号:{0}   名称:{1} / ({2})   是否存在:{3}\r\n", item.ProcurecatalogId, entity.ProductName, entity.GoodsName, item.IsExist);
                        }
                    }
                }
            }
            else if (CheckExistType == 2)
            {
                var checkList = hospitalBLL.CheckExist(rtxtJson.Text);
                if (checkList != null)
                {
                    stringBuilder.AppendFormat("ResultMessage:{0}\r\n", checkList.ReturnMsg);
                    if (checkList.ResultList != null && checkList.ResultList.Count > 0)
                    {
                        foreach (var item in checkList.ResultList)
                        {
                            var entity = hospitalBLL.GetHospitalById(item.HospitalId);
                            stringBuilder.AppendFormat("编号:{0}   名称:{1}   是否存在:{2}\r\n", item.HospitalId, entity.HospitalName, item.IsExist);
                        }
                    }
                }
            }
            rtxtJson.Text += string.Format("\r\n\r\n***********************【 返 回 】***********************\r\n\r\n{0}", stringBuilder.ToString());
        }
    }
}
