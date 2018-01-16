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
* filename:Return
* guid:7d8d88d3-7d56-4d0f-87e2-9ed968e4f704
* auth:lip86
* date:2018-01-08 20:50:11
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
    public class Return
    {
        /// <summary>
        /// 退货明细编号 1,varchar(36)
        /// </summary>
        public string ReturnId { get; set; }
        /// <summary>
        /// 退货时间,datetime
        /// </summary>
        public object ReturnTime { get; set; }
        /// <summary>
        /// 配送明细编号,varchar(36)
        /// </summary>
        public string DistributeId { get; set; }
        /// <summary>
        /// 退货数量,int
        /// </summary>
        public int ReturnCount { get; set; }
        /// <summary>
        /// 退货类型,tinyint，为现场退货(0)为入库后退(1)
        /// </summary>
        public int ReturnType { get; set; }
        /// <summary>
        /// 退货理由,varchar(1024)
        /// </summary>
        public string ReturnReason { get; set; }
        /// <summary>
        /// 自定义退货信息,varchar(1024)
        /// </summary>
        public string ReturnCustomInfo { get; set; }
        /// <summary>
        /// 响应状态,必填，tinyint，已确认待维护退货发票(1)、已确认且已维护退货发票(2)、拒绝退货(3)
        /// </summary>
        public int IsResponse { get; set; }
        /// <summary>
        /// 拒绝原因,isResponse 为 3 时必填，varchar(500)
        /// </summary>
        public string RefuseReason { get; set; }
        /// <summary>
        /// 退货发票号,isResponse 为 2 时必填，varchar(36)
        /// </summary>
        public string ReturnInvoiceId { get; set; }


    }
}
