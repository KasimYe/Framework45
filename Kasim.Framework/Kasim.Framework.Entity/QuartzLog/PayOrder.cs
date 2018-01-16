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
* filename:PayOrder
* guid:f30644f8-1957-4a5c-848e-1c2936cda08d
* auth:lip86
* date:2018-01-08 21:09:57
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
    public class PayOrder
    {
        /// <summary>
        /// 支付编号 1,nvarchar(36)
        /// </summary>
        public string PayOrderCode { get; set; }
        /// <summary>
        /// 付款机构,varchar(255)
        /// </summary>
        public string PayOrgName { get; set; }
        /// <summary>
        /// 结算总金额, decimal(10,3)
        /// </summary>
        public decimal PayOrderAmount { get; set; }
        /// <summary>
        /// 支付状态：int -1 未支付,-2 废止,0 未付款,1 正在付款给药械,2 付款给药械成功,3 付款给药械失败,4 正在扣款,5 扣款失败,
        /// 6 正在贷款,7 贷款失败,8 正在付款给收款人,9 付款给收款人成功,10 付款给收款人失败,20 收款人确认收款,21 已作废,22 已撤销
        /// </summary>
        public int PayStatus { get; set; }
        /// <summary>
        /// 申请时间,datetimet
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 提交时间,datetimet
        /// </summary>
        public DateTime? SubmitTime { get; set; }
        /// <summary>
        /// 审核时间,datetime
        /// </summary>
        public DateTime? AuditTime { get; set; }
        /// <summary>
        /// 支付时间,datetimet
        /// </summary>
        public DateTime? SynchrobankTime { get; set; }
        /// <summary>
        /// 付款给药械时间,datetimet
        /// </summary>
        public DateTime? PayingCenterTime { get; set; }
        /// <summary>
        /// 付款给药械成功时间,datetimet
        /// </summary>
        public DateTime? PayedCenterTime { get; set; }
        /// <summary>
        /// 付款给收款人时间, datetimet
        /// </summary>
        public DateTime? PayingCompanyTime { get; set; }
        /// <summary>
        /// 付款给收款人成功时间,datetimet
        /// </summary>
        public DateTime? PayedCompanyTime { get; set; }

    }
}
