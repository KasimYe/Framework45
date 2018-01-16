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
* namespace:Kasim.Framework.BLL.QuartzLog.CompanyInterface.Drug
* filename:SaleBLL
* guid:2f9814b5-62dc-4985-b952-40e7df0f7604
* auth:lip86
* date:2018-01-08 21:56:34
* desc:
*
*=====================================================================*/
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.Factory;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog.CompanyInterface.Drug
{
    public class SaleBLL : ISaleBLL
    {
        public ReturnEntity<ErrorListEntity_Sale, Sale> AddSale(string saleInfo)
        {
            try
            {
                string url = ModelFactory.Url + "/tradeInterface/v1/companyInterface/drug/saleList/addSale";
                var postVars = new NameValueCollection
                {
                    { "accessToken", AccessTokeBLL.AccessToken.AccessToken },
                    { "saleInfo", saleInfo },
                };
                string result = WebClientHttp.Post(url, postVars);
                //FlashLogger.Info(result);
                var list = new ReturnEntityCommon<ErrorListEntity_Sale, Sale>().CheckReturnCode(result, out int rcode);
                if (rcode == 0) return AddSale(saleInfo);

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
