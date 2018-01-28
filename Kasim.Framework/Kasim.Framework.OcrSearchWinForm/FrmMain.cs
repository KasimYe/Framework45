using Kasim.Framework.Entity.OcrSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.OcrSearchWinForm
{
    public partial class FrmMain : Form
    {
        private Bitmap _catchBmp;        

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnCut_Click(object sender, EventArgs e)
        {
            CutImage();
        }
        private void CutImage()
        {
            // 新建一个和屏幕大小相同的图片
            Bitmap catchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);

            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g = Graphics.FromImage(catchBmp);

            // 把屏幕图片拷贝到我们创建的空白图片 catchBmp中
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            Tools.ScreenShots = catchBmp;
            // 创建截图窗体
            FrmCutter _frmCutter = new FrmCutter
            {
                Tag = this,

                // 指示窗体的背景图片为屏幕图片
                BackgroundImage = catchBmp,                
                Width = Screen.AllScreens[0].Bounds.Width,
                Height = Screen.AllScreens[0].Bounds.Height
            };
            DialogResult dr = _frmCutter.ShowDialog();
        }

        internal void ReadImageResult()
        {
            //截取设置的区域屏幕图片
            Bitmap _screenShots = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g_screenShots = Graphics.FromImage(_screenShots);
            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            g_screenShots.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width,
            Screen.AllScreens[0].Bounds.Height));

            //剪切的图片
            _catchBmp = new Bitmap(Tools.CatchRectangleSize.Width, Tools.CatchRectangleSize.Height);
            Graphics g = Graphics.FromImage(_catchBmp);
            g.DrawImage(_screenShots, new Rectangle(0, 0, Tools.CatchRectangleSize.Width, Tools.CatchRectangleSize.Height),
            Tools.CatchRectangle, GraphicsUnit.Pixel);
            g.Dispose();
            g_screenShots.Dispose();

            //显示图像
            gbQuestion.Width = Tools.CatchRectangleSize.Width;
            gbQuestion.Height = Tools.CatchRectangleSize.Height;
            gbQuestion.BackgroundImage = _catchBmp;

            _catchBmp.Save(@"D:\output\cut.jpg");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cboGames.SelectedIndex = 0;
        }
    }
}
