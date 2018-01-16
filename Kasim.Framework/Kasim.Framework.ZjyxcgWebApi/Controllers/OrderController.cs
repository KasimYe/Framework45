using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace Kasim.Framework.ZjyxcgWebApi.Controllers
{
    /// <summary>
    /// 采购订单API
    /// </summary>
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        IPurchaseOrderBLL purchaseOrderBLL = new PurchaseOrderBLL();

        /// <summary>
        /// C004 阅读订单
        /// </summary>
        /// <param name="value">采购订单明细</param>
        /// <returns>结果Json字符串</returns>
        [HttpPost, Route("read")]
        public string Read([FromBody]string value)
        {
            ReturnEntity<ErrorListEntity_Order, Order> checkList = null;
            try
            {
                checkList = purchaseOrderBLL.Read(value);
                if (checkList != null)
                {
                    return JsonConvert.SerializeObject(new { ResultCode = 1, ResultMsg = "Success", ResultData = checkList });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = "Fail", ResultData = checkList });
                }
            }
            catch (Exception ex)
            {
                FlashLogger.Error(string.Format("api/order/read\r\n{0}\r\n{1}", ex.Message, value));
                return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = string.Format("Error:{0}", ex.Message), ResultData = checkList });
            }
        }

        /// <summary>
        ///  C005 响应订单
        /// </summary>
        /// <param name="value">采购订单明细</param>
        /// <returns>结果Json字符串</returns>
        [HttpPost, Route("response")]
        public string Response([FromBody]string value)
        {
            ReturnEntity<ErrorListEntity_Order, Order> checkList = null;
            try
            {
                checkList = purchaseOrderBLL.Response(value);
                if (checkList != null)
                {
                    return JsonConvert.SerializeObject(new { ResultCode = 1, ResultMsg = "Success", ResultData = checkList });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = "Fail", ResultData = checkList });
                }
            }
            catch (Exception ex)
            {
                FlashLogger.Error(string.Format("api/order/response\r\n{0}\r\n{1}", ex.Message, value));
                return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = string.Format("Error:{0}", ex.Message), ResultData = checkList });
            }
        }
    }
}
