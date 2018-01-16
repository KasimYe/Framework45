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
** file：IPurchaseOrderBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:00:32
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
    public interface IPurchaseOrderBLL
    {
        /// <summary>
        /// C003 获取采购订单 
        /// </summary>
        /// <param name="startTime">“yyyy-MM-dd hh:mm:ss” //药械平台订单提交时间 </param>
        /// <param name="endTime">“yyyy-MM-dd hh:mm:ss” //药械平台订单提交时间 </param>
        /// <param name="currentPageNumber">获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<Order> GetOrders(DateTime startTime, DateTime endTime, string currentPageNumber);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">采购订单 </param>
        /// <returns></returns>
        int AddOrder(Order entity);
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="entity">采购订单</param>
        /// <returns></returns>
        int UpdateOrder(Order entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">采购订单集合 </param>
        void AddOrders(List<Order> list);
        /// <summary>
        /// 根据采购订单明细ID获取采购订单明细
        /// </summary>
        /// <param name="id">订单明细ID</param>
        /// <returns>采购订单</returns>
        Order GetOrderById(string id);
        /// <summary>
        ///  C004 阅读订单 
        /// </summary>
        /// <param name="orderDetailInfo">采购订单明细 JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "orderDetailId":"订单明细编号 1,varchar(36)必填" 
        ///         }, 
        ///         { 
        ///             "orderDetailId":"订单明细编号 2,varchar(36)必填" 
        ///         } 
        ///     ] 
        /// }
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Order, Order> Read(string orderDetailInfo);
        /// <summary>
        /// C005 响应订单 
        /// </summary>
        /// <param name="orderDetailInfo">采购订单明细 JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "orderDetailId":"订单明细编号 1,必填，varchar(36)",
        ///             "responseState":"同意响应/拒绝响应,必填，tinyint，同意响应(2)、拒绝响应(3)", 
        ///             "refuseReason":"拒绝响应理由,拒绝响应时必填，varchar(100)" 
        ///         }, 
        ///         { 
        ///             "orderDetailId":"订单明细编号 2,必填，varchar(36)", 
        ///             "responseState":"同意响应/拒绝响应,必填，tinyint，同意响应(2)、拒绝响应(3)", 
        ///             "refuseReason":"拒绝响应理由,拒绝响应时必填，varchar(100)" 
        ///         } 
        ///     ] 
        /// } 
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Order, Order> Response(string orderDetailInfo);
        List<Order> GetOrderList(DateTime startDate, DateTime endDate, string hospitalId,string procurecatalogId);
        /// <summary>
        /// 订单明细状态初始化
        /// </summary>
        /// <returns></returns>
        List<OrderDetailState> GetOrderDetailStates();
    }
}
