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

* Filename: InventoryCheckService
* Namespace: Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
* Classname: InventoryCheckService
* Created: 2018-04-12 14:14:50
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
    public class InventoryCheckService: JobService<InventoryCheckJob>
    {
        protected override string JobName
        {
            get
            {
                return "进销存库存检验";
            }
        }

        protected override string GroupName
        {
            get
            {
                return "进销存库存检验作业处理";
            }
        }

        protected override ITrigger GetTrigger()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MisConnectionString"].ConnectionString;
            var cron = ConstValue.GetCron(connectionString, "InventoryCheckJobCron");
            if (string.IsNullOrEmpty(cron)) return null;

            var trigger = TriggerBuilder.Create()
              .WithIdentity(JobName, GroupName)
              .WithCronSchedule(cron)
              .Build();
            return trigger;
        }
    }
}
