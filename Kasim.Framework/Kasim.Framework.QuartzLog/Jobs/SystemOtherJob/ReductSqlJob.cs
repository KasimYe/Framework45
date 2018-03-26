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

* Filename: BakReductSqlJob
* Namespace: Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
* Classname: BakReductSqlJob
* Created: 2018-03-26 19:47:29
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.BLL.QuartzLog.SystemOther;
using Kasim.Framework.Common;
using Kasim.Framework.IBLL.QuartzLog.SystemOther;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.QuartzLog.Jobs.SystemOtherJob
{
    public class ReductSqlJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dbName = ConfigurationManager.AppSettings["ReductDbName"];
            var openAway = ConfigurationManager.AppSettings["ReductOpenAway"];
            var dbName_Data = ConfigurationManager.AppSettings["ReductDataPath"];
            var dbName_Log = ConfigurationManager.AppSettings["ReductLogPath"];
            IReductSqlBLL bll = new ReductSqlBLL();
            try
            {
                var dbFile = FileOperate.GetLatestFileTimeInfo(openAway, ".bak");
                if (dbFile != null)
                {
                    FlashLogger.Info(string.Format("最新备份文件[{0}],数据库[{1}]正在还原中...", dbName, dbFile.FullName));
                    FlashLogger.Info(bll.ReductGo(dbName, dbFile.FullName, dbName_Data, dbName_Log));
                    FlashLogger.Info("开始删除数据库备份文件");
                    //dbFile.Delete();
                    FlashLogger.Info("备份文件完毕！");
                }
                else
                {
                    FlashLogger.Error("未找到数据库备份文件，还原失败");
                }
            }
            catch (Exception ex)
            {
                FlashLogger.Error("ReductSqlJob_Execute:" + ex.Message);
            }

        }
    }
}
