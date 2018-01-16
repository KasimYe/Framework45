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
* filename:PayOrderDetail
* guid:1c11944d-a208-4277-af97-d7ddf589e1a9
* auth:lip86
* date:2018-01-08 21:28:18
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
    public class PayOrderDetail
    {
        /// <summary>
        /// 商品编号 1,int
        /// </summary>
        public int ProcurecatalogId { get; set; }
        /// <summary>
        /// 发票号,varchar(512)
        /// </summary>
        public string InvoiceId { get; set; }
        /// <summary>
        /// 收/退货日期,datetime
        /// </summary>
        public DateTime StorageDate { get; set; }
        /// <summary>
        /// 结算数量,int
        /// </summary>
        public int RealQuantity { get; set; }
        /// <summary>
        /// 结算金额（元）,decimal(18,3)
        /// </summary>
        public decimal RealAmount { get; set; }
        /// <summary>
        /// 收/退货标志 1.收货 2.（收货后）退货,tinyint(4)
        /// </summary>
        public int StorageTag { get; set; }
        /// <summary>
        /// "收/退货编号,decimal(18,3)收货时候为省平台配送明细编号;退货时,为省平台退货明细编号
        /// </summary>
        public decimal StorageId { get; set; }

    }
}
