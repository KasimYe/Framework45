/*
                 ___====-_  _-====___
           _--^^^#####//      \\#####^^^--_
        _-^##########// (    ) \\##########^-_
       -############//  |\^^/|  \\############-
     _/############//   (@::@)   \\############\_
    /#############((     \\//     ))#############\
   -###############\\    (oo)    //###############-
  -#################\\  / VV \  //#################-
 -###################\\/      \//###################-
_#/|##########/\######(   /\   )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  |  |  /##/\#/  \/\#/\#/\#| \|
`  |/  V  V  `   V  \#\| |  | |/#/  V   '  V  V  \|  '
   `   `  `      `   / | |  | | \   '      '  '   '
                    (  | |  | |  )
                   __\ | |  | | /__
                  (vvv(VVV)(VVV)vvv)                  

* Filename: SubmitSaleCacheService
* Namespace: Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
* Classname: SubmitSaleCacheService
* Created: 2018-04-10 23:43:21
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
{
    public class SubmitSaleCacheService : JobService<SubmitSaleCacheJob>
    {
        protected override string JobName
        {
            get
            {
                return "提交缓存中的销售单据";
            }
        }

        protected override string GroupName
        {
            get
            {
                return "提交缓存中的销售单据作业处理";
            }
        }

        protected override ITrigger GetTrigger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString;
            var cron = ConstValue.GetCron(connectionString, "SubmitSaleCacheJobCron");
            if (string.IsNullOrEmpty(cron)) return null;

            var trigger = TriggerBuilder.Create()
              .WithIdentity(JobName, GroupName)
              .WithCronSchedule(cron)
              .Build();
            return trigger;
        }
    }
}
