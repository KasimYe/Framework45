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
** file：IDistributionBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:02:37
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
    public interface IDistributionBLL
    {
        /// <summary>
        ///  C006 配送订单 
        /// </summary>
        /// <param name="distributeInfo">配送信息 
        /// JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "companyDistributeId":"企业配送明细编号 1,必填(唯一)， varchar(36)",
        ///             "orderDetailId":"订单明细编号,必填， varchar(36)",
        ///             "distributeCount":"配送数量,必填，int； 配送数量大于 0 且总配送数量不大于采购数量",
        ///             "invoiceId":"发票号,必填，varchar(36)",
        ///             "batchCode":"批号,必填，varchar(36)；一个订单明细可多批号配送",
        ///             "periodDate":"有效期,必填，varchar(36)，(例如“20160430”或“201604”)",
        ///             "distributeCustomInfo":"自定义配送信息,可填，varchar(500)",
        ///             "firstInviceID":"第一票编号【取平台反馈的编号，C018 的 ID】 varchar(36)",
        ///             "middleInviceID":"中间票编号【取平台反馈的编号，C018 的 ID】 varchar(36)",
        ///             "secondInviceCode":"第二票发票代码 varchar(12)。10 位数或者 12 位数" 
        ///         } 
        ///     ] 
        /// }   
        /// </param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Distribute, SuccessListEntity_Distribute> SubmitDistribute(string distributeInfo);
        /// <summary>
        /// 配送订单
        /// </summary>
        /// <param name="list">配送信息</param>
        /// <returns></returns>
        ReturnEntity<ErrorListEntity_Distribute, SuccessListEntity_Distribute> SubmitDistributes(List<Distribute> list);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">配送信息</param>
        /// <returns></returns>
        int AddDistribute(Distribute entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">配送信息集合</param>
        void AddDistributes(List<Distribute> list);
        /// <summary>
        /// 根据ID获取配送信息
        /// </summary>
        /// <param name="id">企业配送明细ID</param>
        /// <returns></returns>
        Distribute GetDistributeById(string id);
        /// <summary>
        /// 从企业开票系统获取配送信息
        /// </summary>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">截至时间</param>
        /// <param name="orderDetailId">订单明细ID</param>
        /// <returns>配送信息集合</returns>
        List<Distribute> GetDistributes(DateTime startDate, DateTime endDate, string orderDetailId);
        /// <summary>
        /// 获取配送信息集合
        /// </summary>
        /// <param name="hospitalId">医院ID</param>
        /// <returns></returns>
        List<Distribute> GetDistributeList(string hospitalId);
        /// <summary>
        /// 回写采购中心配送明细ID
        /// </summary>
        /// <param name="companyDistributeId">企业配送明细编号</param>
        /// <param name="distributeId">中心配送明细编号</param>
        /// <returns></returns>
        int WriteBackDistributeId(string companyDistributeId, string distributeId);
    }
}
