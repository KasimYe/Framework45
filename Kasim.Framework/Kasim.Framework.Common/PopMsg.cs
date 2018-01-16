using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.Common
{
    public partial class PopMsg : Form
    {
        public PopMsg()
        {
            InitializeComponent();            
        }

        public void Show2(string message)
        {
            txtMsg.Text = message;            
            Show();
            Refresh();
            Application.DoEvents();
        }

        public void Close2()
        {
            Hide();
            Application.DoEvents();
        }

        private void txtMsg_Click(object sender, EventArgs e)
        {
            Close2();
        }
    }
}
