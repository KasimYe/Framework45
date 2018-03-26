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

* Filename: BakReductSqlService
* Namespace: Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
* Classname: BakReductSqlService
* Created: 2018-03-26 19:47:40
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
{
    public class ReductSqlService : JobService<ReductSqlJob>
    {
        protected override string JobName
        {
            get
            {
                return "还原数据库备份";
            }
        }

        protected override string GroupName
        {
            get
            {
                return "还原数据库备份作业处理";
            }
        }

        protected override ITrigger GetTrigger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString;
            var cron = ConstValue.GetCron(connectionString, "ReductSqlJobCron");
            if (string.IsNullOrEmpty(cron)) return null;

            var trigger = TriggerBuilder.Create()
              .WithIdentity(JobName, GroupName)
              .WithCronSchedule(cron)
              .Build();
            return trigger;
        }
    }
}
