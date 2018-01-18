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
** file：IReturnBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:03:44
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

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug
{
    public class ReturnBLL : IReturnBLL
    {
        IReturnDAL dal = DALFactory.CreateReturnDAL();

        public int AddReturn(Return entity)
        {
            entity.ReturnTime = TimeHelper.GetTime(entity.ReturnTime.ToString());
            return dal.AddEntity(entity);
        }

        public void AddReturns(List<Return> list)
        {
            foreach (var entity in list)
            {
                if (GetReturnById(entity.ReturnId) == null)
                {
                    AddReturn(entity);
                }
                //else
                //{
                //    UpdateReturn(entity);
                //}
            }
        }

        public Return GetReturnById(string id)
        {
            return dal.GetEntityById(id);
        }

        public List<Return> GetReturnList(DateTime startDate, DateTime endDate)
        {
            return dal.GetList(startDate, endDate);
        }

        public ListEntity<Return> GetReturns(DateTime startTime, DateTime endTime, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/return/getReturn";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "startTime", startTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "endTime", endTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);                
                var list = new ListEntityCommon<Return>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetReturns(startTime, endTime, currentPageNumber);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ReturnEntity<ErrorListEntity_Return, Return> Maintenance(string returnInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/return/maintenance";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "returnInfo", returnInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Return, Return>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return Maintenance(returnInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ReturnEntity<ErrorListEntity_Return, Return> Response(string returnInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/return/response";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "returnInfo", returnInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Return, Return>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return Response(returnInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public int UpdateReturn(Return entity)
        {
            return dal.SetEntity(entity);
        }
    }
}
