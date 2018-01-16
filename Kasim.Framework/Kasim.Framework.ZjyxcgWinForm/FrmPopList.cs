using Kasim.Framework.Common;
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
    public partial class FrmPopList : Form
    {
        public FrmPopList()
        {
            InitializeComponent();
        }

        public DataTable dataTable = null;
        public DataRow dataRow = null;
        private void FrmPopList_Load(object sender, EventArgs e)
        {
            if (dataTable!=null&&dataTable.Rows.Count>0)
            {
                BindDgv();
                dgv.Focus();
                dgv.Select();
            }
            else
            {
                MBox.ShowMsg("数据不存在");
                Close();
            }
        }

        private void BindDgv()
        {
            dgv.DataSource = dataTable;

            Dgv.SetDefaultStyle(dgv);
            for (int i = 0; i < dataTable.Columns.Count - 1; i++)
            {
                var dc = dataTable.Columns[i];
                switch (dc.ColumnName.ToUpper())
                {
                    case "HOSPITALNAME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("hospitalName", "医疗机构名称", 220, _Alignment: Dgv.DgvAlign.ML));
                        break;
                    case "GROUPNAME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("groupName", "部门名称", 120, _Alignment: Dgv.DgvAlign.MC));
                        break;
                    case "LASTUPDATETIME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("lastUpdateTime", "变更时间", 140, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
                        break;
                    case "COMPANYNAME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("companyName", "企业名称", 200, _Alignment: Dgv.DgvAlign.ML));
                        break;
                    case "COMPANYCONTACTTEL":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("companyContactTel", "企业联系电话", 100, _Alignment: Dgv.DgvAlign.MC));
                        break;
                    case "COMPANYCONTACTFAX":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("companyContactFax", "企业传真号码", 100, _Alignment: Dgv.DgvAlign.MC));
                        break;                    
                    case "PRODUCTNAME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("productName", "通用名", 230, _Alignment: Dgv.DgvAlign.ML));
                        break;
                    case "GOODSNAME":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("goodsName", "商品名", 70, _Alignment: Dgv.DgvAlign.MC));
                        break;
                    case "MEDICINEMODEL":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("medicinemodel", "剂型", 80, _Alignment: Dgv.DgvAlign.MC));
                        break;
                    case "OUTLOOK":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("outlook", "规格", 90, _Alignment: Dgv.DgvAlign.ML));
                        break;
                    case "COMPANYNAMESC":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("companyNameSc", "生产企业名称", 180, _Alignment: Dgv.DgvAlign.ML));
                        break;
                    case "UNIT":
                        dgv.Columns.Add(Dgv.AddDgvTextBox("unit", "单位", 35, _Alignment: Dgv.DgvAlign.MC));
                        break;
                    default:
                        dgv.Columns.Add(Dgv.AddDgvTextBox(dc.ColumnName, dc.ColumnName, 0, false));
                        break;
                }
            }
            dgv.Columns[0].Visible = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count>0)
            {
                dataRow = dataTable.Rows[dgv.SelectedRows[0].Index];
                Close();
            }
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            dataRow = null;
            Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataRow = dataTable.Rows[e.RowIndex];
            Close();
        }

        private void FrmPopList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    dataRow = dataTable.Rows[dgv.SelectedRows[0].Index];
                    Close();
                }
            }
        }
    }
}
