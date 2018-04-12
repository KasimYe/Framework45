﻿/*
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

* Filename: SubmitSaleCacheBLL
* Namespace: Kasim.Framework.BLL.QuartzLog.SystemOther
* Classname: SubmitSaleCacheBLL
* Created: 2018-04-10 23:51:35
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.Common;
using Kasim.Framework.Entity.QuartzLog.SystemOther;
using Kasim.Framework.IBLL.QuartzLog.SystemOther;
using Kasim.Framework.IDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog.SystemOther
{
    public class SubmitSaleCacheBLL : ISubmitSaleCacheBLL
    {
        ISubmitSaleCacheDAL dalMySql = new MySQLDAL.QuartzLog.SubmitSaleCacheDAL();
        ISubmitSaleCacheDAL dalSqlServer = new SQLServerDAL.QuartzLog.SubmitSaleCacheDAL();
        public static int MaxId = 0;
        /// <summary>
        /// 全局线程锁
        /// </summary>
        public static bool ThreadLocked = false;
        public void Submit()
        {
            if (ThreadLocked) return;            
            FlashLogger.Info(string.Format("MaxId:{0}", MaxId));
            List<SaleBill> saleBills = dalMySql.GetTopFive(MaxId);
            if (saleBills.Count > 0)
            {
                ThreadLocked = true;
                FlashLogger.Warn("$$$ [ ThreadLocked ] $$$");
                MaxId = saleBills[saleBills.Count - 1].SaleBillID;
                saleBills.ForEach(s => {
                    var insMsg = dalSqlServer.InsertBill(s);                    
                    if (insMsg.IndexOf("单据写入失败") >-1)
                    {
                        FlashLogger.Error(insMsg);
                        MaxId = 0;
                        ThreadLocked = false;
                        FlashLogger.Warn("$$$ [ ThreadUnLocked ] $$$");
                        return;
                    }
                    else
                    {
                        FlashLogger.Info(insMsg);
                        if (dalMySql.SetInvalid(s.SaleBillID) > 0)
                        {
                            FlashLogger.Info("CacheID:" + s.SaleBillID);
                        }
                        else
                        {
                            FlashLogger.Error("ErrorCacheID:" + s.SaleBillID);
                        }
                    }                    
                });
                ThreadLocked = false;
                FlashLogger.Warn("$$$ [ ThreadUnLocked ] $$$");
            }
            else
            {
                FlashLogger.Warn("$$$ [ Heartbeat - ThreadUnLocked ] $$$");
            }
        }
    }
}
