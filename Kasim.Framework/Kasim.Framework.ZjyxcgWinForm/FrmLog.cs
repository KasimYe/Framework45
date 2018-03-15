using Kasim.Framework.Common;
using Kasim.Framework.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.ZjyxcgWinForm
{
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            dtpDate.Value = ModelFactory.ErpSystemDate;
            LoadLog();
        }

        private void LoadLog()
        {
            string fileName = dtpDate.Value.ToString("yyyy-MM-dd") + ".read.log";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", fileName);
            string newFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CopyLogs", fileName);
            FileOperate.FolderCreate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CopyLogs"));
            FileOperate.FileCoppy(filePath, newFile);
            rtxtLog.Text = FileOperate.ReadFile(newFile);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLog();
            }
            catch (Exception ex)
            {
                MBox.ShowErr(string.Format("日志加载失败:{0}", ex.Message));
            }
        }
    }
}
