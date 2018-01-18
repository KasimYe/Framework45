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
** file：ICompanySCBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:05:58
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/
using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface
{
    public interface ICompanySCBLL
    {
        /// <summary>
        /// 根据ID获取生产企业
        /// </summary>
        /// <param name="id">企业编号,varchar(36)</param>
        /// <returns>生产企业 </returns>
        Company GetCompanyById(string id);
        /// <summary>
        ///  C012 获取生产企业 
        /// </summary>
        /// <param name="companyIds">企业编号 获取指定企业编号的变更信息(包括新增、修改) 
        /// JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "companyId":"企业编号 1,必填，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "companyId":"企业编号 2,必填，varchar(36)" 
        ///         } 
        ///     ] 
        /// } 
        /// </param>
        /// <param name="month">月份（药械平台生产企业新增或最新变更变的月份） 
        /// 获取指定月份的第一天至最后一天的变更信息(包括新增、修改)。示例：2016-05</param>
        /// <param name="currentPageNumber">当前页码 获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<Company> GetCompanys(string companyIds, string month, string currentPageNumber);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">生产企业</param>
        /// <returns></returns>
        int AddCompany(Company entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">生产企业集合</param>
        void AddCompanys(List<Company> list);
        /// <summary>
        /// 获取生产企业列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        List<Company> GetCompanyList(DateTime startDate, DateTime endDate, string companyName);
        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="entity">生产企业</param>
        /// <returns></returns>
        int UpdateCompany(Company entity);
    }
}
