/**
 *                             _ooOoo_
 *                            o8888888o
 *                            88" . "88
 *                            (| -_- |)
 *                            O\  =  /O
 *                         ____/`---'\____
 *                       .'  \\|     |//  `.
 *                      /  \\|||  :  |||//  \
 *                     /  _||||| -:- |||||-  \
 *                     |   | \\\  -  /// |   |
 *                     | \_|  ''\---/''  |   |
 *                     \  .-\__  `-`  ___/-. /
 *                   ___`. .'  /--.--\  `. . __
 *                ."" '<  `.___\_<|>_/___.'  >'"".
 *               | | :  `- \`.;`\ _ /`;.`/ - ` : | |
 *               \  \ `-.   \_ __\ /__ _/   .-` /  /
 *          ======`-.____`-.___\_____/___.-`____.-'======
 *                             `=---='
 *          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
 *                     佛祖保佑        永无BUG
 *            佛曰:
 *                   写字楼里写字间，写字间里程序员；
 *                   程序人员写程序，又拿程序换酒钱。
 *                   酒醒只在网上坐，酒醉还来网下眠；
 *                   酒醉酒醒日复日，网上网下年复年。
 *                   但愿老死电脑间，不愿鞠躬老板前；
 *                   奔驰宝马贵者趣，公交自行程序员。
 *                   别人笑我忒疯癫，我笑自己命太贱；
 *                   不见满街漂亮妹，哪个归得程序员？
*/
/*----------------------------------------------------------------
** Copyright (C) 2017 
**
** file：Dgv
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-09 11:29:57
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasim.Framework.Common
{
    public class Dgv
    {
        public enum DgvAlign
        {
            N = DataGridViewContentAlignment.NotSet,
            BL = DataGridViewContentAlignment.BottomLeft,
            BC = DataGridViewContentAlignment.BottomCenter,
            BR = DataGridViewContentAlignment.BottomRight,
            MC = DataGridViewContentAlignment.MiddleCenter,
            ML = DataGridViewContentAlignment.MiddleLeft,
            MR = DataGridViewContentAlignment.MiddleRight,
            TC = DataGridViewContentAlignment.TopCenter,
            TL = DataGridViewContentAlignment.TopLeft,
            TR = DataGridViewContentAlignment.TopRight
        }

        static public void SetDefaultStyle(DataGridView _Dgv, bool _AllowAdd = false, bool _AllowDel = false,
            bool _ReadOnly = true, DataGridViewSelectionMode _SelectModel = DataGridViewSelectionMode.FullRowSelect)
        {
            _Dgv.AllowUserToAddRows = _AllowAdd;
            _Dgv.AllowUserToDeleteRows = _AllowDel;
            _Dgv.AutoGenerateColumns = false;
            _Dgv.ReadOnly = _ReadOnly;
            _Dgv.RowHeadersWidth = 15;
            _Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            _Dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _Dgv.SelectionMode = _SelectModel;
            _Dgv.Columns.Clear();
        }

        static public DataGridViewTextBoxColumn AddDgvTextBox(string _DataPropertyName, string _HeaderText, int _Width, bool _Visible = true, string _Format = "", 
            bool _ReadOnly = false, DgvAlign _Alignment = DgvAlign.N, DataGridViewColumnSortMode _Sort = DataGridViewColumnSortMode.Automatic, 
            DataGridViewAutoSizeColumnMode _AutoSizeMode=DataGridViewAutoSizeColumnMode.NotSet, string _Name = "")
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = (_Name == "" ? _DataPropertyName : _Name),
                DataPropertyName = _DataPropertyName,
                HeaderText = _HeaderText,
                DefaultCellStyle = {
                    Alignment = (DataGridViewContentAlignment)_Alignment,
                    Format=_Format
                },
                ReadOnly = _ReadOnly,
                Visible = _Visible,
                SortMode = _Sort,
                AutoSizeMode= _AutoSizeMode,
                Width= _Width
            };         
            return col;
        }

        static public DataGridViewLinkColumn AddDgvLink(string _DataPropertyName, string _HeaderText, int _Width, bool _Visible = true, string _Format = "",
            bool _ReadOnly = false, DgvAlign _Alignment = DgvAlign.N, DataGridViewColumnSortMode _Sort = DataGridViewColumnSortMode.Automatic,
            DataGridViewAutoSizeColumnMode _AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, string _Name = "")
        {
            var col = new DataGridViewLinkColumn
            {
                Name = (_Name == "" ? _DataPropertyName : _Name),
                DataPropertyName = _DataPropertyName,
                HeaderText = _HeaderText,
                DefaultCellStyle = {
                    Alignment = (DataGridViewContentAlignment)_Alignment,
                    Format=_Format
                },
                ReadOnly = _ReadOnly,
                Visible = _Visible,
                SortMode = _Sort,
                AutoSizeMode = _AutoSizeMode,
                Width = _Width
            };
            return col;
        }

        static public DataGridViewCheckBoxColumn AddDgvCheckBox(string _DataPropertyName, string _HeaderText, int _Width, bool _Visible = true,
            bool _ReadOnly = false, DgvAlign _Alignment = DgvAlign.N, DataGridViewColumnSortMode _Sort = DataGridViewColumnSortMode.Automatic,
            DataGridViewAutoSizeColumnMode _AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, string _Name = "")
        {
            var col = new DataGridViewCheckBoxColumn
            {
                Name = (_Name == "" ? _DataPropertyName : _Name),
                DataPropertyName = _DataPropertyName,
                HeaderText = _HeaderText,
                DefaultCellStyle = {
                    Alignment = (DataGridViewContentAlignment)_Alignment
                },
                ReadOnly = _ReadOnly,
                Visible = _Visible,
                SortMode = _Sort,
                AutoSizeMode = _AutoSizeMode,
                Width = _Width,
                ThreeState = false
            };
            return col;
        }

        static public DataGridViewButtonColumn AddDgvButton(string _DataPropertyName, string _HeaderText, int _Width, bool _Visible = true, string _Format = "",
            bool _ReadOnly = false, DgvAlign _Alignment = DgvAlign.N, DataGridViewColumnSortMode _Sort = DataGridViewColumnSortMode.Automatic,
            DataGridViewAutoSizeColumnMode _AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, string _Name = "")
        {
            var col = new DataGridViewButtonColumn
            {
                Name = (_Name == "" ? _DataPropertyName : _Name),
                DataPropertyName = _DataPropertyName,
                HeaderText = _HeaderText,
                DefaultCellStyle = {
                    Alignment = (DataGridViewContentAlignment)_Alignment,
                    Format=_Format
                },
                ReadOnly = _ReadOnly,
                Visible = _Visible,
                SortMode = _Sort,
                AutoSizeMode = _AutoSizeMode,
                Width = _Width
            };
            return col;
        }

        static public DataGridViewComboBoxColumn AddDgvComboBox(object _DataSource,string _ValueMember,string _DisplayMember, string _DataPropertyName, string _HeaderText, int _Width, bool _Visible = true,
            bool _ReadOnly = false, DgvAlign _Alignment = DgvAlign.N, DataGridViewColumnSortMode _Sort = DataGridViewColumnSortMode.Automatic,
            DataGridViewAutoSizeColumnMode _AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet, string _Name = "")
        {
            var col = new DataGridViewComboBoxColumn
            {
                DataSource = _DataSource,
                ValueMember = _ValueMember,
                DisplayMember = _DisplayMember,
                Name = (_Name == "" ? _DataPropertyName : _Name),
                DataPropertyName = _DataPropertyName,
                HeaderText = _HeaderText,
                DefaultCellStyle = {
                    Alignment = (DataGridViewContentAlignment)_Alignment                    
                },
                ReadOnly = _ReadOnly,
                Visible = _Visible,
                SortMode = _Sort,
                AutoSizeMode = _AutoSizeMode,
                Width = _Width
            };
            return col;
        }
    }
}
