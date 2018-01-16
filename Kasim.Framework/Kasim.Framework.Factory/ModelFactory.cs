using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Factory
{
    static public class ModelFactory
    {
        #region "浙江省药械采购中心"

        #region "接口参数"
        /// <summary>
        /// 药械平台接口正式URL
        /// 测试：http://trade.zgyxcgw.cn:9092
        /// 正式：http://trade.zgyxcgw.cn:8092
        /// </summary>
        static public readonly string Url = ConfigurationManager.AppSettings["ServiceUrl"];
        /// <summary>
        /// 机构信息
        /// </summary>
        static public OrgUser orgUser;

        static private readonly string DesKey = "yss.yh";
        /// <summary>
        /// 药械平台登录用户名
        /// </summary>
        static public readonly string OrgUserName = MySecurity.SDecryptString(ConfigurationManager.AppSettings["OrgUserName"], DesKey);
        /// <summary>
        /// 药械平台登录密码
        /// </summary>
        static public readonly string Secret = MySecurity.SDecryptString(ConfigurationManager.AppSettings["Secret"], DesKey);
        #endregion

        #region "WinForm窗体程序"
        /// <summary>
        /// ERP部门ID
        /// </summary>
        static public int ErpStoreID;
        /// <summary>
        /// ERP用户名
        /// </summary>
        static public int ErpUserID;
        /// <summary>
        /// ERP系统日期
        /// </summary>
        static public DateTime ErpSystemDate;

        static public PopMsg FMsg = new PopMsg();
        #endregion

        #endregion

    }
}
