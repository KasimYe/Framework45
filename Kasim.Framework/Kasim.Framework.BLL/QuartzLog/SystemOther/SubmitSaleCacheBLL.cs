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
        public void Submit()
        {
            FlashLogger.Info("MaxId:" + MaxId.ToString());
            List<SaleBill> saleBills = dalMySql.GetTopFive(MaxId);
            if (saleBills.Count > 0)
            {
                MaxId = saleBills[saleBills.Count - 1].SaleBillID;
                saleBills.ForEach(s => {
                    FlashLogger.Info(dalSqlServer.InsertBill(s));
                    if (dalMySql.SetInvalid(s.SaleBillID) > 0)
                    {
                        FlashLogger.Info("写入完毕缓存SaleBillID:"+ s.SaleBillID);
                    }
                    else
                    {
                        FlashLogger.Error("写入失败缓存SaleBillID:" + s.SaleBillID);
                    }
                });
            }
        }
    }
}
