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
** file：UpdateCompanyJob
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 12:47:04
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.CompanyJob
{
    public class UpdateCompanyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            ICompanySCBLL companyBll = new CompanySCBLL();
            List<Company> companyList = null;
            DateTime dateTimeM = DateTime.Now;
            FlashLogger.Error(string.Format("下载生产企业信息【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
            while (dateTimeM > Convert.ToDateTime("2016-03-01"))
            {
                var listEntity = companyBll.GetCompanys("", dateTimeM.ToString("yyyy-MM"), "1");
                if (listEntity == null)
                {
                    break;
                }
                companyList = listEntity.DataList;
                if (companyList != null && companyList.Count > 0)
                {
                    for (int i = 1; i <= listEntity.TotalPageCount; i++)
                    {
                        companyBll.AddCompanys(companyList);
                        FlashLogger.Warn(string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条生产企业信息.【{4}】", dateTimeM.ToString("yyyy-MM"),
                            i, listEntity.TotalPageCount, companyList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId));
                        companyList = companyBll.GetCompanys("", dateTimeM.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                    }
                }
                dateTimeM = dateTimeM.AddMonths(-1);
            }
            FlashLogger.Error(string.Format("下载完毕【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
        }
    }
}
