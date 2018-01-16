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
** file：IWareHouseBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:03:14
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
    public interface IWareHouseBLL
    {
        /// <summary>
        ///  C007 获取收货信息 
        /// </summary>
        /// <param name="distributeInfo">配送明细 JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "distributeId":" 药械平台配送明细编号 1,必填，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "distributeId":" 药械平台配送明细编号 2,必填，varchar(36)" 
        ///         } 
        ///     ] 
        /// } 
        /// </param>
        /// <param name="currentPageNumber">当前页码，获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<WareHouse> GetWareHouses(string distributeInfo, string currentPageNumber);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">收货信息 </param>
        /// <returns></returns>
        int AddWareHouse(WareHouse entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">收货信息集合 </param>
        void AddWareHouses(List<WareHouse> list);
        /// <summary>
        /// 根据配送明细ID获取收货信息
        /// </summary>
        /// <param name="id">配送明细ID</param>
        /// <returns>收货信息</returns>
        WareHouse GetWareHouseById(string id);
        /// <summary>
        /// 获取收货信息列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        List<WareHouse> GetWareHouseList(DateTime startDate, DateTime endDate, string hospitalId);
        List<WareHouse> GetWareHouseList(string hospitalId);
    }
}
