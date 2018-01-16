using Kasim.Framework.BLL.QuartzLog.CompanyInterface;
using Kasim.Framework.Common;
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
    public partial class FrmAccessToke : Form
    {
        public FrmAccessToke()
        {
            InitializeComponent();
        }
        IAccessTokeBLL accessTokeBLL = new AccessTokeBLL();
        private void FrmAccessToke_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = ModelFactory.ErpSystemDate;
            dtpEndDate.Value = ModelFactory.ErpSystemDate;
            BindDgv();
        }

        private void BindDgv()
        {
            var list = accessTokeBLL.GetAccessTokenList(TimeHelper.GetStartDateTime(dtpStartDate.Value), TimeHelper.GetEndDateTime(dtpEndDate.Value));
            var bs = new BindingSource { DataSource = list };
            bn.BindingSource = bs;
            dgv.DataSource = bs;

            Dgv.SetDefaultStyle(dgv);

            dgv.Columns.Add(Dgv.AddDgvTextBox("accessToken", "凭据", 250, _Alignment: Dgv.DgvAlign.ML));
            dgv.Columns.Add(Dgv.AddDgvTextBox("expiresIn", "有效时间(秒)", 90, _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("currentTime", "当前时间", 150, _Format: "yyyy-MM-dd HH:mm:ss", _Alignment: Dgv.DgvAlign.MC));
            dgv.Columns.Add(Dgv.AddDgvTextBox("resultJson", "JSON", 910, _Alignment: Dgv.DgvAlign.ML));
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            if (MBox.ShowAsk("每日获取不超过10次,请勿频繁获取凭据,是否继续获取新凭据?"))
            {
                var entity = accessTokeBLL.GetToken();
                var result = accessTokeBLL.SaveToken(entity);
                MBox.ShowMsg(entity.ResultJson);
                BindDgv();
            }
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
    }
}
