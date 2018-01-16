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
** file：UpdateOrderJob
** desc：
** 
** auth：KasimYe (KASIM)
** date：2018-01-06 20:23:10
**
** Ver.：V1.0.0
**----------------------------------------------------------------*/

using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog;
using Kasim.Framework.IBLL.QuartzLog.CompanyInterface.Drug;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.OrderJob
{
    public class UpdateOrderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            IPurchaseOrderBLL orderBll = new PurchaseOrderBLL();
            List<Order> orderList = null;
            DateTime dateTimeM = DateTime.Now;
            FlashLogger.Error(string.Format("下载采购订单【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
            while (dateTimeM > Convert.ToDateTime("2016-03-01"))
            {
                var listEntity = orderBll.GetOrders(TimeHelper.GetStartDateTime(dateTimeM),
                    TimeHelper.GetEndDateTime(dateTimeM), "1");
                if (listEntity == null)
                {
                    break;
                }
                orderList = listEntity.DataList;
                if (orderList != null && orderList.Count > 0)
                {
                    for (int i = 1; i <= listEntity.TotalPageCount; i++)
                    {
                        orderBll.AddOrders(orderList);
                        FlashLogger.Warn(string.Format("{0} : 第{1}页/共{2}页 成功下载 {3} 条采购订单信息.【{4}】", dateTimeM.ToString("yyyy-MM-dd"),
                            i, listEntity.TotalPageCount, orderList.Count, System.Threading.Thread.CurrentThread.ManagedThreadId));
                        orderList = orderBll.GetOrders(TimeHelper.GetStartDateTime(dateTimeM),
                            TimeHelper.GetEndDateTime(dateTimeM), (i + 1).ToString()).DataList;
                    }
                }
                //else
                //{
                //    FlashLogger.Warn(string.Format("{0} : 无采购订单信息.【{1}】", dateTimeM.ToString("yyyy-MM-dd"),
                //            System.Threading.Thread.CurrentThread.ManagedThreadId));
                //}
                dateTimeM = dateTimeM.AddDays(-1);
                //System.Threading.Thread.Sleep(3000);
            }
            FlashLogger.Error(string.Format("采购订单下载完毕【{0}】", System.Threading.Thread.CurrentThread.ManagedThreadId));
            //测试

        }
    }
}
