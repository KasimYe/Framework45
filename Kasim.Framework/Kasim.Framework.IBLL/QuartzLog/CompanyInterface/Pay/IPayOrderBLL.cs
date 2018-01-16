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
* namespace:Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Pay
* filename:IPayOrderBLL
* guid:5c6a5b00-5dea-4d17-b99f-087d9070f1cd
* auth:lip86
* date:2018-01-08 21:17:50
* desc:
*
*=====================================================================*/
using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Pay
{
    public interface IPayOrderBLL
    {
        /// <summary>
        /// C016 获取支付订单 
        /// </summary>
        /// <param name="startTime">开始时间 “yyyy-MM-dd hh:mm:ss” //药械平台支付订单提交时间 </param>
        /// <param name="endTime">结束时间 “yyyy-MM-dd hh:mm:ss” //药械平台支付订单提交时间 </param>
        /// <param name="payOrderCodes">支付单号 可获取获取指定支付单编号的变更信息。JSON 格式；格式如下：  
        /// { 
        ///     "list":[
        ///         { 
        ///              "payOrderCode":" 支付单号 1, 必填，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "payOrderCode":"支付单号 2,必填，varchar(36)" 
        ///         } 
        ///     ] 
        /// }
        /// </param>
        /// <param name="currentPageNumber">当前页码 获取指定页码的数据，例如“1”、“2”、“3”等</param>
        /// <returns></returns>
        ListEntity<PayOrder> GetPayOrders(DateTime startTime, DateTime endTime,string payOrderCodes, string currentPageNumber);
        /// <summary>
        /// C017 获取支付明细订单 
        /// </summary>
        /// <param name="payOrderCode">单个支付单号 </param>
        /// <param name="currentPageNumber">当前页码 获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<PayOrderDetail> GetPayOrderDetails(string payOrderCode, string currentPageNumber);

    }
}
