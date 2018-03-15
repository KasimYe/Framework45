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
* namespace:Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug
* filename:IInvoiceBLL
* guid:f4dc8684-a857-4acb-a17d-6ff6c54b1c90
* auth:lip86
* date:2018-01-08 21:43:20
* desc:
*
*=====================================================================*/
using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug
{
    public interface IInvoiceBLL
    {
        /// <summary>
        /// C018 票据上传 
        /// </summary>
        /// <param name="invoiceInfo">发票信息 JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "companyPrimaryKey":"企业主键 varchar(36)",
        ///             "invoiceCode":"发票代码 varchar(8) 8 位数",
        ///             "invoiceID":"发票号码 varchar(12)。10 位数或者 12 位数",
        ///             "invoiceDate":"开票日期 日期型，(例如“20160430”)",
        ///             "invoceType":"发票类型(1:第一票， 3：中间票） int",
        ///             "saleID":"销售方 ID【平台内的企业编号】 varchar(36)",
        ///             "saleRemark":"销售方备注 varchar(36)",
        ///             "buyID":"购买方 ID【平台内的企业编号】 varchar(36)",
        ///             "buyRemarks":"购买方备注 varchar(36)"， 
        ///             "picUrl":"发票扫描件地址（企业自行提供）varchar(72)"， 
        ///             "picMD5":"发票扫描件的 MD5 值，可参照程序示例 5.3 、5.4varchar(36)" 
        ///         } 
        ///     ] 
        /// }
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Invoice, Invoice> SubmitInvoice(string invoiceInfo);
        /// <summary>
        /// 回写采购中心发票ID
        /// </summary>
        /// <param name="companyPrimaryKey">企业发票主键</param>
        /// <param name="id">中心发票编号</param>
        /// <returns></returns>
        int WriteBackInvoiceId(string companyPrimaryKey, string id);
    }
}
