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
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Kasim.Framework.IDAL.QuartzLog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog.CompanyInterface
{
    public class AccessTokeBLL : IAccessTokeBLL
    {
        IAccessTokeDAL dal = DALFactory.CreateAccessTokeDAL();

        public AccessTokenEntity GetToken()
        {
            string url = ModelFactory.Url + "/tradeInterface/v1/companyInterface/accessToken/getToken";
            ModelFactory.orgUser = new OrgUser
            {
                OrgUserName = ModelFactory.OrgUserName,
                Secret = ModelFactory.Secret
            };
            var pars = string.Format("orgUserName={0}&secret={1}&logtime={2}&md5={3}", ModelFactory.orgUser.OrgUserName,
                ModelFactory.orgUser.Secret, ModelFactory.orgUser.Logtime, ModelFactory.orgUser.MD5);
            var postVars = new NameValueCollection
            {
                { "orgUserName", ModelFactory.orgUser.OrgUserName },
                { "params", pars }
            };
            string result = WebClientHttp.Post(url, postVars);
            //FlashLogger.Info(result);
            var entity = (AccessTokenEntity)JsonConvert.DeserializeObject(result, typeof(AccessTokenEntity));
            entity.ResultJson = result;
            return entity;
        }

        public int SaveToken(AccessTokenEntity entity)
        {
            return dal.AddEntity(entity);
        }

        public AccessTokenEntity GetAccessTokenEntity()
        {
            return dal.GetEntity();
        }

        public List<AccessTokenEntity> GetAccessTokenList(DateTime startDate, DateTime endDate)
        {
            return dal.GetListByDate(startDate, endDate);
        }

        public AccessTokenEntity InitNewToken()
        {
            var entity = GetToken();
            SaveToken(entity);
            return entity;
        }

        /// <summary>
        /// 令牌
        /// </summary>
        static public AccessTokenEntity AccessToken
        {
            get
            {
                IAccessTokeBLL accessTokeBll = new AccessTokeBLL();
                var accessTokenEntity = accessTokeBll.GetAccessTokenEntity();
                if (accessTokenEntity == null || string.IsNullOrEmpty(accessTokenEntity.AccessToken))
                {
                    accessTokenEntity = accessTokeBll.GetToken();
                    accessTokeBll.SaveToken(accessTokenEntity);
                }
                return accessTokenEntity;
            }
        }
    }
}
