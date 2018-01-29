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
    public partial class FrmCutter : Form
    {
        private bool _catchStart;
        private bool _catchFinished;
        private Point _downPoint;
        private Rectangle _catchRectangle;

        public FrmCutter()
        {
            InitializeComponent();
        }

        private void FrmCutter_Load(object sender, EventArgs e)
        {

        }

        //点击鼠标右键时，取消设置
        private void FrmCutter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //点击鼠标左键时，开始画区域图
        private void FrmCutter_MouseDown(object sender, MouseEventArgs e)
        {
            // 鼠标左键按下是开始画图，也就是截图
            if (e.Button == MouseButtons.Left)
            {
                // 如果捕捉没有开始
                if (!_catchStart && !_catchFinished)
                {
                    _catchStart = true;

                    // 保存此时鼠标按下坐标
                    Point newPoint = new Point(e.X, e.Y);

                    _downPoint = newPoint;

                    Tools.StartPoint = newPoint;
                }
            }
        }

        //鼠标移动时，根据移动的鼠标和点击时的第一个点，绘制矩形
        private void FrmCutter_MouseMove(object sender, MouseEventArgs e)
        {
            #region 确保截图开始
            if (_catchStart && !_catchFinished)
            {
                // 新建一个图片对象，让它与屏幕图片相同
                Bitmap copyBmp = (Bitmap)Tools.ScreenShots.Clone();

                // 获取鼠标按下的坐标
                Point newPoint = new Point(_downPoint.X, _downPoint.Y);

                // 新建画板和画笔
                Graphics g = Graphics.FromImage(copyBmp);
                Pen p = new Pen(Color.Red, 1);

                // 获取矩形的长宽
                int width = Math.Abs(e.X - _downPoint.X);
                int height = Math.Abs(e.Y - _downPoint.Y);
                if (e.X < _downPoint.X)
                {
                    newPoint.X = e.X;
                }
                if (e.Y < _downPoint.Y)
                {
                    newPoint.Y = e.Y;
                }

                _catchRectangle = new Rectangle(newPoint, new Size(width, height));

                Tools.CatchRectangle = new Rectangle(newPoint, new Size(width, height));
                Tools.CatchRectangleSize = new Size(width, height);


                // 将矩形画在画板上
                g.DrawRectangle(p, _catchRectangle);

                // 释放目前的画板
                g.Dispose();
                p.Dispose();
                // 从当前窗体创建新的画板
                Graphics g1 = this.CreateGraphics();

                // 将刚才所画的图片画到截图窗体上
                // 为什么不直接在当前窗体画图呢？
                // 如果自己解决将矩形画在窗体上，会造成图片抖动并且有无数个矩形
                // 这样实现也属于二次缓冲技术
                g1.DrawImage(copyBmp, new Point(0, 0));
                g1.Dispose();
                // 释放拷贝图片，防止内存被大量消耗
                copyBmp.Dispose();
            }
            #endregion
        }

        //鼠标点击后，弹起来时，完成矩形的绘制
        private void FrmCutter_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 如果截图已经开始，鼠标左键弹起设置截图完成
                if (_catchStart)
                {
                    Tools.EndPoint = new Point(e.X, e.Y);

                    _catchStart = false;
                    _catchFinished = true;
                }
            }
        }

        //双击，确定当前选择的设置
        private void FrmCutter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _catchFinished)
            {
                if (this.Tag != null)
                {
                    FrmMain _frmMain = (FrmMain)this.Tag;
                    if (_frmMain != null)
                    {
                        //_frmMain.btnRead.Focus();
                        _frmMain.ReadImageResult();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
