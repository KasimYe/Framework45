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
* namespace:Kasim.Framework.QuartzLog.Jobs.HospitalJob
* filename:UpdateHospitalService
* guid:2c709b27-f0ad-4dfe-9603-32f06b020eb3
* auth:lip86
* date:2018-01-04 22:21:17
* desc:
*
*=====================================================================*/
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.HospitalJob
{
    public class UpdateHospitalService : JobService<UpdateHospitalJob>
    {
        protected override string JobName
        {
            get
            {
                return "更新医疗机构信息";
            }
        }

        protected override string GroupName
        {
            get
            {
                return "更新医疗机构作业处理";
            }
        }

        protected override ITrigger GetTrigger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString;
            var cron = ConstValue.GetCron(connectionString, "UpdateHospitalJobCron");
            if (string.IsNullOrEmpty(cron)) return null;

            var trigger = TriggerBuilder.Create()
              .WithIdentity(JobName, GroupName)
              .WithCronSchedule(cron)
              .Build();
            return trigger;
        }
    }
}
