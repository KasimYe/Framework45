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

* Filename: CronBLL
* Namespace: Kasim.Framework.BLL.QuartzLog
* Classname: CronBLL
* Created: 2018-03-26 19:56:52
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using Kasim.Framework.IBLL.QuartzLog;
using Kasim.Framework.IDAL.QuartzLog;
using Kasim.Framework.MySQLDAL.QuartzLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.BLL.QuartzLog
{
    public class CronBLL : ICronBLL
    {
        ICronDAL dal;
        public CronBLL(string connectionString)
        {
            dal = new CronDAL(connectionString);
        }

        public string GetCron(string cronName)
        {
            return dal.GetEntity(cronName);
        }
    }
}
