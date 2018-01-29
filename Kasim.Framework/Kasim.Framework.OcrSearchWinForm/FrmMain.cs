using Kasim.Framework.BLL.OcrSearch;
using Kasim.Framework.Entity.OcrSearch;
using Kasim.Framework.IBLL.OcrSearch;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Kasim.Framework.OcrSearchWinForm
{
    public partial class FrmMain : Form
    {
        private Bitmap _catchBmp;
        private List<CutPic> _cutPics = new List<CutPic>();
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
            try
            {
                GetImage();
                var json = baiduAi.GeneralBasic(_catchBmp);
                var quest = question.GetQuestion(json);
                //var result =string.Format("问题：{0}\r\n\r\n答案一：{1}\r\n答案二：{2}\r\n答案三：{3}",
                //    quest.Question,quest.Answer1,quest.Answer2,quest.Answer3);
                rtxtQuestion.Text = quest.Question;
                rtxtAnswer1.Text = quest.Answer1;
                rtxtAnswer2.Text = quest.Answer2;
                rtxtAnswer3.Text = quest.Answer3;
                GetSearch();
            }
            catch (Exception ex)
            {
                rtxtQuestion.Text = ex.Message;
            }
        }

        private void GetSearch()
        {
            int a1, a2, a3;
            a1 = question.GetSearchCount(string.Format("{0} {1}", rtxtQuestion.Text, rtxtAnswer1.Text));
            a2 = question.GetSearchCount(string.Format("{0} {1}", rtxtQuestion.Text, rtxtAnswer2.Text));
            a3 = question.GetSearchCount(string.Format("{0} {1}", rtxtQuestion.Text, rtxtAnswer3.Text));
            lblAnswer1.Text = a1.ToString();
            lblAnswer2.Text = a2.ToString();
            lblAnswer3.Text = a3.ToString();
            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                { "答案一", a1 },
                { "答案二", a2 },
                { "答案三", a3 }
            };
            var dicSort = from objDic in dic orderby objDic.Value descending select objDic;
            var strResult = "";
            foreach (KeyValuePair<string, int> kvp in dicSort)
            {
                strResult += string.Format("{0} > ", kvp.Key);
            }
            lblResult.Text = strResult.Remove(strResult.LastIndexOf(">"), 2);
        }

        private void GetImage()
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
        }

        IBaiduAiBLL baiduAi = new BaiduAiBLL();
        IQuestionBLL question = new QuestionBLL();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TopMost = true;
            cboGames.SelectedIndex = 0;
            //rtxtQuestion.Text = question.GetSearchCount("“在天愿作比翼鸟 在地愿为连理枝”,描述的是谁和谁的爱情故事事? 李隆基和杨玉环").ToString();
        }


        private void Submit(int qLine)
        {
            var list = _cutPics.Where(x => x.Game == cboGames.Text && x.QuestLine == qLine).ToList();
            if (list != null && list.Count > 0)
            {
                if (Tools.Saved)
                {
                    list[0].StartPoint = Tools.StartPoint;
                    list[0].EndPoint = Tools.EndPoint;
                    list[0].CatchRectangleSize = Tools.CatchRectangleSize;
                    list[0].CatchRectangle = Tools.CatchRectangle;
                    list[0].ScreenShots = Tools.ScreenShots;
                    Tools.Saved = false;
                }
                else
                {
                    Tools.StartPoint = list[0].StartPoint;
                    Tools.EndPoint = list[0].EndPoint;
                    Tools.CatchRectangleSize = list[0].CatchRectangleSize;
                    Tools.CatchRectangle = list[0].CatchRectangle;
                    Tools.ScreenShots = list[0].ScreenShots;
                }
            }
            else
            {
                _cutPics.Add(new CutPic
                {
                    Game = cboGames.Text,
                    QuestLine = qLine,
                    StartPoint = Tools.StartPoint,
                    EndPoint = Tools.EndPoint,
                    CatchRectangleSize = Tools.CatchRectangleSize,
                    CatchRectangle = Tools.CatchRectangle,
                    ScreenShots = Tools.ScreenShots
                });
                Tools.Saved = false;
            }
            ReadImageResult();
        }
        private void BtnSubmit1_Click(object sender, EventArgs e)
        {
            Submit(1);
        }

        private void BtnSubmit2_Click(object sender, EventArgs e)
        {
            Submit(2);
        }

        private void BtnSubmit3_Click(object sender, EventArgs e)
        {
            Submit(3);
        }
    }
}
