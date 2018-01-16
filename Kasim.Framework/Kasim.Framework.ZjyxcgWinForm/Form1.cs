using Kasim.Framework.BLL.QuartzLog;
using Kasim.Framework.Common;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog;
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
    public partial class Form1 : Form
    {
        public Form1(int storeId, int userId, DateTime systemDate)
        {
            InitializeComponent();
            ModelFactory.ErpStoreID = storeId;
            ModelFactory.ErpUserID = userId;
            ModelFactory.ErpSystemDate = systemDate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitMenuStrip();
        }

        private void InitMenuStrip()
        {
            foreach (ToolStripMenuItem menu in mainMenu.Items)
            {
                foreach (ToolStripDropDownItem childMenu in menu.DropDownItems)
                {
                    childMenu.Click += new EventHandler(ChildMenu_Click);
                }
            }
        }
        List<Form> listFrm = new List<Form>();
        private void ChildMenu_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem menu = (ToolStripDropDownItem)sender;
            //if (!MBox.ShowAsk(string.Format("确定调用接口【{0}】？", menu.Text))) return; 
            Form form = null;
            switch (menu.Text)
            {
                case "C001连通性测试":
                    IConnectionBLL connectionBLL = new ConnectionBLL();
                    var result = connectionBLL.TestConnection();
                    MBox.ShowMsg(result.ResultJson);
                    break;
                case "C002获取接口调用凭据":
                    ShowFormAgain(menu.Text, new FrmAccessToke
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C003获取采购订单":
                    ShowFormAgain(menu.Text, new FrmOrder
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C004阅读订单":
                    ShowFormAgain(menu.Text, new FrmOrder
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        modeType = 1
                    });
                    break;
                case "C005响应订单":
                    ShowFormAgain(menu.Text, new FrmOrder
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        modeType = 2
                    });
                    break;
                case "C006配送订单":
                    ShowFormAgain(menu.Text, new FrmDistribute
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C007获取收货信息":
                    ShowFormAgain(menu.Text, new FrmWareHouse
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C008获取退货信息":
                    ShowFormAgain(menu.Text, new FrmReturn
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        modeType = 0
                    });
                    break;
                case "C009退货响应":
                    ShowFormAgain(menu.Text, new FrmReturn
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        modeType = 1
                    });
                    break;
                case "C010维护退货发票":
                    ShowFormAgain(menu.Text, new FrmReturn
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        modeType = 2
                    });
                    break;
                case "C011获取商品信息":
                    ShowFormAgain(menu.Text, new FrmProcurecatalog
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C012获取生产企业":
                    ShowFormAgain(menu.Text, new FrmCompany
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C013获取医疗机构":
                    ShowFormAgain(menu.Text, new FrmHospital
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false
                    });
                    break;
                case "C014判断商品是否存在":
                    ShowFormAgain(menu.Text, new FrmCheckExist
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        CheckExistType = 1
                    });
                    break;
                case "C015判断医疗机构是否存在":
                    ShowFormAgain(menu.Text, new FrmCheckExist
                    {
                        MdiParent = this,
                        WindowState = FormWindowState.Maximized,
                        ShowIcon = false,
                        CheckExistType = 2
                    });
                    break;
                case "C016获取支付订单":
                    break;
                case "C017获取支付明细订单":
                    break;
                case "C018票据上传":
                    break;
                case "C019销售清单上传":
                    break;
                default:
                    break;
            }
        }

        private void tsmiLog_Click(object sender, EventArgs e)
        {
            new FrmLog
            {
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }

        private void ShowFormAgain(string menuText, Form form)
        {
            foreach (var item in listFrm)
            {
                item.Hide();
            }
            var newForm = listFrm.Where(f => f.Text == menuText).SingleOrDefault();
            if (form != null)
            {
                if (newForm == null)
                {
                    newForm = form;
                    listFrm.Add(form);
                    ToolStripButton button = new ToolStripButton
                    {
                        Text = menuText,
                        DisplayStyle = ToolStripItemDisplayStyle.Text,
                    };
                    button.Click += TsButton_Click;
                    toolStrip1.Items.Add(button);                   
                }
                else
                {
                    form.Close();
                    form.Dispose();
                }
            }

            foreach (ToolStripButton item in toolStrip1.Items)
            {
                if (menuText==item.Text)
                {
                    item.BackColor = Color.LightBlue;
                    item.ForeColor = Color.Red;
                }
                else
                {
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }          
            }

            newForm.MdiParent = this;
            newForm.WindowState = FormWindowState.Maximized;
            newForm.Show();
        }

        private void TsButton_Click(object sender, EventArgs e)
        {
            ShowFormAgain(((ToolStripButton)sender).Text, null);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in listFrm)
            {
                item.Dispose();
                item.Close();
            }
        }

        private void mainMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text.Length == 0 || e.Item.Text == "还原(&R)" || e.Item.Text == "最小化(&N)" || e.Item.Text == "关闭(&C)")
            {
                e.Item.Visible = false;
            }

        }

    }
}
