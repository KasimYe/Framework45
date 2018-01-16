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
* filename:Sale
* guid:e1e3880b-c656-40fe-af3f-8597a996d3a0
* auth:lip86
* date:2018-01-08 21:59:13
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
    public class Sale
    {
        /// <summary>
        /// 企业主键 varchar(36)
        /// </summary>
        public string CompanyPrimaryKey { get; set; }
        /// <summary>
        /// 发票代码  varchar(8) 8 位数
        /// </summary>
        public string InvoiceCode{ get; set; }
        /// <summary>
        /// 发票号码 varchar(12)。10 位数或者 12 位数
        /// </summary>
        public string InvoiceID { get; set; }
        /// <summary>
        /// 产品 ID int
        /// </summary>
        public int GoodsID { get; set; }
        /// <summary>
        /// 批号 varchar(36) 统一发票内，批号+产品 ID 不能重复出现
        /// </summary>
        public string BatchCode { get; set; }
        /// <summary>
        /// 有效期 (例如“20160430”或“201604”)
        /// </summary>
        public string PeriodDate { get; set; }
        /// <summary>
        /// 销售数量 int
        /// </summary>
        public int SaleNumber{ get; set; }
    }
}
