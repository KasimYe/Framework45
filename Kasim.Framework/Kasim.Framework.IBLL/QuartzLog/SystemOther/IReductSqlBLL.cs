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

* Filename: IReductSqlBLL
* Namespace: Kasim.Framework.IBLL.QuartzLog.SystemOther
* Classname: IReductSqlBLL
* Created: 2018-03-26 20:12:55
* Author: KasimYe
* Ps: For My Son YH
* Description: 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasim.Framework.IBLL.QuartzLog.SystemOther
{
    public interface IReductSqlBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="openAway">保存路径/dbName.bak</param>
        /// <returns></returns>
        string ReductGo(string dbName, string openAway);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="openAway">保存路径/dbName.bak</param>
        /// <param name="dbName_Data">数据文件还原后存放的新位置</param>
        /// <param name="dbName_Log">日志文件还原后存放的新位置</param>
        /// <returns></returns>
        string ReductGo(string dbName, string openAway, string dbName_Data, string dbName_Log);
    }
}
