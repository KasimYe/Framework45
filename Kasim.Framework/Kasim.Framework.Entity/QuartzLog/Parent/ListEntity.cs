/*********************************************************************
 **                             _ooOoo_                             **
 **                            o8888888o                            **
 **                            88" . "88                            **
 **                            (| -_- |)                            **
 **                            O\  =  /O                            **
 **                         ____/`---'\____                         **
 **                       .'  \\|     |//  `.                       **
 **                      /  \\|||  :  |||//  \                      **
 **                     /  _||||| -:- |||||-  \                     **
 **                     |   | \\\  -  /// |   |                     **
 **                     | \_|  ''\---/''  |   |                     **
 **                     \  .-\__  `-`  ___/-. /                     **
 **                   ___`. .'  /--.--\  `. . __                    **
 **                ."" '<  `.___\_<|>_/___.'  >'"".                 **
 **               | | :  `- \`.;`\ _ /`;.`/ - ` : | |               **
 **               \  \ `-.   \_ __\ /__ _/   .-` /  /               **
 **          ======`-.____`-.___\_____/___.-`____.-'======          **
 **                             `=---='                             **
 **          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^          **
 **                     佛祖保佑        永无BUG                     **
 **            佛曰:                                                **
 **                   写字楼里写字间，写字间里程序员；              **
 **                   程序人员写程序，又拿程序换酒钱。              **
 **                   酒醒只在网上坐，酒醉还来网下眠；              **
 **                   酒醉酒醒日复日，网上网下年复年。              **
 **                   但愿老死电脑间，不愿鞠躬老板前；              **
 **                   奔驰宝马贵者趣，公交自行程序员。              **
 **                   别人笑我忒疯癫，我笑自己命太贱；              **
 **                   不见满街漂亮妹，哪个归得程序员？              **
 *********************************************************************/
/*=====================================================================
* Copyright (c) 2018 All Rights Reserved.
* CLRVer.:4.0.30319.42000
* machinenameDESKTOP-U288O1H
* namespace:Kasim.Framework.Entity.QuartzLog
* filename:ListEntity
* guid:e28cbab4-9b24-4b2e-a074-19b9ddce7b96
* auth:lip86
* date:2018-01-03 18:59:55
* desc:
*
*=====================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.QuartzLog
{
    public class ListEntity<T> where T : class
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ReturnEnum ReturnCode { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string ReturnMsg { get; set; }
        
        /// <summary>
        /// 总页数
        /// </summary>
        public int? TotalPageCount { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int? TotalRecordCount { get; set; }
        /// <summary>
        /// 当前页码,为对应的参数值，无论结果返回是否有值。
        /// 例如，当前获取第一页结果返回为空，则 currentPageNumber 返回为 1
        /// </summary>
        public int? CurrentPageNumber { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> DataList { get; set; }
        /// <summary>
        /// 结果集合
        /// </summary>
        public List<T> ResultList { get; set; }
    }
}
