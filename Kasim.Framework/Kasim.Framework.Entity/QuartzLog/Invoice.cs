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
* filename:Invoice
* guid:fa083adc-e186-4836-9666-cf4687b8e73c
* auth:lip86
* date:2018-01-08 21:36:19
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
    public class Invoice
    {
        /// <summary>
        /// 企业主键 varchar(36)
        /// </summary>
        public string CompanyPrimaryKey { get; set; }
        /// <summary>
        /// 发票代码 varchar(8) 8 位数
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号码 varchar(12)。10 位数或者 12 位数
        /// </summary>
        public string InvoiceID { get; set; }
        /// <summary>
        /// 开票日期 日期型，(例如“20160430”)
        /// </summary>
        public string InvoiceDate { get; set; }
        /// <summary>
        /// 发票类型(1:第一票， 3：中间票） int
        /// </summary>
        public int InvoceType { get; set; }
        /// <summary>
        /// 销售方 ID【平台内的企业编号】 varchar(36)
        /// </summary>
        public string SaleID { get; set; }
        /// <summary>
        /// 销售方备注 varchar(36)
        /// </summary>
        public string SaleRemark { get; set; }
        /// <summary>
        /// 购买方 ID【平台内的企业编号】 varchar(36)
        /// </summary>
        public string BuyID { get; set; }
        /// <summary>
        /// 购买方备注 varchar(36)
        /// </summary>
        public string BuyRemarks { get; set; }
        /// <summary>
        /// 发票扫描件地址（企业自行提供）varchar(72)
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 发票扫描件的 MD5 值，可参照程序示例 5.3 、5.4varchar(36)
        /// </summary>
        public string PicMD5 { get; set; }
        /// <summary>
        /// 中心返回发票编号
        /// </summary>
        public string Id { get; set; }
    }
}
