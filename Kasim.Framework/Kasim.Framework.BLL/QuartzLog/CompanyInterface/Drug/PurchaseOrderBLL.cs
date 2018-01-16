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
** file：IPurchaseOrderBLL
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 11:00:32
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
    public class PurchaseOrderBLL : IPurchaseOrderBLL
    {
        IOrderDAL dal = DALFactory.CreateOrderDAL();
        public int AddOrder(Order entity)
        {
            entity.SubmitTime = TimeHelper.GetTime(entity.SubmitTime.ToString());
            IHospitalBLL hospitalBLL = new HospitalBLL();
            if (hospitalBLL.GetHospitalById(entity.HospitalId)==null)
            {
                var objList = new List<object>
                {
                    new { hospitalId = entity.HospitalId.ToString() }
                };
                var hospitalIds = JsonConvert.SerializeObject(new { list = objList });
                var listEntity=hospitalBLL.GetHospitals(hospitalIds, "", "1");
                if (listEntity != null)
                {
                    var hospitalList = listEntity.DataList;
                    if (hospitalList != null && hospitalList.Count > 0)
                    {
                        hospitalBLL.AddHospitals(hospitalList);
                    }
                }
            }

            IProcurecatalogBLL procurecatalogBLL = new ProcurecatalogBLL();
            if (procurecatalogBLL.GetProcurecatalogById(entity.ProcurecatalogId)==null)
            {
                var objList = new List<object>
                {
                    new { procurecatalogId = entity.ProcurecatalogId.ToString() }
                };
                var procurecatalogIds = JsonConvert.SerializeObject(new { list = objList });
                var listEntity = procurecatalogBLL.GetProcurecatalogs(procurecatalogIds, "", "1");
                if (listEntity != null)
                {
                    var procurecatalogList = listEntity.DataList;
                    if (procurecatalogList != null && procurecatalogList.Count > 0)
                    {
                        procurecatalogBLL.AddProcurecatalogs(procurecatalogList);
                    }
                }
            }
            return dal.AddEntity(entity);
        }

        public void AddOrders(List<Order> list)
        {
            foreach (var entity in list)
            {
                if (GetOrderById(entity.OrderDetailId) == null)
                {
                    AddOrder(entity);
                }
                else
                {
                    UpdateOrder(entity);
                }
            }
        }

        public Order GetOrderById(string id)
        {
            return dal.GetEntityById(id);
        }

        public List<OrderDetailState> GetOrderDetailStates()
        {
            return new List<OrderDetailState> {
                new OrderDetailState{ StateId=0,StateName="已保存待提交"},
                new OrderDetailState{ StateId=1,StateName="已提交待响应"},
                new OrderDetailState{ StateId=2,StateName="已响应待配送"},
                new OrderDetailState{ StateId=3,StateName="拒绝响应"},
                new OrderDetailState{ StateId=4,StateName="已配送待收货"},
                new OrderDetailState{ StateId=5,StateName="拒绝配送"},
                new OrderDetailState{ StateId=6,StateName="未及时配送"},
                new OrderDetailState{ StateId=7,StateName="收货中"},
                new OrderDetailState{ StateId=8,StateName="已收货"},
                new OrderDetailState{ StateId=9,StateName="已撤单"},
            };
        }

        public List<Order> GetOrderList(DateTime startDate, DateTime endDate, string hospitalId, string procurecatalogId)
        {
            return dal.GetList(startDate, endDate, hospitalId, procurecatalogId);
        }

        public ListEntity<Order> GetOrders(DateTime startTime, DateTime endTime, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/tradeInterface/v1/companyInterface/drug/purchaseOrder/getOrder";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "startTime", startTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "endTime", endTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);                
                var list = new ListEntityCommon<Order>().CheckReturnCode(result, out int rcode);
                if (rcode==0) return GetOrders(startTime, endTime, currentPageNumber);
               
                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ReturnEntity<ErrorListEntity_Order, Order> Read(string orderDetailInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/tradeInterface/v1/companyInterface/drug/purchaseOrder/read";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "orderDetailInfo", orderDetailInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Order, Order>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return Read(orderDetailInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ReturnEntity<ErrorListEntity_Order, Order> Response(string orderDetailInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/tradeInterface/v1/companyInterface/drug/purchaseOrder/response";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "orderDetailInfo", orderDetailInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Order, Order>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return Read(orderDetailInfo);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public int UpdateOrder(Order entity)
        {
            return dal.SetEntity(entity);
        }
    }
}
