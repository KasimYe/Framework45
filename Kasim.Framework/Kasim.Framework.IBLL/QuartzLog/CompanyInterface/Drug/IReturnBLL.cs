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
** file：IReturnBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:03:44
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/
using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug
{
    public interface IReturnBLL
    {
        /// <summary>
        ///  C008 获取退货信息 
        /// </summary>
        /// <param name="startTime">开始时间 “yyyy-MM-dd hh:mm:ss”  //药械平台订单退货时间 </param>
        /// <param name="endTime">结束时间 “yyyy-MM-dd hh:mm:ss”  //药械平台订单退货时间 </param>
        /// <param name="currentPageNumber">当前页码 获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<Return> GetReturns(DateTime startTime, DateTime endTime, string currentPageNumber);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">退货信息</param>
        /// <returns></returns>
        int AddReturn(Return entity);
        /// <summary>
        /// 更新响应状态
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdateReturn(Return entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">退货信息集合</param>
        void AddReturns(List<Return> list);
        /// <summary>
        /// 根据ID获取退货信息
        /// </summary>
        /// <param name="id">企业退货信息ID</param>
        /// <returns></returns>
        Return GetReturnById(string id);

        /// <summary>
        /// C009 退货响应 
        /// </summary>
        /// <param name="returnInfo">退货信息 JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "returnId":" 药械平台退货明细编号 1,必填，varchar(36)，(只能为入库后退货明细编号，returnType 为 1)", 
        ///             "isResponse":"响应状态,必填，tinyint，已确认待维护退货发票(1)、已确认且已维护退货发票(2)、拒绝退货(3)", 
        ///             "refuseReason":"拒绝原因,isResponse 为 3 时必填，varchar(500)",
        ///             "returnInvoiceId":"退货发票号,isResponse 为 2 时必填，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "returnId":" 药械平台退货明细编号 2,必填，varchar(36)，(只能为入库后退货明细编号，returnType 为 1)", 
        ///             "isResponse":"响应状态,必填，tinyint，已确认待维护退货发票(1)、已确认且已维护退货发票(2)、拒绝退货(3)", 
        ///             "refuseReason":"拒绝原因,isResponse 为 3 时必填，varchar(500)", 
        ///             "returnInvoiceId":"退货发票号,isResponse 为 2 时必填，varchar(36)" 
        ///         } 
        ///     ] 
        /// } 
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Return, Return> Response(string returnInfo);
        /// <summary>
        /// C010 维护退货发票 
        /// </summary>
        /// <param name="returnInfo">退货信息 JSON 格式；格式如下：
        /// { 
        ///     "list":[
        ///         { 
        ///             "returnId":"药械平台退货明细编号 1,必填，varchar(36)，(只能为入库后退货明细编号，returnType 为 1)", 
        ///             "returnInvoiceId":"退货发票号,必填，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "returnId":"必填，药械平台退货明细编号 2,必填，varchar(36)，(只能为入库后退货明细编号，returnType 为 1)", 
        ///             "returnInvoiceId":"退货发票号,必填，varchar(36)" 
        ///         } 
        ///     ] 
        /// }
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Return, Return> Maintenance(string returnInfo);
        List<Return> GetReturnList(DateTime startDate, DateTime endDate);
    }
}
