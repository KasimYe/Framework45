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
** file：DALFactory
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-03 15:13:16
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.Factory
{
    public class DALFactory
    {
        private static readonly string _path = "Kasim.Framework.MySQLDAL";
        private DALFactory()
        {

        }

        public static ICompanyDAL CreateCompanyDAL()
        {
            string className = _path + ".QuartzLog.CompanyDAL";
            return (ICompanyDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IReturnDAL CreateReturnDAL()
        {
            string className = _path + ".QuartzLog.ReturnDAL";
            return (IReturnDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IDistributionDAL CreateDistributionDAL()
        {
            string className = _path + ".QuartzLog.DistributionDAL";
            return (IDistributionDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IDistributionDAL CreateDistributionDAL(string path)
        {
            string className = path + ".QuartzLog.DistributionDAL";
            return (IDistributionDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IWareHouseDAL CreateWareHouseDAL()
        {
            string className = _path + ".QuartzLog.WareHouseDAL";
            return (IWareHouseDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IInvoiceDAL CreateInvoiceDAL()
        {
            string className = _path + ".QuartzLog.InvoiceDAL";
            return (IInvoiceDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IOrderDAL CreateOrderDAL()
        {
            string className = _path + ".QuartzLog.OrderDAL";
            return (IOrderDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IAccessTokeDAL CreateAccessTokeDAL()
        {
            string className = _path + ".QuartzLog.AccessTokeDAL";
            return (IAccessTokeDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IHospitalDAL CreateHospitalDAL()
        {
            string className = _path + ".QuartzLog.HospitalDAL";
            return (IHospitalDAL)Assembly.Load(_path).CreateInstance(className);
        }

        public static IProcurecatalogDAL CreateProcurecatalogDAL()
        {
            string className = _path + ".QuartzLog.ProcurecatalogDAL";
            return (IProcurecatalogDAL)Assembly.Load(_path).CreateInstance(className);
        }
    }
}
