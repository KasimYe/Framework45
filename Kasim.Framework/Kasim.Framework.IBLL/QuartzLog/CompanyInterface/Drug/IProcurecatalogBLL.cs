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
** file：IProcurecatalogBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:05:12
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
    public interface IProcurecatalogBLL
    {
        /// <summary>
        ///  C011 获取商品信息 
        /// </summary>
        /// <param name="procurecatalogIds">商品 id 获取指定商品 id 的变更信息(包括新增、修改) 
        /// JSON 格式；格式如下： 
        /// { 
        ///   "list": 
        ///   [
        ///      { 
        ///        "procurecatalogId":"商品编号" 
        ///      } 
        ///   ] 
        /// }
        /// </param>
        /// <param name="month">月份(药械平台商品新增或商品最新变更变的月份) 
        /// 获取指定月份的第一天至最后一天的变更信息(包括新增、修改)。
        /// 示例：2016-05</param>
        /// <param name="currentPageNumber">当前页码 获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<Procurecatalog> GetProcurecatalogs(string procurecatalogIds, string month, string currentPageNumber);
        /// <summary>
        /// 判断商品在数据库中是否存在
        /// </summary>
        /// <param name="procureCatalogInfo">商品信息</param>
        /// <returns></returns>
        ListEntity<Procurecatalog> CheckExist(string procureCatalogInfo);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">商品</param>
        /// <returns></returns>
        int AddProcurecatalog(Procurecatalog entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">商品集合</param>
        void AddProcurecatalogs(List<Procurecatalog> list);
        /// <summary>
        /// 根据ID获取商品信息
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns></returns>
        Procurecatalog GetProcurecatalogById(int id);
        /// <summary>
        /// 获取商品信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        List<Procurecatalog> GetProcurecatalogList(DateTime startDate, DateTime endDate, string productName);
        /// <summary>
        /// 采购类别初始化
        /// </summary>
        /// <returns></returns>
        List<PurchaseType> GetPurchaseTypes();
    }
}
