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
** file：DistributionBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-15 10:54:34
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kasim.Framework.BLL.QuartzLog;
using Kasim.Framework.BLL.QuartzLog.CompanyInterface;
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IDAL.QuartzLog;
using Newtonsoft.Json;

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug
{
    public class DistributionBLL : IDistributionBLL
    {
        IDistributionDAL dal = DALFactory.CreateDistributionDAL();
        IDistributionDAL dalSql = DALFactory.CreateDistributionDAL("Kasim.Framework.SQLServerDAL");
        public int AddDistribute(Distribute entity)
        {
            return dal.AddEntity(entity);
        }

        public void AddDistributes(List<Distribute> list)
        {
            foreach (var entity in list)
            {
                if (GetDistributeById(entity.CompanyDistributeId) == null)
                {
                    AddDistribute(entity);
                }
            }
        }

        public Distribute GetDistributeById(string id)
        {
            return dal.GetEntityById(id);
        }

        public List<Distribute> GetDistributeList(string hospitalId)
        {
            return dal.GetList(hospitalId);
        }

        public List<Distribute> GetDistributes(DateTime startDate, DateTime endDate, string orderDetailId)
        {
            return dalSql.GetListById(startDate, endDate, orderDetailId);
        }

        public ReturnEntity<ErrorListEntity_Distribute, SuccessListEntity_Distribute> SubmitDistribute(string distributeInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/distribution/distribute";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "distributeInfo", distributeInfo }
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Distribute, SuccessListEntity_Distribute>()
                    .CheckReturnCode(result, out int rcode);
                if (rcode == 0) return SubmitDistribute(distributeInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ReturnEntity<ErrorListEntity_Distribute, SuccessListEntity_Distribute> SubmitDistributes(List<Distribute> list)
        {
            var distributeInfo = JsonConvert.SerializeObject(new { list });
            return SubmitDistribute(distributeInfo);
        }

        public int WriteBackDistributeId(string companyDistributeId, string distributeId)
        {
            return dal.SetDistributeId(companyDistributeId, distributeId);
        }
    }
}
