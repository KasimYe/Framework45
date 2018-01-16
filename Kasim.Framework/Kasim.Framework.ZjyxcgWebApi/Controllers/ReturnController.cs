using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kasim.Framework.ZjyxcgWebApi.Controllers
{
    /// <summary>
    /// 退货信息API
    /// </summary>
    [RoutePrefix("api/return")]
    public class ReturnController : ApiController
    {
        IReturnBLL returnBLL = new ReturnBLL();
        /// <summary>
        /// C009 退货响应
        /// </summary>
        /// <param name="value">退货信息</param>
        /// <returns>结果Json字符串</returns>
        [HttpPost, Route("response")]
        public string Response([FromBody]string value)
        {
            ReturnEntity<ErrorListEntity_Return, Return> checkList = null;
            try
            {
                checkList = returnBLL.Response(value);
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
                FlashLogger.Error(string.Format("api/return/response\r\n{0}\r\n{1}", ex.Message, value));
                return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = string.Format("Error:{0}", ex.Message), ResultData = checkList });
            }
        }

        /// <summary>
        /// C010 维护退货发票
        /// </summary>
        /// <param name="value">退货信息</param>
        /// <returns>结果Json字符串</returns>
        [HttpPost, Route("maintenance")]
        public string Maintenance([FromBody]string value)
        {
            ReturnEntity<ErrorListEntity_Return, Return> checkList = null;
            try
            {
                checkList = returnBLL.Response(value);
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
                FlashLogger.Error(string.Format("api/return/maintenance\r\n{0}\r\n{1}", ex.Message, value));
                return JsonConvert.SerializeObject(new { ResultCode = 0, ResultMsg = string.Format("Error:{0}", ex.Message), ResultData = checkList });
            }
        }
    }
}
