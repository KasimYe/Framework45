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

namespace Kasim.Framework.IBLL.QuartzLog.CompanyInterface
{
    public class CompanySCBLL : ICompanySCBLL
    {
        ICompanyDAL dal = DALFactory.CreateCompanyDAL();
        public int AddCompany(Company entity)
        {
            entity.AddTime = TimeHelper.GetTime(entity.AddTime.ToString());
            entity.LastUpdateTime = TimeHelper.GetTime(entity.LastUpdateTime.ToString());
            return dal.AddEntity(entity);
        }

        public void AddCompanys(List<Company> list)
        {
            foreach (var entity in list)
            {
                if (GetCompanyById(entity.CompanyId) == null)
                {
                    AddCompany(entity);
                }
                else
                {
                    UpdateCompany(entity);
                }
            }
        }

        public Company GetCompanyById(string id)
        {
            return dal.GetEntityById(id);
        }

        public List<Company> GetCompanyList(DateTime startDate, DateTime endDate, string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
            {
                return dal.GetListByDate(startDate, endDate);
            }
            else
            {
                return dal.GetListByName(companyName);
            }
        }

        public ListEntity<Company> GetCompanys(string companyIds, string month, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/companySc/getCompanySc";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "companyIds", companyIds },
                    { "month", month },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                FlashLogger.Info(result);
                var list = new ListEntityCommon<Company>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetCompanys(companyIds, month, currentPageNumber);
                              
                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public int UpdateCompany(Company entity)
        {
            entity.AddTime = TimeHelper.GetTime(entity.AddTime.ToString());
            entity.LastUpdateTime = TimeHelper.GetTime(entity.LastUpdateTime.ToString());
            return dal.SetEntity(entity);
        }
    }
}
