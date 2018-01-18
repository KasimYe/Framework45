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
    public class WareHouseBLL : IWareHouseBLL
    {
        IWareHouseDAL dal = DALFactory.CreateWareHouseDAL();
        public int AddWareHouse(WareHouse entity)
        {
            entity.WarehouseTime = TimeHelper.GetTime(entity.WarehouseTime.ToString());
            return dal.AddEntity(entity);
        }

        public void AddWareHouses(List<WareHouse> list)
        {
            foreach (var entity in list)
            {
                if (GetWareHouseById(entity.DistributeId) == null && entity.WarehouseCount > 0)
                {
                    AddWareHouse(entity);
                }
            }
        }

        public WareHouse GetWareHouseById(string id)
        {
            return dal.GetEntityById(id);
        }

        public List<WareHouse> GetWareHouseList(DateTime startDate, DateTime endDate, string hospitalId)
        {
            return dal.GetList(startDate, endDate, hospitalId);
        }

        public List<WareHouse> GetWareHouseList(string hospitalId)
        {
            return dal.GetList(hospitalId);
        }

        public ListEntity<WareHouse> GetWareHouses(string distributeInfo, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/drug/wareHouse/getWareHouse";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "distributeInfo", distributeInfo },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ListEntityCommon<WareHouse>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetWareHouses(distributeInfo, currentPageNumber);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }
    }
}
