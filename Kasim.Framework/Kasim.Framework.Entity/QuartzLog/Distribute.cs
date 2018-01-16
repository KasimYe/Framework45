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
** file：Distribute
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-07 12:44:33
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Entity.QuartzLog
{
    public class Distribute
    {
        /// <summary>
        /// 企业配送明细编号 1,必填(唯一)， varchar(36)
        /// </summary>
        public string CompanyDistributeId { get; set; }
        /// <summary>
        /// 订单明细编号,必填， varchar(36)
        /// </summary>
        public string OrderDetailId { get; set; }
        /// <summary>
        /// 配送数量,必填，int； 配送数量大于 0 且总配送数量不大于采购数量
        /// </summary>
        public int DistributeCount { get; set; }
        /// <summary>
        /// 发票号,必填，varchar(36)
        /// </summary>
        public string InvoiceId { get; set; }
        /// <summary>
        /// 批号,必填，varchar(36)；一个订单明细可多批号配送
        /// </summary>
        public string BatchCode { get; set; }
        /// <summary>
        /// 有效期,必填，varchar(36)，(例如“20160430”或“201604”)
        /// </summary>
        public string PeriodDate { get; set; }
        /// <summary>
        /// 自定义配送信息,可填，varchar(500)
        /// </summary>
        public string DistributeCustomInfo { get; set; }
        /// <summary>
        /// 第一票编号【取平台反馈的编号，C018 的 ID】 varchar(36)
        /// </summary>
        public string FirstInviceID { get; set; }
        /// <summary>
        /// 中间票编号【取平台反馈的编号，C018 的 ID】 varchar(36)
        /// </summary>
        public string MiddleInviceID { get; set; }
        /// <summary>
        /// 第二票发票代码 varchar(12)。10 位数或者 12 位数
        /// </summary>
        public string SecondInviceCode { get; set; }
        /// <summary>
        /// 中心配送明细编号,varchar(36)
        /// </summary>
        public string DistributeId { get; set; }
        public Order Order { get; set; }


    }
}
