/*
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)                  

* Filename: Cgd
* Namespace: Kasim.Framework.Common
* Classname: Cgd
* Created: 2018-03-15 19:38:46
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using C1.C1Excel;
using C1.Win.C1TrueDBGrid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.Common
{
    public class Cgd
    {
        static public void SetDefaultStyle(C1TrueDBGrid _Dgd, object _DataSource, bool _AllowAddNew = true, bool _AllowDelete = true, bool _AllowUpdate = true,
            bool _AllowRowSelect = true, bool _AllowSort = true, bool _AllowColMove = false, bool _ClearColumns = false, bool _ColumnFooters = false,
            string _Caption = "", bool _FetchRowStyles = false)
        {
            _Dgd.DataSource = _DataSource;
            _Dgd.AllowAddNew = _AllowAddNew;
            _Dgd.AllowDelete = _AllowDelete;
            _Dgd.AllowRowSelect = _AllowRowSelect;
            _Dgd.AllowUpdate = _AllowUpdate;
            _Dgd.AllowSort = _AllowSort;
            _Dgd.AllowColMove = _AllowColMove;
            _Dgd.ColumnFooters = _ColumnFooters;
            _Dgd.FetchRowStyles = _FetchRowStyles;

            _Dgd.VisualStyle = VisualStyle.Office2010Blue;
            _Dgd.BackColor = SystemColors.Window;
            var S = new Style()
            {
                ForeColor = SystemColors.Window,
                Font = new Font("微软雅黑", (float)9.25, FontStyle.Bold)
            };
            S.Borders.BorderType = BorderTypeEnum.Raised;
            S.Borders.Bottom = 2;
            S.Borders.Top = 2;
            S.Borders.Left = 2;
            S.Borders.Right = 2;
            S.Borders.Color = SystemColors.ActiveBorder;
            _Dgd.AddCellStyle(CellStyleFlag.CurrentCell, S);

            _Dgd.WrapCellPointer = true;
            _Dgd.RowHeight = 25;

            _Dgd.Caption = _Caption;
            _Dgd.CaptionHeight = 20;
            _Dgd.CaptionStyle.ForeColor = SystemColors.HotTrack;
            _Dgd.CaptionStyle.Font = new Font("楷体", 12, FontStyle.Bold);

            if (_ClearColumns)
                _Dgd.Columns.Clear();
            else
                AddEndingStyle(_Dgd);

            _Dgd.RowColChange += new RowColChangeEventHandler(_Dgd_RowColChange);
        }

        private static void _Dgd_RowColChange(object sender, RowColChangeEventArgs e)
        {
            C1TrueDBGrid _Dgd = (C1TrueDBGrid)sender;
            _Dgd.MarqueeStyle = MarqueeEnum.HighlightRow;
        }

        static public void SetColumn(C1TrueDBGrid _Dgd, string _DataField, string _Caption, int _Width = -1, int _Index = -1, string _NumberFormat = "",
            AlignHorzEnum _HorizontalAlignment = AlignHorzEnum.Near, bool _Visible = true, PresentationEnum _Presentation = PresentationEnum.Normal, bool _Button = false, bool _Locked = false)
        {
            int i;
            C1DataColumn column;
            if (_Index == -1)
            {
                i = _Dgd.Columns.Count;
                column = new C1DataColumn();
                _Dgd.Columns.Insert(i, column);
            }
            else
            {
                i = _Index;
                column = _Dgd.Columns[_Index];
            }
            column.DataField = _DataField;
            column.Caption = _Caption;

            if (!string.IsNullOrEmpty(_NumberFormat)) column.NumberFormat = _NumberFormat;

            var displayColumn = _Dgd.Splits[0].DisplayColumns[i];
            if (_Width == -1)
                displayColumn.AutoSize();
            else
                displayColumn.Width = _Width;

            displayColumn.Style.HorizontalAlignment = _HorizontalAlignment;
            displayColumn.Visible = _Visible;
            displayColumn.Locked = _Locked;
            if (_Button)
            {
                displayColumn.Button = true;
                displayColumn.ButtonText = true;
                displayColumn.ButtonAlways = true;
                displayColumn.ButtonFooter = true;
                displayColumn.ButtonHeader = true;
            }
            if (_Presentation == PresentationEnum.CheckBox)
            {
                displayColumn.Style.HorizontalAlignment = AlignHorzEnum.Center;
                column.ValueItems.Presentation = PresentationEnum.CheckBox;
                column.ValueItems.Translate = true;
                column.ValueItems.CycleOnClick = true;
            }
        }

        static public void SumFooter(C1TrueDBGrid _Dgd, string[] _ColumnsName)
        {
            var rows = _Dgd.Splits[0].Rows.Count;
            var sumArr = new decimal[_ColumnsName.Length];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < _ColumnsName.Length; j++)
                {
                    sumArr[j] += Convert.ToDecimal(_Dgd[i, _ColumnsName[j]]);
                }
            }
            for (int j = 0; j < _ColumnsName.Length; j++)
            {
                _Dgd.Columns[_ColumnsName[j]].FooterText = sumArr[j].ToString("0.####");
            }
        }

        static public void AddEndingStyle(C1TrueDBGrid _Dgd)
        {
            for (int i = 0; i < _Dgd.Columns.Count; i++)
            {
                var headingStyle = _Dgd.Splits[0].DisplayColumns[i].HeadingStyle;
                headingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                headingStyle.VerticalAlignment = AlignVertEnum.Center;
                headingStyle.ForeColor = SystemColors.HighlightText;
                headingStyle.BackColor = SystemColors.ActiveCaption;
                headingStyle.BackColor2 = SystemColors.MenuHighlight;
                headingStyle.Trimming = StringTrimming.Character;
                headingStyle.GradientMode = GradientModeEnum.BackwardDiagonal;
                headingStyle.Font = new Font("微软雅黑", (float)10.5, FontStyle.Regular);

                if (_Dgd.ColumnFooters)
                {
                    var footerStyle = _Dgd.Splits[0].DisplayColumns[i].FooterStyle;
                    footerStyle.HorizontalAlignment = AlignHorzEnum.Far;
                    footerStyle.VerticalAlignment = AlignVertEnum.Center;
                    footerStyle.ForeColor = SystemColors.WindowText;
                    footerStyle.BackColor = SystemColors.MenuHighlight;
                    footerStyle.BackColor2 = SystemColors.ActiveCaption;
                    footerStyle.Trimming = StringTrimming.Character;
                    footerStyle.GradientMode = GradientModeEnum.BackwardDiagonal;
                    footerStyle.Font = new Font("微软雅黑", (float)9.75, FontStyle.Bold);
                }

                var style = _Dgd.Splits[0].DisplayColumns[i].Style;
                style.VerticalAlignment = AlignVertEnum.Center;
                style.Font = new Font("微软雅黑", (float)9.25, FontStyle.Regular);
            }
        }

        static public void ToExcel(C1TrueDBGrid _Dgd)
        {
            if (_Dgd.RowCount == 0) return;
            string filename = "";
            var book = new C1XLBook();
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "*.xls|*.xls",
                    FileName = "DgdExcel.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    var sheet = book.Sheets[0];
                    sheet.Name = "Page1";
                    XLStyle style = new XLStyle(book);
                    DateTimeFormatInfo dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
                    style.Format = XLStyle.FormatDotNetToXL(dtfi.ShortDatePattern);
                    var k = 0;
                    for (int i = 0; i < _Dgd.Columns.Count; i++)
                    {
                        if (_Dgd.Splits[0].DisplayColumns[i] == null) break;
                        if (_Dgd.Splits[0].DisplayColumns[i].Visible)
                        {
                            sheet[0, k].Value = _Dgd.Columns[i].Caption;
                            k++;
                        }
                    }
                    for (int i = 0; i < _Dgd.RowCount; i++)
                    {
                        k = 0;
                        for (int j = 0; j < _Dgd.Columns.Count; j++)
                        {
                            if (_Dgd.Splits[0].DisplayColumns[j] == null) break;
                            if (_Dgd.Splits[0].DisplayColumns[j].Visible)
                            {
                                var obj = _Dgd[i, j];
                                if (obj != null)
                                {
                                    if (obj.GetType() == typeof(DateTime))
                                    {
                                        sheet[i + 1, k].Style = style;
                                    }
                                    sheet[i + 1, k].Value = _Dgd[i, j];
                                }
                                else
                                {
                                    sheet[i + 1, k].Value = "";
                                }
                                k++;
                            }
                        }
                    }
                    book.Save(filename);
                }
            }
            catch (Exception ex)
            {
                MBox.ShowErr(ex.Message);
                return;
            }
            finally
            {
                book.Dispose();
            }
            if (MBox.ShowAsk(string.Format("数据导出成功。保存路径：{0}\r\n是否打开？", filename)))
                System.Diagnostics.Process.Start(filename);
        }
    }
}
