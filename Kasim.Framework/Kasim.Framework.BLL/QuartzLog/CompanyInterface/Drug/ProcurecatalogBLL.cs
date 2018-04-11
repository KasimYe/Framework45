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
    public class ProcurecatalogBLL : IProcurecatalogBLL
    {
        IProcurecatalogDAL dal = DALFactory.CreateProcurecatalogDAL();

        public int AddProcurecatalog(Procurecatalog entity)
        {
            entity.AddTime = TimeHelper.GetTime(entity.AddTime.ToString());
            entity.LastUpdateTime = TimeHelper.GetTime(entity.LastUpdateTime.ToString());
            return dal.AddEntity(entity);
        }

        public void AddProcurecatalogs(List<Procurecatalog> list)
        {
            foreach (var entity in list)
            {
                if (GetProcurecatalogById(entity.ProcurecatalogId) == null)
                {
                    AddProcurecatalog(entity);
                }
                else
                {
                    UpdateProcurecatalog(entity);
                }
            }
        }

        public Procurecatalog GetProcurecatalogById(int id)
        {
            return dal.GetEntityById(id);
        }

        public ListEntity<Procurecatalog> GetProcurecatalogs(string procurecatalogIds, string month, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/procurecatalog/getProcurecatalog";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "procurecatalogIds", procurecatalogIds },
                    { "month", month },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                FlashLogger.Info(result);
                var list = new ListEntityCommon<Procurecatalog>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetProcurecatalogs(procurecatalogIds, month, currentPageNumber);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ListEntity<Procurecatalog> CheckExist(string procureCatalogInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/procurecatalog/checkExist";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "procureCatalogInfo", procureCatalogInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                FlashLogger.Info(result);
                var list = new ListEntityCommon<Procurecatalog>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return CheckExist(procureCatalogInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public List<Procurecatalog> GetProcurecatalogList(DateTime startDate, DateTime endDate, string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                return dal.GetListByDate(startDate, endDate);
            }
            else
            {
                return dal.GetListByName(productName);
            }
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            return new List<PurchaseType> {
                new PurchaseType{ TypeId=0,TypeName="中标药品"},
                new PurchaseType{ TypeId=1,TypeName="廉价药品"},
                new PurchaseType{ TypeId=2,TypeName="紧张药品"},
                new PurchaseType{ TypeId=3,TypeName="低价药品"},
                new PurchaseType{ TypeId=4,TypeName="备案药品"},
            };
        }

        public int UpdateProcurecatalog(Procurecatalog entity)
        {
            return dal.SetEntity(entity);
        }
    }
}
