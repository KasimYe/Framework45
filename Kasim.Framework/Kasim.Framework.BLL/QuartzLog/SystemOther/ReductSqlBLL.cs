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

* Filename: ReductSqlBLL
* Namespace: Kasim.Framework.BLL.QuartzLog.SystemOther
* Classname: ReductSqlBLL
* Created: 2018-03-26 20:13:24
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.IBLL.QuartzLog.SystemOther;
using Kasim.Framework.IDAL.QuartzLog;
using Kasim.Framework.SQLServerDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog.SystemOther
{
    public class ReductSqlBLL : IReductSqlBLL
    {
        IReductSqlDAL dal = new ReductSqlDAL();
        public string ReductGo(string dbName, string openAway)
        {
            return dal.ReductGo(dbName, openAway);
        }

        public string ReductGo(string dbName, string openAway, string dbName_Data, string dbName_Log)
        {
            return dal.ReductGo(dbName, openAway, dbName_Data, dbName_Log);
        }
    }
}
