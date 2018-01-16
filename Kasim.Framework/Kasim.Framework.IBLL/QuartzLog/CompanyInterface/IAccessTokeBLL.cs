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
** file：IAccessTokeBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 10:58:54
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
    public interface IAccessTokeBLL
    {
        /// <summary>
        ///  C002 获取接口调用凭据 
        /// </summary>
        /// <returns></returns>
        AccessTokenEntity GetToken();
        /// <summary>
        /// 将令牌凭据写入数据库
        /// </summary>
        /// <param name="entity">令牌凭据</param>
        /// <returns></returns>
        int SaveToken(AccessTokenEntity entity);
        /// <summary>
        /// 从数据库中获取令牌凭据
        /// </summary>
        /// <returns> 令牌凭据 </returns>
        AccessTokenEntity GetAccessTokenEntity();
        /// <summary>
        ///  根据C002 获取接口调用凭据 并SaveToken写入数据库
        /// </summary>
        AccessTokenEntity InitNewToken();
        /// <summary>
        /// 根据日期查询凭据
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<AccessTokenEntity> GetAccessTokenList(DateTime startDate, DateTime endDate);
    }
}
