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
* namespace:Kasim.Framework.QuartzLog.Jobs.ProcurecatalogJob
* filename:UpdateProcurecatalogJob
* guid:36b63f63-5345-4849-bc09-1dbe3f4be226
* auth:lip86
* date:2018-01-04 21:43:30
* desc:
*
*=====================================================================*/
using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.ProcurecatalogJob
{
    public class UpdateProcurecatalogJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            IProcurecatalogBLL procurecatalogBll = new ProcurecatalogBLL();
            List<Procurecatalog> procurecatalogList = null;
            DateTime dateTimeM = DateTime.Now;
            FlashLogger.Error(string.Format("下载商品信息【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
            while (dateTimeM > Convert.ToDateTime("2016-03-01"))
            {
                var listEntity = procurecatalogBll.GetProcurecatalogs("", dateTimeM.ToString("yyyy-MM"), "1");
                if (listEntity == null)
                {
                    break;
                }
                procurecatalogList = listEntity.DataList;
                if (procurecatalogList != null && procurecatalogList.Count > 0)
                {
                    for (int i = 1; i <= listEntity.TotalPageCount; i++)
                    {
                        procurecatalogBll.AddProcurecatalogs(procurecatalogList);
                        FlashLogger.Warn(string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条商品信息.【{4}】", dateTimeM.ToString("yyyy-MM"),
                            i, listEntity.TotalPageCount, procurecatalogList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId));
                        procurecatalogList = procurecatalogBll.GetProcurecatalogs("", dateTimeM.ToString("yyyy-MM"), (i + 1).ToString()).DataList;
                    }
                }
                dateTimeM = dateTimeM.AddMonths(-1);
            }
            FlashLogger.Error(string.Format("下载完毕【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
            //测试
            var procurecatalogIdList = new List<object>
            {
                new { procurecatalogId = 12319 },
                new { procurecatalogId = 2 },
                new { procurecatalogId = 10679 }
            };
            var procurecatalogIds = JsonConvert.SerializeObject(new { list = procurecatalogIdList });
            var checkList= procurecatalogBll.CheckExist(procurecatalogIds);

        }
    }
}
