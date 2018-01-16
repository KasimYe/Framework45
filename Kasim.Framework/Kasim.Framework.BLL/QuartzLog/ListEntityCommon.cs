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
** file：MyJson
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 14:15:55
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using Kasim.Framework.BLL.QuartzLog.CompanyInterface;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog
{
    public class ListEntityCommon<T> where T : class
    {
        private ListEntity<T> JsonDeserialize(string json)
        {
            json = json.Replace("\"[]\"", "null");
            var list = (ListEntity<T>)JsonConvert.DeserializeObject(json, typeof(ListEntity<T>));
            return list;
        }

        public ListEntity<T> CheckReturnCode(string json, out int rcode)
        {
            var list = JsonDeserialize(json);
            if (list.ReturnCode == ReturnEnum.业务执行成功)
            {
                rcode = 1;
                return list;

            }
            else if (list.ReturnCode == ReturnEnum.访问未授权_请得到授权后访问 || list.ReturnCode == ReturnEnum.令牌无效_请重新获取令牌)
            {
                IAccessTokeBLL accessTokeBll = new AccessTokeBLL();
                var accessToken = accessTokeBll.InitNewToken();
                if (accessToken.ReturnCode == ReturnEnum.业务执行成功 || accessToken.ReturnCode == ReturnEnum.令牌有效期超过5分钟_不能再次获取令牌)
                {
                    rcode = 0;
                    return null;
                }
            }
            {
                rcode = -1;
                return null;
            }
        }
    }
}
