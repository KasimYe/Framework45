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
            var movePath = ConfigurationManager.AppSettings["ReductMovePath"];
            IReductSqlBLL bll = new ReductSqlBLL();
            try
            {
                var dbFile = FileOperate.GetLatestFileTimeInfo(openAway, ".bak");
                if (dbFile != null)
                {
                    FlashLogger.Info(string.Format("最新备份文件[{0}],\r\n数据库[{1}]\r\n正在还原中...", dbFile.FullName, dbName));
                    FlashLogger.Info(bll.ReductGo(dbName, dbFile.FullName));
                    FlashLogger.Info(string.Format("开始移动数据库备份文件,\r\n[{0}]\r\n   --->\r\n[{1}]", dbFile.FullName, movePath + dbFile.Name));
                    FileOperate.FileMove(dbFile.FullName, movePath + dbFile.Name);
                    FlashLogger.Info("删除目录下多余的备份文件！");
                    FileOperate.DeleteFolderFiles(openAway);
                    FlashLogger.Info("备份文件还原完毕！");
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
