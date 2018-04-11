/*********************************************************************
 **                             _ooOoo_                             **
 **                            o8888888o                            **
 **                            88" . "88                            **
 **                            (| -_- |)                            **
 **                            O\  =  /O                            **
 **                         ____/`---'\____                         **
 **                       .'  \\|     |//  `.                       **
 **                      /  \\|||  :  |||//  \                      **
 **                     /  _||||| -:- |||||-  \                     **
 **                     |   | \\\  -  /// |   |                     **
 **                     | \_|  ''\---/''  |   |                     **
 **                     \  .-\__  `-`  ___/-. /                     **
 **                   ___`. .'  /--.--\  `. . __                    **
 **                ."" '<  `.___\_<|>_/___.'  >'"".                 **
 **               | | :  `- \`.;`\ _ /`;.`/ - ` : | |               **
 **               \  \ `-.   \_ __\ /__ _/   .-` /  /               **
 **          ======`-.____`-.___\_____/___.-`____.-'======          **
 **                             `=---='                             **
 **          ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^          **
 **                     佛祖保佑        永无BUG                     **
 **            佛曰:                                                **
 **                   写字楼里写字间，写字间里程序员；              **
 **                   程序人员写程序，又拿程序换酒钱。              **
 **                   酒醒只在网上坐，酒醉还来网下眠；              **
 **                   酒醉酒醒日复日，网上网下年复年。              **
 **                   但愿老死电脑间，不愿鞠躬老板前；              **
 **                   奔驰宝马贵者趣，公交自行程序员。              **
 **                   别人笑我忒疯癫，我笑自己命太贱；              **
 **                   不见满街漂亮妹，哪个归得程序员？              **
 *********************************************************************/
/*=====================================================================
* Copyright (c) 2018 All Rights Reserved.
* CLRVer.:4.0.30319.42000
* machinenameDESKTOP-U288O1H
* namespace:Kasim.Framework.BLL.QuartzLog.CompanyInterface.Pay
* filename:PayOrderBLL
* guid:3711ec1e-1e38-4456-bc7b-de551bd40dc9
* auth:lip86
* date:2018-01-08 21:17:20
* desc:
*
*=====================================================================*/
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Pay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog.CompanyInterface.Pay
{
    public class PayOrderBLL : IPayOrderBLL
    {
        public ListEntity<PayOrderDetail> GetPayOrderDetails(string payOrderCode, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/pay/getPayOrderDetail";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "payOrderCode", payOrderCode },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                FlashLogger.Info(result);
                var list = new ListEntityCommon<PayOrderDetail>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetPayOrderDetails(payOrderCode, currentPageNumber);

                return list;
            }
            catch (Exception ex)
            {
                FlashLogger.Error(ex.Message);
                return null;
            }
        }

        public ListEntity<PayOrder> GetPayOrders(DateTime startTime, DateTime endTime, string payOrderCodes, string currentPageNumber)
        {
            try
            {
                string url = ModelFactory.Url + "/companyInterface/pay/getPayOrder";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "startTime", startTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "endTime", endTime.ToString("yyyy-MM-dd hh:mm:ss") },
                    { "payOrderCodes", payOrderCodes },
                    { "currentPageNumber", currentPageNumber }
                };
                string result = WebClientHttp.Post(url, postVars);
                FlashLogger.Info(result);                
                var list = new ListEntityCommon<PayOrder>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return GetPayOrders(startTime, endTime, payOrderCodes, currentPageNumber);

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
