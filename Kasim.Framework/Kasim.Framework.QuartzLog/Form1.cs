using Kasim.Framework.BLL.QuartzLog;
using Kasim.Framework.BLL.QuartzLog.CompanyInterface;
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog;
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

namespace Kasim.Framework.QuartzLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyWrite = WriteLine;
            


        }

        public static Write MyWrite;
        void WriteLine(object msg)
        {
            richTextBox1.BeginInvoke(new Action(() =>
            {
                richTextBox1.Text += msg.ToString() + "\n";
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
