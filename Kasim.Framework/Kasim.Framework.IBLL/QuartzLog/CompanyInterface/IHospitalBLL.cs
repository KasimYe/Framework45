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
** file：IHospitalBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:06:47
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
    public interface IHospitalBLL
    {
        /// <summary>
        /// 根据ID获取医疗机构
        /// </summary>
        /// <param name="id">医疗机构ID</param>
        /// <returns></returns>
        Hospital GetHospitalById(string id);
        /// <summary>
        /// C013 获取医疗机构 
        /// </summary>
        /// <param name="hospitalIds">医疗机构编号 获取指定医疗机构编号的变更信息(包括新增、修改) 
        /// JSON 格式；格式如下： 
        /// { 
        ///     "list":[
        ///         { 
        ///             "hospitalId":" 医 疗 机 构 编 号 1, 必 填 ，varchar(36)" 
        ///         }, 
        ///         { 
        ///             "hospitalId":" 医 疗 机 构 编 号 2, 必 填 ，varchar(36)" 
        ///         } 
        ///     ] 
        /// } 
        /// </param>
        /// <param name="month">月份（药械平台医疗机构信息新增或变更变的月份） 
        /// 获取指定月份的第一天至最后一天的变更信息(包括新增、修改)。 示例：2016-05</param>
        /// <param name="currentPageNumber">获取指定页码的数据，例如“1”、“2”、“3”等 </param>
        /// <returns></returns>
        ListEntity<Hospital> GetHospitals(string hospitalIds, string month, string currentPageNumber);
        /// <summary>
        /// 判断医疗机构在数据库中是否存在
        /// </summary>
        /// <param name="hospitalInfo">医疗机构信息</param>
        /// <returns></returns>
        ListEntity<Hospital> CheckExist(string hospitalInfo);
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="entity">医疗机构</param>
        /// <returns></returns>
        int AddHospital(Hospital entity);
        /// <summary>
        /// 写入数据库，写入之前判断数据库是否存在，如不存在，则写入
        /// </summary>
        /// <param name="list">医疗机构集合</param>
        void AddHospitals(List<Hospital> list);
        /// <summary>
        /// 获取医疗机构列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="hospitalName"></param>
        /// <returns></returns>
        List<Hospital> GetHospitalList(DateTime startDate, DateTime endDate, string hospitalName);
    }
}
