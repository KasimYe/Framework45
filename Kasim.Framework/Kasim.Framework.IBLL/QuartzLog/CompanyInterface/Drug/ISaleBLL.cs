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
* filename:ISaleBLL
* guid:90f5b3d2-2268-4a0a-a1c5-ab28e5c12c0c
* auth:lip86
* date:2018-01-08 21:57:00
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
    public interface ISaleBLL
    {
        /// <summary>
        /// C019 销售清单上传 
        /// </summary>
        /// <param name="saleInfo">发票信息 JSON 格式；格式如下： 
        /// {
        ///     "list":[
        ///         {
        ///             "companyPrimaryKey":"企业主键 varchar(36)",
        ///             " invoiceCode ":"发票代码  varchar(12)。10位数或者12位数",
        ///             "invoiceID":"发票号码varchar(8) 8位数",
        ///             "goodsID":"产品ID int",
        ///             "batchCode":"批号 varchar(36) 统一发票内，批号+产品ID不能重复出现",
        ///             "periodDate":"有效期 (例如“20160430”或“201604”)",
        ///             "saleNumber ":"销售数量 int"
        ///         }
        ///     ]
        /// }
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Sale, Sale> AddSale(string saleInfo);
    }
}
